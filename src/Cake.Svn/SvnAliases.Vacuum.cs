using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Vacuum;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Runs SVN vacuum on the given directory using default settings.
        /// SVN vacuum removs all ignored and unversioned files and directories.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directory">The directory.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Vacuums a directory inside of a SVN working copy.</para>
        /// <code>
        /// <![CDATA[ 
        ///     bool vacuumed = SvnVacuum(@"C:\project\src\");
        ///
        ///     Verbose("Directory Vacuumed: {0}", vacuumed);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Vacuum")]
        [CakeNamespaceImport("Cake.Svn.Vacuum")]
        public static bool SvnVacuum(this ICakeContext context, DirectoryPath directory)
        {
            return SvnVacuum(context, directory, new SvnVacuumSettings());
        }

        /// <summary>
        /// Runs SVN vacuum on the given directory using default settings.
        /// SVN vacuum removs all ignored and unversioned files and directories.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directory">The directory.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Cleans a directory inside of a SVN working copy.</para>
        /// <code>
        /// <![CDATA[ 
        ///     SvnVacuumSettings settings = new SvnVacuumSettings
        ///     {
        ///         IncludeExternals = true
        ///     };
        ///     bool vacuumed = SvnVacuum(@"C:\project\src\");
        ///
        ///     Verbose("Directory Vacuumed: {0}", vacuumed);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Vacuum")]
        [CakeNamespaceImport("Cake.Svn.Vacuum")]
        public static bool SvnVacuum(this ICakeContext context, DirectoryPath directory, SvnVacuumSettings settings)
        {
            var vacuum = new SvnVacuum(context.Environment, SvnClientFactoryMethod);

            return vacuum.Vacuum(directory, settings);
        }
    }
}
