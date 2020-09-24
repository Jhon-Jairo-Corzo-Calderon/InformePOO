using System;
using System.Collections.Generic;
using System.Text;

namespace Informe_POO
{
    class Card
    {
        //Se crean los atributos.
        private List<string> suit = new List<string>()
        {
            "♥","♦","♣","♠"
        };


        private List<string> symbol = new List<string>()
        {
            "A","2","3","4","5","6","7","8","9","10","J","Q","K"
        };

        private List<int> score = new List<int>()
        {
            1,2,3,4,5,6,7,8,9,10
        };

        private string color; // No le determino valor, porque depende del atributo "suit".


        //Creacion de Getters, los setter son irrelevantes para este ejercicio.
        public List<string> GetSuit()
        { return suit; }

        public List<string> GetSymbol()
        { return symbol; }

        public List<int> GetScore()
        { return score; }

        public string GetColor()
        { return color; }

        public Card() //Constructor utilizado unicamente para generar el mazo.
        {

        }

        //Metodo Constructor, cuyos parametros son un simbolo y una figura "suit".
        public Card(string symbol, string suit)
        {
            symbol = symbol.ToUpper();//Evita errores, en caso de que el simbolo sea correcto, pero este en minuscula.

            //"indxSymbol" representa el indice del parametro "symbol" en la lista del atributo "symbol".
            int indxSymbol; //Esta variable ayuda a darle el valor a la carta, con el switch que se encuentra mas abajo.

            if (this.symbol.Contains(symbol) == true) // Este if, se encarga de ver que el parametro "symbol", dado por el constructor, pertenezca al de una baraja de poker. 
            {
                indxSymbol = this.symbol.IndexOf(symbol);
                this.symbol.Clear();
                this.symbol.Add(symbol);//Dentro de este if, tambien se asigna valor al atributo symbol.

            }
            else //Si el parametro "symbol" no concuerda, se generara un error.
            {
                throw new System.InvalidOperationException("Error, please type an existing symbol (A,1,2,3,4,5,6,7,8,9,10,J,Q,K).");
            }

            // Este if, cumple el mismo proposito que el anterior if, solo que este evalua el parametro "suit".
            if (this.suit.Contains(suit) == true)
            {
                this.suit.Clear();
                this.suit.Add(suit);//Dentro de este if, tambien se asigna valor al atributo symbol.
            }
            else //Si el parametro "suit" no concuerda, se generara un error.
            {
                throw new System.InvalidOperationException("Error, please type an existing suit (♥,♦,♣,♠).");
            }

            //Este switch, asigna valor al atributo "score", dependiendo de "indxSymbol".
            switch (indxSymbol)
            {
                case 0:
                    int cardScore = score[0];
                    score.Clear();
                    score.Add(cardScore);
                    score.Add(11);
                    break;
                case 1:
                    cardScore = score[1];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 2:
                    cardScore = score[2];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 3:
                    cardScore = score[3];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 4:
                    cardScore = score[4];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 5:
                    cardScore = score[5];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 6:
                    cardScore = score[6];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 7:
                    cardScore = score[7];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 8:
                    cardScore = score[8];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 9:
                    cardScore = score[9];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 10:
                    cardScore = score[9];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 11:
                    cardScore = score[9];
                    score.Clear();
                    score.Add(cardScore);
                    break;
                case 12:
                    cardScore = score[9];
                    score.Clear();
                    score.Add(cardScore);
                    break;
            }

            //Este if, asigna valor al atributo color, dependiendo del parametro "suit".
            if (suit == "♥" || suit == "♦")
            {
                this.color = "red";
            }
            else
            {
                this.color = "black";
            }
        }
    }
}
