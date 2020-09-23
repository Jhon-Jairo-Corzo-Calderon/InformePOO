using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Informe_POO
{
    /// <summary>
    /// Lógica de interacción para Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        List<string> deckInp = new List<string>();
        List<string> dealerDeck = new List<string>();
        List<string> playerDeck = new List<string>();
        Card card = new Card();
        Dealer dealer = new Dealer();
        Player player = new Player();
        public Game()
        {
            InitializeComponent();
        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            if (cont != -1)
            {
                string playerName = Player.name;
                List<string> deck = dealer.Generate();
                List<string> deckInp = dealer.Randomize(deck);
                List<string> dealerDeck = dealer.Init();
                if (cont == 0)
                {
                    List<string> playerDeck = player.Init(deckInp);
                    player.PlayerHand = playerDeck;
                    string symbol = Char.ToString(playerDeck[0][0]);
                    string suit = Char.ToString(playerDeck[0][1]);
                    Card card1 = new Card(symbol, suit);
                    symbol = Char.ToString(playerDeck[1][0]);
                    suit = Char.ToString(playerDeck[1][1]);
                    Card card2 = new Card(symbol, suit);
                    int acumulado = card1.GetScore()[0] + card2.GetScore()[0];
                    txtOutPut.Text += $"{playerName}, tus cartas son: {playerDeck[0]} {playerDeck[1]} \nTu acumulado es: {acumulado}";
                    cont++;
                }
                else
                {
                    playerDeck = player.PlayerHand;
                    txtOutPut.Text = $"{playerName}, tus cartas son: ";
                    playerDeck.Add(dealer.Deal());
                    foreach (string element in playerDeck)
                    {
                        txtOutPut.Text += element + " ";
                    }
                    int acumulado = 0;
                    for (int i = 0; i < playerDeck.Count; i++)
                    {
                        string symbol = Char.ToString(playerDeck[i][0]);
                        string suit = Char.ToString(playerDeck[i][1]);
                        Card card1 = new Card(symbol, suit);
                        acumulado += card1.GetScore()[0];
                    }
                    txtOutPut.Text += $"\nTu acumulado es: {acumulado}";
                    if (acumulado > 21)
                    {
                        MessageBox.Show("Haz perdido, tu acumulado ha sido mayor a 21. Suerte en una próxima oportunidad");
                        cont = -1;
                    }
                    else if (acumulado == 21)
                    {
                        MessageBox.Show("Haz obtenido 21. Felicitaciones!");
                        cont = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Tu juego ya ha terminado, es hora del tallador");
            }
        }
        private static int cont = 0;

        private void btnPlant_Click(object sender, RoutedEventArgs e)
        {
            if (cont != -1)
            {

                if (MessageBox.Show("¿Estas seguro de que quieres plantar? Una vez plantes, el turno será del tallador", "Mensaje", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    cont = -1;
                }
            }
            else
            {
                MessageBox.Show("Tu juego ya ha terminado, es hora del tallador");
            }
        }
    }
}
