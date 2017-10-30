namespace Cake.Svn
{
    /// <summary>
    /// Base class for all settings.
    /// </summary>
    public abstract class SvnSettings
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public SvnSettings()
        {
            ThrowOnCancel = true;
            ThrowOnError = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the call must throw an error if the 
        /// operation is canceled. Defaults to true.
        /// </summary>
        public bool ThrowOnCancel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the call must throw an error if an
        /// error occurs. Defaults to true.
        /// </summary>
        public bool ThrowOnError { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the call must throw an error if a non
        /// fatal error occurs. Defaults to false.
        /// </summary>
        public bool ThrowOnWarning { get; set; }
    }
}
