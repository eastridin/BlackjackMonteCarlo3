using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace BlackjackMonteCarlo2.GUI
{
    public partial class HelpWindow : Form
    {
        Dictionary<TreeNode, string> treeViewPairs;
        ResourceManager rm;
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void HelpWindow_Load(object sender, EventArgs e)
        {
            this.Text = "Help";

            treeViewPairs = new Dictionary<TreeNode, string>();
            rm = new ResourceManager("BlackjackMonteCarlo2.GUI.HelpWindow", Assembly.GetExecutingAssembly()); //Used to retreive data from resource file.

            //Set the nodes in the tree view for different topics to be covered
            directoryTreeView.BeginUpdate();
            directoryTreeView.Nodes.Add("Introduction", "Introduction");

            directoryTreeView.Nodes.Add("UI", "User Interface");
            directoryTreeView.Nodes["UI"].Nodes.Add("mainmenu", "Main Menu");
            directoryTreeView.Nodes["UI"].Nodes.Add("gamewindow", "Game Interface");
            directoryTreeView.Nodes["UI"].Nodes.Add("settings", "Settings Menu");
            directoryTreeView.Nodes["UI"].Nodes.Add("tree", "Tree Visualiser");
            directoryTreeView.Nodes["UI"].Nodes.Add("node", "Node State Visualiser");

            directoryTreeView.Nodes.Add("Blackjack", "Blackjack");
            directoryTreeView.Nodes["Blackjack"].Nodes.Add("Rules", "Rules");
            directoryTreeView.EndUpdate();


            //set treeviewpairs
            treeViewPairs.Add(directoryTreeView.Nodes["Introduction"], (string)rm.GetObject("introduction"));
            treeViewPairs.Add(directoryTreeView.Nodes["UI"].Nodes["mainmenu"], (string)rm.GetObject("mainmenu"));
            treeViewPairs.Add(directoryTreeView.Nodes["UI"].Nodes["gamewindow"], (string)rm.GetObject("gamewindow"));
            treeViewPairs.Add(directoryTreeView.Nodes["UI"].Nodes["settings"], (string)rm.GetObject("settings"));
            treeViewPairs.Add(directoryTreeView.Nodes["UI"].Nodes["tree"], (string)rm.GetObject("tree"));
            treeViewPairs.Add(directoryTreeView.Nodes["UI"].Nodes["node"], (string)rm.GetObject("node"));
            treeViewPairs.Add(directoryTreeView.Nodes["Blackjack"].Nodes["Rules"], (string)rm.GetObject("blackjackRules"));
        }

        private void DirectoryTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewPairs.TryGetValue(e.Node, out string value))
            {
                helpDisplay.DocumentText = value; //If there is a help file relating to the selected directory on the left panel, its HTML is loaded into the help display.
            }
        }
    }
}
