using System.Collections.Generic;

namespace Cake.Svn.Revert
{
    /// <summary>
    /// Settings for <see cref="SvnReverter"/>
    /// </summary>
    public sealed class SvnRevertSettings : SvnSettings
    {
        /// <summary>
        /// Creates an instance of <see cref="SvnRevertSettings"/>
        /// and sets all properties to default values.
        /// </summary>
        public SvnRevertSettings()
        {
            this.ChangeLists = new HashSet<string>();
            this.MetaDataOnly = false;
            this.ClearChangeLists = false;
            this.Depth = SvnDepth.Empty;
        }

        /// <summary>
        /// A collection of changelist names, used as a restrictive filter on items reverted.
        /// An item will NOT be reverted unless it is a member of one of these changelists.
        /// If this is empty, no changelist filtering occurs.
        /// </summary>
        public ICollection<string> ChangeLists { get; private set; }

        /// <summary>
        /// If this is set to true, the working copy files are untouched, but if there
        /// are conflict markers attached to the files, those markers are removed.
        /// 
        /// Defaulted to <c>false</c>
        /// </summary>
        public bool MetaDataOnly { get; set; }

        /// <summary>
        /// If this is set to true, then changelist information for the paths is cleared while reverting.
        /// 
        /// Defaulted to <c>false</c>
        /// </summary>
        public bool ClearChangeLists { get; set; }

        /// <summary>
        /// If it is a directory that needs to be reverted, this
        /// determines how far inside the directory to revert.
        /// 
        /// Defaulted to <see cref="SvnDepth.Empty"/>.
        /// </summary>
        /// <seealso cref="SvnDepth"/>
        public SvnDepth Depth { get; set; }
    }
}
