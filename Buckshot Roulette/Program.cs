using Buckshot_Roulette.Models;
using Extensions.Extensions;
using Extensions.StableModels;
using System.Reflection.Metadata;

namespace Buckshot_Roulette
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print.ByGame("Welcome to @%!#$", MessageType.GameInfo);
        sign:
            Console.WriteLine("\n--------------------------------" +
                              "\n| GENERAL RELEASE OF LIABILITY |" +
                              "\n|                              |" +
                              "\n| &%$ @#$!@ !@$ $*#^@%@! $*@$! |" +
                              "\n| * %^#$ &#^$ !%^ &&^ %$@^$#$^ |" +
                              "\n| @#$ %&^ %$# @!@# $%^& &^% *^ |" +
                              "\n| !#! $@% #@* %&# %$@! %$^&%&* |" +
                              "\n| % $%$ $%^%$ #*& @!@# $%^& &^ |" +
                              "\n| sign here ______             |" +
                              "\n|                              |" +
                              "\n--------------------------------" +
                              "");
            Console.Write("Enter your name to sign the concract: ");
            string username = Console.ReadLine()!;
            if (username.Length >= 7)
            {
                Print.ByGame($"You are not allowed to create name \nmore that 6 letters ! Please resign.", MessageType.Exception);
                Thread.Sleep(3000);
                Console.Clear();
                goto sign;
            }

            Console.Clear();
            Game game = new Game(username);
            game.Start();
        }
    }
}
