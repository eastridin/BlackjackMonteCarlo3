using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackMonteCarlo2.Common
{
    public enum HandResult
    {
        User,
        Dealer,
        Draw,
        Blackjack
    }

    [Serializable]
    public abstract class Hand
    {
        public List<Card> Cards { get; private set; }
        public List<int> Values { get; private set; } //List of values as an ace can have a value of 1 or 11.
        public Game.Game Game { get; set; }

        public Hand() //This is used solely for deserializing the json file back into an object.
        {
            Cards = new List<Card>();
            Values = new List<int>();
        }

        public Hand(Game.Game sender)
        {
            Game = sender;
        }

        public void SetHand() //Set a new hand by adding two cards to it from the deck
        {
            Cards = new List<Card>();
            AddCard();
            AddCard();
            Values = GetHandValues(Cards);
        }

        public void SetHand(List<Card> cards) //Set a hand in which you already know what cards it will contain.
        {
            Cards = cards;
            Values = GetHandValues(Cards);
        }

        public virtual void AddCard() //Add a card to the hand from the deck from the Hand's game parent.
        {
            Cards.Add(Game.GetCard());
            Values = GetHandValues(Cards); 
        }

        protected List<int> GetHandValues(List<Card> hand) //Finds the overall value of the hand.
        {
            List<int> total = new List<int>() { 0 };

            var values = hand.Select(x => x.value).ToList(); //Projects the cards in the hand to a new list containing each card's values.
            foreach (var value in values)
            {
                if (value.Count > 1) //Checks if the card has more than one value (Ace can have a value of 1 or 11)
                {
                    List<int> tempTotal = new List<int>();
                    foreach (var subValue in value) //Gets every potential value of the card.
                    {
                        foreach (var item in total)
                        {
                            if (!tempTotal.Contains(item + subValue)) //If the new potential value is not in the list of potential values, it is added to the list.
                            {
                                tempTotal.Add(item + subValue);
                            }
                        }
                    }
                    total = tempTotal;
                }
                else //If it has one value it can simply be added to all the potential values.
                {
                    for (int i = 0; i < total.Count; i++)
                    {
                        total[i] += value.First();
                    }
                }
            }
            return total;

        }
    }

    [Serializable]
    public class DealerHand : Hand
    {
        public DealerHand() : base() //This is used solely for deserializing the json file back into an object.
        {

        }

        public DealerHand(Game.Game sender) : base(sender)
        {

        }

        public override void AddCard()
        {
            base.AddCard();
            Game.DealerCardIsAdded(this, Cards.Last());
        }
    }

    [Serializable]
    public class PlayerHand : Hand
    {
        public int Bet { get; set; }
        public HandResult Result { get; set; }
        public bool SplitChild { get; private set; }
        public bool Played { get; set; }
        public Common.Player Parent { get; set; }
        public int userTurns = 0;

        public PlayerHand() //This is used solely for deserializing the json file back into an object.
        {

        }

        public PlayerHand(Game.Game sender, Common.Player parent, int bet) : base(sender)
        {
            Parent = parent;
            Bet = bet;
            SplitChild = false;
            Played = false;
        }

        public PlayerHand(Game.Game sender, Common.Player parent, int bet, bool splitChild) : this(sender, parent, bet)
        {
            SplitChild = splitChild;
        }

        public override void AddCard()
        {
            base.AddCard();
            Game.PlayerCardIsAdded(Parent, this, Cards.Last());
        }
    }
}
