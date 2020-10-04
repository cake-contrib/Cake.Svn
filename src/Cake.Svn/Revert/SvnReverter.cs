using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Svn.Internal.Extensions;

namespace Cake.Svn.Revert
{
    /// <summary>
    /// Class for reverting files contained with an svn repository.
    /// 
    /// WARNING!  The revert command permanently loses local modifications.
    /// </summary>
    public sealed class SvnReverter : SvnTool<SvnRevertSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnReverter"/> class.
        /// </summary>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        public SvnReverter(ICakeEnvironment environment, Func<ISvnClient> clientFactoryMethod)
            : base(clientFactoryMethod)
        {
            environment.NotNull(nameof(environment));
            clientFactoryMethod.NotNull(nameof(clientFactoryMethod));

            _environment = environment;
        }

        /// <summary>
        /// Runs the SVN revert command on the given file.
        /// </summary>
        /// <param name="filePath">The path to the file in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        public bool Revert(FilePath filePath, SvnRevertSettings settings)
        {
            filePath.NotNull(nameof(filePath));
            settings.NotNull(nameof(settings));

            using(var client = GetClient())
            {
                string pathStr = filePath.MakeAbsolute(this._environment).ToString();
                return client.Revert(pathStr, settings);
            }
        }

        /// <summary>
        /// Runs the SVN revert command on the given files.
        /// </summary>
        /// <param name="filePaths">The paths to the files in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        public bool Revert(FilePathCollection filePaths, SvnRevertSettings settings)
        {
            filePaths.NotNull(nameof(filePaths));
            settings.NotNull(nameof(settings));

            return RevertCollectionInternal(filePaths, null, settings);
        }

        /// <summary>
        /// Runs the SVN revert command on the given directory.
        /// </summary>
        /// <remarks>
        /// Remember to set <see cref="SvnRevertSettings.Depth"/> to the desired value
        /// when reverting a directory.
        /// </remarks>
        /// <param name="directoryPath">The path to the directory in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        public bool Revert(DirectoryPath directoryPath, SvnRevertSettings settings)
        {
            directoryPath.NotNull(nameof(directoryPath));
            settings.NotNull(nameof(settings));

            using(var client = GetClient())
            {
                string pathStr = directoryPath.MakeAbsolute(this._environment).ToString();
                return client.Revert(pathStr, settings);
            }
        }

        /// <summary>
        /// Runs the SVN revert command on the given directories.
        /// </summary>
        /// <remarks>
        /// Remember to set <see cref="SvnRevertSettings.Depth"/> to the desired value
        /// when reverting a directory.
        /// </remarks>
        /// <param name="directoryPaths">The paths to the directories in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        public bool Revert(DirectoryPathCollection directoryPaths, SvnRevertSettings settings)
        {
            directoryPaths.NotNull(nameof(directoryPaths));
            settings.NotNull(nameof(settings));

            return RevertCollectionInternal( null, directoryPaths, settings);
        }

        /// <summary>
        /// Runs the SVN revert command on the given file paths and directories at the same time.
        /// </summary>
        /// <remarks>
        /// Remember to set <see cref="SvnRevertSettings.Depth"/> to the desired value
        /// when reverting a directory.
        /// </remarks>
        /// <param name="filePaths">The paths to the files in the working copy to revert.</param>
        /// <param name="directoryPaths">The paths to the directories in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        public bool Revert(FilePathCollection filePaths, DirectoryPathCollection directoryPaths, SvnRevertSettings settings)
        {
            filePaths.NotNull(nameof(filePaths));
            directoryPaths.NotNull(nameof(directoryPaths));
            settings.NotNull(nameof(settings));

            return RevertCollectionInternal(filePaths, directoryPaths, settings);
        }

        /// <summary>
        /// Helper function that runs the SVN revert command on both types of collections.
        /// If a collection is null, it is skipped.
        /// </summary>
        private bool RevertCollectionInternal(FilePathCollection filePathCollection, DirectoryPathCollection directoryPathCollection, SvnRevertSettings settings)
        {
            List<string> paths = new List<string>();

            if(filePathCollection != null)
            {
                foreach(FilePath filePath in filePathCollection)
                {
                    paths.Add(filePath.MakeAbsolute(this._environment).ToString());
                }
            }

            if( directoryPathCollection != null )
            {
                foreach(DirectoryPath dirPath in directoryPathCollection)
                {
                    paths.Add(dirPath.MakeAbsolute(this._environment).ToString());
                }
            }

            using(var client = GetClient())
            {
                return client.Revert(paths, settings);
            }
        }
    }
}
