using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Svn.Checkout;

namespace Cake.Svn
{
    public static partial class SvnAliases
    {
        /// <summary>
        /// Checkout a Subversion directory tree.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="repositoryUrl">The URL of the Subversion repository.</param>
        /// <param name="path">The local directory name.</param>
        /// <returns>Result of the Checkout operation.</returns>
        /// <example>
        /// <para>Checkout a SVN repository and output revision ID:</para>
        /// <code>
        /// <![CDATA[
        ///     var result = SvnCheckout(
        ///         new Uri("https://svn.example.com"),
        ///         @"c:\repo");
        ///
        ///     Verbose("Revision: {0}", result.Revision);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Checkout")]
        [CakeNamespaceImport("Cake.Svn.Checkout")]
        public static SvnCheckoutResult SvnCheckout(
            this ICakeContext context,
            Uri repositoryUrl,
            DirectoryPath path
        )
        {
            return SvnCheckout(context, repositoryUrl, path, null);
        }

        /// <summary>
        /// Checkout a Subversion directory tree with specific settings.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="repositoryUrl">The URL of the Subversion repository.</param>
        /// <param name="path">The local directory name.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Result of the Checkout operation.</returns>
        /// <example>
        /// <para>Checkout root files from a SVN repository while overwriting files in the target location and output revision ID:</para>
        /// <code>
        /// <![CDATA[
        ///     var settings =
        ///         new SvnCheckoutSettings 
        ///         { 
        ///             Overwrite = true,
        ///             Depth = SvnDepth.Files 
        ///         };
        ///         
        ///     var result = SvnCheckout(
        ///         new Uri("https://svn.example.com"),
        ///         @"c:\repo",
        ///         settings);
        ///
        ///     Verbose("Revision: {0}", result.Revision);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Checkout")]
        [CakeNamespaceImport("Cake.Svn.Checkout")]
        public static SvnCheckoutResult SvnCheckout(
            this ICakeContext context,
            Uri repositoryUrl,
            DirectoryPath path,
            SvnCheckoutSettings settings
        )
        {
            var checkouter = new SvnCheckouter(context.Environment, SvnClientFactoryMethod);

            return checkouter.Checkout(repositoryUrl, path, settings ?? new SvnCheckoutSettings());
        }
    }
}