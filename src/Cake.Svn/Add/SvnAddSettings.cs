namespace Cake.Svn.Add
{
    /// <summary>
    /// Settings for <see cref="SvnAdder"/>.
    /// </summary>
    public sealed class SvnAddSettings : SvnSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvnAddSettings"/> class.
        /// </summary>
        public SvnAddSettings()
        {
            Depth = SvnDepth.Infinity;
            AddParents = true;
            AutoProperties = true;
            Ignore = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Subversion should recurse up path's directory and
        /// look for a versioned directory. If found, add all intermediate paths between it and path. 
        /// If not found the command will not succeed.
        /// </summary>
        public bool AddParents { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the command should be forced.
        /// If Force is not set and path is already under version control the command will not succeed. 
        /// If Force is set, do not error on already-versioned items.
        /// When used on a directory in conjunction with the recursive flag, this has the
        /// effect of scheduling for addition unversioned files and directories scattered
        /// deep within a versioned tree.
        /// </summary>
        public bool Force { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether auto properties should be enabled on the file or folder.
        /// </summary>
        public bool AutoProperties { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether files or directories which are not under 
        /// Subversion control should be ignored.
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// Gets or sets a the tree depth to which Subversion should limit the scope.
        /// </summary>
        public SvnDepth Depth { get; set; }
    }
}
