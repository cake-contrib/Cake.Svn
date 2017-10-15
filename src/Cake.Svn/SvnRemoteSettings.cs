namespace Cake.Svn
{
    /// <summary>
    /// Base setting class for operations accessing a remote subversion repository.
    /// </summary>
    public abstract class SvnRemoteSettings : SvnSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether insecure SSL certificates should be ignored or not.
        /// </summary>
        public bool Insecure { get; set; }

        /// <summary>
        /// Gets or sets the credentials to use for accessing the repository.
        /// </summary>
        public SvnCredentials Credentials { get; set; }
    }
}
