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
        int playerScore = 0;
        int dealerScore = 0;
        public Game()
        {
            InitializeComponent();
        }
        private static int Check(List<string> cards)
        {
            int acumulado = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                string symbol = Char.ToString(cards[i][0]);
                string suit = Char.ToString(cards[i][1]);
                Card card1 = new Card(symbol, suit);
                acumulado += card1.GetScore()[0];
            }
            return acumulado;
        }
        static int cont = 0;
        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            string playerName = Player.name;
            if (contPlayer != -1)
            {
                List<string> deck = dealer.Generate();
                List<string> deckInp = dealer.Randomize(deck);
                Dealer.Deck = deckInp;
                Dealer.DealerHand = dealer.Init();
                if (contPlayer == 0)
                {
                    playerDeck = player.Init(deckInp);
                    player.PlayerHand = playerDeck;
                    playerScore = Game.Check(playerDeck);
                    txtOutPut.Text += $"{playerName}, tus cartas son: {playerDeck[0]} {playerDeck[1]} \nTu acumulado es: {playerScore} \n\nLa primera carta del tallador es: {Dealer.DealerHand[0]}";
                    if (playerScore == 21)
                    {
                        MessageBox.Show("Haz ganado automáticamente, haz obtenido 21. Felicitaciones!");
                        txtOutPut.Text = ($"{playerName}, haz ganado. Felicitaciones!");
                        contPlayer = -1;
                        contDealer = -1;
                    }
                    cont++;
                    contPlayer++;
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
                    playerScore = Game.Check(playerDeck);
                    cont++;
                    txtOutPut.Text += $"\nTu acumulado es: {playerScore}\n\nLa primera carta del tallador es: {Dealer.DealerHand[0]}";
                    if (playerScore > 21)
                    {
                        MessageBox.Show("Haz perdido, tu acumulado ha sido mayor a 21. Suerte en una próxima oportunidad. Ahora es turno del tallador");
                        contPlayer = -1;
                        contDealer = 0;
                    }
                    else if (playerScore == 21)
                    {
                        MessageBox.Show("Haz obtenido 21. Felicitaciones! Ahora es turno del tallador");
                        contPlayer = -1;
                        contDealer = 0;
                    }
                    else if (playerScore == 21 && cont==2)
                    {
                        MessageBox.Show("Haz ganado automáticamente, haz obtenido 21. Felicitaciones!");
                        txtOutPut.Text = ($"{playerName}, haz ganado. Felicitaciones!");
                        contPlayer = -1;
                        contDealer = -1;
                    }
                }
            }
            else if (contDealer!=-1)
            {
                if (contDealer == 0) 
                {
                    dealerScore = Game.Check(Dealer.DealerHand);
                    txtOutPut.Text = $"Tallador, tus cartas son: {Dealer.DealerHand[0]} {Dealer.DealerHand[1]} \nEl acumulado del tallador es: {dealerScore}";
                    contDealer++;
                }
                else
                {
                    txtOutPut.Text = $"Tallador, tus cartas son: ";
                    Dealer.DealerHand.Add(dealer.Deal());
                    foreach (string element in Dealer.DealerHand)
                    {
                        txtOutPut.Text += element + " ";
                    }
                    dealerScore = Game.Check(Dealer.DealerHand);
                    txtOutPut.Text += $"\nEl acumulado del tallador es: {dealerScore}";
                    if (dealerScore > 21)
                    {
                        MessageBox.Show("El acumulado del tallador ha sido mayor a 21. Acontinuación determinaremos quien fue el ganador del juego");
                        if (playerScore>21)
                        {
                            txtOutPut.Text = $"Tanto el tallador como tú han obtenido más de 21, por lo que ninguno tuvo la fortuna de ganar. Suerte en un próxima juego";
                            contDealer = -1;
                        }
                        else
                        {
                            txtOutPut.Text =($"{playerName}, haz ganado. Felicitaciones!");
                            contDealer = -1;
                        }
                        
                    }
                    else if (dealerScore == 21)
                    {
                        if (playerScore == 21)
                        {
                            txtOutPut.Text = $"Tanto el tallador como tú han obtenido 21, por lo que ninguno tuvo la fortuna de ganar. Suerte en una próxima oportunidad";
                            contDealer = -1;
                        }
                        else
                        {
                            txtOutPut.Text = $"{playerName}, el tallador ha ganado este juego. Suerte en una próxima oportunidad";
                            contDealer = -1;
                        }
                    }
                }
            }
        }
        private static int contPlayer = 0;
        private static int contDealer = -1;

        private void btnPlant_Click(object sender, RoutedEventArgs e)
        {
            string playerName = Player.name;
            if (contPlayer != -1 && contDealer==-1)
            {

                if (MessageBox.Show("¿Estas seguro de que quieres plantar? Una vez plantes, el turno será del tallador, por lo que la próxima vez que solicites una carta, estarás solicitando la carta del tallador", "Mensaje", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    contPlayer = -1;
                    contDealer = 0;
                }
                else
                {
                    contPlayer = 0;
                    contDealer = -1;
                }
            }
            else if (contDealer != -1 && contPlayer==-1)
            {

                if (MessageBox.Show("¿Estas seguro de que quieres plantar? Una vez plantes, el juego habrá terminado, por lo que a continuación se mostrará quien fue el ganador del juego", "Mensaje", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if(playerScore>dealerScore && playerScore<=21)
                    {
                        txtOutPut.Text = $"{playerName}, haz ganado este juego. Felicitaciones!";
                        contDealer = -1;
                    }
                    else if(dealerScore>playerScore && dealerScore<=21)
                    {
                        txtOutPut.Text = $"{playerName}, el tallador ha ganado este juego. Suerte en una próxima oportunidad";
                        contDealer = -1;
                    }
                    else
                    {
                        txtOutPut.Text = $"Tanto el tallador como tú han obtenido el mismo acumulado, por lo que ninguno tuvo la fortuna de ganar. Suerte en una próxima oportunidad";
                        contDealer = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("El juega ya ha terminado, si quieres jugar de nuevo solo es cuento de que oprima el botón \"Jugar de nuevo\"");
            }
        }
    }
}
