using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaWarChallenge
{
    public class Player
    {
        public List<Card> _Hand { get; set; }

        public Player(List<Card> hand)
        {
            _Hand = hand;
        }
    }
}