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
using System.IO;
using chooseYourOwnAdventure.Properties;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

// CHOOSE YOUR OWN ADVENTURE GAME
// Ben Leberg
// Started:         March, 10, 2023
// Submitted:       March, 27, 2023

namespace chooseYourOwnAdventure
{
    public partial class Form1 : Form
    {
        #region Global Variables
        //Current Page and "Hearts":
        int currentPage = 1;
        int playerHealth = 3;

        //random generator:
        Random randGen = new Random();

        //Lists: Storing all labels and Heart images
        List<Label> allOutputs = new List<Label>();
        List<PictureBox> allHearts = new List<PictureBox>();

        //Sound Players: 
        SoundPlayer Sound1 = new SoundPlayer(Resources.Sound1);
        SoundPlayer Sound2 = new SoundPlayer(Resources.Sound2);
        #endregion

        #region All Page Info!
        //Stores all pages:
        Page[] pageIndex =
        {
            //Each page is laid out as follows, with strings for text and integers for the pages that you will be taken to:
            //new Page(new string[] {outputLabel Text, option#Label Texts}, new int[] {option#Label Click takes you to page __}, Image to display)
            #region Page0 
            new Page(new string[] { "CURRENTLY EMPTY", }, new int[] {}, Resources.Page0),
#endregion
            #region Page1
            new Page(new string[] { "SOUPER CEREAL SIMULATOR@", "BEGIN@", "EXIT@" }, new int[] {2,0}, Resources.Page1),
#endregion
            #region Page2
            new Page(new string[] { "<<<<<<<<<<>>>Welcome to Souper Cereal Simulator!@","Add MILK@","Add CEREAL" }, new int[] {3,4}, Resources.Page2),
#endregion
            #region Page3
            new Page(new string[] { "But there is no cereal!!?@","Add Cereal?","Refuse." }, new int[] {5,6}, Resources.Page3),
#endregion
            #region Page4
            new Page(new string[] {
                "You dumped out more than necessary...@@%Adding any milk at all would overflow onto your fine silk tablecloth due to the absolutely unnecessary amount of cereal in this bowl.@",
                "Add Milk@",
                "Walk away and take a second to think about things"
            }, new int[] {7,8}, Resources.Page4),
#endregion
            #region Page5
            new Page(new string[] {
            "Your cereal looks appetizing..@ But something is not complete here.@@%The trisection of the ingredients of cereal only complete themselves when you really FEEL cereal.@",
            "You have done it. Feel acceptance; the metaphorical hand outstretched to you.@",
            "This is all you have. Feel loved; walk along a path you wish had been there before.@",
            "Feel ambitious; you have built a bridge to something beyond real.@",
            "Impossibly small and impossibly big@%Feel inadequate; the world shrinks itself around you."

            }, new int[] {9,10,11,12}, Resources.Page5),
#endregion
            #region Page6
            new Page(new string[] {
                "Your bowl of milk disappoints you...@@ after some time the duck you stole begins to swim circles in the only liquid it can see.@ There is now a duck in your cereal.@@",
                "Eat anyway@",
                "Eat around it"
            }, new int[] {13,14}, Resources.Page6),
#endregion
            #region Page7
            new Page(new string[] {
                "Wh- Why??@ There was no room for the milk??@ THERE WAS NO ROOM FOR THE MILK--@@%" +
                "A TIDLE WAVE- A TSUNAMI- NOTHING CAN COMPARE TO THE QUANTITY OF MILK WHICH LASHES ITS FEARSOM MAGNITUDE AT ITS GOD WHO CHOSE TO POUR IT ONTO A CEREAL ROCK-@@%" +
                "The blast knocks you into the back wall of your kitchen- as you try to recover against the tide your body is contorted back< and forth< against the lactose waves.@@%" +
                "Swept into the undertow you find your lungs filling- before you can cry milky screams you pass out...@",
                "Surrender your last breaths@",
                "Wake up"
            }, new int[] {0,15}, Resources.Page7),
#endregion
            #region Page8
            new Page(new string[] {
                "Its been a hard life..@@%" +
                "after your partner of seven years left you due to those golden days fading and the reality of this commitment setting in;@@@%" +
                "the only thing you have which is certain to forever be yours is your lifetime supply of \"Yummy Tum Morning Flakes\".@@@%" +
                "The duck you stole from the river is less and less happy with its new home..@ your pillows are not happy with the amount of holes a duck chewed in them...@@%" +
                "And you can't even make dinner without failing to make enough space for the milk.@@%" +
                "You never made enough space for anything else besides those flakes.@@@%" +
                "Its been a while.@ You aren't going to see them again...@ you aren't going to get them back.@@ ",
                "Begin to eat the cereal",
                "Step away from the cereal"
            }, new int[] {16,17}, Resources.Page8),
        #endregion
            #region Page9
        new Page(new string[] {
            "The hand pulls you toward the light.@ Immortality is yours!@@% " +
            "For as long as you eat Yummy Tum Morning Flakes you will be as the wind. Ever present among nature as a physical praised entity.@@@%" +
            "Your interactions have affect on the world:@ You@ have@ correctly@ made@ cereal.@@",
            "Play again",
            "Exit"
            }, new int[] {2,0}, Resources.Page9),
        
#endregion
            #region Page10
new Page(new string[] {
                "Doing the work to mend your heart; your cereal tastes like care and snap and excitement;@@%" +
    "The milk is cool and thin and light.. the flavor rushes through you like a refreshing shower. You are more awake now,@ you have made cereal.@@",
                "Play Again",
                "Exit"
            }, new int[] {2,0}, Resources.Page10),
        #endregion
            #region Page11
        new Page(new string[] {
                "Your ego is heightened,@ your spirits are lifted;@ the cereal tastes proud and looks like it would totally try to take someone in a fight;@" +
            " this massive amount of concentrated ambition causes you to impulsively break the bowl of cereal over your head.@@%You certainly made cereal.",
                "Play Again",
                "Exit"
            }, new int[] {2,0}, Resources.Page11),
        
#endregion
            #region Page12
new Page(new string[] {
                "What separates you from the flakes?@ One of many identical pieces,@ equally interchangeable.@@ You have made cereal,@ but not correctly.@ You cannot sense it's taste and pay no attention to its texture.@@%" +
    "All your progress passes you by as you leave your cares behind.@",
                "Play Again@",
                "Exit"
            }, new int[] { 2, 0 }, Resources.Page12),
        #endregion
            #region Page13
        new Page(new string[] {
                "You have eaten the duck.@@ Its soul heals your weakened body,@ but its teeth much< munch< munch< and you die.@",
                "Play Again@",
                "Exit"
            }, new int[] { 2, 0 }, Resources.Page13),
#endregion
            #region Page14
        new Page(new string[] {
                "The duck blesses you for passing its test of benevolence.@ It spits out its dentures and transforms into the spiritual embodiment of milk.@ Thats probably why its still around when you forgot what ducks eat and drink....@",
                "Play Again@",
                "Exit"
            }, new int[] { 2, 0 }, Resources.Page14),
#endregion
            #region Page15
        new Page(new string[] {
                "An unholy light fills the room...@ A chorus of birds becomes an orchestra of clouds and calm blue beyond...@ Suddenly the walls of your house no longer apply...@@%" +
            "A strange figure appears in front of you..@ You suddenly feel stronger>@%" +
            "Their deep voice fills the heavens...@@ \"Welcome to souper cereal simulator :)\"@",
                "Add Cereal@",
                "Add Milk"
            }, new int[] { 18, 19 }, Resources.Page15),
#endregion
            #region Page16
        new Page(new string[] {
                "Your teeth slowly crumble after each bite of cereal;<@ the compact rocklike structure breaks you down as you try to break down it.@",
                "Break the glass on emergency dentures case@",
                "\"GOSH GOLLIE MA TOOTTHS\""
            }, new int[] {20, 21}, Resources.Page16),
            #endregion
            #region Page17
        new Page(new string[] {
            "The duck has bitten holes in your mothers silk tablecloth...@ You cannot picture how the kitchen looked when they were there.@ You can cry and pout and wail and scream but you cannot take back the old world.@@%" +
            "Your suffering breaks your heart(s)@<@<",
            "Leave",
            "Choose Forgiveness"
        }, new int[] {22, 23}, Resources.Page17),

            #endregion
            #region Page18
        new Page(new string[] {
            ">A> >P>e>r>f>e>c>t> tumble of each uncracked flaky crumb;@ no breakfast commercial could replicate its simplicity--@ elegant crisp wings flutter for no consumer audience or target age group.@@%" +
            "This is beyond the modern understanding of snacks;@ countless eras have been lost with the people who belonged to them only present in their sacrifices and contributions to a modern society.@ All of humanities contributions could have lead to this very moment.@ A voice reaches out to you.@ Follow?@",
            "Yes",
            "No"
        }, new int[] {24, 25}, Resources.Page18),

            #endregion
            #region Page19
        new Page(new string[] {
            "Milk was destined to be this way--@ its silky smooth contribution to the bowl highlights every curve, each crease and crevasse.@ Odin says that anyone who adds milk first deserves an unhappy ending;@@%" +
            "Just as lucifer fell from above so hath the milk as Odin'th's words curthed I.@ The bounds of the realm fall to the depths of the darkest hole, your milk runneth dry and the bowl transforms into a representation of bad stuff.@ Odin punches you a lot.<@<@<<<<<<<<%",
            "Play Again@",
            "Exit"
        }, new int[] {2, 0}, Resources.Page19),

            #endregion
            #region Page20
        new Page(new string[] {
            "As the bones in your mouth crumble you scramble within the dentures case--@ But the dentures have gone; they have left you too...@" +
            "as you continue to shovel the cereal into your gums you scramble to find anything to protect yourself--@@%" +
            "Where could your dentures have gone?@ You refuse to acknowledge the pain, but you cannot help choke and fall to the floor...@ The last thing your eyes can make out are the wholes in your mothers silk cloth..@< they do look awfully tooth..@<toothy..@<",
            "Play Again@",
            "Exit"
        }, new int[] {2, 0}, Resources.Page20),

            #endregion
            #region Page21
        new Page(new string[] {
            "You acknowledge the pain.@< You acknowledge the choices you have made have hurt you.< The world is the same but the pain is real;< the world feels more real,<@ not to YOU, but to HIM.@<",
            "Play Again@",
            "Exit"
        }, new int[] {2, 0}, Resources.Page21),

            #endregion
            #region Page22
        new Page(new string[] {
            "You abandon the game.@ There is no replaying this time.@",
            "Exit"
        }, new int[] {0}, Resources.Page22),

            #endregion
            #region Page23
        new Page(new string[] {
            "The duck clacks on in the background...@ the pond lays its head without its friend... they are gone... and you will move on.@",
            "Play Again@",
            "Exit"
        }, new int[] {2, 0}, Resources.Page23),

            #endregion
            #region Page24
        new Page(new string[] {
            "The hierarchy bows to you.@ A king of this world, your stats are maxed out;@ your health grander than any other beings; your power maxed.@ You have beaten the game.@ He can live on a true deity in the eyes of all that enjoy flaky flake flakes. You can exit the program or play again." +
            "@@%The only power holding YOU is a denial of artificial choices.@ Thank you for playing.@ You will not continue this run.@",
            "Exit"
        }, new int[] {0}, Resources.Page24),

            #endregion
            #region Page25
        new Page(new string[] {
            "You have chosen not to continue your journey.@ Would rewarding you with choice be a reward or a punishment?@ Is exploration still free when an end can only be reached through it?@ In an infinite life with many endings and beginnings do you really feel the way you impact anyone?" +
            "@@%There is always a way out, and always a way through.",
            "Play Again@",
            "Exit"
        }, new int[] {2, 0}, Resources.Page25),

            #endregion
            #region Page26
        new Page(new string[] {
            "You added an appropriate amount of cereal to an appropriate amount of bowl.@ Odin smiles slightly from behind my computer screen as the cereal being morally correct satisfies her. she criticizes the talking people around me and informs them about their misdoings, what should I do now?@",
            "Continue working on my computer science project@",
            "Have you seen\"ratatouille 2 the rattening\"? Its a hit!"
        }, new int[] {27, 28}, Resources.Page26),

            #endregion
            #region Page27
        new Page(new string[] {
            "Bens grade is raised as he doesn't tread off topic for too long, turning his lack of inspiration for a souper adventure into the game itself." +
            "@@%But what becomes this worlds reality if it exists inside itself?@ A game watching the onslaught of time gazing into its own creation with full knowledge its actions are entirely ineffective in affecting the world." +
            "@@%There is no health; there is no end nor beginning.@",
            "Exit"
        }, new int[] {0}, Resources.Page27),

            #endregion
            #region Page28
        new Page(new string[] {
            "As someone who doesn't know what this means, I don't know why you clicked this option,@ unless the abstract nature of a one or the other choice leaves you with a chance to dive deeper into randomness :O!" +
            "@@%Is there no curiosity- but a following of choices :O?@ Ben is sorry if this project has sounded snooty" +
            "@@%After the first world war Americas technological craze turned to fear; people realized we were all stuck inside a city praising a conception that will no doubt lead to greater power turning abstract hatred into physical destruction." +
            "@@%Now the connection between hunger, desire, and rage, and the affect on the physical world; this a bridge unable to be severed after construction.",
            "Play Again?:)@",
            "Here is the exit if you would like:)"
        }, new int[] {2, 0}, Resources.Page28),

            #endregion
        };
        #endregion

