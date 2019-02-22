using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace CardsApp
{
    public class Deck
    {
        public static readonly string[] Figures = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static readonly string[] Colours = { "S", "H", "D", "C" };
        public List<string> Cards = new List<string>();
        private static readonly Random getrandom = new Random();

        public Deck(string deck)
        {
            char[] separators = { '[' };
            string[] splitDeck = deck.Split(separators,  StringSplitOptions.RemoveEmptyEntries);
            switch (splitDeck.Length)
            {
                case 1: // All colours - for example splitDeck == {"2-A]"}

                    if (!CheckFigures(splitDeck[0]))
                    {
                        DislplayError();
                    }
                    else
                    {
                        ReadCards(splitDeck, 1);
                    }
                    break;

                case 2: // Not all colours - for example splitDeck == {"SH", "2-A]"}

                    if (CheckColours(splitDeck[0]) == false || CheckFigures(splitDeck[1]) == false)
                    {
                        DislplayError();
                    }
                    else
                    {
                        ReadCards(splitDeck, 2);
                    }
                    break;

                default:
                    DislplayError();
                    break;
            }

        }

        private void DislplayError()
        {
            Console.WriteLine("Task 2 impossible – improper CardDeck in the first line");
        }

        private void ReadCards(string[] splitDeck, int length)
        {
            string minFigure = splitDeck[length-1][0].ToString();
            string maxFigure = splitDeck[length-1][2].ToString();
            int indexMinFigure = Array.IndexOf(Figures, minFigure);
            int indexMaxFigure = Array.IndexOf(Figures, maxFigure);

            if (length == 1)
            {
                foreach (var colour in Deck.Colours)
                {
                    for (int i = indexMinFigure; i <= indexMaxFigure; i++)
                    {
                        Cards.Add(colour.ToString() + Figures[i]);
                    }
                }
            }
            else if (length == 2)
                foreach (var colour  in splitDeck[0])
            {
                for (int i = indexMinFigure; i <= indexMaxFigure; i++)
                {
                    Cards.Add(colour.ToString() + Figures[i]);
                }
                
            }
        }


        private  bool CheckFigures(string inputFigures)
        {
            
                if (!Figures.Any(item => item == inputFigures[0].ToString()) || !Figures.Any(item => item == inputFigures[2].ToString()))
                {
                    return false;
                }
                
                return true;
        }

        private  bool CheckColours(string inputColours)
        {
            
            foreach (var item in inputColours)
            {
                if (!Colours.Any(colour => colour == item.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        public static string PrintCards(string[] cards)
        {
            string txtCards = "";

            foreach (var card in cards)
            {
                txtCards += card + ", ";
            }

            txtCards = txtCards.Remove(txtCards.Length - 2, 2);
            return txtCards;
        }

        public string PrintCards()
        {
            string txtCards = "";

            foreach (var card in Cards)
            {
                txtCards += card + ", ";
            }

            txtCards = txtCards.Remove(txtCards.Length - 2, 2);
            return txtCards;
        }

        public static string[] RandomCards(List<Deck> listDecks, int numberCards)
        {
            List<string> cards = new List<string>();
            string[] randomCards = new string[numberCards];
            foreach (Deck deck in listDecks)
            {
                cards.AddRange(deck.Cards);
            }
            for (int i = 0; i < numberCards; i++)
            {
                int number;
                number = getrandom.Next(cards.Count);
                randomCards[i] = cards[number];
            }
            return randomCards;
        }

        public static string[] RandomCards(string filePath, int numberCards)
        {
            string[] marksDecks = GetDecksFromFille(filePath);
            List<Deck> listDecks = ReadDecks(marksDecks);
            return RandomCards(listDecks, numberCards);
        }
        public static string[] RandomCards(string[] marksDecks, int numberCards)
        {
            List<Deck> listDecks = ReadDecks(marksDecks);
            return RandomCards(listDecks, numberCards);
        }


        public static string[] GetDecksFromFille(string filePath)
        {
            string inputData = File.ReadAllText(filePath).Trim();
            return inputData.Split('\n');
        }

        public static List<Deck> ReadDecks(string[] marksDecks)
        {
            List<Deck> decks = new List<Deck>();
            foreach (var markDeck in marksDecks)
            {
                decks.Add(new Deck(markDeck));
            }
            return decks;
        }



    }
}
