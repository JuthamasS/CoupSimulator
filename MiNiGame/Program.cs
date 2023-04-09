using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace MiNiGame
{
    public class Program
    {
        #region variable

        public Random random = new Random();
        public List<string> listRoles = new List<string> { "DUKE", "AMBASSDOR", "CONTESSA", "CAPTAIN", "ASSASIN" };
        //public Boolean isPlayerTurn = true;

        public int bot_coin = 2;
        public int bot_influence = 2;
        public List<string> bot_action = new List<string>();
        public List<string> bot_index_role = new List<string>();

        public string playerName = "";
        public int player_coin = 2;
        public int player_influence = 2;
        public List<string> player_action = new List<string>();
        public List<string> player_index_role = new List<string>();
        
        #endregion

        static void Main(string[] args)
        {
            
            Program program = new Program();

            program.WelcomeText();

            program.playerName = program.GetPlayerName();
            //program.playerName = "Juthamaz";

            program.GetCommand();

            program.RandomRolesStartingGame();

            while (true)
            {
                program.MonitorInteface(true);

                program.PrintAction(false, false, false, false, false, false);

                var result = program.PlayerInput();
                if (result == "exit")
                {
                    Console.WriteLine();
                    Console.WriteLine("Have a good one.. See you soon~");
                    break;
                }

                program.MonitorInteface(false);
            }
        }

        public void RandomRolesAfterChallenge(Boolean isPlayer, string exchangeRole)
        {
            var index_role = random.Next(listRoles.Count);

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

        public void MonitorInteface(Boolean isPlayerTurn)
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
                Console.WriteLine("[ Waiting for Bot..   ]");
                Console.WriteLine();
                Console.WriteLine();
                BotTurn(false);
                Console.WriteLine();
                Console.WriteLine("                      >> Bot <<");
                Console.WriteLine();
                Console.WriteLine("                      " + (bot_coin < 2 ? "coin : " : "coins :") + bot_coin);
                Console.WriteLine("                  " + (bot_influence < 2 ? "bot_influence : " : "bot_influences :") + bot_influence);

                Console.WriteLine();
                Console.WriteLine("                =====================");
                
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }

        public List<string> BotAction(Boolean isChooseToLose,
            Boolean ischooseToBlockStealBy,
            Boolean canChallenge,
            Boolean hasStealAction,
            Boolean hasForeignAidAction,
            Boolean hasAssasinateAction)
        {
            List<string> actionist = new List<string>();

            actionist.Add("i");
            actionist.Add("f");
            actionist.Add("t");
            actionist.Add("st");
            actionist.Add("ex");

            if (player_coin > 6) actionist.Add("cp");
            if (player_coin > 2) actionist.Add("as");

            if (canChallenge) actionist.Add("c");

            if (hasStealAction) actionist.Add("bst");

            if (hasForeignAidAction) actionist.Add("bfa");

            if (hasAssasinateAction) actionist.Add("bas");

            if (isChooseToLose)
            {
                if (player_index_role[0] != null || player_index_role[1] != null)
                {
                    if (player_index_role.Contains("duke")) actionist.Add("d");

                    if (player_index_role.Contains("ambassador")) actionist.Add("am");

                    if (player_index_role.Contains("assasin")) actionist.Add("as");

                    if (player_index_role.Contains("captain")) actionist.Add("cp");

                    if (player_index_role.Contains("contessa")) actionist.Add("cs");
                }
            }

            if (ischooseToBlockStealBy)
            {
                actionist.Add("am"); 
                actionist.Add("cp");
            }

            return actionist;
        }

        public void PrintAction(Boolean isChooseToLose,
            Boolean isChooseToBlockStealBy,
            Boolean canChallenge,
            Boolean hasStealAction, 
            Boolean hasForeignAidAction, 
            Boolean hasAssasinateAction)
        {
            
            Console.WriteLine("     - Actions -");
            Console.WriteLine();
            Console.WriteLine("     i - income");
            Console.WriteLine("     f - foreign aid");
            Console.WriteLine("     t - tax");
            Console.WriteLine("    st - steal");
            Console.WriteLine("    ex - exchange");

            if (player_coin > 6) Console.WriteLine("    cp - coup");
            if (player_coin > 2) Console.WriteLine("    as - assasinate");

            if (canChallenge)
            {
                Console.WriteLine("     c - challenge");
                Console.WriteLine("     p - pass");
            }
            
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

            if (isChooseToBlockStealBy)
            {
                Console.WriteLine("    am - ambassador");
                Console.WriteLine("    cp - captain");
            }
        }
        

        public Boolean BotTurn(Boolean canChallenge)
        {
            Boolean resultTurn = false;
            Boolean isChooseToLoseParam = false;
            Boolean isChooseToBlockStealParam = false;
            Boolean canChallengeParam = false;
            Boolean hasStealActionParam = false;
            Boolean hasForeignAidActtionParam = false;
            Boolean hasAssasinateActtionParam = false;
            
            if (canChallenge)
            {
                canChallengeParam = true;
            }
            
            var bottAction = BotAction(isChooseToLoseParam, isChooseToBlockStealParam, canChallengeParam, hasStealActionParam, hasForeignAidActtionParam, hasAssasinateActtionParam);
            int num = random.Next(1, bottAction.Count);
            string bot_action = bottAction[num - 1];
            var result = ProcessAction("Bot", bot_action, false);

            return resultTurn;
        }

        public string PlayerInput()
        {
            string player_input = "";

            Console.WriteLine();
            Console.WriteLine("Choose your action :");
            player_input = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            return ProcessAction(playerName,player_input,true);
        }

        public string ProcessAction(string name,string action_input,Boolean isPlayerTurn)
        {
            string result_return = "";
            switch (action_input)
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
                    MonitorInteface(true);
                    break;
                case "help":
                    GetCommand();
                    break;
                case "i":
                    Console.WriteLine(name + " take 1 coins");
                    if (isPlayerTurn) 
                    {
                        player_coin += 1;
                    }
                    else
                    {
                        bot_coin += 1;
                    }
                    break;
                case "f":
                    Console.WriteLine(name + " take 2 coins");
                    if (isPlayerTurn)
                    {
                        player_coin += 2;
                    }
                    else
                    {
                        bot_coin += 2;
                    }
                    break;
                case "t":
                    if (isPlayerTurn)
                    {
                        player_coin += 3;
                    }
                    else
                    {
                        bot_action.Add("st");
                        PrintAction(false, false, true, false, false, false);
                    }
                    break;
                case "st":
                    if (isPlayerTurn)
                    {
                        player_action.Add("st");
                        BotTurn(true);
                        Console.WriteLine(name + " take 2 coins from Bot");
                        player_coin += 2;
                    }
                    else
                    {
                        bot_action.Add("st");
                        PrintAction(false, true, true, false, false, false);
                    }
                    break;
                case "p":
                    if (isPlayerTurn)
                    {

                    }
                    else
                    {
                        switch (player_action[(player_action.Count - 2)])
                        {
                            case "st":
                                Console.WriteLine("Bot take 2 coins from " + name);
                                bot_coin += 2;
                                break;
                            case "t":
                                Console.WriteLine("Bot take 3 coins");
                                bot_coin += 3;
                                break;
                            case "as":
                                
                                break;
                            case "ex":
                                
                                break;
                            case "bas":
                                
                                break;
                            case "bst":
                                
                                break;
                            case "bfa":
                                
                                break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("!?Don't understand the command. Please try another word.");
                    break;
            }

            return result_return;
        }

        public void WelcomeText()
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
            string playerName = 
                Console.ReadLine();
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
            var random_bot_index_role1 = random.Next(listRoles.Count);
            var random_bot_index_role2 = random.Next(listRoles.Count);

            bot_index_role.Add(listRoles[random_bot_index_role1]);
            bot_index_role.Add(listRoles[random_bot_index_role2]);

            var random_player_index_role1 = random.Next(listRoles.Count);
            var random_player_index_role2 = random.Next(listRoles.Count);

            player_index_role.Add(listRoles[random_player_index_role1]);
            player_index_role.Add(listRoles[random_player_index_role2]);

        }
    }   
}
