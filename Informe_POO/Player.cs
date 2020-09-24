using System;
using System.Collections.Generic;
using System.Text;

namespace Informe_POO
{
    class Player
    {
        static public string name;
        private List<string> playerHand = new List<string>();

        public List<string> PlayerHand { get => playerHand; set => playerHand = value; }

        public List<string> AddCard(string card)
        {
            playerHand.Add(card);

            return playerHand;
        }

        public List<string> Init(List<string> deck)
        {
            int deckSize = deck.Count;
            int lastCard = deckSize - 1;

            int condicionVariable = 52; // SI EL TALLADOR COMIENZA PRIMERO, SE DEBE CAMBIAR ESTE VALOR POR 48.

            if (deckSize < condicionVariable && deckSize == 0)
                throw new System.ArgumentOutOfRangeException("Error, please, generate a deck before, using this method.");
            else
            {
                string card1 = deck[lastCard];
                deck.Remove(card1);

                string card2 = deck[lastCard - 1];
                deck.Remove(card2);

                AddCard(card1);
                AddCard(card2);
            }

            return playerHand;

        }
    }
}
