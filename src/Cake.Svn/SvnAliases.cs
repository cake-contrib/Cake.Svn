using System;
using Cake.Core.Annotations;
using Cake.Svn.Internal;

namespace Cake.Svn
{
    /// <summary>
    /// Contains functionality for working with Subversion.
    /// </summary>
    [CakeAliasCategory("Svn")]
    public static partial class SvnAliases
    {
        private static readonly Func<ISvnClient> SvnClientFactoryMethod = () => new SvnSharpClient();
    }
}
