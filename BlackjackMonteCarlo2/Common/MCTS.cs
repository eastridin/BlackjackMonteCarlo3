using System;
using System.Collections.Generic;

namespace BlackjackMonteCarlo2.Common
{
    public static class MCTS
    {
        public static void Run(Node node, int maxIterations, double uctConstant) //Runs a Monte Carlo Tree Search with the selected parameters.
        {
            for (int i = 0; i < maxIterations; i++)
            {
                var nodeToVisit = Select(node, uctConstant);
                if (node.TimesVisited != 0) //If the selected node has been visited before, expand the node with all the potential moves from that point then select the child node to Rollout from.
                {
                    Expand(nodeToVisit);
                    nodeToVisit = Select(node, uctConstant); //Reselect the node to visit after a potential expansion.
                }
                nodeToVisit.Value += Rollout(nodeToVisit);
                nodeToVisit.TimesVisited += 1;
            }
        }

        private static Node Select(Node node, double uctConstant) //Selects which node to explore based upon the upper confidence bound 1 applied to trees.
        {
            Node nodeToVisit = null;
            if (IsLeaf(node))
            {
                return node; //If a leaf node has been found, terminate the recursive selection process and return a node.
            }
            else
            {
                foreach (var child in node.children)
                {
                    if (nodeToVisit != null)
                    {
                        if (GetUctValue(child, uctConstant) > GetUctValue(nodeToVisit, uctConstant)) //Compares the UCT value of each child from the current node to find the greatest value so that node can be chosen.
                        {
                            nodeToVisit = child;
                        }
                    }
                    else
                    {
                        nodeToVisit = child; //Initially sets the node to visit if one hasn't been selected yet, so it can be compared to other nodes.
                    }
                }
                return Select(nodeToVisit, uctConstant); //Recursively return node to visit so that the process repeats until a leaf node has been found.
            }
        }

        private static void Expand(Node node, int? children = null)
        {
            List<Game.Moves> moves = Game.Game.GetAvailableMoves(node.game.CurrentState.Players[0]);
            if (children == null)
            {
                //children = methods.Count;
                foreach (var move in moves)
                {
                    Game.Game oldGame = node.game.DeepCopy(true, false);
                    oldGame.MakeMove(move);
                    node.AddChild(new Node(oldGame)
                    {
                        previousMove = move
                    });
                }
            }
            else
            {
                for (int i = 0; i < children; i++)
                {
                    Game.Moves move = moves[RandomNumGen.Next(0, moves.Count)];
                    Game.Game oldGame = node.game.DeepCopy(true, false);
                    oldGame.MakeMove(move);
                    node.AddChild(new Node(oldGame)
                    {
                        previousMove = move
                    });
                }
            }
        }

        private static double Rollout(Node node) //Randomly play out moves from the input game state, then return the value of the game once it has been completed.
        {
            if (node.game.CurrentState.gameFinished)
            {
                return GetPlayerValue(node.game.CurrentState.Players[0]); //Once game has been fully played out, return the value of the game's state.
            }
            else
            {
                //Create a copy of the current state, make a random move from the potential moves, then recursively call the rollout to continue this process until the game has completed.
                Game.Game newGame = node.game.DeepCopy(true, false);
                List<Game.Moves> moves = Game.Game.GetAvailableMoves(newGame.CurrentState.CurrentPlayer);
                newGame.MakeMove(moves[RandomNumGen.Next(0, moves.Count)]);

                return Rollout(new Node(newGame));
            }
        }

        private static double GetUctValue(Node node, double UCTConstant) //Gets UCT value of currrent player using the input UCT constant.
        {
            if (node.TimesVisited == 0) //If it has not yet been visited, should be infinitely high.
            {
                return double.PositiveInfinity;
            }
            else
            {
                return (node.Value / node.TimesVisited) + (UCTConstant * Math.Sqrt(Math.Log(node.parent.TimesVisited) / node.TimesVisited)); //UCT formula
            }
        }

        private static bool IsLeaf(Node node) //Checks if a node is a leaf
        {
            return node.children.Count > 0 ? false : true;
        }

        private static double GetPlayerValue(Player player)
        {
            //Runs through how many overall winnings the player got then adjusts the value accordingly, additional value for each winning halves each time.
            if (player.Winnings < 0)
            {
                double x = -1;
                double y = player.Winnings;
                double value = 0;
                while (y < 0)
                {
                    value += x;
                    y += player.Bet;
                    x /= 2;
                }
                return value; //Returns this if a loss
            }
            else if (player.Winnings > 0)
            {
                double x = 1;
                double y = player.Winnings;
                double value = 0;
                while (y > 0)
                {
                    value += x;
                    y -= player.Bet;
                    x /= 2;
                }
                return value; //Returns this if a win
            }
            return 0; //Returns this if a draw
        }
    }
}
