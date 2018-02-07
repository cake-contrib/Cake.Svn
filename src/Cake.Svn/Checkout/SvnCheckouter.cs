using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Svn.Checkout
{
    /// <summary>
    /// Class for checking out from an svn repository
    /// </summary>
    public sealed class SvnCheckouter : SvnTool<SvnCheckoutSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of <see cref="SvnCheckouter"/>
        /// </summary>
        /// <param name="environment">The Cake environemnt.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        /// <returns></returns>
        public SvnCheckouter(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod): base(clientFactoryMethod)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            _environment = environment;
        }

        /// <summary>
        /// Checkout a Subversion directory tree.
        /// </summary>
        /// <param name="repositoryUrl">The URL of the Subversion repository to checkout</param>
        /// <param name="path">The local directory name to checkout to.</param>
        /// <param name="settings">The seetings.</param>
        /// <returns>Result of the checkout operation.</returns>
        public SvnCheckoutResult Checkout(Uri repositoryUrl, DirectoryPath path, SvnCheckoutSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (settings.Revision.HasValue && settings.Revision < 0)
            {
                throw new ArgumentException("A negative revision is not allowed", nameof(settings));
            }

            var absolutePath = path.MakeAbsolute(_environment).ToString();

            using(var client = GetClient())
            {
                client.TrustServerCertificate = settings.Insecure;
                if (settings.Credentials != null)
                {
                    client.ForceCredentials(settings.Credentials);
                }

                return client.Checkout(repositoryUrl.ToString(), absolutePath, settings);
            }
        }
    }
}