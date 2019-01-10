using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaWarChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        public Deck Deck { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public List<Card> Bounty { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Deck = new Deck();
            Deck.CreateDeck();
            Player1 = new Player(new List<Card>());
            Player2 = new Player(new List<Card>());
            Bounty = new List<Card>();
        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text += String.Format("<br />=====================<br /><strong>DEALING CARDS!</strong><br />=====================<br />");

            //Deals deck randomly to both players and displays the deal to user
            DealDeckToPlayers();

            //Game last 20 rounds.
            for (int i = 0; i < 20; i++)
            {
                resultLabel.Text += String.Format("<br />=====================<br /><strong>BEGIN BATTLE #{0}!</strong><br />=====================<br />", i+1);
                
                //Conduct one round of play
                DoBattle(Player1, Player2, Bounty);
            }
            resultLabel.Text += GameOver(Player1, Player2);
        }

        private void DealDeckToPlayers()
        {
            while (Deck._Cards.Count > 0)
            {
                Card dealtCard;
                dealtCard = Deck.DealCard(Player1);
                resultLabel.Text += String.Format("Player 1 is dealt the {0} of {1}.<br />", dealtCard._Name, dealtCard._Suit);
                dealtCard = Deck.DealCard(Player2);
                resultLabel.Text += String.Format("Player 2 is dealt the {0} of {1}.<br />", dealtCard._Name, dealtCard._Suit);
            }
        }

        public void DoBattle(Player player1, Player player2, List<Card> bounty)
        {
            Battle battle = new Battle(player1, player2, bounty);
            battle.AddCardsToBounty();
            resultLabel.Text += battle.ShowBattleCards(battle.Bounty);

            CompareBattleCards(player1, player2, battle);

            //resultLabel.Text += CompareBattleCards(battle);
        }
        
        public void WeHaveWar(Player player1, Player player2, Battle battle)
        {
            resultLabel.Text += String.Format("********** WAR **********<br />");
            for (int i = 0; i < 3; i++)
            {
                battle.AddCardsToBounty();
            }
            resultLabel.Text += battle.ShowBattleCards(battle.Bounty);
            CompareBattleCards(player1, player2, battle);
        }

        public void CompareBattleCards(Player player1, Player player2, Battle battle)
        {
            if (battle.AreBattleCardsTheSame(battle.Bounty))
            {
                WeHaveWar(player1, player2, battle);
            }
            else
            {
                resultLabel.Text += battle.ListBountyOfCards(battle.Bounty);
                resultLabel.Text += AssignWinner(player1, player2, battle);
            }
        }

        public string AssignWinner(Player player1, Player player2, Battle battle)
        {
            string result = "";

            if (battle.Bounty.ElementAt(battle.Bounty.Count - 2)._Value > battle.Bounty.ElementAt(battle.Bounty.Count - 1)._Value)
            {
                result += String.Format("<strong>Player 1 wins!</strong><br />");
                foreach (Card card in battle.Bounty) player1._Hand.Add(card);
                //foreach (Card card in battle.Bounty) battle.Bounty.Remove(card);
            }
            else
            {
                result += String.Format("<strong>Player 2 wins!</strong><br />");
                foreach (Card card in battle.Bounty) player2._Hand.Add(card);
                //foreach (Card card in battle.Bounty) battle.Bounty.Remove(card);
            }

            battle.Bounty.RemoveAll(Card => Card._Value >= 0);

            return result;
        }

        public string GameOver(Player player1, Player player2)
        {
            string result = "";

            result += String.Format("<br />=====================<br /><strong>CARD COUNT:</strong><br />=====================<br />");
            result += String.Format("&nbsp;&nbsp;Player 1: {0}<br />", player1._Hand.Count);
            result += String.Format("&nbsp;&nbsp;Player 2: {0}<br />", player2._Hand.Count);

            if (player1._Hand.Count > player2._Hand.Count) result += String.Format("<strong>Player 1 wins!</strong>");
            else if (player1._Hand.Count < player2._Hand.Count) result += String.Format("<strong>Player 2 wins!</strong>");
            else if (player1._Hand.Count == player2._Hand.Count) result += String.Format("<strong>It's a tie!</strong>");

            return result;
        }
    }
}