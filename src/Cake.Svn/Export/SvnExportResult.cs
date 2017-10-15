namespace Cake.Svn.Export
{
    /// <summary>
    /// Result for <see cref="SvnExporter"/>.
    /// </summary>
    public sealed class SvnExportResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvnExportResult"/> class.
        /// </summary>
        /// <param name="revision"></param>
        public SvnExportResult(long revision)
        {
            Revision = revision;
        }

        /// <summary>
        /// Gets the Subversion revision number.
        /// </summary>
        public long Revision { get; private set; }
    }
}
