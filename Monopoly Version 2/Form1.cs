using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly_Version_2
{
    public partial class Form1 : Form
    {

        public class Streets
        {
            private string _name;
            private string _colour;
            private string _owner = "Unowned";
            private int _price;
            private int _rent;
            private int _posX;
            private int _posY;

            public Streets(string name, string colour, int price, int rent, int PositionX, int PositionY)
            {
                this._name = name;
                this._colour = colour;
                this._price = price;
                this._rent = rent;
                this._posX = PositionX;
                this._posY = PositionY;
            }

            public string getName()
            {
                return _name;
            }

            public string getColour()
            {
                return _colour;
            }

            public string owner
            {
                get { return _owner; }
                set { this._owner = value; }
            }

            public int getPrice()
            {
                return _price;
            }

            public int getRent()
            {
                return _rent;
            }

            public int getPosX()
            {
                return _posX;
            }

            public int getPosY()
            {
                return _posY;
            }
        }

        public class Railways
        {
            private string _name;
            private const int _price = 200;
            private int _rent = 25;
            private string _owner = "Unowned";
            private static string _colour = "Black";
            private int _posX;
            private int _posY;

            public Railways(string name, int PositionX, int PositionY)
            {
                this._name = name;
                this._posX = PositionX;
                this._posY = PositionY;
            }

            public string getName()
            {
                return _name;
            }

            public int getPrice()
            {
                return _price;
            }

            public string getColour()
            {
                return _colour;
            }

            public int getPosX()
            {
                return _posX;
            }

            public int getPosY()
            {
                return _posY;
            }

            public int getRent()
            {
                return _rent;
            }

            public string owner
            {
                get { return _owner; }
                set { this._owner = value; }
            }

            public int calculateRent(int ownedRailways)
            {
                int RentSum = getRent();

                if (ownedRailways == 4) { RentSum = RentSum * 4; }
                else if (ownedRailways == 3) { RentSum = RentSum * 3; }
                else if (ownedRailways == 2) { RentSum = RentSum * 2; }

                return RentSum;
            }
        }

        public class ActionTiles
        {
            private string _name;
            private int _posX;
            private int _posY;

            public ActionTiles(string name, int x, int y)
            {
                this._name = name;
                this._posX = x;
                this._posY = y;
            }

            public string getName()
            {
                return _name;
            }

            public int getPosX()
            {
                return _posX;
            }

            public int getPosY()
            {
                return _posY;
            }
        }

        public class Utilities
        {
            private string _name;
            private const int _price = 150;
            private string _rent = "One owned utility\nRent = DiceRoll * 4\nTwo owned utility\nRent = DiceRoll * 10";
            private static string _colour = "White";
            private string _owner = "Unowned";
            private int _posX;
            private int _posY;

            public Utilities(string name, int x, int y)
            {
                this._name = name;
                this._posX = x;
                this._posY = y;
            }

            public string getName()
            {
                return _name;
            }

            public string owner
            {
                get { return _owner; }
                set { this._owner = value; }
            }

            public string getColour()
            {
                return _colour;
            }

            public string getRent()
            {
                return _rent;
            }

            public int getPrice()
            {
                return _price;
            }

            public int getPosX()
            {
                return _posX;
            }

            public int getPosY()
            {
                return _posY;
            }

            public int calculateRent(int diceRoll, int ownedUtilites)
            {
                int TotalRent;

                if (ownedUtilites == 2)
                {
                    TotalRent = diceRoll * 10;
                }
                else
                {
                    TotalRent = diceRoll * 4;
                }
                return TotalRent;
            }
        }

        public class Players
        {
            private string _name;
            private int _money = 1500;
            private int _posX;
            private int _posY;
            private int _currentTile;
            private bool _inJail = false;
            private int _ownedRailways = 0;
            private int _ownedUtilities = 0;

            public Players(string name, int x, int y)
            {
                this._name = name;
                this._posX = x;
                this._posY = y;
            }

            public int currentTile
            {
                get { return _currentTile; }
                set { this._currentTile = value; }
            }

            public int positionX
            {
                get { return _posX; }
                set { this._posX = value; }
            }

            public int positionY
            {
                get { return _posY; }
                set { this._posY = value; }
            }

            public string getName()
            {
                return _name;
            }

            public int getMoney()
            {
                return _money;
            }

            public void addMoney(int HowMuch)
            {
                _money += HowMuch;
            }

            public void subMoney(int HowMuch)
            {
                _money -= HowMuch;
            }

            public void incrementRailwayCount()
            {
                _ownedRailways = _ownedRailways + 1;
            }

            public void incrementUtilityCount()
            {
                _ownedUtilities = _ownedUtilities + 1;
            }

            public int getOwnedRailways()
            {
                return _ownedRailways;
            }

            public int getOwnedUtilities()
            {
                return _ownedUtilities;
            }

            public bool getInJail()
            {
                return _inJail;
            }

            public void goToJail()
            {
                _inJail = true;
            }
        }

        public class Board
        {
            private int _tileNumber;
            private int _arrayNumber;
            private int _tileX;
            private int _tileY;
            private int _streetType;

            public Board(int tileNumber, int tileX, int tileY, int ArrNum, int streetType)
            {
                this._tileNumber = tileNumber;
                this._tileX = tileX;
                this._tileY = tileY;
                this._arrayNumber = ArrNum;
                this._streetType = streetType;
            }

            public int getTileNum()
            {
                return _tileNumber;
            }

            public int getArrayNumber()
            {
                return _arrayNumber;
            }

            public int getStreetType()
            {
                return _streetType;
            }

            public int getTileX()
            {
                return _tileX;
            }

            public int getTileY()
            {
                return _tileY;
            }

        }
        
        //instanciate the class arrays
        Streets[] street = new Streets[22];
        Railways[] railway = new Railways[4];
        ActionTiles[] actionTile = new ActionTiles[12];
        Utilities[] utility = new Utilities[2];
        Board[] boardspace = new Board[40];
        Players[] player = new Players[4];

        //global values (possibly move them to another place in time..)
        int _currentPlayer = 0;
        const int _passGoAmount = 200;
        int _diceRoll;
        
        public Form1()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; //set window to maximized

            label6.Text = "";
            PropertyDetails.Text = "";
            label47.Text = "";
            label48.Text = "";


            initialiseTiles();
            initialisePlayers();            
            updateLabels(); //update player money count & owned property colours
        }

        private void initialiseTiles()
        {
            //all coloured streets
            street[0] = new Streets("Old Kent Rd\n", "Sienna", 60, 2, 1054, 915); label1.Text = street[0].getName() + street[0].getPrice();
            street[1] = new Streets("White Chapel Rd\n", "Sienna", 60, 4, 760, 915); label2.Text = street[1].getName() + street[1].getPrice();
            street[2] = new Streets("The Angel, Islington\n", "LightBlue", 100, 6, 466, 915); label3.Text = street[2].getName() + street[2].getPrice();
            street[3] = new Streets("Euston Rd\n", "LightBlue", 100, 6, 270, 915); label4.Text = street[3].getName() + street[3].getPrice();
            street[4] = new Streets("Pentonville Rd\n", "LightBlue", 120, 8, 172, 915); label5.Text = street[4].getName() + street[4].getPrice();
            street[5] = new Streets("Pall Mall\n", "Purple", 140, 10, 74, 840); label8.Text = street[5].getName() + street[5].getPrice();
            street[6] = new Streets("Whitehall\n", "Purple", 140, 10, 74, 680); label9.Text = street[6].getName() + street[6].getPrice();
            street[7] = new Streets("Northumberland Ave\n", "Purple", 160, 12, 74, 600); label10.Text = street[7].getName() + street[7].getPrice();
            street[8] = new Streets("Bow St\n", "Orange", 180, 14, 74, 430); label11.Text = street[8].getName() + street[8].getPrice();
            street[9] = new Streets("Marlborough St\n", "Orange", 180, 14, 74, 270); label12.Text = street[9].getName() + street[9].getPrice();
            street[10] = new Streets("Vine St\n", "Orange", 200, 16, 74, 190); label13.Text = street[10].getName() + street[10].getPrice();
            street[11] = new Streets("Strand\n", "Red", 220, 18, 172, 15); label14.Text = street[11].getName() + street[11].getPrice();
            street[12] = new Streets("Fleet St\n", "Red", 220, 18, 368, 15); label15.Text = street[12].getName() + street[12].getPrice();
            street[13] = new Streets("Trafalgar Sq\n", "Red", 240, 20, 466, 15); label16.Text = street[13].getName() + street[13].getPrice();
            street[14] = new Streets("Leicester Sq\n", "Yellow", 260, 22, 662, 15); label17.Text = street[14].getName() + street[14].getPrice();
            street[15] = new Streets("Coventry St\n", "Yellow", 260, 22, 760, 15); label18.Text = street[15].getName() + street[15].getPrice();
            street[16] = new Streets("Piccadilly\n", "Yellow", 280, 24, 956, 15); label19.Text = street[16].getName() + street[16].getPrice();
            street[17] = new Streets("Regent St\n", "Green", 300, 26, 1100, 190); label20.Text = street[17].getName() + street[17].getPrice();
            street[18] = new Streets("Oxford St\n", "Green", 300, 26, 1100, 270); label21.Text = street[18].getName() + street[18].getPrice();
            street[19] = new Streets("Bond St\n", "Green", 320, 28, 1100, 430); label22.Text = street[19].getName() + street[19].getPrice();
            street[20] = new Streets("Park Lane\n", "DarkBlue", 350, 35, 1100, 680); label23.Text = street[20].getName() + street[20].getPrice();
            street[21] = new Streets("Mayfair\n", "DarkBlue", 400, 50, 1100, 840); label24.Text = street[21].getName() + street[21].getPrice();

            //All Railways

            railway[0] = new Railways("Kings Cross\nStation\n", 564, 915); label29.Text = railway[0].getName() + railway[0].getPrice();
            railway[1] = new Railways("Marylbone\nStation\n", 74, 515); label30.Text = railway[1].getName() + railway[1].getPrice();
            railway[2] = new Railways("Fenchurch\nStation\n", 564, 15); label31.Text = railway[2].getName() + railway[2].getPrice();
            railway[3] = new Railways("Liverpool\nStation\n", 1100, 515); label32.Text = railway[3].getName() + railway[3].getPrice();

            //ALL Action tiles

            actionTile[0] = new ActionTiles("GO", 1054, 915); label33.Text = actionTile[0].getName();
            actionTile[1] = new ActionTiles("Community\nChest", 858, 915); label34.Text = actionTile[1].getName();
            actionTile[2] = new ActionTiles("Income tax", 662, 915); label35.Text = actionTile[2].getName();
            actionTile[3] = new ActionTiles("Chance", 368, 915); label36.Text = actionTile[3].getName();
            actionTile[4] = new ActionTiles("JAIL/\nJust\nVisiting", 74, 915); label37.Text = actionTile[4].getName();
            actionTile[5] = new ActionTiles("Community\nChest", 74, 350); label38.Text = actionTile[5].getName();
            actionTile[6] = new ActionTiles("FREE PARKING", 74, 15); label39.Text = actionTile[6].getName();
            actionTile[7] = new ActionTiles("Chance", 270, 15); label40.Text = actionTile[7].getName();
            actionTile[8] = new ActionTiles("GO TO JAIL!", 1054, 15); label41.Text = actionTile[8].getName();
            actionTile[9] = new ActionTiles("Community\nChest", 1100, 350); label42.Text = actionTile[9].getName();
            actionTile[10] = new ActionTiles("Chance", 1100, 600); label43.Text = actionTile[10].getName();
            actionTile[11] = new ActionTiles("Super tax", 1100, 760); label44.Text = actionTile[11].getName();

            //ALL Utilities

            utility[0] = new Utilities("Electric Company", 74, 760); label45.Text = utility[0].getName();
            utility[1] = new Utilities("Water Works", 858, 15); label46.Text = utility[1].getName();

            //pictureBox3.Location = new Point(200, 15);

            //ALL board spaces with their positions
            //streets
            boardspace[1] = new Board(1, street[0].getPosX(), street[0].getPosY(), 0, 0);
            boardspace[3] = new Board(3, street[1].getPosX(), street[1].getPosY(), 1, 0);
            boardspace[6] = new Board(6, street[2].getPosX(), street[2].getPosY(), 2, 0);
            boardspace[8] = new Board(8, street[3].getPosX(), street[3].getPosY(), 3, 0);
            boardspace[9] = new Board(9, street[4].getPosX(), street[4].getPosY(), 4, 0);
            boardspace[11] = new Board(11, street[5].getPosX(), street[5].getPosY(), 5, 0);
            boardspace[13] = new Board(13, street[6].getPosX(), street[6].getPosY(), 6, 0);
            boardspace[14] = new Board(14, street[7].getPosX(), street[7].getPosY(), 7, 0);
            boardspace[16] = new Board(16, street[8].getPosX(), street[8].getPosY(), 8, 0);
            boardspace[18] = new Board(18, street[9].getPosX(), street[9].getPosY(), 9, 0);
            boardspace[19] = new Board(19, street[10].getPosX(), street[10].getPosY(), 10, 0);
            boardspace[21] = new Board(21, street[11].getPosX(), street[11].getPosY(), 11, 0);
            boardspace[23] = new Board(23, street[12].getPosX(), street[12].getPosY(), 12, 0);
            boardspace[24] = new Board(24, street[13].getPosX(), street[13].getPosY(), 13, 0);
            boardspace[26] = new Board(26, street[14].getPosX(), street[14].getPosY(), 14, 0);
            boardspace[27] = new Board(27, street[15].getPosX(), street[15].getPosY(), 15, 0);
            boardspace[29] = new Board(29, street[16].getPosX(), street[16].getPosY(), 16, 0);
            boardspace[31] = new Board(31, street[17].getPosX(), street[17].getPosY(), 17, 0);
            boardspace[32] = new Board(32, street[18].getPosX(), street[18].getPosY(), 18, 0);
            boardspace[34] = new Board(34, street[19].getPosX(), street[19].getPosY(), 19, 0);
            boardspace[37] = new Board(37, street[20].getPosX(), street[20].getPosY(), 20, 0);
            boardspace[39] = new Board(39, street[21].getPosX(), street[21].getPosY(), 21, 0);
            //railways
            boardspace[5] = new Board(5, railway[0].getPosX(), railway[0].getPosY(), 0, 1);
            boardspace[15] = new Board(15, railway[1].getPosX(), railway[1].getPosY(), 1, 1);
            boardspace[25] = new Board(25, railway[2].getPosX(), railway[2].getPosY(), 2, 1);
            boardspace[35] = new Board(35, railway[3].getPosX(), railway[3].getPosY(), 3, 1);
            //actionTiles
            boardspace[0] = new Board(0, actionTile[0].getPosX(), actionTile[0].getPosY(), 0, 2);
            boardspace[2] = new Board(2, actionTile[1].getPosX(), actionTile[1].getPosY(), 1, 2);
            boardspace[4] = new Board(4, actionTile[2].getPosX(), actionTile[2].getPosY(), 2, 2);
            boardspace[7] = new Board(7, actionTile[3].getPosX(), actionTile[3].getPosY(), 3, 2);
            boardspace[10] = new Board(10, actionTile[4].getPosX(), actionTile[4].getPosY(), 4, 2);
            boardspace[17] = new Board(17, actionTile[5].getPosX(), actionTile[5].getPosY(), 5, 2);
            boardspace[20] = new Board(20, actionTile[6].getPosX(), actionTile[6].getPosY(), 6, 2);
            boardspace[22] = new Board(22, actionTile[7].getPosX(), actionTile[7].getPosY(), 7, 2);
            boardspace[30] = new Board(30, actionTile[8].getPosX(), actionTile[8].getPosY(), 8, 2);
            boardspace[33] = new Board(33, actionTile[9].getPosX(), actionTile[9].getPosY(), 9, 2);
            boardspace[36] = new Board(36, actionTile[10].getPosX(), actionTile[10].getPosY(), 10, 2);
            boardspace[38] = new Board(38, actionTile[11].getPosX(), actionTile[11].getPosY(), 11, 2);
            //utilities
            boardspace[12] = new Board(12, utility[0].getPosX(), utility[0].getPosY(), 0, 3);
            boardspace[28] = new Board(28, utility[1].getPosX(), utility[1].getPosY(), 1, 3);
        }

        private void initialisePlayers()
        {
            //Initialise player spaces
            player[0] = new Players("Player1", boardspace[0].getTileX(), boardspace[0].getTileY()); pictureBox3.Location = new Point(player[0].positionX, player[0].positionY);
            player[1] = new Players("Player2", boardspace[0].getTileX(), boardspace[0].getTileY()); pictureBox2.Location = new Point(player[1].positionX + 30, player[1].positionY);
            player[2] = new Players("Player3", boardspace[0].getTileX(), boardspace[0].getTileY()); pictureBox4.Location = new Point(player[2].positionX, player[2].positionY + 30);
            player[3] = new Players("Player4", boardspace[0].getTileX(), boardspace[0].getTileY()); pictureBox5.Location = new Point(player[3].positionX + 30, player[3].positionY + 30);
        }

        private string setLabelColour(string owner)
        {
            string colour = "Honeydew";

            if(owner == player[0].getName())
            {
                colour = "Yellow";
            }
            else if(owner == player[1].getName())
            {
                colour = "Pink";
            }
            else if(owner == player[2].getName())
            {
                colour = "Blue";
            }
            else if (owner == player[3].getName())
            {
                colour = "Green";
            }
            return colour;
        }

        private void movePlayer(int diceRoll, int CurrentPlayer, int CurrentTile, int CurrentX, int CurrentY)
        {
            int MovedTo;

            MovedTo = player[_currentPlayer].currentTile + diceRoll;

            if (MovedTo >= 40)
            {
                MovedTo = (CurrentTile + diceRoll) - 40;
                label49.Text = player[_currentPlayer].getName() + " passed GO, and collected £200";
                player[_currentPlayer].addMoney(_passGoAmount);
            }

            player[CurrentPlayer].positionX = boardspace[MovedTo].getTileX();

            player[CurrentPlayer].positionY = boardspace[MovedTo].getTileY();

            player[CurrentPlayer].currentTile = MovedTo;
                        
        }

        private int diceRoll()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int Dice1;
            int Dice2;
            int Roll;
            Dice1 = random.Next(1, 7);
            Dice2 = random.Next(1, 7);
            Roll = Dice1 + Dice2;

            return Roll;
        }

        private int UpdateCurrentPlayer(int currentPlayer)
        {
            currentPlayer = currentPlayer + 1;
            if (currentPlayer == 4)
            {
                currentPlayer = 0;
            }
            return currentPlayer;
        }

        private void updateLabels()
        {
            label25.Text = player[0].getName() + "\n" + player[0].getMoney() + "\n";
            label26.Text = player[1].getName() + "\n" + player[1].getMoney() + "\n";
            label27.Text = player[2].getName() + "\n" + player[2].getMoney() + "\n";
            label28.Text = player[3].getName() + "\n" + player[3].getMoney() + "\n";
            
            //street label colour
            label1.BackColor = Color.FromName(setLabelColour(street[0].owner));
            label2.BackColor = Color.FromName(setLabelColour(street[1].owner));
            label3.BackColor = Color.FromName(setLabelColour(street[2].owner));
            label4.BackColor = Color.FromName(setLabelColour(street[3].owner));
            label5.BackColor = Color.FromName(setLabelColour(street[4].owner));
            label8.BackColor = Color.FromName(setLabelColour(street[5].owner));
            label9.BackColor = Color.FromName(setLabelColour(street[6].owner));
            label10.BackColor = Color.FromName(setLabelColour(street[7].owner));
            label11.BackColor = Color.FromName(setLabelColour(street[8].owner));
            label12.BackColor = Color.FromName(setLabelColour(street[9].owner));
            label13.BackColor = Color.FromName(setLabelColour(street[10].owner));
            label14.BackColor = Color.FromName(setLabelColour(street[11].owner));
            label15.BackColor = Color.FromName(setLabelColour(street[12].owner));
            label16.BackColor = Color.FromName(setLabelColour(street[13].owner));
            label17.BackColor = Color.FromName(setLabelColour(street[14].owner));
            label18.BackColor = Color.FromName(setLabelColour(street[15].owner));
            label19.BackColor = Color.FromName(setLabelColour(street[16].owner));
            label20.BackColor = Color.FromName(setLabelColour(street[17].owner));
            label21.BackColor = Color.FromName(setLabelColour(street[18].owner));
            label22.BackColor = Color.FromName(setLabelColour(street[19].owner));
            label23.BackColor = Color.FromName(setLabelColour(street[20].owner));
            label24.BackColor = Color.FromName(setLabelColour(street[21].owner));

            //railway label colour
            label29.BackColor = Color.FromName(setLabelColour(railway[0].owner));
            label30.BackColor = Color.FromName(setLabelColour(railway[1].owner));
            label31.BackColor = Color.FromName(setLabelColour(railway[2].owner));
            label32.BackColor = Color.FromName(setLabelColour(railway[3].owner));

            //utility label colour
            label45.BackColor = Color.FromName(setLabelColour(utility[0].owner));
            label46.BackColor = Color.FromName(setLabelColour(utility[1].owner));
        }

        private string ColourBox(string colour)
        {
            string box = "█████████████████";

            label6.ForeColor = Color.FromName(colour);

            return box;
        }

        //Roll Dice button
        private void button1_Click(object sender, EventArgs e)
        {
            label47.Text = "";
            label7.Text = Convert.ToString(diceRoll());

            _diceRoll = diceRoll();

            movePlayer(_diceRoll, _currentPlayer, player[_currentPlayer].currentTile, player[_currentPlayer].positionX, player[_currentPlayer].positionY);

            switch (_currentPlayer)
            {
                case (0):
                    pictureBox3.Location = new Point(player[0].positionX, player[0].positionY);
                    break;

                case (1):
                    pictureBox2.Location = new Point(player[1].positionX + 30, player[1].positionY);
                    break;

                case (2):
                    pictureBox4.Location = new Point(player[2].positionX, player[2].positionY + 30);
                    break;

                case (3):
                    pictureBox5.Location = new Point(player[3].positionX + 30, player[3].positionY + 30);
                    break;
            }

            //perform tile interaction
            TileAction(boardspace[player[_currentPlayer].currentTile].getArrayNumber(),  //Array number
                       player[_currentPlayer].currentTile,                               //Current tile
                       _currentPlayer,                                                   //Current Player
                       boardspace[player[_currentPlayer].currentTile].getStreetType());  //Tile Type


            _currentPlayer = UpdateCurrentPlayer(_currentPlayer);
        }

        private void TileAction(int arrayNum, int currentTile, int currentPlayer, int tileType)
        {
            switch (tileType)
            {
                case (0):
                    if (street[arrayNum].owner == "Unowned")
                    {
                        label47.Text = "Would you like to purchase " + street[arrayNum].getName() + " for £" + street[arrayNum].getPrice();
                        buyStreetTile(arrayNum, currentPlayer);
                    }
                    else if(street[arrayNum].owner != player[currentPlayer].getName()) 
                    {
                        payStreetRent(arrayNum, currentPlayer);
                    }
                    break;

                case (1):
                    if (railway[arrayNum].owner == "Unowned")  //remember to implement railway count increment
                    {
                        label47.Text = "Would you like to purchase " + railway[arrayNum].getName() + " for £" + railway[arrayNum].getPrice();
                        buyRailwayTile(arrayNum, currentPlayer);
                    }
                    else if (railway[arrayNum].owner != player[currentPlayer].getName())
                    {
                        payRailwayRent(arrayNum, currentPlayer);
                    }
                    break;

                case (2):
                    whichAction(actionTile[arrayNum].getName(), currentPlayer);
                    break;

                case (3):
                    if (utility[arrayNum].owner == "Unowned")  //remember to implement utility count increment
                    {
                        label47.Text = "Would you like to purchase " + utility[arrayNum].getName() + " for £" + utility[arrayNum].getPrice();
                        buyUtilityTile(arrayNum, currentPlayer);
                    }
                    else if (utility[arrayNum].owner != player[currentPlayer].getName())
                    {
                        payUtilityRent(arrayNum, currentPlayer);
                    }
                    break;
            }
            landedWhere(tileType, arrayNum, currentPlayer);
            updateLabels();
        }

        public void landedWhere(int tileType, int arrayNum, int currentPlayer)
        {
            switch (tileType)
            {
                case 0:
                    label48.Text = player[currentPlayer].getName() + " landed on "+ street[arrayNum].getName();
                    break;
                case 1:
                    label48.Text = player[currentPlayer].getName() + " landed on " + railway[arrayNum].getName();
                    break;
                case 2:
                    label48.Text = player[currentPlayer].getName() + " landed on " + actionTile[arrayNum].getName();
                    break;
                case 3:
                    label48.Text = player[currentPlayer].getName() + " landed on " + utility[arrayNum].getName();
                    break;
            }
        }

        private void whichAction(string name, int currentPlayer)
        {
            int incomeTax = 200;
            int superTax = 100;

            switch (name)
            {
                case "Community\nChest":
                    break;
                case "Income Tax":
                    player[currentPlayer].subMoney(incomeTax);
                    break;
                case "Chance":
                    break;
                case "JAIL /\nJust\nVisiting":
                    break;
                case "FREE PARKING":
                    break;
                case "GO TO JAIL":
                    break;
                case "Super Tax":
                    player[currentPlayer].subMoney(superTax);
                    break;
            }
        }
            
        //buy properties & pay rent
        private void buyUtilityTile(int arrayNum, int currentPlayer)
        {
            int utilityCost = utility[arrayNum].getPrice();
            player[_currentPlayer].subMoney(utilityCost);
            utility[arrayNum].owner = player[currentPlayer].getName();
            player[currentPlayer].incrementUtilityCount();
        }

        private void buyRailwayTile(int arrayNum, int currentPlayer)
        {
            int railwayCost = railway[arrayNum].getPrice();
            player[_currentPlayer].subMoney(railwayCost);
            railway[arrayNum].owner = player[currentPlayer].getName();
            player[currentPlayer].incrementRailwayCount();
        }

        private void buyStreetTile(int arrayNum, int currentPlayer)
        {
            int houseCost = street[arrayNum].getPrice();
            player[_currentPlayer].subMoney(houseCost);
            street[arrayNum].owner = player[currentPlayer].getName();
        }

        private void payStreetRent(int arrayNum, int currentPlayer)
        {
            int rentDue = street[arrayNum].getRent();
            player[currentPlayer].subMoney(rentDue);
            if(street[arrayNum].owner == player[0].getName())
            {
                player[0].addMoney(rentDue);
            }
            else if (street[arrayNum].owner == player[1].getName())
            {
                player[1].addMoney(rentDue);
            }
            else if (street[arrayNum].owner == player[2].getName())
            {
                player[2].addMoney(rentDue);
            }
            else if (street[arrayNum].owner == player[3].getName())
            {
                player[3].addMoney(rentDue);
            }
        }

        private void payRailwayRent(int arrayNum, int currentPlayer)
        {
            int rentDue = railway[arrayNum].calculateRent(player[currentPlayer].getOwnedRailways());
            player[currentPlayer].subMoney(rentDue);
            if (railway[arrayNum].owner == player[0].getName())
            {
                player[0].addMoney(rentDue);
            }
            else if (railway[arrayNum].owner == player[1].getName())
            {
                player[1].addMoney(rentDue);
            }
            else if (railway[arrayNum].owner == player[2].getName())
            {
                player[2].addMoney(rentDue);
            }
            else if (railway[arrayNum].owner == player[3].getName())
            {
                player[3].addMoney(rentDue);
            }
        }

        private void payUtilityRent(int arrayNum, int currentPlayer)
        {
            int rentDue = utility[arrayNum].calculateRent(_diceRoll, player[currentPlayer].getOwnedUtilities());
            player[currentPlayer].subMoney(rentDue);
            if (utility[arrayNum].owner == player[0].getName())
            {
                player[0].addMoney(rentDue);
            }
            else if (utility[arrayNum].owner == player[1].getName())
            {
                player[1].addMoney(rentDue);
            }
            else if (utility[arrayNum].owner == player[2].getName())
            {
                player[2].addMoney(rentDue);
            }
            else if (utility[arrayNum].owner == player[3].getName())
            {
                player[3].addMoney(rentDue);
            }
        }

        #region Label clicks
        //StreetClicks
        private void label1_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[0].getColour());
            PropertyDetails.Text = street[0].getName() + "\nOwner: " + street[0].owner + "\nPrice: £" + street[0].getPrice() + "\nRent: £" + street[0].getRent();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[1].getColour());
            PropertyDetails.Text = street[1].getName() + "\nOwner: " + street[1].owner + "\nPrice: £" + street[1].getPrice() + "\nRent: £" + street[1].getRent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[2].getColour());
            PropertyDetails.Text = street[2].getName() + "\nOwner: " + street[2].owner + "\nPrice: £" + street[2].getPrice() + "\nRent: £" + street[2].getRent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[3].getColour());
            PropertyDetails.Text = street[3].getName() + "\nOwner: " + street[3].owner + "\nPrice: £" + street[3].getPrice() + "\nRent: £" + street[3].getRent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[4].getColour());
            PropertyDetails.Text = street[4].getName() + "\nOwner: " + street[4].owner + "\nPrice: £" + street[4].getPrice() + "\nRent: £" + street[4].getRent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[5].getColour());
            PropertyDetails.Text = street[5].getName() + "\nOwner: " + street[5].owner + "\nPrice: £" + street[5].getPrice() + "\nRent: £" + street[5].getRent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[6].getColour());
            PropertyDetails.Text = street[6].getName() + "\nOwner: " + street[6].owner + "\nPrice: £" + street[6].getPrice() + "\nRent: £" + street[6].getRent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[7].getColour());
            PropertyDetails.Text = street[7].getName() + "\nOwner: " + street[7].owner + "\nPrice: £" + street[7].getPrice() + "\nRent: £" + street[7].getRent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[8].getColour());
            PropertyDetails.Text = street[8].getName() + "\nOwner: " + street[8].owner + "\nPrice: £" + street[8].getPrice() + "\nRent: £" + street[8].getRent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[9].getColour());
            PropertyDetails.Text = street[9].getName() + "\nOwner: " + street[9].owner + "\nPrice: £" + street[9].getPrice() + "\nRent: £" + street[9].getRent();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[10].getColour());
            PropertyDetails.Text = street[10].getName() + "\nOwner: " + street[10].owner + "\nPrice: £" + street[10].getPrice() + "\nRent: £" + street[10].getRent();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[11].getColour());
            PropertyDetails.Text = street[11].getName() + "\nOwner: " + street[11].owner + "\nPrice: £" + street[11].getPrice() + "\nRent: £" + street[11].getRent();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[12].getColour());
            PropertyDetails.Text = street[12].getName() + "\nOwner: " + street[12].owner + "\nPrice: £" + street[12].getPrice() + "\nRent: £" + street[12].getRent();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[13].getColour());
            PropertyDetails.Text = street[13].getName() + "\nOwner: " + street[13].owner + "\nPrice: £" + street[13].getPrice() + "\nRent: £" + street[13].getRent();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[14].getColour());
            PropertyDetails.Text = street[14].getName() + "\nOwner: " + street[14].owner + "\nPrice: £" + street[14].getPrice() + "\nRent: £" + street[14].getRent();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[15].getColour());
            PropertyDetails.Text = street[15].getName() + "\nOwner: " + street[15].owner + "\nPrice: £" + street[15].getPrice() + "\nRent: £" + street[15].getRent();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[16].getColour());
            PropertyDetails.Text = street[16].getName() + "\nOwner: " + street[16].owner + "\nPrice: £" + street[16].getPrice() + "\nRent: £" + street[16].getRent();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[17].getColour());
            PropertyDetails.Text = street[17].getName() + "\nOwner: " + street[17].owner + "\nPrice: £" + street[17].getPrice() + "\nRent: £" + street[17].getRent();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[18].getColour());
            PropertyDetails.Text = street[18].getName() + "\nOwner: " + street[18].owner + "\nPrice: £" + street[18].getPrice() + "\nRent: £" + street[18].getRent();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[19].getColour());
            PropertyDetails.Text = street[19].getName() + "\nOwner: " + street[19].owner + "\nPrice: £" + street[19].getPrice() + "\nRent: £" + street[19].getRent();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[20].getColour());
            PropertyDetails.Text = street[20].getName() + "\nOwner: " + street[20].owner + "\nPrice: £" + street[20].getPrice() + "\nRent: £" + street[20].getRent();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(street[21].getColour());
            PropertyDetails.Text = street[21].getName() + "\nOwner: " + street[21].owner + "\nPrice: £" + street[21].getPrice() + "\nRent: £" + street[21].getRent();
        }

        //accidental clicker
        private void label28_Click(object sender, EventArgs e)
        {

        }
        //accidental clicker


        //RailwayCLicks
        private void label29_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(railway[0].getColour());
            PropertyDetails.Text = railway[0].getName() + "\nOwner: " + railway[0].owner + "\nPrice: £" + railway[0].getPrice() + "\nRent: £" + railway[0].getRent();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(railway[1].getColour());
            PropertyDetails.Text = railway[1].getName() + "\nOwner: " + railway[1].owner + "\nPrice: £" + railway[1].getPrice() + "\nRent: £" + railway[1].getRent();
        }

        private void label31_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(railway[2].getColour());
            PropertyDetails.Text = railway[2].getName() + "\nOwner: " + railway[2].owner + "\nPrice: £" + railway[2].getPrice() + "\nRent: £" + railway[2].getRent();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(railway[3].getColour());
            PropertyDetails.Text = railway[3].getName() + "\nOwner: " + railway[3].owner + "\nPrice: £" + railway[3].getPrice() + "\nRent: £" + railway[3].getRent();
        }


        //UtilityClicks
        private void label45_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(utility[0].getColour());
            PropertyDetails.Text = utility[0].getName() + "\nOwner: " + utility[0].owner + "\nPrice: £" + utility[0].getPrice() + "\n\n" + utility[0].getRent();
        }

        private void label46_Click(object sender, EventArgs e)
        {
            label6.Text = ColourBox(utility[1].getColour());
            PropertyDetails.Text = utility[1].getName() + "\nOwner: " + utility[1].owner + "\nPrice: £" + utility[1].getPrice() + "\n\n" + utility[1].getRent();
        }
        #endregion

       
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

    }
}
