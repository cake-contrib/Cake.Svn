using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Vacuum
{
    /// <summary>
    /// Performs an SVN vacuum on the working copy.
    /// This deletes all ignored or unversioned files from the working copy.
    /// </summary>
    public class SvnVacuum : SvnTool<SvnVacuumSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnVacuum"/> class.
        /// </summary>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnVacuum(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod)
            : base(clientFactoryMethod)
        {
            environment.NotNull(nameof(environment));
            clientFactoryMethod.NotNull(nameof(clientFactoryMethod));

            _environment = environment;
        }

        /// <summary>
        /// Runs the SVN vacuum command.
        /// </summary>
        /// <param name="path">The path in the working copy to vacuum.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        public bool Vacuum(DirectoryPath path, SvnVacuumSettings settings)
        {
            path.NotNull(nameof(path));
            settings.NotNull(nameof(settings));

            using (var client = GetClient())
            {
                string pathStr = path.MakeAbsolute(this._environment).ToString();
                return client.Vacuum(pathStr, settings);
            }
        }
    }
}
