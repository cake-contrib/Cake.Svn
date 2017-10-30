namespace Cake.Svn
{
    /// <summary>
    /// Tree depth to which Subversion can limit its scope for specific operations.
    /// </summary>
    public enum SvnDepth
    {
        /// <summary>
        /// Depth undetermined or ignored.
        /// </summary>
        Unknown = -2,

        /// <summary>
        /// Just the named directory, no entries. 
        /// Updates will not pull in any files or subdirectories not already present.
        /// </summary>
        Empty = 0,

        /// <summary>
        /// Directory and its file children, but not subdirs.
        /// Updates will pull in any files not already present, but not subdirectories.
        /// </summary>
        Files = 1,

        /// <summary>
        /// Directory and immediate children (Directory and its entries).
        /// Updates will pull in any files or subdirectories not already present.
        /// </summary>
        Immediates = 2,

        /// <summary>
        /// Directory and all descendants (full recursion from Directory).
        /// Updates will pull in any files or subdirectories not already present.
        /// </summary>
        Infinity = 3
    }
}
