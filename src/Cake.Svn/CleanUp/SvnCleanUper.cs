using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.CleanUp
{
    /// <summary>
    /// Performs an SVN cleanup on the working directory.
    /// SVN Cleanup removes all working copy locks left behind by crashed clients.
    /// </summary>
    public sealed class SvnCleanUper : SvnTool<SvnCleanUpSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnCleanUper"/> class.
        /// </summary>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnCleanUper(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod)
            : base(clientFactoryMethod)
        {
            environment.NotNull(nameof(environment));
            clientFactoryMethod.NotNull(nameof(clientFactoryMethod));

            _environment = environment;
        }

        /// <summary>
        /// Runs the SVN cleanup command.
        /// </summary>
        /// <param name="path">The path in the working copy to clean.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        public bool CleanUp(DirectoryPath path, SvnCleanUpSettings settings)
        {
            path.NotNull(nameof(path));
            settings.NotNull(nameof(settings));

            using (var client = GetClient())
            {
                string pathStr = path.MakeAbsolute(this._environment).ToString();
                return client.CleanUp(pathStr, settings);
            }
        }
    }
}
