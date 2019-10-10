namespace Cake.Svn
{
    /// <summary>
    /// Status of Subversion files.
    /// </summary>
    public enum SvnStatus
    {
        /// <summary>
        /// Zero value. Never used by Subversion
        /// </summary>
        Zero = 0,
        /// <summary>
        /// does not exist
        /// </summary>
        None = 1,
        /// <summary>
        /// is not a versioned thing in this wc
        /// </summary>
        NotVersioned = 2,
        /// <summary>
        /// exists, but uninteresting
        /// </summary>
        Normal = 3,
        /// <summary>
        /// is scheduled for addition
        /// </summary>
        Added = 4,
        /// <summary>
        /// under v.c., but is missing
        /// </summary>
        Missing = 5,
        /// <summary>
        /// scheduled for deletion
        /// </summary>
        Deleted = 6,
        /// <summary>
        /// was deleted and then re-added
        /// </summary>
        Replaced = 7,
        /// <summary>
        /// text or props have been modified
        /// </summary>
        Modified = 8,
        /// <summary>
        /// local mods received repos mods
        /// </summary>
        Merged = 9,
        /// <summary>
        /// local mods received conflicting repos mods
        /// </summary>
        Conflicted = 10,
        /// <summary>
        /// is unversioned but configured to be ignored
        /// </summary>
        Ignored = 11,
        /// <summary>
        /// an unversioned resource is in the way of the versioned resource
        /// </summary>
        Obstructed = 12,
        /// <summary>
        /// an unversioned path populated by an svn:externals property
        /// </summary>
        External = 13,
        /// <summary>
        /// a directory doesn't contain a complete entries list
        /// </summary>
        Incomplete = 14,
    }
}
