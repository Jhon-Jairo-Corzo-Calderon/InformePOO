using System;
using System.Collections.Generic;
using System.Text;


namespace Informe_POO
{
    class Dealer
    {
        private List<string> deck = new List<string>();

        private List<string> dealerHand = new List<string>();

        public List<string> Generate()
        {
            deck.Clear();

            Card card = new Card();

            List<string> suit = card.GetSuit();


            List<string> symbol = card.GetSymbol();



            foreach (string i in symbol)
            {
                foreach (string x in suit)
                {
                    string cardSS = i + x;
                    deck.Add(cardSS);
                }
            }
            return deck;
        }

        public List<string> Randomize(List<string> deckInp)
        {
            List<string> originalDeck = new List<string>();

            originalDeck = deck.GetRange(0, 51);

            if (deckInp.Count == 0 || deck != deckInp)
                throw new System.InvalidOperationException("Error, please, generate a deck before, using this method.");
            else
            {
                Random rdm = new Random();

                for (int i = 0; i < 51; i++)
                {
                    string singleCard = originalDeck[i];
                    int rdmNum = rdm.Next(51);
                    deckInp.Remove(singleCard);
                    deckInp.Insert(rdmNum, singleCard);
                }

                return deckInp;

            }
        }

    }
}
