using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo14Delegate01.Models
{
    public delegate void VSCExtFunction();  //encapsulation is internal by default

    public class VisualStudioCode : IDisposable
    {
        private VSCExtFunction _extensionsInit;
        private VSCExtFunction _extensionsStop;

        public List<VSCExtension> Extensions { get; private set; }

        public VisualStudioCode(VSCExtension[] extensions)
        {
            Extensions = new List<VSCExtension>();
            if (extensions != null)
            {
                foreach (VSCExtension ext in extensions)
                {
                    SetNewExtension(ext);
                }
                //if(_extensionsInit != null)
                //{
                //    _extensionsInit();
                //}

                _extensionsInit?.Invoke();
            }
        }

        private void SetNewExtension(VSCExtension extension)
        {
            Extensions.Add(extension);
            _extensionsInit += extension.InitExtension;
            _extensionsStop += extension.StopExtension;
        }

        public void RestartExtension()
        {
            _extensionsStop?.Invoke();
            _extensionsInit?.Invoke();
        }

        public void Dispose()
        {
            _extensionsStop?.Invoke();
        }
    }
}
