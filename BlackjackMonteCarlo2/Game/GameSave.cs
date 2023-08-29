using System;
using System.Collections.Generic;

namespace BlackjackMonteCarlo2.Game
{
    public class GameSave
    {
        #region Setting fields
        public List<Common.Card> deck;
        public bool userTurnsEnded = false;
        public bool gameFinished = false;
        public bool gameStarted = false;
        #endregion

        #region Setting properties
        public Common.DealerHand DealerHand { get; set; }
        public List<Common.Player> Players { get; private set; } = new List<Common.Player>(); //the players and such still reference the parent game class, rendering this whole class kinda useless
        #endregion

        #region Constructors
        public GameSave()
        {

        }

        public GameSave(GameState state)
        {
            deck = state.deck;
            userTurnsEnded = state.userTurnsEnded;
            gameFinished = state.gameFinished;
            gameStarted = state.gameStarted;
            DealerHand = new Common.DealerHand(null);

            var dealerCards = new List<Common.Card>(); //This is p much repeated from deepcopy
            dealerCards.AddRange(state.DealerHand.Cards);
            DealerHand.SetHand(dealerCards);

            foreach (var player in state.Players) //This is coppied from the deepcopy method pretty much, wasteful code much????
            {
                List<Common.PlayerHand> hands = new List<Common.PlayerHand>();
                var newPlayerInfo = new Common.PlayerInfo(player.Info.IsUser, player.Info.Balance);
                dynamic newPlayer = Activator.CreateInstance(player.GetType(), new object[] { null, hands, player.Bet, newPlayerInfo });
                foreach (var hand in player.PlayerHands)
                {
                    var cards = new List<Common.Card>();
                    hand.Cards.ForEach(x => cards.Add(x));
                    var newHand = new Common.PlayerHand(null, null, hand.Bet);
                    newHand.SetHand(cards);
                    newHand.Played = hand.Played;
                    newHand.userTurns = hand.userTurns;
                    hands.Add(newHand);
                }
                Players.Add(newPlayer);
            }
        }
        #endregion
    }
}
