using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Delete
{
    /// <summary>
    /// Class for deleting files or directories from Subversion directory trees.
    /// </summary>
    public sealed class SvnDeleter : SvnTool<SvnDeleteSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnDeleter"/> class.
        /// </summary>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnDeleter(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod)
            : base(clientFactoryMethod)
        {
            environment.NotNull(nameof(environment));
            clientFactoryMethod.NotNull(nameof(clientFactoryMethod));

            _environment = environment;
        }

        /// <summary>
        /// Delete a directory from Subversion.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        public bool Delete(DirectoryPath directory, SvnDeleteSettings settings)
        {
            settings.NotNull(nameof(settings));
            directory.NotNull(nameof(directory));

            return Delete(directory.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Delete a file from Subversion.
        /// </summary>
        /// <param name="file">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        public bool Delete(FilePath file, SvnDeleteSettings settings)
        {
            settings.NotNull(nameof(settings));
            file.NotNull(nameof(file));

            return Delete(file.MakeAbsolute(_environment).ToString(), settings);
        }

        /// <summary>
        /// Delete a file or directory from Subversion.
        /// </summary>
        /// <param name="absolutePath">The absolute path.</param>
        /// <param name="settings">The settings.</param>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        private bool Delete(string absolutePath, SvnDeleteSettings settings)
        {
            using (var client = GetClient())
            {
                return client.Delete(absolutePath, settings);
            }
        }
    }
}
