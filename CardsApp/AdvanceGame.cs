using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsApp
{
    public static class AdvanceGame
    {
        private static readonly int[,] beats = new int[3,3] { { 2, 3, 4 }, { 0, 3, 6 }, { -2, 3, 8 } };
        private static readonly string[] powerName = new string[] { "Weak", "Normal", "Strong" };
        private static readonly string[] beatName = new string[] { "Easy", "Typical", "Hard" };

        public static string Play()
        {
            Console.WriteLine("Choose power: 1-Weak 2-Normal 3-Strong");
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose beat: 1-Easy 2-Typical 3-Hard");
            int beat = int.Parse(Console.ReadLine());
            int[] deck = { power * 3 + beats[beat-1,0] , beats[beat - 1, 1], beats[beat - 1, 2] };
            deck[2] += deck[1] / 3;
            string[] marksDecks = CreateDecks(deck);
            SimpleGame game = new SimpleGame(marksDecks, 4);
            return PrintResults(game, powerName[power-1], beatName[beat-1], deck);
        }

        private static string[] CreateDecks(int[] deck)
        {
            string[] marksDecks = new string[]{ "H[2-" + Deck.Figures[deck[0]] + "]", "D[2-" + Deck.Figures[deck[1]] + "]", "C[2-" + Deck.Figures[deck[2]] + "]"};

            return marksDecks;

        }

        public static string PrintResults(SimpleGame game, string power, string beat, int[] deck)
        {
            
            string txtResults = "Power: " + power + ", Bet: " + beat + ". Deck: [" + deck[0] + "," + deck[1] + "," + deck[2] + "]." + "\r\n";
            
            for (int i = 0; i < game.Results.Length; i++)
            {
                txtResults += "* Game" + (i+1) + ": " + game.Cards[i] + ". Result: " + game.Results[i] + ".\r\n";
            }
            txtResults = txtResults.Remove(txtResults.Length - 2, 2);
            return txtResults;
        }
    }
}
