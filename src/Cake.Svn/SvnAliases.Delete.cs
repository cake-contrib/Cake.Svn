using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Delete;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Delete a directory from Subversion.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directory">The directory to delete.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Delete a directory from Subversion.</para>
        /// <code>
        /// <![CDATA[
        ///     var directoryRemoved = SvnDelete(@"C:\project\src\newfolder\");
        ///
        ///     Verbose("Directory removed: {0}", directoryRemoved);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Delete")]
        [CakeNamespaceImport("Cake.Svn.Delete")]
        public static bool SvnDeleteDirectory(this ICakeContext context, DirectoryPath directory)
        {
            return SvnDeleteDirectory(context, directory, null);
        }

        /// <summary>
        /// Delete a directory from Subversion.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directory">The directory to delete.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Delete a directory from Subversion.</para>
        /// <code>
        /// <![CDATA[
        ///     var svnDeleteSettings = new SvnDeleteSettings
        ///     {
        ///         Force = true
        ///     };
        ///
        ///     var directoryRemoved = SvnDelete(@"C:\project\src\newfolder\", svnDeleteSettings);
        ///
        ///     Verbose("Directory removed: {0}", directoryRemoved);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Delete")]
        [CakeNamespaceImport("Cake.Svn.Delete")]
        public static bool SvnDeleteDirectory(this ICakeContext context, DirectoryPath directory, SvnDeleteSettings settings)
        {
            var commands = new SvnDeleter(context.Environment, SvnClientFactoryMethod);

            return commands.Delete(directory, settings ?? new SvnDeleteSettings());
        }

        /// <summary>
        /// Delete a file from Subversion.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="file">The file.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Delete a file from Subversion.</para>
        /// <code>
        /// <![CDATA[
        ///     var fileRemoved = SvnDelete(@"C:\project\src\newfile.cs");
        ///
        ///     Verbose("File removed: {0}", fileRemoved);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Delete")]
        [CakeNamespaceImport("Cake.Svn.Delete")]
        public static bool SvnDeleteFile(this ICakeContext context, FilePath file)
        {
            return SvnDeleteFile(context, file, null);
        }

        /// <summary>
        /// Delete a file from Subversion.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="file">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Delete a file from Subversion.</para>
        /// <code>
        /// <![CDATA[
        ///     var svnDeleteSettings =  new SvnDeleteSettings
        ///     {
        ///         Force = true
        ///     };
        ///
        ///     var fileRemoved = SvnDelete(@"C:\project\src\newfile.cs", svnDeleteSettings);
        ///
        ///     Verbose("File removed: {0}", fileRemoved);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Delete")]
        [CakeNamespaceImport("Cake.Svn.Delete")]
        public static bool SvnDeleteFile(this ICakeContext context, FilePath file, SvnDeleteSettings settings)
        {
            var deleter = new SvnDeleter(context.Environment, SvnClientFactoryMethod);

            return deleter.Delete(file, settings ?? new SvnDeleteSettings());
        }
    }
}
