using System;
using System.Collections.Generic;

namespace OOP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ConsoleKey AddPlayerInMenu = ConsoleKey.D1;
            const ConsoleKey ShowAllPlayersInMenu = ConsoleKey.D2;
            const ConsoleKey BanPlayerInMenu = ConsoleKey.D3;
            const ConsoleKey UnbanPlayerInMenu = ConsoleKey.D4;
            const ConsoleKey ExitInMenu = ConsoleKey.D5;

            Database players = new Database();

            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine($"Для добавления игрока нажмите: {AddPlayerInMenu}");
                Console.WriteLine($"Для вывода всех играков нажмите: {ShowAllPlayersInMenu}");
                Console.WriteLine($"Для для блокировки игрока нажмите: {BanPlayerInMenu}");
                Console.WriteLine($"Для для разбана игрока нажмите: {UnbanPlayerInMenu}");
                Console.WriteLine($"Для выхода нажмите: {ExitInMenu}");

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                switch ( consoleKeyInfo.Key )
                {
                    case AddPlayerInMenu:
                        players.AddPlayer();
                        break;

                    case ShowAllPlayersInMenu:
                        players.ShowALLPlayers();
                        break;

                    case BanPlayerInMenu:
                        players.BanPlayer();
                        break;

                    case UnbanPlayerInMenu:
                        players.UnBanlaPlayer();
                        break;

                    case ExitInMenu:
                        isWorking = false;
                        break;
                }
            }

        }
    }

    class Player
    {
        public Player(int id, string nicName, int level, bool isActive)
        {
            ID = id;
            NicName = nicName;
            Level = level;
            IsActive = isActive;
        }

        public int ID { get; private set; }
        public string NicName { get; private set; }
        public int Level { get; private set; }

        public bool IsActive { get; set; }
    }

    class Database
    {
        private int idCount = 1;
        List<Player> list = new List<Player>();

        public void AddPlayer()
        {
            Console.Clear();

            string tempNicName;
            int tempLevel;
            bool tempActive;
            string tempNicNameText = "Введите Никнейм игрока: ";
            string tempLevelText = "Введите уровень игрока: ";
            string tempAativeText = "Ввдите false если игрок не активен или true если игрок активен: ";

            GetNicName(out tempNicName, tempNicNameText);
            GetLevel(out tempLevel, tempLevelText);
            GetIsActive(out tempActive, tempAativeText);

            Player player = new Player(idCount++, tempNicName, tempLevel, tempActive);
            list.Add(player);                 
        }

        private void GetLevel(out int veriableForinItialization, string text)
        {
            string userInput;

            Console.Write(text);

            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out veriableForinItialization)) ;
            else
            {
                Console.WriteLine("Вы ввели неправильное значение");
            }
        }

        private void GetNicName(out string veriableForinItialization, string text)
        {
            string userInput;

            Console.Write(text);

            userInput = Console.ReadLine();

            veriableForinItialization = userInput;
        }

        private void GetIsActive(out bool veriableForinItialization, string text)
        {
            string userInput;

            Console.Write(text);

            userInput = Console.ReadLine();

            if (bool.TryParse(userInput, out veriableForinItialization)) ;
            else
            {
                Console.WriteLine("Вы ввели неправильное значение");
            }
        }

        public void ShowALLPlayers()
        {
            Console.Clear();

            foreach (Player player in list)
            {
                Console.WriteLine(player.ID + " " + player.NicName + " " + player.Level + " " + player.IsActive);
            }

            Console.ReadKey();
        }

        public void BanPlayer()
        {
            int userInputBanId;
            string userInputBanText = "Введите ID игрока которого хотите забанить:";

            GetLevel(out userInputBanId, userInputBanText);

            foreach (Player player in list)
            {
                if (player.ID == userInputBanId)
                {
                    player.IsActive = false;
                }
            }
        }

        public void UnBanlaPlayer()
        {
            int userInputBanId;
            string userInputBanText = "Введите ID игрока которого хотите забанить:";

            GetLevel(out userInputBanId, userInputBanText);

            foreach (Player player in list)
            {
                if (player.ID == userInputBanId)
                {
                    player.IsActive = true;
                }
            }
        }
    }

   
}
