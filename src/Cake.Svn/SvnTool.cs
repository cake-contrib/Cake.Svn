using System;

namespace Cake.Svn
{
    /// <summary>
    /// Base class for all Subversion operations.
    /// </summary>
    /// <typeparam name="TSettings">Type of the settings class.</typeparam>
    public abstract class SvnTool<TSettings>
        where TSettings : SvnSettings
    {
        private readonly Func<ISvnClient> _clientFactoryMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvnTool{TSettings}"/> class.
        /// </summary>
        /// <param name="clientFactoryMethod">Method to use to initialize a Subversion client.</param>
        protected SvnTool(Func<ISvnClient> clientFactoryMethod)
        {
            if (clientFactoryMethod == null)
            {
                throw new ArgumentNullException(nameof(clientFactoryMethod));
            }

            _clientFactoryMethod = clientFactoryMethod;
        }

        /// <summary>
        /// Returns a new instance of a Subversion client.
        /// </summary>
        /// <returns>New instance of a Subversion client.</returns>
        protected ISvnClient GetClient()
        {
            return _clientFactoryMethod();
        }

        /// <summary>
        /// Checks the setting parameter is not null and throws an exception if it is.
        /// </summary>
        protected void CheckSettingsIsNotNull(SvnRemoteSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

        }
    }
}
