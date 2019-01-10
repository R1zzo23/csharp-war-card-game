using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaWarChallenge
{
    public class Card
    {
        public int _Value { get; set; }
        public string _Name { get; set; }
        public string _Suit { get; set; }

        public Card (int value, string name, string suit)
        {
            _Value = value;
            _Name = name;
            _Suit = suit;
        }
    }
}