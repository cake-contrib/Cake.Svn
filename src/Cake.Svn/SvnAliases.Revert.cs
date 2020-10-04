using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Revert;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Runs the SVN Revert command on the given file.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The path to the file in the working copy to revert.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a file inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[  
        ///     FilePath file = File("src/Program.cs");
        /// 
        ///     bool reverted = SvnRevert(file);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, FilePath filePath)
        {
            return SvnRevert(context, filePath, new SvnRevertSettings());
        }

        /// <summary>
        /// Runs the SVN Revert command on the given file.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The path to the file in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a file inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[
        ///     SvnRevertSettings settings = new SvnRevertSettings
        ///     {
        ///         Depth = SvnDepth.Infinity
        ///     };
        ///     
        ///     FilePath file = File("src/Program.cs");
        /// 
        ///     bool reverted = SvnRevert(file, settings);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, FilePath filePath, SvnRevertSettings settings)
        {
            var reverter = new SvnReverter(context.Environment, SvnClientFactoryMethod);

            return reverter.Revert(filePath, settings);
        }

        /// <summary>
        /// Runs the SVN Revert command on the given directory.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The path to the directory in the working copy to revert.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a directory inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[
        ///     DirectoryPath dir = Directory("src");
        /// 
        ///     bool reverted = SvnRevert(dir);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, DirectoryPath directoryPath)
        {
            return SvnRevert(context, directoryPath, new SvnRevertSettings());
        }

        /// <summary>
        /// Runs the SVN Revert command on the given directory.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <remarks>
        /// Remember to set <see cref="SvnRevertSettings.Depth"/> to the desired value
        /// when reverting a directory.
        /// </remarks>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The path to the directory in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a directory inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[
        ///     SvnRevertSettings settings = new SvnRevertSettings
        ///     {
        ///         Depth = SvnDepth.Infinity
        ///     };
        ///     
        ///     DirectoryPath dir = Directory("src");
        /// 
        ///     bool reverted = SvnRevert(dir, settings);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, DirectoryPath directoryPath, SvnRevertSettings settings)
        {
            var reverter = new SvnReverter(context.Environment, SvnClientFactoryMethod);

            return reverter.Revert(directoryPath, settings);
        }

        /// <summary>
        /// Runs the SVN Revert command on the given collection of file paths.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePaths">The paths to the files in the working copy to revert.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a collection of files inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[  
        ///     FilePathCollection files = GetFiles("*.txt");
        /// 
        ///     bool reverted = SvnRevert(files);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, FilePathCollection filePaths)
        {
            return SvnRevert(context, filePaths, new SvnRevertSettings());
        }

        /// <summary>
        /// Runs the SVN Revert command on the given collection of file paths.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePaths">The paths to the files in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a collection of files inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[
        ///     SvnRevertSettings settings = new SvnRevertSettings
        ///     {
        ///         Depth = SvnDepth.Infinity
        ///     };
        ///     
        ///     FilePathCollection files = GetFiles(".txt");
        /// 
        ///     bool reverted = SvnRevert(files, settings);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, FilePathCollection filePaths, SvnRevertSettings settings)
        {
            var reverter = new SvnReverter(context.Environment, SvnClientFactoryMethod);

            return reverter.Revert(filePaths, settings);
        }

        /// <summary>
        /// Runs the SVN Revert command on the given collection of directory paths.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPaths">The paths to the directories in the working copy to revert.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a collection of directories inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[
        ///     DirectoryPathCollection dirs = GetDirectories("*");
        /// 
        ///     bool reverted = SvnRevert(dirs);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, DirectoryPathCollection directoryPaths)
        {
            return SvnRevert(context, directoryPaths, new SvnRevertSettings());
        }

        /// <summary>
        /// Runs the SVN Revert command on the given collection of directory paths.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <remarks>
        /// Remember to set <see cref="SvnRevertSettings.Depth"/> to the desired value
        /// when reverting a directory.
        /// </remarks>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPaths">The paths to the directories in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a collection of files and directories inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[
        ///     SvnRevertSettings settings = new SvnRevertSettings
        ///     {
        ///         Depth = SvnDepth.Infinity
        ///     };
        ///     
        ///     DirectoryPathCollection dirs = GetDirectories("*");
        /// 
        ///     bool reverted = SvnRevert(dirs, settings);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, DirectoryPathCollection directoryPaths, SvnRevertSettings settings)
        {
            var reverter = new SvnReverter(context.Environment, SvnClientFactoryMethod);

            return reverter.Revert(directoryPaths, settings);
        }

        /// <summary>
        /// Runs the SVN Revert command on the given collection of file paths and directory paths.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePaths">The paths to the files in the working copy to revert.</param>
        /// <param name="directoryPaths">The paths to the directories in the working copy to revert.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a collection of files and directories inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[  
        ///     DirectoryPathCollection dirs = GetDirectories("*");
        ///     FilePathCollection files = GetFiles(".txt");
        /// 
        ///     bool reverted = SvnRevert(files, dirs);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, FilePathCollection filePaths, DirectoryPathCollection directoryPaths)
        {
            return SvnRevert(context, filePaths, directoryPaths, new SvnRevertSettings());
        }

        /// <summary>
        /// Runs the SVN Revert command on the given collection of file paths and directory paths.
        /// WARNING!  The revert command will permanently lose local modifications.
        /// </summary>
        /// <remarks>
        /// Remember to set <see cref="SvnRevertSettings.Depth"/> to the desired value
        /// when reverting a directory.
        /// </remarks>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePaths">The paths to the files in the working copy to revert.</param>
        /// <param name="directoryPaths">The paths to the directories in the working copy to revert.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns><c>true</c> if the command was successful.  Otherwise <c>false</c> will be returned.</returns>
        /// <example>
        /// <para>Reverts a collection of files and directories inside of a SVN working copy.  This can not be undone.</para>
        /// <code>
        /// <![CDATA[
        ///     SvnRevertSettings settings = new SvnRevertSettings
        ///     {
        ///         Depth = SvnDepth.Infinity
        ///     };
        ///     
        ///     DirectoryPathCollection dirs = GetDirectories("*");
        ///     FilePathCollection files = GetFiles(".txt");
        /// 
        ///     bool reverted = SvnRevert(files, dirs, settings);
        ///     Verbose("Reverted: {0}", reverted);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Revert")]
        [CakeNamespaceImport("Cake.Svn.Revert")]
        public static bool SvnRevert(this ICakeContext context, FilePathCollection filePaths, DirectoryPathCollection directoryPaths, SvnRevertSettings settings)
        {
            var reverter = new SvnReverter(context.Environment, SvnClientFactoryMethod);

            return reverter.Revert(filePaths, directoryPaths, settings);
        }
    }
}
