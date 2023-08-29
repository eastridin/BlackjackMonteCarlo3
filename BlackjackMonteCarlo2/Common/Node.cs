using System.Collections.Generic;

namespace BlackjackMonteCarlo2.Common
{
    public class Node
    {
        public Game.Game game;
        public List<Node> children;
        public Game.Moves? previousMove;
        public Node parent;
        private int timesVisited = 0; //private field which is exposed by property
        public int TimesVisited
        {
            get { return timesVisited; }
            set
            {
                if (parent != null)
                {
                    parent.TimesVisited += value - timesVisited; // Backpropogates the additional visit to the node's parent, so when the visits increments it is added all the way up the tree.
                }
                timesVisited = value;
            }
        }
        private double value = 0; //private field which is exposed by property
        public double Value
        {
            get { return value; }
            set
            {
                if (parent != null)
                {
                    parent.Value += value - this.value; //Backpropogates the additional value of this node to its parent, so when a MCTS adds value it is added all the way up the tree.
                }
                this.value = value;
            }
        }
        public Node(Game.Game game) //Creates a new node with no parent
        {
            this.game = game;
            children = new List<Node>();
            parent = null;
        }
        public Node(Game.Game game, Node parent) //Creates a new node which references its parent.
        {
            this.game = game;
            children = new List<Node>();
            this.parent = parent;
        }

        public void AddChild(Node node) //Adds the input node to the current nodes' children.
        {
            node.parent = this;
            this.children.Add(node);
        }

        public void AddChild(Game.Game game) //Creates a new node based upon the game input, then adds the new node to the current nodes' children
        {
            this.children.Add(new Node(game, this));
        }
    }
}
