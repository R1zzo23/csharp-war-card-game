using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaWarChallenge
{
    public class Deck
    {
        public List<Card> _Cards { get; set; }
        public Random random = new Random();

        public Deck()
        {
            _Cards = new List<Card>();
        }

        public void CreateDeck()
        {
            // create cards
            for (int i = 2; i < 15; i++)
            {
                _Cards.Add(new Card(i, "", "Hearts"));
                _Cards.Add(new Card(i, "", "Diamonds"));
                _Cards.Add(new Card(i, "", "Spades"));
                _Cards.Add(new Card(i, "", "Clubs"));
            }
            foreach (Card card in _Cards)
            {
                if (card._Value == 14) card._Name = "Ace";
                else if (card._Value == 13) card._Name = "King";
                else if (card._Value == 12) card._Name = "Queen";
                else if (card._Value == 11) card._Name = "Jack";
                else card._Name = card._Value.ToString();
            }
        }

        public Card DealCard(Player player)
        {
            Card nextCard = _Cards.ElementAt(random.Next(0, _Cards.Count));
            player._Hand.Add(nextCard);
            _Cards.Remove(nextCard);

            return nextCard;
        }
    }

}