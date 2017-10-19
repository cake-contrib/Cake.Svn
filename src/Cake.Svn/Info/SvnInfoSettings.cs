namespace Cake.Svn.Info
{
    /// <summary>
    /// Settings for <see cref="SvnInfo"/>.
    /// </summary>
    public sealed class SvnInfoSettings : SvnRemoteSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvnInfoSettings"/> class.
        /// </summary>
        public SvnInfoSettings()
        {
            Depth = SvnDepth.Infinity;
            RetrieveActualOnly = true;
            RetrieveExcluded = true;
            Revision = -1;
        }

        /// <summary>
        /// Gets or sets the value of the revision on which Subversion should operate.
        /// </summary>
        public long Revision { get; set; }

        /// <summary>
        /// Gets or sets a the tree depth to which Subversion should limit the scope.
        /// </summary>
        public SvnDepth Depth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether externals should be included or not.
        /// </summary>
        public bool IncludeExternals { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Subversion should include actual only 
        /// (tree conflict) nodes in the result (Default true).
        /// </summary>
        public bool RetrieveActualOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Subversion should include excluded nodes in 
        /// the result (Default true).
        /// </summary>
        public bool RetrieveExcluded { get; set; }
    }
}
