using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

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

            Database database = new Database();

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
                        database.AddPlayer();
                        break;

                    case ShowAllPlayersInMenu:
                        database.ShowALLPlayers();
                        break;

                    case BanPlayerInMenu:
                        database.BanPlayer();
                        break;

                    case UnbanPlayerInMenu:
                        database.UnbanlaPlayer();
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

        public bool IsActive { get; private set; }

        public void SetIsActiveTrue()
        {
            IsActive = true;
        }

        public void SetIsActiveFalse()
        {
            IsActive = false;
        }
    }

    class Database
    {
        private int idCount = 0;
        private List<Player> _list = new List<Player>();

        public void AddPlayer()
        {
            Console.Clear();
             
            string tempNicName = "";
            int tempLevel = 0;
            bool tempActive = false;
            string tempNicNameText = "Введите Никнейм игрока: ";
            string tempLevelText = "Введите уровень игрока: ";
            string tempAativeText = "Ввдите false если игрок не активен или true если игрок активен: ";

            tempNicName = GetNicName(tempNicName, tempNicNameText);
            tempLevel = GetLevel(tempLevel, tempLevelText);
            tempActive = GetIsActive(tempActive, tempAativeText);

            Player player = new Player(++idCount, tempNicName, tempLevel, tempActive);
            _list.Add(player);                 
        }

        private int GetLevel(int veriableForinItialization, string text)
        {
            bool result;
            string userInput;

            Console.Write(text);

            userInput = Console.ReadLine();

            result = int.TryParse(userInput , out veriableForinItialization);

            if (result == false)
            {
                Console.WriteLine("Вы ввели неправильное значение");
                Console.ReadKey();
            }
          
            return veriableForinItialization;
        }

        private string GetNicName(string veriableForinItialization, string text)
        {
            Console.Write(text);

            veriableForinItialization = Console.ReadLine();

            return veriableForinItialization;
        }

        private bool GetIsActive(bool veriableForinItialization, string text)
        {
            bool result;
            string userInput;

            Console.Write(text);

            userInput = Console.ReadLine();

            result = bool.TryParse(userInput, out veriableForinItialization);

            if (result == false)
            {
                Console.WriteLine("Вы ввели неправильное значение");
                Console.ReadKey();
            }

            return veriableForinItialization;
        }

        public void ShowALLPlayers()
        {
            Console.Clear();

            foreach (Player player in _list)
            {
                Console.WriteLine(player.ID + " " + player.NicName + " " + player.Level + " " + player.IsActive);
            }

            Console.ReadKey();
        }

        public void BanPlayer()
        {
            Console.Clear();

            Player player = null;

            bool isPlayerInList;
            int userInputBanId = 0;
            string userInputBanText = "Введите ID игрока которого хотите забанить:";

            userInputBanId = GetLevel(userInputBanId, userInputBanText);

            isPlayerInList = TryGetPlayer(userInputBanId, out player);

            if(isPlayerInList == true)
            {
                player.SetIsActiveFalse();
            }
        }

        public void UnbanlaPlayer()
        {
            Console.Clear();

            Player player = null;

            bool isPlayerInList;
            int userInputBanId = 0;
            string userInputBanText = "Введите ID игрока которого хотите забанить:";

            userInputBanId = GetLevel(userInputBanId, userInputBanText);

            isPlayerInList = TryGetPlayer(userInputBanId, out player);

            if (isPlayerInList == true)
            {
                player.SetIsActiveTrue();
            }
        }

        private bool TryGetPlayer (int userInputBanId, out Player player)
        {
            player = null;
            bool result = false;

            foreach (Player players in _list)
            {
                if (players.ID == userInputBanId)
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
