namespace Cake.Svn.Delete
{
    /// <summary>
    /// Settings for <see cref="SvnDeleter"/>.
    /// </summary>
    public sealed class SvnDeleteSettings : SvnSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the file or directory will not be removed from 
        /// the local file system.
        /// </summary>
        public bool KeepLocal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command should be forced.
        /// If Force is not set then this operation will fail if any path contains locally
        /// modified and/or unversioned items. If Force is set such items will be deleted.
        /// </summary>
        public bool Force { get; set; }
    }
}
