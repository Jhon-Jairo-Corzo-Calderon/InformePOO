using System;
using System.Collections.Generic;
using System.Text;


namespace Informe_POO
{
    class Dealer
    {
        private List<string> deck = new List<string>();



        public List<string> Generate()
        {
            Card card = new Card();

            List<string> suit = card.GetSuit();


            List<string> symbol = card.GetSymbol();



            foreach (string i in symbol)
            {
                foreach (string x in suit)
                {
                    string cardSS = i + x;
                    this.deck.Add(cardSS);
                }
            }

            return this.deck;
        }


    }
}
