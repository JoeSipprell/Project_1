using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main()
        {
            Player[] playerList = new Player[40];
            int x;
            int BUDGET_REMAINING = 95000000;
            int highRankPlayers = 0;
            List<Player> pickedPlayers = new List<Player>();
            String nameRow,rankRow, salaryRow, originRow, playerName, positionRow, errorRow;
            bool playerNameFound, playerInputValid, sentinelValueEntered;
            

            void CreatePlayer(string Name, string Position, string Institution, int Salary, int Rank, int pNumber)
            {
                playerList[pNumber] = new Player(Name, Position, Institution, Salary, Rank);
            }

            //Quarterbacks
            CreatePlayer("Mason Rudolph", "Quarterback", "Oklahoma State", 26400100, 1, 0);
            CreatePlayer("Lamar Jackson", "Quarterback", "Louisville", 20300100, 2, 1);
            CreatePlayer("Josh Rosen", "Quarterback", "UCLA", 17420300, 3, 2);
            CreatePlayer("Sam Darnold", "Quarterback", "Southern California", 13100145, 4, 3);
            CreatePlayer("Backer Mayfield", "Quarterback", "Oklahoma", 10300000, 5, 4);

            //Running backs
            CreatePlayer("Saquon Barkley", "Running Back", "Penn State", 24500100, 1, 5);
            CreatePlayer("Derrius Guice", "Running Back", "LSU", 19890200, 2, 6);
            CreatePlayer("Bryce Love", "Running Back", "Stanford", 18700800, 3, 7);
            CreatePlayer("Ronald Jones II", "Running Back", "Southern California", 15000000, 4, 8);
            CreatePlayer("Damien Harris", "Running Back", "Alabama", 11600400, 5, 9);

            //Wide-Receivers
            CreatePlayer("Courtland Sutton", "Wide-Receiver", "Southern Methodist", 23400000, 1, 10);
            CreatePlayer("James Washington", "Wide-Receiver", "Oklahoma State", 21900300, 2, 11);
            CreatePlayer("Marcell Ateman", "Wide-Receiver", "Oklahoma State", 19300230, 3, 12);
            CreatePlayer("Anthony Miller", "Wide-Receiver", "Memphis", 13400230, 4, 13);
            CreatePlayer("Calvin Ridley", "Wide-Receiver", "Alabama", 10000000, 5, 14);

            //Defensive Linemen
            CreatePlayer("Maurice Hurst", "Defensive Lineman", "Michigan", 26200300, 1, 15);
            CreatePlayer("Vita Vea", "Defensive Lineman", "Washington", 22000000, 2, 16);
            CreatePlayer("Taven Bryan", "Defensive Lineman", "Florida", 16000000, 3, 17);
            CreatePlayer("Da'Ron Payne", "Defensive Lineman", "Alabama", 18000000, 4, 18);
            CreatePlayer("Harrison Phillips", "Defensive Lineman", "Stanford", 13000000, 5, 19);

            //Defensive-Backs
            CreatePlayer("Joshua Jackson", "Defensive-Back", "Iowa", 24000000, 1, 20);
            CreatePlayer("Derwin James", "Defensive-Back", "Florida State", 22500249, 2, 21);
            CreatePlayer("Denzel Ward", "Defensive-Back", "Ohio State", 20000100, 3, 22);
            CreatePlayer("Minkah Fitzpatrick", "Defensive-Back", "Alabama", 16000200, 4, 23);
            CreatePlayer("Isaiah Oliver", "Defensive-Back", "Colorado", 11899999, 5, 24);

            //Tight Ends
            CreatePlayer("Mark Andrews", "Tight End", "Oklahoma", 27800900, 1, 25);
            CreatePlayer("Dallas Goedert", "Tight End", "So. Dakota State", 21000800, 2, 26);
            CreatePlayer("Jaylen Samuels", "Tight End", "NC State", 17499233, 3, 27);
            CreatePlayer("Mike Gesicki", "Tight End", "Penn State", 27900800, 4, 28);
            CreatePlayer("Troy Fumagalli", "Tight End", "Wisconsin", 14900333, 5, 29);

            //Line-Backers
            CreatePlayer("Roquan Smith", "Line-Backer", "Georgia", 22900300, 1, 30);
            CreatePlayer("Tremaine Edmunds", "Line-Backer", "Virginia Tech", 19000590, 2, 31);
            CreatePlayer("Kendall Joseph", "Line-Backer", "Clemson", 18000222, 3, 32);
            CreatePlayer("Dorian O'Daniel", "Line-Backer", "Clemson", 12999999, 4, 33);
            CreatePlayer("Malik Jefferson", "Line-Backer", "Texas", 10000100, 5, 34);

            //Offensive Tackles
            CreatePlayer("Orlando Brown", "Offensive Tackle", "Oklahoma", 23000000, 1, 35);
            CreatePlayer("Kolton Miller", "Offensive Tackle", "UCLA", 20000000, 2, 36);
            CreatePlayer("Chukwuma Okorafor", "Offensive Tackle", "Western Michigan", 19400000, 3, 37);
            CreatePlayer("Connor Williams", "Offensive Tackle", "Texas", 16200700, 4, 38);
            CreatePlayer("Mike McGlinchey", "Offensive Tackle", "Notre Dame", 15900000, 5, 39);

            void printPosition(int positionNum)
            {
                nameRow = "Name:    ";
                rankRow = String.Format("Rank:    {0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", "1", "2", "3", "4", "5");
                salaryRow = "Salary:  ";
                originRow = "Origin:  ";
                errorRow =  "         ";

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nCurrently viewing: {0}s", playerList[(positionNum - 1) * 5].gPosition());

                Console.Write("Players highlighted in ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("red ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("cannot be picked.\n");

                Console.WriteLine(rankRow);

                Console.Write(nameRow);
                for (x = (positionNum - 1) * 5; x <= (positionNum - 1) * 5 + 4; x++)
                {
                    nameRow = String.Format("{0,-20}", playerList[x].gName());

                    if(playerList[x].isPicked() == false && playerList[x].gSalary() <= BUDGET_REMAINING)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        errorRow += "                    ";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if(playerList[x].gSalary() > BUDGET_REMAINING)
                        {
                            errorRow += String.Format("{0,-20}", "Too expensive!");
                        }
                        else if (playerList[x].isPicked() == true)
                        {
                            errorRow += String.Format("{0,-20}", "Already Picked");
                        }
                    }

                    Console.Write(nameRow);
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(salaryRow);
                for (x = (positionNum - 1) * 5; x <= (positionNum - 1) * 5 + 4; x++)
                {
                    salaryRow = String.Format("{0,-20:C0}", playerList[x].gSalary());

                    if (playerList[x].isPicked() == false && playerList[x].gSalary() <= BUDGET_REMAINING) { Console.ForegroundColor = ConsoleColor.Green; }
                    else { Console.ForegroundColor = ConsoleColor.Red; }
                    
                    Console.Write(salaryRow);
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(originRow);
                for (x = (positionNum - 1) * 5; x <= (positionNum - 1) * 5 + 4; x++)
                {
                    originRow = String.Format("{0,-20}", playerList[x].gInst());

                    if (playerList[x].isPicked() == false && playerList[x].gSalary() <= BUDGET_REMAINING) { Console.ForegroundColor = ConsoleColor.Green; }
                    else { Console.ForegroundColor = ConsoleColor.Red; }
                    
                    Console.Write(originRow);
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorRow);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Remaining Budget: {BUDGET_REMAINING,0:C0}");
            }

            void printPickedPlayers()
            {
                nameRow =     "Name:       ";
                rankRow =     "Rank:       ";
                salaryRow =   "Salary:     ";
                originRow =   "Origin:     ";
                positionRow = "Position:   ";

                foreach(Player p in pickedPlayers)
                {
                    nameRow = nameRow + String.Format("{0,-21}", p.gName());

                    positionRow = positionRow + String.Format("{0,-21}", p.gPosition());

                    rankRow = rankRow + String.Format("{0,-21}", p.gRank());

                    originRow = originRow + String.Format("{0,-21}", p.gInst());

                    salaryRow = salaryRow + String.Format("{0,-21:C0}", p.gSalary());
                }

                Console.WriteLine("Your picked players:");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(nameRow);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(positionRow);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(rankRow);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(originRow);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(salaryRow);
                Console.BackgroundColor = ConsoleColor.Black;
            }

            void inputPlayer(ref bool validInput, ref bool sentVal)
            {
                if (pickedPlayers.Count > 0)
                {
                    printPickedPlayers();
                    Console.WriteLine("\nCumulative salaries of picked players: {0:C0}", 95000000 - BUDGET_REMAINING);
                }
                Console.WriteLine("Your remaining budget is {0:C0}\n", BUDGET_REMAINING);
                Console.WriteLine($"You can pick up to {5 - pickedPlayers.Count} more players.");

                Console.WriteLine();

                Console.WriteLine(" 1. Quarterback \n 2. Running Back \n 3. Wide-Receiver \n 4. Defensive Lineman" +
                " \n 5. Defensive-Back \n 6. Tight End \n 7. Line-Backer \n 8. Offensive Tackles \n 9. Quit \n");


                Console.Write("Enter the number for what position you would like to pick: ");
                int pNum = Convert.ToInt32(Console.ReadLine());

                if (1 <= pNum && pNum <= 8)
                {
                    printPosition(pNum);
                    Console.WriteLine("\nEnter 6 to cancel");

                    Console.Write("Enter the name of the player you would like to pick, or the player's rank number: ");
                    playerName = Console.ReadLine();

                    Console.Clear();

                    if (playerName != "6")
                    {
                        validInput = playerSearch(playerName, pNum);
                    }
                }
                else if (pNum == 9)
                {
                    sentVal = true;
                    validInput = true;
                }
                else if (pNum <= 0 || pNum >= 10)
                {
                    Console.WriteLine($"Sorry, {pNum} is not a valid number");
                }
            }

            bool playerSearch(string pName, int pNumber) // Searches the array of players for a name that matches the input, or a player with the correct rank
            {
                string errorMessage = "";
                playerNameFound = false;

                for (x = (pNumber - 1) * 5; x <= (pNumber - 1) * 5 + 4; x++)
                {
                    Player play = playerList[x];

                    if (play.gName().ToLower() == playerName.ToLower() || play.gRank().ToString() == pName)
                    {
                        if (play.isPicked() == false && BUDGET_REMAINING >= play.gSalary())
                        {
                            play.pickPlayer();
                            pickedPlayers.Add(play);
                            BUDGET_REMAINING = BUDGET_REMAINING - play.gSalary();
                            if(play.gRank() <= 3) { highRankPlayers = highRankPlayers + 1; }
                            playerNameFound = true;


                            Console.WriteLine($"You picked {play.gName()} \n");
                        }
                        else
                        {
                            if(BUDGET_REMAINING < play.gSalary())
                            {
                                errorMessage = "Sorry, that player is not within your budget.";
                            }
                            if(play.isPicked() == true)
                            {
                                errorMessage = "Sorry, that player has already been picked.";
                            }
                            playerNameFound = true;
                        }
                    }
                } // end for each playername
                if(playerNameFound == false)
                {
                    errorMessage = "Sorry, that is not a valid player name.";
                }
                if(errorMessage.Length != 0)
                {
                    Console.Clear();
                    Console.WriteLine(errorMessage);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
                return (playerNameFound);
            }


            //
            //  MAIN INPUT LOOP
            //
            sentinelValueEntered = false;

            while(pickedPlayers.Count < 5 && sentinelValueEntered == false && BUDGET_REMAINING >= 10000000)
            {
                playerInputValid = false;
                while (playerInputValid == false)
                {
                    inputPlayer(ref playerInputValid, ref sentinelValueEntered);
                    
                } // end player name input loop
            }


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("PLAYER INPUT ENDED.");
            if (pickedPlayers.Count >= 5) { Console.WriteLine("The maximum amount of players (5) has been reached."); }
            if (sentinelValueEntered == true) { Console.WriteLine("The user quit the program by pressing 9"); }
            if (BUDGET_REMAINING < 10000000) { Console.WriteLine("Remaining budget was lower than the minimum player salary"); }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress enter to continue to final results.");
            Console.ReadLine();

            //
            //  FINAL OUTPUT
            //
            if (pickedPlayers.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"Number of players picked: {pickedPlayers.Count}");
                Console.WriteLine();
                Console.WriteLine("Remaining Budget: {0:C0}", BUDGET_REMAINING);
                Console.WriteLine();
                Console.WriteLine($"{highRankPlayers} of the players you picked were in the top 3 for their position");
                if (BUDGET_REMAINING >= 30000000 && highRankPlayers >= 3)
                {
                    Console.WriteLine("Cost Effective");
                }
                Console.WriteLine();

                printPickedPlayers();
            }
            else { Console.WriteLine("No players were entered."); }

            Console.Write("\nPress enter to close the program");
            Console.ReadLine();
            
        }//end main method
    }

    class Player
    {
        private string name;
        private string position;
        private string institution;
        private int salary;
        private int rank;
        private bool picked = false;

        public Player(string name, string position, string institution, int salary, int rank) // T H E   C O N S T R U C C
        {
            this.name = name;
            this.position = position;
            this.institution = institution;
            this.salary = salary;
            this.rank = rank;
        }

        public bool isPicked() { return picked; }
        public void pickPlayer() { this.picked = true; }
        
        public string gName() { return name; }
        public string gPosition() { return position; }
        public string gInst() { return institution; }

        public int gSalary() { return salary; }
        public int gRank() { return rank; }
    }
}
