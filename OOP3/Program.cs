using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

            DataBase players = new DataBase();

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
                        players.Add();
                        break;

                    case ShowAllPlayersInMenu:
                        players.ShowALL();
                        break;

                    case BanPlayerInMenu:
                        players.Ban();
                        break;

                    case UnbanPlayerInMenu:
                        players.UnBan();
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

    class DataBase
    {
        List<Player> list = new List<Player>();

        public void Add()
        {
            Console.Clear();

            int tempId;
            string tempNicName;
            int tempLevel;
            bool tempActive;
            string tempIdText = "Введите ID игрока: ";
            string tempNicNameText = "Введите Никнейм игрока: ";
            string tempLevelText = "Введите уровень игрока: ";
            string tempAativeText = "Ввдите false если игрок не активен или true если игрок активен: ";
            bool doesMatchID = false;

            TakeValue(out tempId, tempIdText);
            TakeValue(out tempNicName, tempNicNameText);
            TakeValue(out tempLevel, tempLevelText);
            TakeValue(out tempActive, tempAativeText);

            Player player = new Player(tempId, tempNicName, tempLevel, tempActive);

            for (int i = 0; i < list.Count; i++)
            {
                if (player.ID == list[i].ID)
                {
                    Console.WriteLine($"Игрок с номером {tempId} же есть");
                    Console.ReadKey();
                    doesMatchID = true;
                    break;
                }
            }

            if (doesMatchID == false)
            {
                list.Add(player);
            }                     
        }

        static void TakeValue(out int veriableForinItialization, string text)
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

        static void TakeValue(out string veriableForinItialization, string text)
        {
            string userInput;

            Console.Write(text);

            userInput = Console.ReadLine();

            veriableForinItialization = userInput;

        }

        static void TakeValue(out bool veriableForinItialization, string text)
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

        public void ShowALL()
        {
            Console.Clear();

            foreach (Player player in list)
            {
                Console.WriteLine(player.ID + " " + player.NicName + " " + player.Level + " " + player.IsActive);
            }

            Console.ReadKey();
        }

        public void Ban()
        {
            int userInputBanId;
            string userInputBanText = "Введите ID игрока которого хотите забанить:";

            TakeValue(out userInputBanId, userInputBanText);

            foreach (Player player in list)
            {
                if (player.ID == userInputBanId)
                {
                    player.IsActive = false;
                }
            }
        }

        public void UnBan()
        {
            int userInputBanId;
            string userInputBanText = "Введите ID игрока которого хотите забанить:";

            TakeValue(out userInputBanId, userInputBanText);

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
