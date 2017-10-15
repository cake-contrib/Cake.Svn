namespace Cake.Svn
{
    /// <summary>
    /// Credentials for authentication with Subversion server.
    /// </summary>
    public sealed class SvnCredentials
    {
        /// <summary>
        /// Name of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Passwod of the user.
        /// </summary>
        public string Password { get; set; }
    }
}
