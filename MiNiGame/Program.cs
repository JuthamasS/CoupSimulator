using System.Drawing;

namespace MiNiGame
{
    public class Program
    {
        public Random randomRoles = new Random();
        public List<string> listRoles = new List<string> { "DUKE", "AMBASSDOR", "CONTESSA", "CAPTAIN", "ASSASIN" };
        public Boolean isPlayerTurn = true;

        public int bot_coin = 2;
        public int bot_influence = 2;
        public List<string> bot_action = new List<string>();
        public List<string> bot_index_role = new List<string>();

        public string playerName = "";
        public int player_coin = 2;
        public int player_influence = 2;
        public List<string> player_action = new List<string>();
        public List<string> player_index_role = new List<string>();

        static void Main(string[] args)
        {
            
            Program program = new Program();
            
            //program.welcomeText();

            program.playerName = program.GetPlayerName();

            program.GetCommand();

            program.RandomRolesStartingGame();

            while (true)
            {
                program.MonitorInteface(program.playerName);

                program.PrintAction(false, false, false, false, false, false, false);

                var result = program.playerInput();
                if (result == "exit")
                {
                    Console.WriteLine();
                    Console.WriteLine("Have a good one.. See you soon~");
                    break;
                }
            }
        }

        public void RandomRolesAfterChallenge(Boolean isPlayer, string exchangeRole)
        {
            var index_role = randomRoles.Next(listRoles.Count);

            if (isPlayer)
            {
                if (player_index_role[0] != null && player_index_role[1] == exchangeRole)
                {
                    player_index_role[0] = exchangeRole;
                }
                else
                {
                    player_index_role[1] = exchangeRole;
                }
            }
            else
            {
                if (bot_index_role[0] != null && bot_index_role[1] == exchangeRole)
                {
                    bot_index_role[0] = exchangeRole;
                }
                else
                {
                    bot_index_role[1] = exchangeRole;
                }
            }
        }

        public void MonitorInteface(string playerName)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            if (isPlayerTurn)
            {
                Console.WriteLine("> " + playerName + "'s turn..");


                Console.WriteLine();
                Console.WriteLine("                      >> Bot <<");
                Console.WriteLine();
                Console.WriteLine("                      " + (bot_coin < 2 ? "coin : " : "coins :") + bot_coin);
                Console.WriteLine("                  " + (bot_influence < 2 ? "bot_influence : " : "bot_influences :") + bot_influence);
                
                Console.WriteLine();
                Console.WriteLine("                =====================");
                Console.WriteLine();

                Console.WriteLine("                       >> " + playerName + " <<");
                Console.WriteLine();
                Console.WriteLine("                  " + (player_index_role[0] == "" ? "     X    " : player_index_role[0]) + " | " + (player_index_role[1] == "" ? "     X    " : player_index_role[1]));
                Console.WriteLine();
                Console.WriteLine("                      " + (player_coin < 2 ? "coin : " : "coins :") + player_coin);
                Console.WriteLine("                  " + (player_influence < 2 ? "bot_influence : " : "bot_influences :") + player_influence);

                Console.WriteLine();
                Console.WriteLine("                =====================");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("> " + "Bot's turn..");
                Console.WriteLine();
                Console.WriteLine("                      >> Bot <<");
                Console.WriteLine();
                Console.WriteLine("                      " + (bot_coin < 2 ? "coin : " : "coins :") + bot_coin);
                Console.WriteLine("                  " + (bot_influence < 2 ? "bot_influence : " : "bot_influences :") + bot_influence);

                Console.WriteLine();
                Console.WriteLine("                =====================");
                Console.WriteLine();
                Console.WriteLine("[Waiting for Bot..   ]");
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }

