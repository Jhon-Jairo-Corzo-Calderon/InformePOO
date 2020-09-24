using System;
using System.Collections.Generic;
using System.Text;


namespace Informe_POO
{
    class Dealer
    {
        private static List<string> deck = new List<string>();

        public static List<string> Deck { get => deck; set => deck = value; }

        private static List<string> dealerHand = new List<string>();

        public static List<string> DealerHand { get => dealerHand; set => dealerHand = value; }

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

            originalDeck = deck.GetRange(0, 52);

            if (deckInp.Count == 0 || deck != deckInp)
                throw new System.InvalidOperationException("Error, please, generate a deck before, using this method.");
            else
            {
                Random rdm = new Random();

                for (int i = 0; i <= 51; i++)
                {
                    string singleCard = originalDeck[i];
                    int rdmNum = rdm.Next(51);
                    deckInp.Remove(singleCard);
                    deckInp.Insert(rdmNum, singleCard);
                }

                return deckInp;

            }
        }

        public string Deal()
        {
            int lastCard = deck.Count - 1;
            string card = deck[lastCard];
            deck.Remove(card);

            return card;
        }

        public List<string> AddCard(string card)
        {
            dealerHand.Add(card);

            return dealerHand;
        }

        public List<string> Init()
        {
            string card1 = Deal();
            string card2 = Deal();

            AddCard(card1);
            AddCard(card2);

            return dealerHand;
        }

    }
}
