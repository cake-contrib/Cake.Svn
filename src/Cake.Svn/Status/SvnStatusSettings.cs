namespace Cake.Svn.Status
{
    /// <summary>
    /// Settings for <see cref="SvnStatusTool"/>
    /// </summary>
    public sealed class SvnStatusSettings : SvnRemoteSettings
    {
        /// <summary>
        /// Gets or sets the value of the revision on which Subversion should operate.
        /// Use <c>null</c> for the default revision, <c>-1</c> for the head revision and numbers
        /// bigger than -1 for a certain revision.
        /// </summary>
        public long? Revision { get; set; }

        /// <summary>
        /// Gets or sets the tree depth to which Subversion should limit the scope.
        /// </summary>
        public SvnDepth Depth { get; set; } = SvnDepth.Infinity;

        /// <summary>
        /// Gets or sets a value indicating whether externals should be ignored.
        /// </summary>
        public bool IgnoreExternals { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether working copy status should be ignored.
        /// </summary>
        public bool IgnoreWorkingCopyStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether in addition to updating paths also the sticky ambient 
        /// depth value must be set to depth.
        /// </summary>

        /// <summary>
        /// Gets or sets a value indicating whether excluded nodes should be shown as additions
        /// if also <see cref="RetrieveRemoteStatus"/> is set to <c>true</c>.
        /// This behavior is the same as an update with <see cref="Cake.Svn.Update.SvnUpdateSettings.KeepDepth"/>.
        /// </summary>
        public bool KeepDepth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether all status properties should be retrieved.
        /// </summary>
        public bool RetrieveAllEntries { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ignored files should be retrieved.
        /// </summary>
        public bool RetrieveIgnoredEntries { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the repository should be contacted
        /// to retrieve out of date information
        /// </summary>
        public bool RetrieveRemoteStatus { get; set; }
    }
}
