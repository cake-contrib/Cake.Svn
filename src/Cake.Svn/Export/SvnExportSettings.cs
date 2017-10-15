namespace Cake.Svn.Export
{
    /// <summary>
    /// Settings for <see cref="SvnExporter"/>.
    /// </summary>
    public sealed class SvnExportSettings : SvnRemoteSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvnExportSettings"/> class.
        /// </summary>
        public SvnExportSettings()
        {
            Depth = SvnDepth.Infinity;
            IgnoreExternals = true;
            IgnoreKeywords = false;
            LineStyle = SvnLineStyle.Default;
            Overwrite = false;
            Revision = -1;
        }

        /// <summary>
        /// Gets or sets a the tree depth to which Subversion should limit the scope.
        /// </summary>
        public SvnDepth Depth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether externals definitions and the external working copies managed by them should be ignored.
        /// </summary>
        public bool IgnoreExternals { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether keyword expansion should be disabled.
        /// </summary>
        public bool IgnoreKeywords { get; set; }

        /// <summary>
        /// Gets or sets the line style.
        /// </summary>
        public SvnLineStyle LineStyle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether existing files should be overwriten.
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// Gets or sets the revision on with which to operate.
        /// </summary>
        public long Revision { get; set; }
    }
}
