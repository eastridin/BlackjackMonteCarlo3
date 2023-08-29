using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BlackjackMonteCarlo2.GUI
{
    public partial class TreeVisualiser : Form
    {
        private List<Common.Node> trees;
        private Dictionary<Game.Moves, int> move;
        private PictureBox treePictureBox;
        private Common.Node currentTree;
        private NodePanel currentTreePanel;
        private List<PlayerTreeDisplayData> players;
        private Game.Game game;
        private System.Windows.Forms.Panel linePanel;
        public event EventHandler InvalidateLines;
        private int currentIndex;
        private int CurrentIndex { 
            get 
            {
                return currentIndex;
            }
            set 
            {
                currentIndex = value;
                indexTextBox.Text = currentIndex.ToString();
            }
        }

        public TreeVisualiser(List<PlayerTreeDisplayData> players, Game.Game game)
        {
            this.players = players;
            this.game = game;
            InitializeComponent();
        }

        private void TreeVisualiserLoad(object sender, EventArgs e)
        {

            this.Text = "Tree Visualiser";
            SetAvailablePlayers();
            playerComboBax.SelectedIndexChanged += (s, ev) => {
                SetAvailableMoves();
                moveComboBox.SelectedIndex = 0; //Select the first move by default
            };
            moveComboBox.SelectedIndexChanged += (s, ev) => SetTreesDisplay();

            playerComboBax.SelectedIndex = 0;
        }

        private void SetAvailablePlayers() //Adds each player that has a tree that can be viewed
        {
            playerComboBax.Items.Clear();
            foreach (var player in players)
            {
                playerComboBax.Items.Add($"Player {game.CurrentState.Players.IndexOf(player.player) + 1}");
            }
        }

        private void SetAvailableMoves() //Adds each move that can be selected from a selected player
        {
            moveComboBox.Items.Clear();
            var selected = players[playerComboBax.SelectedIndex];
            for (int i = 0; i < selected.moves.Count; i++)
            {
                moveComboBox.Items.Add($"Move {i + 1} ({selected.moves[i].Item2.Aggregate((l, r) => l.Value > r.Value ? l : r).Key})");
            }
        }
        
        private void SetTreesDisplay() //Set the info panel and tree for the currently selected tree.
        {
            var selected = players[playerComboBax.SelectedIndex].moves[moveComboBox.SelectedIndex];
            trees = selected.Item1;
            move = selected.Item2;

            this.iterationsCompletedLabel.Text = $"{trees.Count}";

            linePanel = new System.Windows.Forms.Panel(); //Panel which draws the lines that connect the nodes in the tree
            this.linePanel.Location = new System.Drawing.Point(0, 0);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(550, 425);
            this.linePanel.TabIndex = 1;
            this.linePanel.Paint += LinePanelPaint;

            treePictureBox = new PictureBox();
            treePictureBox.Image = new Bitmap(50, 50);
            treePictureBox.Location = new Point(250, 0);

            hitValueLabel.Text = move[Game.Moves.Hit].ToString();
            stickValueLabel.Text = move[Game.Moves.Stick].ToString();
            doubleDownValueLabel.Text = move[Game.Moves.DoubleDown].ToString();
            splitValueLabel.Text = move[Game.Moves.Split].ToString();

            treePanel.Controls.Add(linePanel);

            InvalidateLines += (eventSender, eventArgs) => linePanel.Invalidate(); //Redraw lines when they are invalidated

            try
            {
                CurrentIndex = 0;
                SetCurrentTree(trees[currentIndex]);
            }
            catch { Console.WriteLine("invalid tree index"); }
        }

        private void LinePanelPaint(object sender, PaintEventArgs e)
        {
            
            DrawLines(currentTreePanel, new Point(currentTreePanel.Location.X + (currentTreePanel.Width / 2), currentTreePanel.Location.Y + (currentTreePanel.Height)), e.Graphics);
        }

        private void LeftTreeButtonClick(object sender, EventArgs e) //Move to the next left iteration if it is possible
        {
            if(CurrentIndex - 1 < 0 == false)
            {
                try { SetCurrentTree(trees[--CurrentIndex]); } catch { Console.WriteLine("invalid tree index"); }
            }
        }

        private void RightTreeButtonClick(object sender, EventArgs e) //Move to the next right iteration if it is possible
        {
            if(CurrentIndex + 1 >= trees.Count == false)
            {
                try { SetCurrentTree(trees[++CurrentIndex]); } catch { Console.WriteLine("invalid tree index"); }
            }
        }

        private void DrawTree(NodePanel node, Point pos, Graphics g, int depth = 1, int width = 300) //Recursively draw the tree, halving in width each time the depth increases.
        {
            node.Location = new Point(pos.X, pos.Y);
            treePanel.Controls.Add(node);

            double spacing = node.node.children.Count - 1 <= 0 ? width : width / node.node.children.Count - 1;
            double midpoint = node.node.children.Count / 2;
            double firstTreeX = pos.X;
            for (int i = 0; i < midpoint; i++) //Calculate how much the first node should be from the midpoint
            {
                firstTreeX -= spacing;
            }
            Point previousPoint = new Point((int)firstTreeX, pos.Y);

            for (int i = 0; i < node.children.Count; i++) //Recursively call method, with the new starting point being the previous point.
            {
                DrawTree(node.children[i], new Point(previousPoint.X, previousPoint.Y + 75), g, depth + 1, width /  2);
                previousPoint = new Point(previousPoint.X + (int)spacing, previousPoint.Y);
            }
        }


        private void DrawLines(NodePanel node, Point pos, Graphics g) //Draw lines connecting each enabled node.
        {
            using (Pen p = new Pen(Color.Red))
            using (Font font = new Font("Arial", 10))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                Rectangle r = new Rectangle(pos.X, pos.Y, 50, 50);
                foreach (var child in node.children.Where(x => x.Enabled))
                {
                    DrawLines(child, new Point(child.Location.X + (child.Width / 2), child.Location.Y + (child.Height)), g);
                    g.DrawLine(p, pos, new Point(child.Location.X + (child.Width / 2), child.Location.Y));
                }
            }
        }

        private int GetHeight(Common.Node node) //Gets the current height of the tree.
        {
            int count = 0;
            foreach (var child in node.children)
            {
                count = Math.Max(count, GetHeight(child));
            }

            return count + 1;
        }

        private void TreePanelPaint(object sender, PaintEventArgs e) //Whenever the tree panel is repainted, redraw the tree and the lines.
        {
            if(currentTreePanel != null)
            {
                Console.WriteLine($"height {GetHeight(currentTreePanel.node)}");
                DrawTree(currentTreePanel, new Point(250, 0), e.Graphics);
                linePanel.Invalidate();
                treePanel.Controls.Add(linePanel);
            }
        }

        private void DrawTreeButtonClick(object sender, EventArgs e) //Draw the inputted index tree.
        {
            try { 
                CurrentIndex = Convert.ToInt32(indexTextBox.Text); 
                SetCurrentTree(trees[Convert.ToInt32(indexTextBox.Text)]); 
            } catch { Console.WriteLine("invalid tree index"); } //Prevents user from breaking the program by inputting a value that is out of range.
        }

        private void SetCurrentTree(Common.Node tree) //Set current tree to inputted tree
        {
            //Set current tree to the new tree.
            currentTree = tree;
            currentTreePanel = SetCurrentTreePanel(currentTree);
            moveMadeValueLabel.Text = Common.AI.EvaluateTree(tree).ToString();
            //Reset the tree panel.
            treePanel.Controls.Clear();
            treePanel.Refresh();
        }

        private NodePanel SetCurrentTreePanel(Common.Node tree)
        {
            var newTreePanel = new NodePanel(tree, new Size(50, 50), this);
            foreach (var child in newTreePanel.node.children)
            {
                var newTreePanelChild = SetCurrentTreePanel(child);
                newTreePanel.children.Add(newTreePanelChild);

            }
            return newTreePanel;
        }

        class NodePanel : Panel
        {
            public Common.Node node;
            public List<NodePanel> children;
            public event EventHandler NodeStatesChanged;
            Pen p;
            Font font;
            SolidBrush brush;
            Rectangle r;

            public NodePanel(Common.Node node, Size nodeSize)
            {
                this.node = node;
                this.Size = nodeSize;
                this.Paint += NodePanelPaint;
                this.Click += OnSingleClick;
                this.DoubleClick += OnDoubleClick;

                children = new List<NodePanel>();
                p = new Pen(Color.Blue);
                font = new Font("Arial", 10);
                brush = new SolidBrush(Color.Black);
                r = new Rectangle(0, 0, (int)(nodeSize.Width - p.Width), (int)(nodeSize.Height - p.Width));
            }

            public NodePanel(Common.Node node, Size nodeSize, TreeVisualiser parent) : this(node, nodeSize)
            {
                NodeStatesChanged += (sender, e) => parent.InvalidateLines?.Invoke(this, EventArgs.Empty); //Reset drawn lines so that disabled nodes do not have lines drawn from them.
            }

            private void OnDoubleClick(object sender, EventArgs e) //Open node state visualiser in another window to get more information about a node.
            {
                NodeStateVisualiser nodeStateVisualiser = new NodeStateVisualiser(((NodePanel)sender).node);
                nodeStateVisualiser.ShowDialog();
            }

            private void OnSingleClick(object sender, EventArgs e) //Either hide a node's children or show a nodes children.
            {
                void ChangeNodeState(NodePanel node, bool isEnabled)
                {
                    node.Enabled = node.Visible = isEnabled;
                    foreach (var child in node.children)
                    {
                        ChangeNodeState(child, isEnabled);
                    }
                }
                foreach (var child in children) //Invert the enabled status for each child node from the clicked node.
                {
                    ChangeNodeState(child, child.Enabled ? false : true);
                }
                NodeStatesChanged?.Invoke(this, EventArgs.Empty); //Redraw lines
            }

            public NodePanel(Common.Node node, Size nodeSize, List<NodePanel> children) : this(node, nodeSize)
            {
                this.children = children;
            }

            public NodePanel(Common.Node node, Size nodeSize, Point pos) : this(node, nodeSize)
            {
                this.Location = pos;
            }

            public NodePanel(Common.Node node, Size nodeSize, Point pos, List<NodePanel> children) : this(node, nodeSize, pos)
            {
                this.children = children;
            }

            private void NodePanelPaint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                //Draws the node as a blue rectangle.
                g.DrawRectangle(p, r);
                //Set the data which will be displayed inside the node
                string valueString;
                string timesVisitedString;
                string previousMoveString;
                try { valueString = $"{node.Value}"; } catch { valueString = "Error"; }
                try { timesVisitedString = $"{node.TimesVisited}"; } catch { timesVisitedString = "Error"; }
                try { previousMoveString = $"{node.previousMove}"; } catch { previousMoveString = "Error"; }
                //Draw the data inside the node as a string.
                g.DrawString($"{valueString}/{timesVisitedString}", font, brush, new Point(r.X, r.Y + 10));
                g.DrawString($"{previousMoveString}", font, brush, new Point(r.X, r.Y + 20));
            }


        }
    }
}
