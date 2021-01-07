/*
* FILE : tiles
* PROJECT : PROG2001 - Assignment #7
* PROGRAMMER : Janeth Santos and Hongsik Eom
* FIRST VERSION : December 10, 2020
* DESCRIPTION :
* this file contains the tiles class and data binding methods
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace A7_TilePuzzleGame
{
    //NAME : MainPAge
    //PURPOSE : it's main purpose is to keep track of tiles on the game
    public class Tiles : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Tiles ()  {

            t1 = "/tiles/t1x.jpg";           // represents the tile 1
            t2 = "/tiles/t2x.jpg";           // represents the tile 2
            t3 = "/tiles/t3x.jpg";           // represents the tile 3
            t4 = "/tiles/t4x.jpg";           // represents the tile 4
            t5 = "/tiles/t5x.jpg";           // represents the tile 5
            t6 = "/tiles/t6x.jpg";           // represents the tile 6
            t7 = "/tiles/t7x.jpg";           // represents the tile 7
            t8 = "/tiles/t8x.jpg";           // represents the tile 8
            t9 = "/tiles/t9x.jpg";           // represents the tile 9
            t10 = "/tiles/t10x.jpg";          // represents the tile 10
            t11 = "/tiles/t11x.jpg";          // represents the tile 11
            t12 = "/tiles/t12x.jpg";          // represents the tile 12
            t13 = "/tiles/t13x.jpg";          // represents the tile 13
            t14 = "/tiles/t14x.jpg";          // represents the tile 14
            t15 = "/tiles/t15x.jpg";          // represents the tile 15
            t16 = "/tiles/t16x.jpg";          // represents the tile 16

            recTagList = new string[] { "t1", "t2", "t3", "t4", "t5", "t6", "t7", "t8", "t9", "t10", "t11", "t12", "t13", "t14", "t15", "t16" };

            rectList = new List<Rectangle>();

            for (int i = 0; i < 16; i++)
            {
                Rectangle tempRect = new Rectangle(); 
                tempRect.Name = $"r{i}";
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri($"ms-appx:///tiles/{recTagList[i]}.jpg"));
                tempRect.Fill = imageBrush;
                tempRect.Tag = recTagList[i];
                rectList.Add(tempRect);
            }
        }

        public List<Rectangle> rectList;
        public string[] recTagList;


        public string timer;        //represents the timer on the game
        public string t1;           // represents the tile 1
        public string t2;           // represents the tile 2
        public string t3;           // represents the tile 3
        public string t4;           // represents the tile 4
        public string t5;           // represents the tile 5
        public string t6;           // represents the tile 6
        public string t7;           // represents the tile 7
        public string t8;           // represents the tile 8
        public string t9;           // represents the tile 9
        public string t10;          // represents the tile 10
        public string t11;          // represents the tile 11
        public string t12;          // represents the tile 12
        public string t13;          // represents the tile 13
        public string t14;          // represents the tile 14
        public string t15;          // represents the tile 15
        public string t16;          // represents the tile 16


            /*
        Name	: T1 -- Property
        Purpose : to get or set the value of the private attribute "T1" 
                 data binding is implemented
        Inputs	:	value
        Outputs	:	NONE
        Returns	: string - private attribute "T1"
        */
        public string T1
        {
            get { return t1; }
            set
            {
                t1 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T1");
                PropertyChanged?.Invoke(this, args);
            }
        }

                /*
         Name	: Timer -- Property
         Purpose : to get or set the value of the private attribute "Timer" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "Timer"
         */
        public string Timer
        {
            get { return timer; }
            set
            {
                timer = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Timer");
                PropertyChanged?.Invoke(this, args);
            }
        }

                /*
         Name	: T2 -- Property
         Purpose : to get or set the value of the private attribute "T2" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T2"
         */
        public string T2
        {
            get { return t2; }
            set
            {
                t2 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T2");
                PropertyChanged?.Invoke(this, args);
            }
        }
                /*
         Name	: T3 -- Property
         Purpose : to get or set the value of the private attribute "T3" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T3"
         */
        public string T3
        {
            get { return t3; }
            set
            {
                t3 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T3");
                PropertyChanged?.Invoke(this, args);
            }
        }
                /*
         Name	: T4 -- Property
         Purpose : to get or set the value of the private attribute "T4" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T4"
         */
        public string T4
        {
            get { return t4; }
            set
            {
                t4 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T4");
                PropertyChanged?.Invoke(this, args);
            }
        }

        /*
        Name	: T5 -- Property
        Purpose : to get or set the value of the private attribute "T5" 
                 data binding is implemented
        Inputs	:	value
        Outputs	:	NONE
        Returns	: string - private attribute "T5"
        */
        public string T5
        {
            get { return t5; }
            set
            {
                t5 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T5");
                PropertyChanged?.Invoke(this, args);
            }
        }

        /*
        Name	: T6 -- Property
        Purpose : to get or set the value of the private attribute "T6" 
                 data binding is implemented
        Inputs	:	value
        Outputs	:	NONE
        Returns	: string - private attribute "T6"
        */
        public string T6
        {
            get { return t6; }
            set
            {
                t6 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T6");
                PropertyChanged?.Invoke(this, args);
            }
        }

        /*
      Name	: T7 -- Property
      Purpose : to get or set the value of the private attribute "T7" 
               data binding is implemented
      Inputs	:	value
      Outputs	:	NONE
      Returns	: string - private attribute "T7"
      */
        public string T7
        {
            get { return t7; }
            set
            {
                t7 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T17");
                PropertyChanged?.Invoke(this, args);
            }
        }

        /*
          Name	: T8 -- Property
          Purpose : to get or set the value of the private attribute "T8" 
                   data binding is implemented
          Inputs	:	value
          Outputs	:	NONE
          Returns	: string - private attribute "T8"
          */
        public string T8
        {
            get { return t8; }
            set
            {
                t8 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T8");
                PropertyChanged?.Invoke(this, args);
            }
        }

        /*
            Name	: T9 -- Property
            Purpose : to get or set the value of the private attribute "T9" 
                     data binding is implemented
            Inputs	:	value
            Outputs	:	NONE
            Returns	: string - private attribute "T9"
            */
        public string T9
        {
            get { return t9; }
            set
            {
                t9 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T9");
                PropertyChanged?.Invoke(this, args);
            }
        }

            /*
         Name	: T10 -- Property
         Purpose : to get or set the value of the private attribute "T10" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T10"
         */
        public string T10
        {
            get { return t10; }
            set
            {
                t10 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T10");
                PropertyChanged?.Invoke(this, args);
            }
        }

            /*
         Name	: T11 -- Property
         Purpose : to get or set the value of the private attribute "T11" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T11"
         */
        public string T11
        {
            get { return t11; }
            set
            {
                t11 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T11");
                PropertyChanged?.Invoke(this, args);
            }
        }


            /*
         Name	: T12 -- Property
         Purpose : to get or set the value of the private attribute "T12" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T12"
         */
        public string T12
        {
            get { return t12; }
            set
            {
                t12 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T12");
                PropertyChanged?.Invoke(this, args);
            }
        }

            /*
         Name	: T13 -- Property
         Purpose : to get or set the value of the private attribute "T13" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T13"
         */
        public string T13
        {
            get { return t13; }
            set
            {
                t13 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T13");
                PropertyChanged?.Invoke(this, args);
            }
        }


            /*
         Name	: T14 -- Property
         Purpose : to get or set the value of the private attribute "T14" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T14"
         */
        public string T14
        {
            get { return t14; }
            set
            {
                t14 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T14");
                PropertyChanged?.Invoke(this, args);
            }
        }

            /*
         Name	: T15 -- Property
         Purpose : to get or set the value of the private attribute "T15" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T15"
         */
        public string T15
        {
            get { return t15; }
            set
            {
                t15 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T15");
                PropertyChanged?.Invoke(this, args);
            }
        }

            /*
         Name	: T16 -- Property
         Purpose : to get or set the value of the private attribute "T16" 
                  data binding is implemented
         Inputs	:	value
         Outputs	:	NONE
         Returns	: string - private attribute "T16"
         */
        public string T16
        {
            get { return t16; }
            set
            {
                t16 = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("T16");
                PropertyChanged?.Invoke(this, args);
            }
        }

    }
}
