using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Add
{
    /// <summary>
    /// Class for adding files or directories to Subversion directory trees.
    /// </summary>
    public sealed class SvnAdder : SvnTool<SvnAddSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnAdder"/> class.
        /// </summary>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnAdder(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod)
            : base(clientFactoryMethod)
        {
            environment.NotNull(nameof(environment));
            clientFactoryMethod.NotNull(nameof(clientFactoryMethod));

            _environment = environment;
        }

        /// <summary>
        /// Add a directory to Subversion.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        public bool Add(DirectoryPath directory, SvnAddSettings settings)
        {
            settings.NotNull(nameof(settings));
            directory.NotNull(nameof(directory));

            return Add(directory.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Add a file to Subversion.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        public bool Add(FilePath file, SvnAddSettings settings)
        {
            settings.NotNull(nameof(settings));
            file.NotNull(nameof(file));

            return Add(file.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Add a file or directory to Subversion.
        /// </summary>
        /// <param name="absolutePath">The absolute path.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        private bool Add(string absolutePath, SvnAddSettings settings)
        {
            using (var client = GetClient())
            {
                return client.Add(absolutePath, settings);
            }
        }
    }
}
