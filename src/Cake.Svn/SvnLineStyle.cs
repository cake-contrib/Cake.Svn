using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn
{
    public enum SvnLineStyle
    {
        Default = 0,
        Windows = 1,
        CRLF = 1,
        Unix = 2,
        LF = 2,
        CR = 3,
    }
}
