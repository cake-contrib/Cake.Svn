namespace Cake.Svn
{
    /// <summary>
    /// The kind of the Subversion Node.
    /// </summary>
    public enum SvnKind
    {
        /// <summary>
        /// The kind of the node ist not set.
        /// </summary>
        None = 0,

        /// <summary>
        /// The kind of the node is a file.
        /// </summary>
        File = 1,

        /// <summary>
        /// The kind of the node is a directory.
        /// </summary>
        Directory = 2,

        /// <summary>
        /// The kind of the node is unknown.
        /// </summary>
        Unknown = 3,

        /// <summary>
        /// The kind of the node is a symbolic link.
        /// </summary>
        SymbolicLink = 4
    }
}
