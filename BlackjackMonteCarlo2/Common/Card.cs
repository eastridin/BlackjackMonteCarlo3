using System;
using System.Collections.Generic;

namespace BlackjackMonteCarlo2.Common
{
    [Serializable]
    public struct Card
    {
        public readonly Suit suit;
        public readonly Rank rank;
        public readonly List<int> value;

        public enum Suit
        {
            Clubs,
            Diamonds,
            Spades,
            Hearts
        }

        public enum Rank
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
        public enum Value
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack = 10,
            Queen = 10,
            King = 10
        }

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
            value = new List<int>
            {
                (int)Enum.Parse(typeof(Value), Enum.GetName(typeof(Rank), rank))
            };
            if (rank == Rank.Ace)
            {
                value.Add(11);
            }
        }
    }
}