        #region Initialize Components!
        public Form1()
        {
            InitializeComponent();

            //Fill Each List with Labels and PictureBoxes:

            //outputLabel and all 4 option#Labels
            allOutputs = new List<Label>()
        { outputLabel, option1Label, option2Label, option3Label, option4Label };

            //all 10 Heart PictureBoxes
            allHearts = new List<PictureBox>()
        { heartContainer1, heartContainer2, heartContainer3, heartContainer4, heartContainer5, heartContainer6, heartContainer7, heartContainer8, heartContainer9, heartContainer10 };


            //Both "playerHealth" and all pages are global variables, so to use "playerHealth" in a page, we have to say so here.
            pageIndex[0].outputLabelTexts[0] = $"You made souper choices! You had: {playerHealth} Hearts! Goodbye!@@";


            //start the game off on page 1
            createPage(1);
        }
        #endregion

        #region CREATE PAGE
        void createPage(int pageNumber)
        {
            //Play a sound:
            Sound2.Play();

            //Update Current Page:
            currentPage = pageNumber;

            //Display Current Image:
            imageBox.Image = pageIndex[pageNumber].image;

            //check which outputs are visible on the Current Page:
            for (int x = 0; x < allOutputs.Count - 1; x++)
            {
                if (pageIndex[pageNumber].pathOptions.Length >= (x + 1))
                { buttonLabelToggle(x, true); }
                else
                { buttonLabelToggle(x, false); }
            }

            //PRINTING TEXT: 
            //First; Reset all output texts:
            foreach (Label label in allOutputs)
            {
                label.Text = "";
                wait(1);
            }
            
            //Second; Print out each letter one at a time; if the character is "Special", follow the case output instead:
            //Define "x" as the current output label.
            for (int x = 0; x <= pageIndex[pageNumber].outputLabelTexts.Length - 1; x++)
            {
                //for each character in the current output label; check what character it is:
                foreach (char letter in pageIndex[pageNumber].outputLabelTexts[x])
                {
                    switch ($"{letter}")
                    {
                        //"Special" Characters:
                        case "@":
                            wait(1300);
                            break;
                        case "%":
                            wait(1700);
                            allOutputs[x].Text = "";
                            break;
                        case "<":
                            displayHearts(-1);
                            Sound1.Play();
                            break;
                        case ">":
                            Sound1.Play();
                            displayHearts(1);
                            break;                        

                        //Default Prints the letter:
                        default:
                            allOutputs[x].Text += letter;
                            wait(1);
                            break;
                    }
                }
            }

            //Specific actions on specifc pages:
            switch (pageNumber)
            {
                //page 0 ends the game:
                case 0:
                    System.Windows.Forms.Application.Exit();
                    break;
                //page 2 sets the players health to 3:
                case 2:
                    playerHealth = 3;
                    displayHearts(0);
                    break;
            }
        }
        #endregion

