using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaWarChallenge
{
    public class Battle
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public List<Card> Bounty { get; set; }

        public Battle(Player player1, Player player2, List<Card> bounty)
        {
            Player1 = player1;
            Player2 = player2;
            Bounty = bounty;
        }

        public void AddCardsToBounty()
        {
            Bounty.Add(Player1._Hand.ElementAt(0));
            Player1._Hand.Remove(Player1._Hand.ElementAt(0));
            Bounty.Add(Player2._Hand.ElementAt(0));
            Player2._Hand.Remove(Player2._Hand.ElementAt(0));
        }
        
        public bool AreBattleCardsTheSame(List<Card> bounty)
        {
            if (bounty.ElementAt(bounty.Count -2)._Value == bounty.ElementAt(bounty.Count - 1)._Value) return true;
            else return false;
        }

        public string ShowBattleCards(List<Card> bounty)
        {
            string result = "";

            result = String.Format("Battle Cards: {0} of {1} versus {2} of {3}<br />",
                bounty.ElementAt(bounty.Count - 2)._Name,
                bounty.ElementAt(bounty.Count - 2)._Suit,
                bounty.ElementAt(bounty.Count - 1)._Name,
                bounty.ElementAt(bounty.Count - 1)._Suit);

            //result += ListBountyOfCards(bounty);

            return result;
        }       

        public string ListBountyOfCards(List<Card> bounty)
        {
            string result = "";
            result += String.Format("Bounty...<br />");
            foreach (Card card in bounty)
                result += String.Format("&nbsp;&nbsp;&nbsp;{0} of {1}<br />", card._Name, card._Suit);

            return result;
        }

        public void WeHaveWar(Player player1, Player player2)
        {

        }
    }
}