using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn.Update
{
    /// <summary>
    /// The result of an svn checkout.
    /// </summary>
    public sealed class SvnUpdateResult
    {
        internal SvnUpdateResult(long revision)
        {
            Revision = revision;
        }

        /// <summary>
        /// The Revision of the updated directory tree.
        /// </summary>
        public long Revision { get; }
    }
}