        #region Engable Or Disable Lables
        //function enabling or disabling lables (this will depend on how many options the page gives the player) 
        void buttonLabelToggle(int x, bool trueOrFalse)
        {
            //"x" is the specified option#Label; I specify [x + 1] because the top output label is in slot 0 and it is always enabled.
            allOutputs[x + 1].Enabled = trueOrFalse;
            allOutputs[x + 1].Visible = trueOrFalse;
        }
        #endregion

        #region Wait Function
        //Wait Function:
        void wait(int waitTime)
        {
            Refresh();
            Thread.Sleep(waitTime);
        }
        #endregion

        #region Display Hearts Function
        void displayHearts(int affectHealth)
        {
            //Add/Subtract "affectHealth" to the playerHealth:
            playerHealth += affectHealth;

            //If the players health has gone below 0, set it to 0:
            if (playerHealth < 0) { playerHealth = 0; }

            //if the players health has gone beyond the total health, set it back to max health:
            //(these allow me to add a whole bunch of hurts/heals without worrying about how much im hurting/healing)
            else if (playerHealth > allHearts.Count) { playerHealth = allHearts.Count; }

            //For each heart PictureBox, if its number in the list is greater than the players current health, don't show it.
            int y = 0;
            foreach (PictureBox heart in allHearts)
            {
                if (y + 1 <= playerHealth) { heart.Visible = true; }
                else { heart.Visible = false; }
                y++;
            }
        }
        #endregion

        #region Label Clicks
        //inputs from player:
        private void option1Label_Click(object sender, EventArgs e)
        {
            createPage(pageIndex[currentPage].pathOptions[0]);
        }

        private void option2Label_Click(object sender, EventArgs e)
        {
            //If the page is determined by a randomization:
            switch (currentPage)
            {
                case 2:
                    //Generate a random number; if its greater than a value, create a different page.
                    int randomValue = randGen.Next(1, 11);
                    if (randomValue >= 5)
                    {
                        createPage(26);
                    }
                    break;
                    //Otherwise just create the regular page:
                default:
                    createPage(pageIndex[currentPage].pathOptions[1]);
                    break;
            }
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

