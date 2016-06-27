using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.Svn
{
    public abstract class SvnRemoteSettings : SvnSettings
    {
        public bool Insecure { get; set; }
        public SvnCredentials Credentials { get; set; }
    }
}
