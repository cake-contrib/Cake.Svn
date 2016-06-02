using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn.Internal.Extensions
{
    internal static class SvnLineStyleExtensions
    {
        internal static SharpSvn.SvnLineStyle ToSharpSvn(this SvnLineStyle lineStyle)
        {
            switch (lineStyle)
            {
                case SvnLineStyle.Default:
                    return SharpSvn.SvnLineStyle.Default;
                case SvnLineStyle.Windows:
                    return SharpSvn.SvnLineStyle.Windows;
                case SvnLineStyle.Unix:
                    return SharpSvn.SvnLineStyle.Unix;
                case SvnLineStyle.CR:
                    return SharpSvn.SvnLineStyle.CarriageReturn;
                default:
                    return SharpSvn.SvnLineStyle.Default;
            }
        }
    }
}
