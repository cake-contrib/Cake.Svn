using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSvn;

namespace Cake.Svn.Update
{
    /// <summary>
    /// Settings for <see cref="SvnUpdater"/>.
    /// </summary>
    public sealed class SvnUpdateSettings : SvnRemoteSettings
    {
        /// <summary>
        /// Gets or sets a the tree depth to which Subversion should limit the scope.
        /// </summary>
        public SvnDepth Depth { get; set; } = SvnDepth.Infinity;

        /// <summary>
        /// Gets or sets a value indicating whether externals definitions and the external 
        /// working copies managed by them should be ignored.
        /// </summary>
        public bool IgnoreExternals { get; set; } = true;

        /// <summary>
        /// Gets or sets the revision on with which to operate.
        /// </summary>
        public long? Revision { get; set; }

        /// <summary>
        /// Gets or sets the AllowObstructions value
        /// </summary>
        /// <remarks>
        /// If AllowObstructions is TRUE then the update tolerates existing unversioned
        /// items that obstruct added paths from @a URL. Only obstructions of the same
        /// type (file or dir) as the added item are tolerated. The text of obstructing
        /// files is left as-is, effectively  treating it as a user modification after
        /// the update. Working properties of obstructing items are set equal to the
        /// base properties.
        ///
        /// If AllowObstructions is FALSE then the update will abort if there are any
        /// unversioned obstructing items 
        /// </remarks>
        public bool AllowObstructions { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether Subversion should recurse up path's 
        /// directory and look for a versioned directory. If found, update all 
        /// intermediate paths between it and path. If not found the command will not 
        /// succeed.
        /// </summary>
        public bool UpdateParents { get; set; } = false;

        /// <summary>
        /// Gets or sets whether in addition to updating paths also the sticky ambient 
        /// depth value must be set to depth.
        /// </summary>
        public bool KeepDepth { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether externals definitions and the 
        /// external working copies managed by them should be ignored.
        /// </summary>
        public bool AddAsModifications { get; set; } = false;

        /// <summary>
        /// Gets the SvnRevision representation of the Revision parameter.
        /// </summary>
        public SvnRevision SvnRevision
        {
            get
            {
                if (Revision == null)
                {
                    return SvnRevision.Head;
                }
                else
                {
                    return new SvnRevision((long)Revision);
                }
            }
        }
    }
}