        public void PrintAction(Boolean isChooseToLose,
            Boolean ischooseToBlockStealBy,
            Boolean canChallenge, 
            Boolean canCoup,
            Boolean hasStealAction, 
            Boolean hasForeignAidAction, 
            Boolean hasAssasinateAction)
        {
            
            Console.WriteLine("     - Actions -");
            Console.WriteLine();
            Console.WriteLine("     i - income");
            Console.WriteLine("     f - foreign aid");
            Console.WriteLine("     t - tax");
            Console.WriteLine("    as - assasinate");
            Console.WriteLine("    st - steal");
            Console.WriteLine("    ex - exchange");

            if (canCoup) Console.WriteLine("    cp - coup");
            

            if (canChallenge) Console.WriteLine("     c - challenge");
            
            if (hasStealAction) Console.WriteLine("   bst - block stealing");
            
            if (hasForeignAidAction) Console.WriteLine("   bfa - block foreign aid");

            if (hasAssasinateAction) Console.WriteLine("   bas - block assasinate");

            if (isChooseToLose)
            { 
                if (player_index_role[0] != null || player_index_role[1] != null)
                {
                    if (player_index_role.Contains("duke")) Console.WriteLine("     d - duke");

                    if (player_index_role.Contains("ambassador")) Console.WriteLine("    am - ambassador");

                    if (player_index_role.Contains("assasin")) Console.WriteLine("    as - assasin");

                    if (player_index_role.Contains("captain")) Console.WriteLine("    cp - captain");

                    if (player_index_role.Contains("contessa")) Console.WriteLine("    cs - contessa");
                }
            }

            if (ischooseToBlockStealBy)
            {
                Console.WriteLine("    am - ambassador");
                Console.WriteLine("    cp - captain");
            }
        }
        public string playerInput()
        {
            string player_input = "";
            string result_return = "";

            Console.WriteLine();
            Console.WriteLine("Choose your action :");
            player_input = Console.ReadLine();
            Console.WriteLine(); 
            Console.WriteLine();
            Console.WriteLine();

            switch (player_input)
            {
                case "exit":
                    while (true)
                    {
                        Console.WriteLine("Are you sure ? Y/N :");
                        string ask_leave = Console.ReadLine();
                        if (ask_leave == "Y" || ask_leave == "y")
                        {
                            result_return = "exit";
                            break;
                        }
                        else if (ask_leave == "N" || ask_leave == "n")
                        {
                            result_return = "notexit";
                            break;
                        }
                    }
                    break;
                case "rule":
                    GetGameRoles();
                    GetGameRules();
                    break;
                case "role":
                    GetGameRoles();
                    GetGameRules();
                    break;
                case "ok":
                    MonitorInteface(playerName);
                    break;
                case "help":
                    GetCommand();
                    break;
                case "i":
                    Console.WriteLine("income");
                    break;
                case "f":
                    Console.WriteLine("foreign aid");
                    break;
                case "t":
                    Console.WriteLine("tax");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("!?Don't understand the command. Please try another word.");
                    break;
            }

            return result_return;
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
            int i = 0;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("!NOTE : type below command if you need help.");
                Console.WriteLine("help - to read all command again.");
                Console.WriteLine("rule - to read the game rule then type 'ok' to back to game");
                Console.WriteLine("role - to read the character and action then type 'ok' to back to game");
                Console.WriteLine("exit - to leave game");
                Console.WriteLine();
                Console.WriteLine("Are you ready ? Y/N : ");
                string isReady = Console.ReadLine();

                if (isReady == "y" || isReady == "Y") break;

                if (i > 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("!! You will stuck in loops, If you don't choose 'Y'");
                }

                i++;
            }
        }

        public void GetGameRules()
        {
            Console.WriteLine();
            Console.WriteLine("Take one action..");
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(" Character |    Action   |               Effect             |   Counteraction");
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine("           |   Income    | Take 1 coin                      |         X");
            Console.WriteLine("           | Foreign Aid | Take 2 coins                     |         X");
            Console.WriteLine("           |     Coup    | Pay 7 coins                      |         X");
            Console.WriteLine("   Duke    |     Tax     | Take 3 coins                     | Blocked Foreign Aid");
            Console.WriteLine("  Assasin  |  Assasinate | Pay 3 coins                      |         X");
            Console.WriteLine("Ambassador |   Exchange  | Exchange cards                   |  Blocks stealing");
            Console.WriteLine("  Captain  |    Steal    | Take 2 coins from another player |  Blocks stealing");
            Console.WriteLine(" Contessa  |      X      |                 X                | blocks assasination");
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
        }

        public void GetGameRoles()
        {
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("Characters, Actions and Play");
            Console.WriteLine();
            Console.WriteLine("> Income Take 1 coin. Cannot be blocked or challenged.");
            //Console.WriteLine("Cannot be blocked or challenged.");
            Console.WriteLine();
            Console.WriteLine("> Foreign Aid Take 2 coins. Cannot be challenged. Can be blockd by player claiming Duke.");
            //Console.WriteLine("challenged. Can be blockd by player");
            //Console.WriteLine("claiming Duke.");
            Console.WriteLine();
            Console.WriteLine("> Duke - Tax: Take 3 coins. Cannot be blocked.");
            Console.WriteLine();
            Console.WriteLine("> Captain - Steal: Take 2 coins from another player. Can be blocked by Captain or Ambassado.");
            //Console.WriteLine("Can be blocked by Captain or Ambassado.");
            Console.WriteLine();
            Console.WriteLine("> Assasin - Assasinate: Pay 3 coins choose player to lose Influence. Can be blocked by Contessa.");
            //Console.WriteLine("lose Influence. Can be blocked by Contessa.");
            Console.WriteLine();
            Console.WriteLine("> Contessa - Block assasinate. Cannot be blocked.");
            Console.WriteLine();
            Console.WriteLine("> Ambassador - Exchange: Take 2 cards return 2 cards to court deck. Cannot be blocked.");
            //Console.WriteLine("court deck. Cannot be blocked.");
            Console.WriteLine();
            Console.WriteLine("** Coup Pay 7 coins, Choose player to lose influence. Cannot be blocked or challenged.");
            //Console.WriteLine("influence. Cannot be blocked or challenged.");
            Console.WriteLine();
            Console.WriteLine("*** If 10+ coins must Coup.");
        }

        public void RandomRolesStartingGame()
        {
            var random_bot_index_role1 = randomRoles.Next(listRoles.Count);
            var random_bot_index_role2 = randomRoles.Next(listRoles.Count);

            bot_index_role.Add(listRoles[random_bot_index_role1]);
            bot_index_role.Add(listRoles[random_bot_index_role2]);

            var random_player_index_role1 = randomRoles.Next(listRoles.Count);
            var random_player_index_role2 = randomRoles.Next(listRoles.Count);

            player_index_role.Add(listRoles[random_player_index_role1]);
            player_index_role.Add(listRoles[random_player_index_role2]);

        }
    }   
}
