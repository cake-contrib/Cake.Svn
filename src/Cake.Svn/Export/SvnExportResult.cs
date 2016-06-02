using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn.Export
{
    public sealed class SvnExportResult
    {
        public SvnExportResult(long revision)
        {
            Revision = revision;
        }

        public long Revision { get; private set; }
    }
}
