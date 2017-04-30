using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Svn
{
    public abstract class SvnTool<TSettings>
        where TSettings : SvnSettings
    {
        private readonly Func<ISvnClient> _clientFactoryMethod;

        protected ISvnClient GetClient()
        {
            return _clientFactoryMethod();
        }

        protected SvnTool(Func<ISvnClient> clientFactoryMethod)
        {
            if (clientFactoryMethod == null)
            {
                throw new ArgumentNullException(nameof(clientFactoryMethod));
            }

            _clientFactoryMethod = clientFactoryMethod;
        }
    }
}
