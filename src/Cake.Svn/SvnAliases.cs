using System;
using Cake.Core.Annotations;
using Cake.Svn.Internal;

namespace Cake.Svn
{
    [CakeAliasCategory("Svn")]
    public static partial class SvnAliases
    {
        private static readonly Func<ISvnClient> SvnClientFactoryMethod = () => new SvnSharpClient();
    }
}
