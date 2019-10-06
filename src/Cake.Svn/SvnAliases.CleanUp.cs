using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.CleanUp;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Runs SVN cleanup on the given directory using default settings.
        /// SVN cleanup removes all working copy locks left behind by crashed clients.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directory">The directory.</param>
        /// <returns>
        /// <c>true</c> if the command was successful. Otherwise <c>false</c> will be returned.
        /// </returns>
        /// <example>
        /// <para>Cleans a directory inside of a SVN working copy.</para>
        /// <code>
        /// <![CDATA[ 
        ///     bool directoryCleaned = SvnCleanUp(@"C:\project\src\");
        ///
        ///     Verbose("Directory Cleaned: {0}", directoryCleaned);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory( "CleanUp" )]
        [CakeNamespaceImport( "Cake.Svn.CleanUp" )]
        public static bool SvnCleanUp(this ICakeContext context, DirectoryPath directory)
        {
            return SvnCleanUp(context, directory, new SvnCleanUpSettings());
        }

        /// <summary>
        /// Runs SVN cleanup on the given directory using given settings settings.
        /// SVN cleanup removes all working copy locks left behind by crashed clients.
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
        ///     SvnCleanUpSettings settings = new SvnCleanUpSettings
        ///     {
        ///         IncludeExternals = true
        ///     };
        ///     bool directoryCleaned = SvnCleanUp(@"C:\project\src\", settings);
        ///
        ///     Verbose("Directory Cleaned: {0}", directoryCleaned);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory( "CleanUp" )]
        [CakeNamespaceImport( "Cake.Svn.CleanUp" )]
        public static bool SvnCleanUp(this ICakeContext context, DirectoryPath directory, SvnCleanUpSettings settings)
        {
            var cleaner = new SvnCleaner(context.Environment, SvnClientFactoryMethod);

            return cleaner.CleanUp(directory, settings);
        }
    }
}
