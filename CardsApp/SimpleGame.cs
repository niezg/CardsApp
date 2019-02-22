using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsApp
{
    public class SimpleGame
    {
        public string[] Results { get; set; }
        public string[] Cards { get; set; }
        

        public SimpleGame(int numberGames)
        {
            Results = new string[numberGames];
            Cards = new string[numberGames];

            for (int i = 0; i < numberGames; i++)
            {
                string[] cards = Deck.RandomCards(Program.inputPathFolder + "inputFile.txt", 2);
                Results[i] = CompareCards(cards);
                Cards[i] = Deck.PrintCards(cards);
            }
            
        }

        public SimpleGame(string[] marksDecks, int numberGames)
        {
            Results = new string[numberGames];
            Cards = new string[numberGames];

            for (int i = 0; i < numberGames; i++)
            {
                string[] cards = Deck.RandomCards(marksDecks, 2);
                Results[i] = CompareCards(cards);
                Cards[i] = Deck.PrintCards(cards);
            }

        }

        private string CompareCards(string[] cards)
        {
            
            int addValue = GetCardValue(cards[0]) + GetCardValue(cards[1]);
            if (addValue > 0) return "win";
            else if (addValue < 0) return "loss";
            else return "tie";

        }

        private int GetCardValue(string card)
        {
            if (card[0] == 'C') return -1;
            else if (card[0] == 'H') return 1;
            else return 0;
        }

        public string PrintResults()
        {
            string txtResults = "";

            for (int i = 0; i < Results.Length; i++)
            {
                txtResults += Cards[i] + ", " + Results[i] + "\r\n";
            }
            txtResults = txtResults.Remove(txtResults.Length - 2, 2);
            return txtResults;
        }
    }

}

