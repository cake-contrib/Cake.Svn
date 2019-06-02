using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Updates the Subversion directory tree defined by the supplied <paramref name="directoryPath"/>.
        /// The new revision is returned as the result of the operation. To update to a specific revision
        /// the overload <see cref="SvnUpdate(ICakeContext, DirectoryPath, SvnUpdateSettings)"/> 
        /// can be used with the settings parameter.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The directory.</param>
        /// <returns>A result object containing the resulting revision of the <paramref name="directoryPath"/>.</returns>
        /// <example>
        /// <para>Update a Subversion directory tree.</para>
        /// <code>
        /// <![CDATA[
        ///     var updateResult = SvnUpate(@"C:\project\src\");
        ///
        ///     Verbose("Revision: {0}", updateResult.Revision);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        [CakeNamespaceImport("Cake.Svn.Update")]
        public static SvnUpdateResult SvnUpdate(this ICakeContext context, DirectoryPath directoryPath)
        {
            return SvnUpdate(context, directoryPath, null);
        }

        /// <summary>
        /// Updates the Subversion directory tree defined by the supplied <paramref name="directoryPath"/>
        /// with specific settings.
        /// The new revision is returned as the result of the operation.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="directoryPath">The directory.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>A result object containing the resulting revision of the <paramref name="directoryPath"/>.</returns>
        /// <example>
        /// <para>Update a Subversion directory tree to a specific revision.</para>
        /// <code>
        /// <![CDATA[
        ///     var svnUpdateSettings = new SvnUpdateSettings
        ///     {
        ///         Revision = 42;
        ///     };
        ///
        ///     Verbose("Revision: {0}", updateResult.Revision);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        [CakeNamespaceImport("Cake.Svn.Update")]
        public static SvnUpdateResult SvnUpdate(this ICakeContext context, DirectoryPath directoryPath, SvnUpdateSettings settings)
        {
            var svnUpdater = new SvnUpdater(context.Environment, SvnClientFactoryMethod);

            return svnUpdater.Update(directoryPath, settings ?? new SvnUpdateSettings());
        }

        /// <summary>
        /// Update an individual file at <paramref name="filePath"/> in a Subversion tree.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The file.</param>
        /// <returns>The resulting revision of the file.</returns>
        /// <example>
        /// <para>Updates an individual file at <paramref name="filePath"/> in a Subversion tree.</para>
        /// <code>
        /// <![CDATA[
        ///     var updateResult = SvnUpdate(@"C:\project\src\file.cs");
        ///
        ///     Verbose("Revision: {0}", updateResult.Revision);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        [CakeNamespaceImport("Cake.Svn.Update")]
        public static SvnUpdateResult SvnUpdate(this ICakeContext context, FilePath filePath)
        {
            return SvnUpdate(context, filePath, null);
        }

        /// <summary>
        /// Update an individual file at <paramref name="filePath"/> in a Subversion tree 
        /// with specific settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="filePath">The file.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The resulting revision of the file.</returns>
        /// <example>
        /// <para>Updates an individual file to a specific revision.</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = new SvnUpdateSettings
        ///     {
        ///         Revision = 1138;
        ///     };
        ///
        ///     var updateResult = SvnUpdate(@"C:\project\src\", settings);
        ///
        ///     Verbose("Revision: {0}", updateResult.Revision);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        [CakeNamespaceImport("Cake.Svn.Update")]
        public static SvnUpdateResult SvnUpdate(this ICakeContext context, FilePath filePath, SvnUpdateSettings settings)
        {
            var svnUpdater = new SvnUpdater(context.Environment, SvnClientFactoryMethod);

            return svnUpdater.Update(filePath, settings ?? new SvnUpdateSettings());
        }
    }
}
