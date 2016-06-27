using System;
using Cake.Core.IO;
using Cake.Svn.Export;

namespace Cake.Svn
{
    public interface ISvnClient : IDisposable
    {
        bool Insecure { get; set; }
        void ForceCredentials(SvnCredentials credentials);

        SvnExportResult Export(string from, string to, SvnExportSettings settings);
    }
}
