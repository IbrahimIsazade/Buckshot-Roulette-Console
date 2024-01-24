using Extensions.Extensions;
using Extensions.StableModels;
using System;

namespace Buckshot_Roulette.Models
{
    internal class Game
    {
        private readonly string PlayerName;
        private byte PHealth;
        private byte DHealth;
        private byte Stage;
        private byte MaxCount = 0;
        BulletType[] Sequence = Array.Empty<BulletType>();

        internal Game(string playerName)
        {
            this.PlayerName = playerName;
        }

        internal void Start()
        {
            Print.ByDealer("Let's play a game.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Stage = 1;
            switch (Stage)
            {
                case 1:
                    MaxCount = 3;
                    Stage1();
                    break;

                case 2:
                    MaxCount = 5;
                    Stage2();
                    break;

                case 3:
                    MaxCount = 8;
                    Stage3();
                    break;

                default:
                    throw new Exception($"Incorrect stage by number `{Stage}`");
            }
            Stage++;
        }

        internal void Stage1()
        {
            Random random = new Random();

            // Setting settings (compound sentence ._.)
            PHealth = 2;
            DHealth = 2;

            // Generating count of bullets
            byte live = (byte)(random.Next(1, 3));
            byte blank = (byte)(MaxCount - live);

            // Appending bullets
            for (int i = 0; i < live; i++)
            {
                Array.Resize(ref Sequence, Sequence.Length + 1);
                Sequence[Sequence.Length - 1] = BulletType.Live;
            }
            for (int i = 0; i<blank; i++)
            {
                Array.Resize(ref Sequence, Sequence.Length + 1);
                Sequence[Sequence.Length - 1] = BulletType.Blank;
            }

            // Shuffle
            Sequence = Sequence.OrderBy(x => random.Next()).ToArray();

            // Showing all bullets
            Print.Bullets(blank, live);
            Thread.Sleep(1000);
        restart:
            Print.ByGame($"{blank} blank, {live} live", MessageType.GameInfo);
        playerChoise:
            Print.ByDealer("Your turn.");
            Thread.Sleep(1000);

            // Clearing to hide bullets
            Console.Clear();

            while(MaxCount > 0)
            {
                // Checking choise
                switch (PlayerChoise())
                {
                    case 1:
                        Random rLuck = new Random();
                        Print.ByGame("You chose yourself.", MessageType.GameInfo);
                        Print.ByGame("...", MessageType.GameInfo);
                        Thread.Sleep(2000);

                        // Loking for player's luck =]
                        byte luck = (byte)(rLuck.Next(0, MaxCount));
                        BulletType selectedBullet = Sequence[(int)luck];
                        MaxCount--;

                        // Checking for live or blank
                        if (selectedBullet == BulletType.Live)
                        {
                            Console.Clear();
                            Sequence = Sequence.Where((bullet, index) => index != (int)luck).ToArray();
                            PHealth--;

                            // Checking for health
                            if (PHealth > 0)
                            {
                                Print.ByGame("You got shot.", MessageType.GameInfo);
                                Print.ByGame($"{PlayerName}: {PHealth} lives", MessageType.Health);
                                Print.ByGame($"Dealer: {DHealth} lives", MessageType.Health);
                            }
                            else
                            {
                                Thread.Sleep(2000);
                                Print.ByGame("???: ...", MessageType.Exception);
                                Thread.Sleep(1000);
                                Print.ByGame("???: You got shot and died.", MessageType.Exception);
                                Thread.Sleep(1000);
                                Print.ByGame("???: I think you should try again", MessageType.Exception);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Sequence = Sequence.Where((bullet, index) => index != (int)luck).ToArray();
                            
                            Print.ByGame("You didn't get shot.", MessageType.GameInfo);
                        }
                        break;
                }

                // Dealer choise
                Random dealerChoise = new Random();
                switch (dealerChoise.Next(1, 2))
                {
                    case 1:
                        Random rLuck = new Random();
                        Print.ByGame("Dealer is choosing...", MessageType.GameInfo);
                        Thread.Sleep(2000);
                        Print.ByGame("Dealer chose itself.", MessageType.GameInfo);
                        Print.ByGame("...", MessageType.GameInfo);
                        Thread.Sleep(2000);

                        // Loking for dealers's luck =]
                        byte luck = (byte)(rLuck.Next(0, MaxCount));
                        BulletType selectedBullet = Sequence[(int)luck];
                        MaxCount--;

                        // Checking for live or blank
                        if (selectedBullet == BulletType.Live)
                        {
                            Console.Clear();
                            Sequence = Sequence.Where((bullet, index) => index != (int)luck).ToArray();
                            DHealth--;

                            // Checking for health
                            if (DHealth > 0)
                            {
                                Print.ByGame("It got shot.", MessageType.GameInfo);
                                Print.ByGame($"{PlayerName}: {PHealth} lives", MessageType.Health);
                                Print.ByGame($"Dealer: {DHealth} lives", MessageType.Health);
                            }
                            else
                            {
                                Thread.Sleep(2000);
                                Print.ByDealer("Dealer: This time I won't let you get me");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Sequence = Sequence.Where((bullet, index) => index != (int)luck).ToArray();
                            
                            Print.ByGame("Dealer didn't get shot.", MessageType.GameInfo);
                        }
                        break;
                }
            }
            
        }

        internal void Stage2()
        {

        }

        internal void Stage3()
        {

        }

        internal byte PlayerChoise()
        {
        getChoise:
            Print.ByGame("Select who to shot", MessageType.GameInfo);
            Print.ByGame("1. Yourself", MessageType.GameInfo);
            Print.ByGame("2. Dealer", MessageType.GameInfo);

            bool status = Byte.TryParse(Console.ReadLine(), out byte choise);
            if (!status)
            {
                Print.ByGame("Incorrect choise, please rewrite.", MessageType.Exception);
                Thread.Sleep(1000);
                goto getChoise;
            }

            return choise;

        }
    }
}
