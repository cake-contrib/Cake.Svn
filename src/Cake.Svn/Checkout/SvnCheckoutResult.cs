namespace Cake.Svn.Checkout
{
    /// <summary>
    /// The result of an svn checkout
    /// </summary>
    public sealed class SvnCheckoutResult
    {
        internal SvnCheckoutResult(long revision)
        {
            Revision = revision;
        }

        /// <summary>
        /// The Revision of the checked out directory tree.
        /// </summary>
        /// <returns></returns>
        public long Revision { get; }
    }
}