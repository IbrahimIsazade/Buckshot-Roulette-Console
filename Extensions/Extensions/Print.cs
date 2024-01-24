using Extensions.StableModels;
using System.Security.AccessControl;

namespace Extensions.Extensions
{
    public static class Print
    {
        static public void ByGame(string message, MessageType messageType)
        {
            var whiteConsole = ConsoleColor.White;
            switch (messageType)
            {
                case MessageType.GameInfo:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case MessageType.Inventory:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case MessageType.Health:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case MessageType.Exception:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    throw new Exception("Incorrect type of message");
            }

            Type(message);
            Console.ForegroundColor = whiteConsole;
        }

        static public void ByDealer(string message)
        {
            var whiteConsole = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;

            Type("Dealer: "+message);

            Console.ForegroundColor = whiteConsole;
        }

        static public void Bullets(byte blanks, byte lives)
        {
            for (int i = 0; i < lives; i++)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Red;
                Thread.Sleep(100);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }

            for (int i = 0; i < blanks; i++)
            {
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Thread.Sleep(100);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static private void Type(string message)
        {
            Random r = new Random();
            foreach (char letter in message)
            {
                int wait = r.Next(1, 100);

                Thread.Sleep(wait);
                Console.Write(letter);
            }
            Console.WriteLine();
        }
    }
}
