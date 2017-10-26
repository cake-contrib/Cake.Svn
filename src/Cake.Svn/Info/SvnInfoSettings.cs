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
            RetrieveActualOnly = true;
            RetrieveExcluded = true;
        }

        /// <summary>
        /// Gets or sets the value of the revision on which Subversion should operate.
        /// Use <c>null</c> for the default revision, <c>-1</c> for the head revision and numbers 
        /// bigger than -1 for a certain revision.
        /// </summary>
        public long? Revision { get; set; }

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
