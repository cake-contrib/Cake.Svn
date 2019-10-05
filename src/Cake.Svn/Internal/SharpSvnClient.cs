using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using Cake.Svn.Add;
using Cake.Svn.Checkout;
using Cake.Svn.CleanUp;
using Cake.Svn.Delete;
using Cake.Svn.Export;
using Cake.Svn.Info;
using Cake.Svn.Internal.Extensions;
using Cake.Svn.Update;
using SharpSvn;
using SharpSvn.Security;

namespace Cake.Svn.Internal
{
    internal class SvnSharpClient : SharpSvn.SvnClient, ISvnClient
    {
        private SvnCredentials _svnCredentials;

        public bool TrustServerCertificate { get; set; }

        public void ForceCredentials(SvnCredentials credentials)
        {
            _svnCredentials = credentials;

            Authentication.Clear();
            Authentication.ClearAuthenticationCache();
            Authentication.DefaultCredentials = new NetworkCredential(credentials.Username, credentials.Password);

            //Re-register handlers
            Authentication.SslServerTrustHandlers += OnAuthenticationOnSslServerTrustHandlers;
            Authentication.UserNameHandlers += OnAuthenticationUserNameHandlers;
            Authentication.UserNamePasswordHandlers += OnAuthenticationUserNamePasswordHandlers;
        }

        private void OnAuthenticationUserNamePasswordHandlers(object sender, SvnUserNamePasswordEventArgs args)
        {
            if (_svnCredentials == null)
            {
                return;
            }

            args.UserName = _svnCredentials.Username;
            args.Password = _svnCredentials.Password;
            args.Save = false;
            args.Break = true;
        }

        private void OnAuthenticationUserNameHandlers(object sender, SvnUserNameEventArgs args)
        {
            if (_svnCredentials == null)
            {
                return;
            }

            args.UserName = _svnCredentials.Username;
            args.Save = false;
            args.Break = true;
        }

        public SvnSharpClient()
        {
            //Register handlers
            Authentication.SslServerTrustHandlers += OnAuthenticationOnSslServerTrustHandlers;
        }

        private void OnAuthenticationOnSslServerTrustHandlers(object sender, SvnSslServerTrustEventArgs args)
        {
            if (!TrustServerCertificate)
            {
                return;
            }

            args.AcceptedFailures = args.Failures;
            args.Save = false;
        }

        public SvnCheckoutResult Checkout(string from, string to, SvnCheckoutSettings settings)
        {
            var arguments = settings.ToSharpSvn();
            SharpSvn.SvnUpdateResult result;
            CheckOut(SvnUriTarget.FromString(from), to, arguments, out result);

            return new SvnCheckoutResult(result.Revision);
        }

        public SvnExportResult Export(string from, string to, SvnExportSettings settings)
        {
            var arguments = settings.ToSharpSvn();

            SharpSvn.SvnUpdateResult result;
            Export(from, to, arguments, out result);

            return new SvnExportResult(result.Revision);
        }

        /// <inheritdoc/>
        public bool Delete(string fileOrDirectoryPath, SvnDeleteSettings settings)
        {
            return Delete(fileOrDirectoryPath, settings.ToSvnDeleteArgs());
        }

        /// <inheritdoc/>
        public bool Add(string fileOrDirectoryPath, SvnAddSettings settings)
        {
            return Add(fileOrDirectoryPath, settings.ToSvnAddArgs());
        }

        /// <inheritdoc/>
        public bool IsWorkingCopy(string fileOrDirectoryPath)
        {
            return GetUriFromWorkingCopy(fileOrDirectoryPath) != null;
        }

        /// <inheritdoc/>
        public IEnumerable<SvnInfoResult> GetInfo(string repositoryUrl, SvnInfoSettings settings)
        {
            Collection<SvnInfoEventArgs> eventArgs = null;
            GetInfo(repositoryUrl, settings.ToSvnInfoArgs(), out eventArgs);

            return 
                (from eventArg in eventArgs 
                    select new SvnInfoResult(
                        eventArg.RepositoryId,
                        eventArg.RepositoryRoot,
                        eventArg.LastChangeAuthor,
                        eventArg.Revision,
                        eventArg.LastChangeRevision,
                        eventArg.Uri,
                        eventArg.Path,
                        eventArg.FullPath,
                        eventArg.NodeKind.ToSvnKind())).ToList();
        }

        /// <inheritdoc/>
        public Update.SvnUpdateResult Update(string fileOrDirectoryPath, SvnUpdateSettings settings)
        {
            SharpSvn.SvnUpdateResult result;
            Update(fileOrDirectoryPath, settings.ToSvnUpdateArgs(), out result);
            return new Update.SvnUpdateResult(result.Revision);
        }

        /// <inheritdoc/>
        public bool CleanUp( string directoryPath, SvnCleanUpSettings settings )
        {
            return CleanUp( directoryPath, settings.ToSvnCleanUpArgs() );
        }
    }
}