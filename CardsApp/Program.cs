using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsApp
{
    class Program
    {

        public static readonly string inputPathFolder = @"..\\..\\Inputs\\";
        public static readonly string outputPathFolder = @"..\\..\\Outputs\\";
        //private static List<string> AllCards = new List<string>();
        static void Main(string[] args)
        {

            int taskNumber = 0;

            for (int i = 0; ; i++)
            {

                #region console display 

                if (i >= 1)
                {
                    if (taskNumber == 6)
                        Console.WriteLine("Tasks completed.");
                    else
                        Console.WriteLine("Task completed.");
                }
                Console.WriteLine("Which task do you wish to run? (1-5, 6-All, 0-Exit) ");
                taskNumber = int.Parse(Console.ReadLine());
                if (taskNumber == 0) break;
                Console.Clear();
                #endregion
                switch (taskNumber)
                {
                    case 1: //task 1

                        CopyInputToOutput("InputFile.txt", "OutputFile.txt");
                        break;
                    case 2: //task 2
                        UnpackDeck("InputFile.txt", "OutputFile-2.txt");
                        break;
                    case 3: //task 3
                        TaskRandomCards("InputFile.txt", "OutputFile-3.txt");
                        break;
                    case 4: //task 4
                        PlaySimpleGame("InputFile.txt", "OutputFile-4.txt");
                        break;
                    case 5: //task 5
                        PlayAdvanceGame("OutputFile-5.txt");
                        break;
                    case 6:
                        CopyInputToOutput("InputFile.txt", "OutputFile.txt");
                        UnpackDeck("InputFile.txt", "OutputFile-2.txt");
                        TaskRandomCards("InputFile.txt", "OutputFile-3.txt");
                        PlaySimpleGame("InputFile.txt", "OutputFile-4.txt");
                        PlayAdvanceGame("OutputFile-5.txt");
                        break;
                    default:
                        Console.WriteLine("Incorrect number");
                        break;
                }
            }
        }

        private static void PlayAdvanceGame(string outputFileName)
        {
            string[] gameResults = new string[4];

            for (int i = 0; i < 4; i++)
            {
               gameResults[i] = AdvanceGame.Play();
            }

            File.WriteAllLines(outputPathFolder + outputFileName, gameResults);
        }

        private static void PlaySimpleGame(string inputFileName, string outputFileName)
        {
            SimpleGame game = new SimpleGame(10);
            File.WriteAllText(outputPathFolder + outputFileName, game.PrintResults());
        }

        private static void TaskRandomCards(string inputFileName, string outputFileName)
        {
            string[] cards = Deck.RandomCards(inputPathFolder + inputFileName, 10);
            File.WriteAllText(outputPathFolder + outputFileName, Deck.PrintCards(cards));
        }

        private static void UnpackDeck(string inputFileName, string outputFileName)
        {
            string[] marksDecks = Deck.GetDecksFromFille(inputPathFolder + inputFileName);
            Deck deck = new Deck(marksDecks[0]);
            File.WriteAllText(outputPathFolder + outputFileName, deck.PrintCards());
        }


        private static void CopyInputToOutput(string inputFileName, string outputFileName)
        {
            File.WriteAllText(outputPathFolder + outputFileName, File.ReadAllText(inputPathFolder + inputFileName));
        }

        
    }
}
