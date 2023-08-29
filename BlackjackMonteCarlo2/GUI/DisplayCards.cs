using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Linq;

namespace BlackjackMonteCarlo2.GUI
{
    public class DisplayCards
    {
        public class HandPanel : Panel //Creates a custom panel which has a list which contains all the cards in that hand.
        {
            public List<PictureBox> Cards { get; set; } = new List<PictureBox>();
        }

        public List<HandPanel> Hands { get; set; }
        public Panel DisplayPanel { get; set; } //Panel which will contain all the items to be displayed and display them to the user.

        protected DisplayCards(int x, int y)
        {
            DisplayPanel = new Panel()
            {
                BackColor = Color.Transparent,
                Size = new Size(200, 200),
                Location = new Point(x, y)
            };
        }

        public DisplayCards(int x, int y, List<Common.PlayerHand> hands) : this(x, y)
        {
            Hands = new List<HandPanel>();
            for (int i = 0; i < hands.Count; i++) //Adds each input hand to the display.
            {
                Hands.Add(new HandPanel()
                {
                    BackColor = Color.Transparent,
                    Size = new Size(0, 0),
                    Location = new Point(0 + (i * 60), 0)
                });
                foreach (var card in hands[i].Cards)
                {
                    AddCard(card, i);
                }
                DisplayPanel.Controls.Add(Hands[i]);
            }
        }

        public DisplayCards(int x, int y, List<Common.DealerHand> hands) : this(x, y)
        {
            Hands = new List<HandPanel>();
            for (int i = 0; i < hands.Count; i++)
            {
                Hands.Add(new HandPanel()
                {
                    BackColor = Color.Transparent,
                    Size = new Size(0, 0),
                    Location = new Point(0, 0 + (i * 15))
                });
                foreach (var card in hands[i].Cards)
                {
                    AddCard(card, i);
                }
                DisplayPanel.Controls.Add(Hands[i]);
            }
        }

        protected void SetDisplay() //Removes all hands from the display then adds a fresh new hand.
        {
            Hands = new List<HandPanel>();
            AddHand();
        }

        public virtual void AddHand() //Adds an empty hand to the hands list.
        {
            Hands.Add(new HandPanel()
            {
                BackColor = Color.Transparent,
                Size = new Size(0, 0),
                Location = new Point(0 + (60 * Hands.Count), 0)
            });
            DisplayPanel.Controls.Add(Hands.Last());
            Hands.Last().BringToFront();
        }

        public virtual void AddHand(Common.Hand hand) //Adds a specified hand to the hands list.
        {
            AddHand();
            foreach (var card in hand.Cards)
            {
                AddCard(card, Hands.IndexOf(Hands.Last()));
            }
        }

        public void ResetDisplay() //Removes all the displayed hands from the displaypanel then sets the display again.
        {
            foreach(var hand in Hands)
            {
                DisplayPanel.Controls.Remove(hand);
            }
            SetDisplay();
        }
        protected virtual Bitmap GetCardBitmap(Common.Card card) //Retrieves relevant card image from resource file and returns it as a bitmap.
        {
            ResourceManager rm = new ResourceManager("BlackjackMonteCarlo2.GUI.Cards", Assembly.GetExecutingAssembly());
            return (Bitmap)rm.GetObject($"{card.rank}{card.suit}");
        }
        protected PictureBox AddCardImage(Bitmap cardBitmap, int handIndex) //Creates a card picturebox using a given bitmap and adds that card to the chosen hand.
        {
            var card = new PictureBox()
            {
                Image = cardBitmap,
                Size = new Size(55, 75),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(0, (Hands[handIndex].Cards.Count) * 15)
            };
            Hands[handIndex].Size = new Size(55, 75 + ((Hands[handIndex].Cards.Count) * 15));
            Hands[handIndex].Cards.Add(card);
            Hands[handIndex].Controls.Add(card);
            card.BringToFront();
            return card;
        }
        public void AddCard(Common.Card card, int handIndex) //Adds an input card to the chosen hand.
        {
            AddCardImage(GetCardBitmap(card), handIndex);
        }

    }

    public class PlayerDisplay : DisplayCards
    {
        #region Properties
        public Common.PlayerInfo Player { get; set; } //Reference to the base player, used so it can link data between the actual game logic and the UI
        public int Bet { get; set; }
        public PictureBox Circle { get; set; } //Circle which represents a player.
        public Label BalanceLabel { get; set; }
        #endregion

        #region Constructors
        public PlayerDisplay(Common.PlayerInfo player, int x, int y, int bet = 0) : base(x, y + 23)
        {
            Player = player;
            Bet = bet;
            Circle = new PictureBox()
            {
                Image = new Bitmap(GUI.UI.circle),
                Size = new Size(88, 88),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Location = new Point(0, 0)
            };
            BalanceLabel = new Label()
            {
                Location = new Point(x, y)
            };
            Player.BalanceChanged += (sender, e) => BalanceLabel.Text = $"Balance: {((Common.PlayerInfo)sender).Balance}"; //Whenever the player's balance changes, update the balance label to that new balance.
            DisplayPanel.Controls.Add(Circle);
            SetDisplay();
        }
        #endregion

        #region Methods
        public override void AddHand()
        {
            Hands.Add(new HandPanel()
            {
                BackColor = Color.Transparent,
                Size = new Size(0, 0),
                Location = new Point(Circle.Location.X + (60 * Hands.Count), Circle.Location.Y)
            });
            DisplayPanel.Controls.Add(Hands.Last());
            Hands.Last().BringToFront();
        }

        public void SplitCards() //Splits the cards in the display.
        {
            AddHand(); //Adds a new empty hand panel
            var lastCard = Hands[0].Cards.Last();
            Hands[0].Cards.Remove(lastCard); //Remove one of the cards that is split from the original hand
            Hands[0].Controls.Remove(lastCard);
            AddCardImage(new Bitmap(lastCard.Image), 1); //Add this card that was removed to the new empty hand.
        }
        #endregion
    }

    public class DealerDisplay : DisplayCards
    {
        public DealerDisplay(int x, int y) : base(x, y)
        {
            SetDisplay();
        }

        protected override Bitmap GetCardBitmap(Common.Card card)
        {
            Bitmap cardBitmap;
            //Checks if the card to display is the first card. if it is, it displays a hidden card instead.
            if (Hands[0].Cards.Count > 0)
            {
                cardBitmap = base.GetCardBitmap(card);
            }
            else
            {
                cardBitmap = (Bitmap)new ResourceManager("BlackjackMonteCarlo2.GUI.Cards", Assembly.GetExecutingAssembly()).GetObject("Emerald");
            }
            return cardBitmap;
        }

        public void ShowHiddenCard(Game.Game game) //Reveals the hidden card.
        {
            Hands[0].Cards[0].Image = GetCardBitmap(game.CurrentState.DealerHand.Cards[0]);
        }
    }

}
