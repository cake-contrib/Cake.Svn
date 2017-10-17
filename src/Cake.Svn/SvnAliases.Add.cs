using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Add;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Add a directory to Subversion.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directory">The directory.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Add a directory to Subversion.</para>
        /// <code>
        /// <![CDATA[ 
        ///     var directoryAdded = SvnAdd(@"C:\project\src\");
        ///
        ///     Verbose("Directory added: {0}", directoryAdded);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Add")]
        [CakeNamespaceImport("Cake.Svn.Add")]
        public static bool SvnAddDirectory(this ICakeContext context, DirectoryPath directory)
        {
            return SvnAddDirectory(context, directory, null);
        }

        /// <summary>
        /// Add a directory to Subversion.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directory">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Add a directory to Subversion.</para>
        /// <code>
        /// <![CDATA[
        ///     var svnAddSettings = 
        ///         new SvnAddSettings
        ///         {
        ///             Force = true
        ///         };
        ///
        ///     var directoryAdded = SvnAdd(@"C:\project\src\", svnAddSettings);
        ///
        ///     Verbose("Directory added: {0}", directoryAdded);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Add")]
        [CakeNamespaceImport("Cake.Svn.Add")]
        public static bool SvnAddDirectory(this ICakeContext context, DirectoryPath directory, SvnAddSettings settings)
        {
            var adder = new SvnAdder(context.Environment, SvnClientFactoryMethod);

            return adder.Add(directory, settings ?? new SvnAddSettings());
        }

        /// <summary>
        /// Add a file to Subversion.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="file">The file.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Add a file to Subversion.</para>
        /// <code>
        /// <![CDATA[
        ///     var fileAdded = SvnAdd(@"C:\project\src\newfile.cs");
        ///
        ///     Verbose("File added: {0}", fileAdded);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Add")]
        [CakeNamespaceImport("Cake.Svn.Add")]
        public static bool SvnAddFile(this ICakeContext context, FilePath file)
        {
            return SvnAddFile(context, file, null);
        }

        /// <summary>
        /// Add a file to Subversion.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="file">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Add a file to Subversion.</para>
        /// <code>
        /// <![CDATA[
        ///     var svnAddSettings = 
        ///         new SvnAddSettings
        ///         {
        ///         Force = true
        ///         };
        ///
        ///     var fileAdded = SvnAdd(@"C:\project\src\newfile.cs", svnAddSettings);
        ///
        ///     Verbose("File added: {0}", fileAdded);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Add")]
        [CakeNamespaceImport("Cake.Svn.Add")]
        public static bool SvnAddFile(this ICakeContext context, FilePath file, SvnAddSettings settings)
        {
            var adder = new SvnAdder(context.Environment, SvnClientFactoryMethod);

            return adder.Add(file, settings ?? new SvnAddSettings());
        }
    }
}
