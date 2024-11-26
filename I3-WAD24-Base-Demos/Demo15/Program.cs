namespace Demo15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToolBox tb = new ToolBox();
            string text = null;

            tb.WriteVertically("Salut les WADs!");
            tb.WriteVertically(text);

            tb.WriteVertically(new char[] { 'O', 'K' });
            tb.WriteVertically(new char[] { '\0', ' ', '\t' });
        }
    }
}
