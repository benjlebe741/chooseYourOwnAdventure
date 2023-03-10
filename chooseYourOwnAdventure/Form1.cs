using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Threading;
using System.IO;
using chooseYourOwnAdventure.Properties;

// CHOOSE YOUR OWN ADVENTURE GAME
// Ben Leberg
// Started:         March, 10, 2023
// Submitted:       March, __, 2023

namespace chooseYourOwnAdventure
{
    public partial class Form1 : Form
    {
        #region Global Variables
        //keeping track of what page you are on
        int currentPage = 1;
        //list to look at all output labels
        List<Label> allOutputs = new List<Label>();
        #endregion

        #region All Page Info!
        // All information for each page
        Page[] pageIndex =
        {
     // new Page(new string[] {Header-text, Option-Texts}, new int[] {Take-me-to-page __ based-on-the-option-#}, Image-To-Display })
        new Page(new string[] { "Thank You For Playing!", "", "" }, new int[] { }, Resources.deepBrush),
        new Page(new string[] { "You are lost in a forest", "North", "South" }, new int[] { 2, 3 }, Resources.deepBrush),
        new Page(new string[] { "You come to a lake..@\nDo you want to take a drink?", "Yes", "No" }, new int[] { 4, 5 }, Resources.forestLake),
        new Page(new string[] { "You fall in a pit and die.@\nPlay again?", "Yes", "No" }, new int[] { 1, 0 }, Resources.forestLake),
        new Page(new string[] {  "The water is stagnent, you die of Cholera@\nPlay Again?", "Yes", "No" }, new int[] { 1, 0 }, Resources.deepBrush),
        new Page(new string[] { "A horse swims by, do you try and ride it?", "Yes", "No" }, new int[] { 6, 7 }, Resources.forestLake),
        new Page(new string[] { "You tame the horse and ride to safety! YAY!@\nPlay Again?", "Yes", "No" }, new int[] { 1, 0 }, Resources.forestLake),
        new Page(new string[] { "The horse walks past. You die of lonilyness.@\nPlay Again?", "Yes", "No" }, new int[] { 1, 0 }, Resources.deepBrush),
        };
        #endregion

        #region Initialize Components!
        public Form1()
        {
            InitializeComponent();
            //fill the label list 
            allOutputs = new List<Label>()
        {
        outputLabel,
        option1Label,
        option2Label,
        option3Label,
        option4Label
        };
            //start the game off on page 1
            createPage(1);
        }
        #endregion

        #region CREATE PAGE
        void createPage(int pageNumber)
        {
            //update current page and current image
            currentPage = pageNumber;
            imageBox.Image = pageIndex[pageNumber].image;

            //check to see what outputs are visible on each page
            for (int x = 0; x < allOutputs.Count - 1; x++)
            {
                if (pageIndex[pageNumber].pathOptions.Length >= (x + 1))
                { buttonLabelToggle(x, true); }
                else
                { buttonLabelToggle(x, false); }
            }

            //print each textbox, reset all textboxes and then fill them out one letter at a time! 
            //reset all texts
            foreach (Label label in allOutputs)
            {
                label.Text = "";
                wait(1);
            }
            //fill out each letter
            for (int x = 0; x <= pageIndex[pageNumber].outputLabelTexts.Length - 1; x++)
            {
                foreach (char letter in pageIndex[pageNumber].outputLabelTexts[x])
                {
                    //any special letters do special things!
                    switch ($"{letter}")
                    {
                        case "@":
                            wait(1000);
                            break;
                        //otherwise print the letter!
                        default:
                            allOutputs[x].Text += letter;
                            wait(1);
                            break;
                    }
                }
            }

            //any special actions on specifc pages
            //page 0 ends the game
            if (currentPage == 0)
            {
                wait(2000);
                Application.Exit();
            }
        }
        #endregion

        #region Engable Or Disable Lables
        //function enabling or disabling lables (this will depend on what options the page gives the player) 
        void buttonLabelToggle(int x, bool trueOrFalse)
        {
            allOutputs[x + 1].Enabled = trueOrFalse;
            allOutputs[x + 1].Visible = trueOrFalse;
        }
        #endregion

        #region Wait Function
        //wait function
        void wait(int waitTime)
        {
            Refresh();
            Thread.Sleep(waitTime);
        }
        #endregion

        #region Label Clicks
        //inputs from player
        private void option1Label_Click(object sender, EventArgs e)
        {
            createPage(pageIndex[currentPage].pathOptions[0]);
        }

        private void option2Label_Click(object sender, EventArgs e)
        {
            createPage(pageIndex[currentPage].pathOptions[1]);
        }

        private void option3Label_Click(object sender, EventArgs e)
        {
            createPage(pageIndex[currentPage].pathOptions[2]);
        }

        private void option4Label_Click(object sender, EventArgs e)
        {
            createPage(pageIndex[currentPage].pathOptions[3]);
        }
        #endregion
    }

}

