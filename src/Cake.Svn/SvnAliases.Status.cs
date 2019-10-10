using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Status;

namespace Cake.Svn
{
    public partial class SvnAliases
    {
        /// <summary>
        /// Gets Subversion status about the directory at <paramref name="directoryPath"/>.
        /// The result list contains recursive status about the <paramref name="directoryPath"/>
        /// (<see cref="SvnDepth.Infinity"/>). To get status with another <see cref="SvnDepth"/>
        /// the overload <see cref="SvnStatusDirectory(ICakeContext, DirectoryPath, SvnStatusSettings)"/>
        /// can be used with chaning the settings parameter.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The directory.</param>
        /// <returns>
        /// A result list containing recursive status about the <paramref name="directoryPath"/>
        /// (<see cref="SvnDepth.Infinity"/>). To get status with another <see cref="SvnDepth"/>
        /// the overload <see cref="SvnStatusDirectory(ICakeContext, DirectoryPath, SvnStatusSettings)"/>
        /// can be used with changing the settings parameter.
        /// </returns>
        /// <example>
        /// <para>
        /// Gets Subversion status about the directory at <paramref name="directoryPath"/>.
        /// The result list contains recursive status about the <paramref name="directoryPath"/>
        /// (<see cref="SvnDepth.Infinity"/>). To get status with another <see cref="SvnDepth"/>
        /// the overload <see cref="SvnStatusDirectory(ICakeContext, DirectoryPath, SvnStatusSettings)"/>
        /// can be used with changing the settings parameter.
        /// </para>
        /// <code>
        /// <![CDATA[
        ///     var localDirectoryStatus = SvnStatusDirectory(@"C:\project\src\");
        ///
        ///     foreach(var svnStatusResult in localDirectoryStatus)
        ///     {
        ///         Verbose("Path: {0}", svnStatusResult.Path);
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Status")]
        [CakeNamespaceImport("Cake.Svn.Status")]
        public static IEnumerable<SvnStatusResult> SvnStatusDirectory(this ICakeContext context, DirectoryPath directoryPath)
        {
            return SvnStatusDirectory(context, directoryPath, null);
        }

        /// <summary>
        /// Gets Subversion status about the directory at <paramref name="directoryPath"/> with specific settings.
        /// The result list contains recursive status about the <paramref name="directoryPath"/>
        /// (<see cref="SvnDepth.Infinity"/>). To get status with another <see cref="SvnDepth"/>
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>A result list containing recursive status about the <paramref name="directoryPath"/>
        /// (<see cref="SvnDepth.Infinity"/>). To get status with another <see cref="SvnDepth"/>
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/></returns>
        /// <example>
        /// <para>
        /// Gets Subversion status about the directory at <paramref name="directoryPath"/> with specific settings.
        /// The result list contains recursive status about the <paramref name="directoryPath"/>
        /// (<see cref="SvnDepth.Infinity"/>). To get status with another <see cref="SvnDepth"/>
        /// change the <see cref="SvnDepth"/> on <paramref name="settings"/>.
        /// </para>
        /// <code>
        /// <![CDATA[
        ///     var svnStatusSettings = new SvnStatusSettings
        ///     {
        ///         Depth = SvnDepth.Unknown;
        ///     };
        ///
        ///     var localDirectoryStatus = SvnStatusDirectory(@"C:\project\src\", svnStatusSettings);
        ///
        ///     foreach(var svnStatusResult in localDirectoryStatus)
        ///     {
        ///         Verbose("Path: {0}", svnStatusResult.Path);
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Status")]
        [CakeNamespaceImport("Cake.Svn.Status")]
        public static IEnumerable<SvnStatusResult> SvnStatusDirectory(this ICakeContext context, DirectoryPath directoryPath, SvnStatusSettings settings)
        {
            var commands = new SvnStatusTool(context.Environment, SvnClientFactoryMethod);

            return commands.Status(directoryPath, settings ?? new SvnStatusSettings());
        }

        /// <summary>
        /// Gets Subversion status about the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The file.</param>
        /// <returns>The Subversion status.</returns>
        /// <example>
        /// <para>Gets Subversion status about the file at <paramref name="filePath"/>.</para>
        /// <code>
        /// <![CDATA[
        ///     var localFileStatus = SvnFileStatus(@"C:\project\src\file.cs");
        ///
        ///     Verbose("Path: {0}", localFileStatus.Path);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Status")]
        [CakeNamespaceImport("Cake.Svn.Status")]
        public static IEnumerable<SvnStatusResult> SvnStatusFile(this ICakeContext context, FilePath filePath)
        {
            return SvnStatusFile(context, filePath, null);
        }

        /// <summary>
        /// Gets Subversion status about file at <paramref name="filePath"/> with specific settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The Subversion status. If no status about the file is available on Subversion
        /// <c>null</c> will be returned. For this <see cref="SvnSettings.ThrowOnError"/> has to be set to <c>false</c>.
        /// </returns>
        /// <example>
        /// <para>Gets Subversion status about file at <paramref name="filePath"/> with specific settings.</para>
        /// <code>
        /// <![CDATA[
        ///     var svnStatusSettings = new SvnStatusSettings
        ///     {
        ///         Depth = SvnDepth.Unknown;
        ///     };
        ///
        ///     var localFileStatus = SvnFileStatus(@"C:\project\src\", svnStatusSettings);
        ///
        ///     Verbose("Path: {0}", localFileStatus.Path);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Status")]
        [CakeNamespaceImport("Cake.Svn.Status")]
        public static IEnumerable<SvnStatusResult> SvnStatusFile(this ICakeContext context, FilePath filePath, SvnStatusSettings settings)
        {
            var commands = new SvnStatusTool(context.Environment, SvnClientFactoryMethod);

            return commands.Status(filePath, settings ?? new SvnStatusSettings());
        }
    }
}
