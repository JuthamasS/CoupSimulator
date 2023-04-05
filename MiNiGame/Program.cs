using System.Drawing;

namespace MiNiGame
{
    public class Program
    {
        public int bot_coin = 0;
        public int bot_action = 0;

        public int player_coin = 0;
        public int player_action = 0;

        static void Main(string[] args)
        {

            Program program = new Program();
            
            program.welcomeText();

            var playerName = program.GetPlayerName();

            program.GetCommand();

            program.PlayState(playerName);

        }

        public void welcomeText()
        {
            var time = 200;
            Thread.Sleep(1000);
            Console.WriteLine("________/\\\\\\\\\\\\\\\\\\_        _______/\\\\\\\\\\______        __/\\\\\\________/\\\\\\_        __/\\\\\\\\\\\\\\\\\\\\\\\\\\___");
            Thread.Sleep(time);
            Console.WriteLine(" _____/\\\\\\////////__        _____/\\\\\\///\\\\\\____        _\\/\\\\\\_______\\/\\\\\\_        _\\/\\\\\\/////////\\\\\\_   ");
            Thread.Sleep(time);
            Console.WriteLine("  ___/\\\\\\/___________        ___/\\\\\\/__\\///\\\\\\__        _\\/\\\\\\_______\\/\\\\\\_        _\\/\\\\\\_______\\/\\\\\\_ ");
            Thread.Sleep(time);
            Console.WriteLine("   __/\\\\\\_____________        __/\\\\\\______\\//\\\\\\_        _\\/\\\\\\_______\\/\\\\\\_        _\\/\\\\\\\\\\\\\\\\\\\\\\\\\\/__ ");
            Thread.Sleep(time);
            Console.WriteLine("    _\\/\\\\\\_____________        _\\/\\\\\\_______\\/\\\\\\_        _\\/\\\\\\_______\\/\\\\\\_        _\\/\\\\\\/////////____");
            Thread.Sleep(time);
            Console.WriteLine("     _\\//\\\\\\____________        _\\//\\\\\\______/\\\\\\__        _\\/\\\\\\_______\\/\\\\\\_        _\\/\\\\\\_____________");
            Thread.Sleep(time);
            Console.WriteLine("      __\\///\\\\\\__________        __\\///\\\\\\__/\\\\\\____        _\\//\\\\\\______/\\\\\\__        _\\/\\\\\\_____________");
            Thread.Sleep(time);
            Console.WriteLine("       ____\\////\\\\\\\\\\\\\\\\\\_        ____\\///\\\\\\\\\\/_____        __\\///\\\\\\\\\\\\\\\\\\/___        _\\/\\\\\\_____________ ");
            Thread.Sleep(time);
            Console.WriteLine("        _______\\/////////__        ______\\/////_______        ____\\/////////_____        _\\///______________");
            //Console.WriteLine("made by JUTHAMAZ");
        }

        public string GetPlayerName()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(800);
            Console.Write("                                          Player name : ");
            string playerName = Console.ReadLine();
            Console.WriteLine(); 
            Console.WriteLine(); 
            Console.WriteLine(); 
            Console.WriteLine();

            return playerName;
        }

        public void GetCommand()
        {
            Console.WriteLine("!NOTE : type below command if you need help.");
            Console.WriteLine("help - to read all command again.");
            Console.WriteLine("rule - to read the game rule then type 'ok' to back to game");
            Console.WriteLine("role - to read the character and action then type 'ok' to back to game");
            Console.WriteLine("exit - to leave game");
        }

        public void GetGameRules()
        {
            Console.WriteLine("get game rule yah");
        }

        public void GetGameRoles()
        {
            Console.WriteLine("get game role yah");
        }

        public void RandomRoles()
        {
            //random cardds
            var randomRoles = new Random();
            var listRoles = new List<string> { "DUKE", "AMBASSDOR", "CONTESSA", "CAPTAIN", "ASSASIN" };

            int random_bot_index_role1 = randomRoles.Next(listRoles.Count);
            int random_bot_index_role2 = randomRoles.Next(listRoles.Count);
            List<int> bot_index_role = new List<int>();
            bot_index_role.Add(random_bot_index_role1);
            bot_index_role.Add(random_bot_index_role2);

            int random_player_index_role1 = randomRoles.Next(listRoles.Count);
            int random_player_index_role2 = randomRoles.Next(listRoles.Count);
            List<int> player_index_role = new List<int>();
            player_index_role.Add(random_player_index_role1);
            player_index_role.Add(random_player_index_role2);

        }

        public void PlayState(string playerName)
        {
            while (true)
            {
                //Draw
                //random cardds
                var randomRoles = new Random();
                var listRoles = new List<string> { "DUKE", "AMBASSDOR", "CONTESSA", "CAPTAIN", "ASSASIN" };
                var coin = 2;
                var actionLog = "";

                int random_bot_index_role1 = randomRoles.Next(listRoles.Count);
                int random_bot_index_role2 = randomRoles.Next(listRoles.Count);
                List<int> bot_index_role = new List<int>();
                bot_index_role.Add(random_bot_index_role1);
                bot_index_role.Add(random_bot_index_role2);

                int random_player_index_role1 = randomRoles.Next(listRoles.Count);
                int random_player_index_role2 = randomRoles.Next(listRoles.Count);
                List<int> player_index_role = new List<int>();
                player_index_role.Add(random_player_index_role1);
                player_index_role.Add(random_player_index_role2);



                Console.WriteLine();
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine("| " + listRoles[0] + " | " + listRoles[1] + " | ");
                Console.WriteLine();
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - ");

                if (true)
                {
                    Console.WriteLine(playerName + " turn..");
                }
                else
                {
                    Console.WriteLine("BOT turn..");
                }

                Console.WriteLine("Log..");

                Console.WriteLine("two crads..");

                Console.WriteLine((coin < 2 ? "coin : " : "coins :") + coin);

                var optionActionStr = "i - income | f - foreign aid | t - tax | as - assasinate | st - steal | ex - exchange " +
                    " bst - block stealing | bfa - block foreign aid | bas - block assasinate";
                Console.WriteLine(optionActionStr);


                var x = "i - income " +
                    "| f - foreign aid " +
                    "| t - tax " +
                    "| as - assasinate " +
                    "| st - steal " +
                    "| ex - exchange " +
                    "| bst - block stealing " +
                    "| bfa - block foreign aid " +
                    "| bas - block assasinate";
            }
        }

        public void playerInput()
        {
            string player_input = "";
            Console.WriteLine("Choose and type the action..");
            player_input = Console.ReadLine();



            switch (player_input)
            {
                case "exit":
                    Console.WriteLine("Leave game..");
                    break;
                case "rule":
                    GetGameRules();
                    break;
                case "role":
                    GetGameRoles();
                    break;
                case "ok":
                    //playState();
                    break;
                case "help":
                    GetCommand();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("!?Don't understand the command. Please try another word.");
                    break;
            }
        }
    }   
}