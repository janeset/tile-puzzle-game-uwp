/*
* FILE : MainPage.xaml.cs
* PROJECT : PROG2001 - Assignment #7
* PROGRAMMER : Janeth Santos and Hongsik Eom
* FIRST VERSION : December 10, 2020
* DESCRIPTION :
* this file contains the mainpage logic of the application.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Timers;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml.Hosting;


namespace A7_TilePuzzleGame
{
 
    //NAME : MainPAge
    //PURPOSE : it's main purpose is to add contain the logic for the main app page
    public sealed partial class MainPage : Page
    {
        //constants
        const int TIME_INTERVAL = 1000;         //time interval in miliseconds
        const int MAX_SECS = 59;                //Max number of seconds 1 minute 
        const int MIN_SECS = 0;                 //Min number of seconds 1 minute 
        const int MAX_TILES = 16;               //Max number of tiles 
        const int TOP_TEN = 10;                 // max players on leaderboard



        Timer gameTimer = new Timer();          //create timer object
        public int timerSecs = 0;               //represents the seconds in the timer
        public int timerMins = 0;               //represents the minutes in the timer
        public string topTenList;               //String list of Leaderboard to Update UI

        string gameMode = "off";                // tracks if game mode is started

        List<Rectangle> rectangleList = new List<Rectangle>();  //Tracks Ordered Positions of Rectangles
        List<string> regList = new List<string>();              //Tracks Ordered Tags on the Rectangles's position
        AppWindow winnerWindow = null;                          //create secondary Appwindow
        Frame appWindowFrame = new Frame();                     //used for secondary window
        string playerName = "";                                 // input name when player wins
        player players = new player();                          //Tracks Ordered Positions of Players on leaderboard
        Tiles tiles = new Tiles();                              //Tracks Ordered Positions of tiles

        public MainPage()
        {
            this.InitializeComponent();

            //Load app data 
            timerSecs = ((App)Application.Current).timeSecs;
            timerMins = ((App)Application.Current).timeMins;

            tiles = ((App)Application.Current).tiles;
            players = ((App)Application.Current).players;         

            gameTimer.Elapsed += Time_Elapsed;
            gameTimer.Interval = TIME_INTERVAL;

            if (players.topTenPlayers.Count > 0)
            {
                players.topTenPlayers = player.OrderByTime(players.topTenPlayers, out topTenList); //sort the list by time, output string to update UI 
                top10List_Box.Text = topTenList;
            }

            this.DataContext = tiles;

            tiles.rectList = new List<Rectangle> { r0, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15 };  //order of rectangles
            regList = new List<string> { "t1", "t2", "t3", "t4", "t5", "t6", "t7", "t8", "t9", "t10", "t11", "t12", "t13", "t14", "t15", "t16" };


            for (int i = 0; i < MAX_TILES; i++)
            {
                tiles.rectList[i].Tag = ((App)Application.Current).tags[i];
            }



            //if game was already started, continue timer were left off.
            if (timerMins > 0 || timerSecs > 0)
            {
                gameTimer.Start();
            }
        }


        //------------------------------- TIMER --------------------------------



        //Name   : Time_Elapsed
        //Purpose : increment the timer count
        //Inputs   : 
        //      object sender: sender object
        //      RoutedEventArgs e: Contains state information and event data associated with a routed event
        //Outputs   : NONE
        //Returns   : Void
        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            timerSecs += 1;
            if (timerSecs > MAX_SECS) { timerSecs = MIN_SECS; timerMins++; }
            UpdateTextblock();
        }


     
        //Name   : UpdateTextblock()
        //Purpose :purpose to update the text in the timer text block
        //Inputs   : none
        //Outputs   : NONE
        //Returns   : Void
        async private void UpdateTextblock()
        {
            var dispatcher = timerBlock.Dispatcher;
            if (!dispatcher.HasThreadAccess)
            {
                await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { UpdateTextblock(); });
            }
            else
            {
                tiles.Timer = $"Timer : {timerMins.ToString("D2")}:{timerSecs.ToString("D2")}";
            }

        }

        //------------------------------- TIMER --------------------------------

        //------------------------------- BUTTONS --------------------------------



     
        //Name   : randomBtn_Click
        //Purpose :purpose to shuffle the tiles on the matrix
        //Inputs   : 
        //      object sender: sender object
        //      RoutedEventArgs e: Contains state information and event data associated with a routed event
        //Outputs   : NONE
        //Returns   : Void
        private async void randomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (gameMode == "off")
            {
                ShuffleRectangles();
            }
            else if (gameMode == "start")
            {
                
                MessageDialog msgDialog = new MessageDialog("Current game will reset\nDo you wish to Continue..?", "Warning!");

                //add ok button
                UICommand okBtn = new UICommand("Yes");
                okBtn.Invoked = OkBtnClick;
                msgDialog.Commands.Add(okBtn);

                //add cancel button
                UICommand cancelBtn = new UICommand("Cancel");
                cancelBtn.Invoked = CancelBtnClick;
                msgDialog.Commands.Add(cancelBtn);

                //show message
                await msgDialog.ShowAsync();

            }
          
        }



        //Name   : CancelBtnClick
        //Purpose :purpose  cancel the shuffle of the game while its running
        //Inputs   :  command from messagebox button
        //Outputs   : NONE
        //Returns   : Void
        private void CancelBtnClick(IUICommand command)
        {
            if (gameMode == "start")
            {
                gameMode = "start";
            }       
        }

        //Name   : OkBtnClick
        //Purpose :purpose  continue with the shuffle of the game while its running
        //Inputs   :  command from messagebox button
        //Outputs   : NONE
        //Returns   : Void
        private void OkBtnClick(IUICommand command)
        {

            timerSecs = 0;          //reset seconds in the timer
            timerMins = 0;          //reset the minutes in the timer
            tiles.Timer = $"Timer : {timerMins.ToString("D2")}:{timerSecs.ToString("D2")}";
            gameTimer.Stop();       //stop timer
            ShuffleRectangles();        
            gameMode = "off";
        }

        //------------------------------- BUTTONS --------------------------------

        //------------------------------- Randomizer --------------------------------


        
        //Name   : ShuffleRectangles
        //Purpose :this function shuffles the tiles on the matrix
        //Inputs  : none
        //Outputs : NONE
        //Returns : Void
        private void ShuffleRectangles()
        {
            List<string> RectanglesList = new List<string> { "t1", "t2", "t3", "t4", "t5", "t6", "t7", "t8", "t9", "t10", "t11", "t12", "t13", "t14", "t15", "t16" };  //order of tiles

            var RandomOrder = RectanglesList.OrderBy(a => Guid.NewGuid()).ToList();  //create random list order
            int i = 0;
            //place tiles on the matrix
            foreach (Rectangle t in tiles.rectList)
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri($"ms-appx:///tiles/{RandomOrder[i]}.jpg"));
                t.Fill = imageBrush;
                t.Tag = RandomOrder[i];
                i++;
            }

        }

        //------------------------------- Randomizer --------------------------------

        //------------------------------- CheckWin --------------------------------

        

        //Name   :  checkWin()
        //Purpose :check if the current position of the tile matches the right order, if they match the player wins the game
        //Inputs  : none
        //Outputs : NONE
        //Returns : bool   true id winner false otherwise
        bool checkWin()
        {
            int matchCounter = 0, i = 0;
            bool winner = false;

            foreach (Rectangle r in tiles.rectList)
            {
                if ((string)r.Tag == regList[i])
                {
                    matchCounter++;
                }
                i++;
            }

            if (matchCounter == MAX_TILES)
            {
                winner = true;
            }

            return winner;
        }

        //------------------------------- CheckWin --------------------------------


        //------------------------------- switch tile --------------------------------

        //Name   :  SwitchTile
        //Purpose : to switch the tiles on the game when the player taps on a rectangle
        //Inputs  : object sender: sender object
        //          TappedRoutedEventArgs e: Contains state information and event data associated with a routed event
        //Outputs : NONE
        //Returns : bool   true id winner false otherwise
        private void SwitchTile(object sender, TappedRoutedEventArgs e)
        {

            Rectangle rectTouched = (Rectangle)sender;

            if ((string)rectTouched.Tag == "t16")   //check if touched the blank tile, do nothing
            {
                return;
            }

            Rectangle blankRect = null;
            foreach (Rectangle r in tiles.rectList)
            {
                if ((string)r.Tag == "t16")   //find position of blank rectangle
                {
                    blankRect = r;
                    break;
                }
            }

            if(blankRect != null)
            {
                //get index
                int rectTouchedIndex = Convert.ToInt32(rectTouched.Name.Substring(1, rectTouched.Name.Length - 1));
                int blankIndex = Convert.ToInt32(blankRect.Name.Substring(1, blankRect.Name.Length - 1));

                //check if touched rectangle is next to blankRect

                if (rectTouchedIndex == (blankIndex - 1) ||   //LEFT tile neighbour
                    rectTouchedIndex == (blankIndex - 4) ||   //UP tile neighbour
                    rectTouchedIndex == (blankIndex + 1) ||   //RIGHT tile neighbour
                    rectTouchedIndex == (blankIndex + 4))     //DOWN tile neighbour
                {

                    if(checkWin())
                    {
                        ShuffleRectangles();
                    }

                    if (gameMode == "off")
                    {
                        gameTimer.Enabled = true; //activates the timer
                        gameTimer.Start();        // start timer   
                        gameMode = "start";
                    }

                    ImageBrush imgBrush = new ImageBrush();

                    //match found, place blank tile where TileTouched was
                    imgBrush.ImageSource = new BitmapImage(new Uri($"ms-appx:///tiles/{blankRect.Tag}.jpg"));
                    tiles.rectList[rectTouchedIndex].Fill = imgBrush;
                    string touchedTag = (string)rectTouched.Tag;
                    tiles.rectList[rectTouchedIndex].Tag = blankRect.Tag;

                    ImageBrush imgBrush2 = new ImageBrush();
                    //place TileTouched where blank tile  was
                    imgBrush2.ImageSource = new BitmapImage(new Uri($"ms-appx:///tiles/{touchedTag}.jpg"));
                    tiles.rectList[blankIndex].Fill = imgBrush2;
                    tiles.rectList[blankIndex].Tag = touchedTag;

                    if (checkWin())  //check if tiles are in the right order to win the game
                    {
                        gameOver();  //game is over
                    }
                }
            }
           
                       

        }
        //------------------------------- switch tile --------------------------------


        //game is over

        //Name   :  gameOver
        //Purpose : to stop the timer, prompt the user for their name using a new window and reseting the game values
        //Inputs  : none
        //Outputs : NONE
        //Returns : void
        async void gameOver()
        {
            gameTimer.Stop();       //stop timer
           

            if (winnerWindow == null)
            {
                winnerWindow = await AppWindow.TryCreateAsync();
                winnerWindow.Closed += delegate { winnerWindow = null; appWindowFrame.Content = null; };
                appWindowFrame.Navigate(typeof(WinnerPage));

                ElementCompositionPreview.SetAppWindowContent(winnerWindow, appWindowFrame);
            }

            // Now show the window
            await winnerWindow.TryShowAsync();

            gameMode = "off";
            tiles.Timer = $"Timer : 00:00";
        }

        //Name   :  getUserName
        //Purpose : to manage the Leaderboard and get the userName from the secondary window
        //Inputs  : string      userInput        name of player
        //Outputs : NONE
        //Returns : bool   true id winner false otherwise
        public async void getUserName(string userInput)
        {
            topTenList = "";
            playerName = userInput;
            int CurrentTotalTime = player.totalSeconds(timerMins, timerSecs);  //get current total time in seconds

            player temp = new player();  //temporary player object

            temp.PlayerName = playerName;
            temp.Mins = timerMins;
            temp.Secs = timerSecs;
            temp.Final_time_in_secs = CurrentTotalTime;

            if (players.topTenPlayers.Count <= TOP_TEN) //add if top10 list is not full
            {
                players.topTenPlayers.Add(temp);
                players.topTenPlayers = player.OrderByTime(players.topTenPlayers, out topTenList); //sort the list by time , output string to update UI
            }
            else  //list is full
            {                           
              
                foreach (player p in players.topTenPlayers)  // add/update list
                {
                    if (temp.Final_time_in_secs < p.Final_time_in_secs) //check if player is faster than other on the list
                    {
                        players.topTenPlayers.Add(temp);
                        break;                    
                      
                    }
                }

                players.topTenPlayers = player.OrderByTime(players.topTenPlayers, out topTenList); //sort the list by time, output string to update UI
                if (players.topTenPlayers.Count > TOP_TEN)
                {
                    players.topTenPlayers.RemoveAt(TOP_TEN); //extra player at position 11 on list
                }
                
            }

            top10List_Box.Text = topTenList;  //update UI value
            timerSecs = 0;                    //reset seconds in the timer
            timerMins = 0;                    //reset the minutes in the timer

            //check if 2nd window is open
            if (winnerWindow.IsVisible)
            {
                //close window
                await winnerWindow.CloseAsync();
            }
        }



        //------------------------------- SUSPEND SAVE DATA --------------------------------

      
        //Name   :  App_Suspending()
        //Purpose : to save current app values when the app goes in suspend state
        //Inputs  : string      userInput        name of player
        //Outputs : NONE
        //Returns : bool   true id winner false otherwise
        public void App_Suspending()
        {
            ApplicationDataCompositeValue composite = new ApplicationDataCompositeValue();
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;


            composite = new ApplicationDataCompositeValue();
            composite["t1"] = $"/tiles/{tiles.rectList[0].Tag.ToString()}.jpg";
            composite["t2"] = $"/tiles/{tiles.rectList[1].Tag.ToString()}.jpg";
            composite["t3"] = $"/tiles/{tiles.rectList[2].Tag.ToString()}.jpg";
            composite["t4"] = $"/tiles/{tiles.rectList[3].Tag.ToString()}.jpg";
            composite["t5"] = $"/tiles/{tiles.rectList[4].Tag.ToString()}.jpg";
            composite["t6"] = $"/tiles/{tiles.rectList[5].Tag.ToString()}.jpg";
            composite["t7"] = $"/tiles/{tiles.rectList[6].Tag.ToString()}.jpg";
            composite["t8"] = $"/tiles/{tiles.rectList[7].Tag.ToString()}.jpg";
            composite["t9"] = $"/tiles/{tiles.rectList[8].Tag.ToString()}.jpg";
            composite["t10"] = $"/tiles/{tiles.rectList[9].Tag.ToString()}.jpg";
            composite["t11"] = $"/tiles/{tiles.rectList[10].Tag.ToString()}.jpg";
            composite["t12"] = $"/tiles/{tiles.rectList[11].Tag.ToString()}.jpg";
            composite["t13"] = $"/tiles/{tiles.rectList[12].Tag.ToString()}.jpg";
            composite["t14"] = $"/tiles/{tiles.rectList[13].Tag.ToString()}.jpg";
            composite["t15"] = $"/tiles/{tiles.rectList[14].Tag.ToString()}.jpg";
            composite["t16"] = $"/tiles/{tiles.rectList[15].Tag.ToString()}.jpg";
            composite["Timer"] = tiles.Timer;
            composite["tag1"] = tiles.rectList[0].Tag;
            composite["tag2"] = tiles.rectList[1].Tag;
            composite["tag3"] = tiles.rectList[2].Tag;
            composite["tag4"] = tiles.rectList[3].Tag;
            composite["tag5"] = tiles.rectList[4].Tag;
            composite["tag6"] = tiles.rectList[5].Tag;
            composite["tag7"] = tiles.rectList[6].Tag;
            composite["tag8"] = tiles.rectList[7].Tag;
            composite["tag9"] = tiles.rectList[8].Tag;
            composite["tag10"] = tiles.rectList[9].Tag;
            composite["tag11"] = tiles.rectList[10].Tag;
            composite["tag12"] = tiles.rectList[11].Tag;
            composite["tag13"] = tiles.rectList[12].Tag;
            composite["tag14"] = tiles.rectList[13].Tag;
            composite["tag15"] = tiles.rectList[14].Tag;
            composite["tag16"] = tiles.rectList[15].Tag;
            composite[$"playerTopList"] = topTenList;


            int numOfPlayers = 0;
            for (numOfPlayers = 0; numOfPlayers < players.topTenPlayers.Count; numOfPlayers++)
            {
                composite[$"playerName{numOfPlayers + 1}"] = players.topTenPlayers[numOfPlayers].PlayerName;
                composite[$"totalSecs{numOfPlayers + 1}"] = players.topTenPlayers[numOfPlayers].Final_time_in_secs;
                composite[$"mins{numOfPlayers + 1}"] = players.topTenPlayers[numOfPlayers].Mins;
                composite[$"secs{numOfPlayers + 1}"] = players.topTenPlayers[numOfPlayers].Secs;
            }

            composite["numOfPlayers"] = numOfPlayers;
            localSettings.Values["Tiles"] = composite;
        //}
          
        }


        //------------------------------- SUSPEND SAVE DATA --------------------------------

     
    }
}
