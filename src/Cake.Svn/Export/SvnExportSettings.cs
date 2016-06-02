using System;

namespace Cake.Svn.Export
{
    public sealed class SvnExportSettings : SvnRemoteSettings
    {
        public SvnExportSettings()
        {
            Depth = SvnDepth.Infinity;
            IgnoreExternals = true;
            IgnoreKeywords = false;
            LineStyle = SvnLineStyle.Default;
            Overwrite = false;
            Revision = -1;
        }

        public SvnDepth Depth { get; set; }
        public bool IgnoreExternals { get; set; }
        public bool IgnoreKeywords { get; set; }
        public SvnLineStyle LineStyle { get; set; }
        public bool Overwrite { get; set; }
        public long Revision { get; set; }
    }
}
