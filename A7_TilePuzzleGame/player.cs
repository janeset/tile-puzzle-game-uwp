/*
* FILE : player
* PROJECT : PROG2001 - Assignment #7
* PROGRAMMER : Janeth Santos and Hongsik Eom
* FIRST VERSION : December 10, 2020
* DESCRIPTION :
* this file contains the player class and data binding methods
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

//NAME : MainPAge
//PURPOSE : it's main purpose is to keep track of players on the leaderboard
// saving their time and name
namespace A7_TilePuzzleGame
{
    public class player : INotifyPropertyChanged
    {
        //constants
        const int MAX_SECS = 60;                //Max number of seconds in 1 minute 
        const int TOP_TEN = 10;                 // max players on leaderboard


        public event PropertyChangedEventHandler PropertyChanged;

        //constructor
        public player()
        {
            playerName = "";
            mins = 0;
            secs = 0;
            final_time_in_secs = 0;
        }

        private string playerName;            //name of player
        private int final_time_in_secs;       //final time in seconds
        private int mins;                     // mins to finish the game
        private int secs;                     //seconds to finish the game 
        private string playerList;            //player list with leaderboard info used to update UI element

        public List<player> topTenPlayers;    //top 10 player on leaderboard




            /*
	    Name	: PlayerName -- Property
	    Purpose : to get or set the value of the private attribute "PlayerName" 
                 data binding is implemented
	    Inputs	:	value
	    Outputs	:	NONE
	    Returns	: string - private attribute "PlayerName"
        */
        public string PlayerName
        {
            get { return playerName; }
            set
            {
                playerName = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("PlayerName");
                PropertyChanged?.Invoke(this, args);
            }
        }


                /*
        Name	: Final_time_in_secs -- Property
        Purpose : to get or set the value of the private attribute "Final_time_in_secs" 
                 data binding is implemented
        Inputs	:	value
        Outputs	:	NONE
        Returns	: string - private attribute "Final_time_in_secs"
        */
        public int Final_time_in_secs
        {
            get { return final_time_in_secs; }
            set
            {
                final_time_in_secs = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Final_time_in_secs");
                PropertyChanged?.Invoke(this, args);
            }
        }

        /*
      Name	: Mins -- Property
      Purpose : to get or set the value of the private attribute "Mins" 
               data binding is implemented
      Inputs	:	value
      Outputs	:	NONE
      Returns	: string - private attribute "Mins"
      */
        public int Mins
        {
            get { return mins; }
            set
            {
                mins = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Mins");
                PropertyChanged?.Invoke(this, args);
            }
        }

        /*
      Name	: Secs -- Property
      Purpose : to get or set the value of the private attribute "Secs" 
               data binding is implemented
      Inputs	:	value
      Outputs	:	NONE
      Returns	: string - private attribute "Secs"
      */
        public int Secs
        {
            get { return secs; }
            set
            {
                secs = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Secs");
                PropertyChanged?.Invoke(this, args);
            }
        }

                /*
          Name	: PlayerList -- Property
          Purpose : to get or set the value of the private attribute "PlayerList" 
                   data binding is implemented
          Inputs	:	value
          Outputs	:	NONE
          Returns	: string - private attribute "PlayerList"
          */
        public string PlayerList
        {
            get { return playerList; }
            set
            {
                playerList = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("PlayerList");
                PropertyChanged?.Invoke(this, args);
            }
        }


        //Name   : totalSeconds
        //Purpose : convert the mins and secs from timer just to seconds
        //Inputs   : 
        //      int      min     mins on timer
        //      int      sec     seconds on timer
        //Outputs   : NONE
        //Returns   : int totalsecs    total time in seconds
        public static int totalSeconds(int min, int sec)
        {
            int totalSecs = 0;

            totalSecs = (min * MAX_SECS) + sec;

            return totalSecs;
        }


        //Name   : OrderByTime
        //Purpose : sorts the top10List using the totalTimeinSeconds , and updates a string with the result
        //Inputs   : 
        //      List<player>     sortedList      sortedList by player time
        //      string           top10list        contains the sortedList of player names and times
        //Outputs   : NONE
        //Returns   : List<player>     sortedList      sortedList by player time
        //            string           top10list       contains the sortedList of player names and times
        public static List<player> OrderByTime(List<player> top10players, out string updatedStrList)
        {
            List<player> sortedList = top10players.OrderBy(player => player.final_time_in_secs).ToList(); //create sorted list
            int rank = 1;
            string rankList = "";

            IEnumerable<player> query = top10players.OrderBy(player => player.final_time_in_secs);  //orders by increment 

            foreach (player p in query) //update string
            {
                if (rank <= TOP_TEN)
                {
                    rankList += $"# {rank}- {p.playerName} \t {p.mins.ToString("D2")}:{p.secs.ToString("D2")}\n";
                }

                rank++;
            }

            updatedStrList = rankList;
            return sortedList;
        }

    }
}
