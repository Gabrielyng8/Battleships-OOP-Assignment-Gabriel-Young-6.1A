using PresentationLayer;

namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            Presentation pt = new Presentation();
            while (true)
            {
                pt.ShowMenu();
            }
        }
    }
}