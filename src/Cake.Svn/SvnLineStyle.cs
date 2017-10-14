using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn
{
    /// <summary>
    /// Line style to use in Subversion files.
    /// </summary>
    public enum SvnLineStyle
    {
        /// <summary>
        /// Default line style.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Default line style used in Windows environments.
        /// Similar to <see cref="SvnLineStyle.CRLF"/>.
        /// </summary>
        Windows = 1,

        /// <summary>
        /// Use carriage return and line feed as line separator.
        /// </summary>
        CRLF = 1,

        /// <summary>
        /// Default line style used in Unix environments.
        /// Similar to <see cref="SvnLineStyle.LF"/>.
        /// </summary>
        Unix = 2,

        /// <summary>
        /// Use line feed as line separator.
        /// </summary>
        LF = 2,

        /// <summary>
        /// Use carriage return as line separator.
        /// </summary>
        CR = 3,
    }
}
