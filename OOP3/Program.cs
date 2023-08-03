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
            const ConsoleKey DeletePlayerInMenu = ConsoleKey.D5;
            const ConsoleKey ExitInMenu = ConsoleKey.D6;

            Database database = new Database();

            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine($"Для добавления игрока нажмите: {AddPlayerInMenu}");
                Console.WriteLine($"Для вывода всех играков нажмите: {ShowAllPlayersInMenu}");
                Console.WriteLine($"Для для блокировки игрока нажмите: {BanPlayerInMenu}");
                Console.WriteLine($"Для для разбана игрока нажмите: {UnbanPlayerInMenu}");
                Console.WriteLine($"Для удаления игрока нажмите: {DeletePlayerInMenu}");
                Console.WriteLine($"Для выхода нажмите: {ExitInMenu}");

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                switch ( consoleKeyInfo.Key )
                {
                    case AddPlayerInMenu:
                        database.AddPlayer();
                        break;

                    case ShowAllPlayersInMenu:
                        database.ShowAllPlayers();
                        break;

                    case BanPlayerInMenu:
                        database.BanPlayer();
                        break;

                    case UnbanPlayerInMenu:
                        database.UnbanPlayer();
                        break;

                    case DeletePlayerInMenu:
                        database.DeletePlayer();
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
            Id = id;
            NicName = nicName;
            Level = level;
            IsBanned = isActive;
        }

        public int Id { get; private set; }
        public string NicName { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }

    class Database
    {
        private int _idCount = 0;
        private List<Player> _players = new List<Player>();

        public void AddPlayer()
        {
            Console.Clear();
             
            string nicName;
            int level;
            bool isBanned;
            string tempNicNameText = "Введите Никнейм игрока: ";
            string tempLevelText = "Введите уровень игрока: ";
            string tempAativeText = "Ввдите false если игрок не активен или true если игрок активен: ";

            nicName = GetNicName(tempNicNameText);
            level = GetLevel(tempLevelText);
            isBanned = GetIsBanned(tempAativeText);

            Player player = new Player(++_idCount, nicName, level, isBanned);
            _players.Add(player);                 
        }

        public void ShowAllPlayers()
        {
            Console.Clear();

            foreach (Player player in _players)
            {
                Console.WriteLine(player.Id + " " + player.NicName + " " + player.Level + " " + player.IsBanned);
            }

            Console.ReadKey();
        }

        public void BanPlayer()
        {
            Console.Clear();
            Player player = null;

            bool isPlayerInList;
            int userInputPlayerId = 0;
            string userInputBanText = "Введите ID игрока которого хотите забанить:";

            userInputPlayerId = GetLevel(userInputBanText);

            isPlayerInList = TryGetPlayer(userInputPlayerId, out player);

            if(isPlayerInList == true)
            {
                player.Unban();
            }
        }

        public void UnbanPlayer()
        {
            Console.Clear();
            Player player = null;

            bool isPlayerInList;
            int userInputPlayerId = 0;
            string userInputBanText = "Введите ID игрока которого хотите забанить:";

            userInputPlayerId = GetLevel(userInputBanText);

            isPlayerInList = TryGetPlayer(userInputPlayerId, out player);

            if (isPlayerInList == true)
            {
                player.Ban();
            }
        }

        public void DeletePlayer()
        {
            Console.Clear();
            Player player = null;

            bool isPlayerInList;
            int userInputPlayerId = 0;
            string userInputDeleteText = "Введите ID игрока которого хотите удалить:";

            userInputPlayerId = GetLevel(userInputDeleteText);

            isPlayerInList = TryGetPlayer(userInputPlayerId, out player);

            if (isPlayerInList == true)
            {
                _players.Remove(player);
            }
        }

        private int GetLevel(string text)
        {
            int number;
            bool result;
            string userInput;

            Console.Write(text);

            userInput = Console.ReadLine();
            result = int.TryParse(userInput, out number);

            if (result == false)
            {
                Console.WriteLine("Вы ввели неправильное значение");
                Console.ReadKey();
            }

            return number;
        }

        private string GetNicName(string text)
        {
            string nicName;

            Console.Write(text);
            nicName = Console.ReadLine();

            return nicName;
        }

        private bool GetIsBanned(string text)
        {
            bool isBanned;
            bool result;
            string userInput;

            Console.Write(text);

            userInput = Console.ReadLine();
            result = bool.TryParse(userInput, out isBanned);

            if (result == false)
            {
                Console.WriteLine("Вы ввели неправильное значение");
                Console.ReadKey();
            }

            return isBanned;
        }

        private bool TryGetPlayer (int userInputBanId, out Player player)
        {
            player = null;
            bool result = false;

            foreach (Player players in _players)
            {
                if (players.Id == userInputBanId)
                {
                    player = players;
                    result = true;
                }
                else
                {
                    Console.WriteLine($"Игрока с {userInputBanId} ID Нет");
                    Console.ReadKey();
                }
            }

            return result;
        }
    }
}
