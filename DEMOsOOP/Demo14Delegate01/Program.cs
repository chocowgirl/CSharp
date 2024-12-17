using Demo14Delegate01.Models;

namespace Demo14Delegate01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VSCExtension ext1 = new VSCExtension("C#");
            VSCExtension ext2 = new VSCExtension("dotnet");



            using (VisualStudioCode vsc = new VisualStudioCode([ext1, ext2]))  // the using b/c we implemented the dispose from Idisposable
            {
                vsc.RestartExtension();
            }

        }
    }
}
