/*
* FILE : WinnerPage.xaml.cs
* PROJECT : PROG2001 - Assignment #7
* PROGRAMMER : Janeth Santos and Hongsik Eom
* FIRST VERSION : December 10, 2020
* DESCRIPTION :
* this file contains the WinnerWindow page logic of the application.
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
using System.Windows;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace A7_TilePuzzleGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WinnerPage : Page
    {
        Frame rootFrame = null;
        MainPage page = null;

        
        public WinnerPage()
        {
            this.InitializeComponent();

            rootFrame = (Frame)Window.Current.Content;
            page = (MainPage)rootFrame.Content;
            WinnerMsg_Box.Text = $"WINNER! CONGRATULATIONS!!\n\n Final Time was {page.timerMins.ToString("D2")}:{page.timerSecs.ToString("D2")} !";
        }


        //Name   : OK_Btn_Click
        //Purpose :purpose to retrieve user input
        //Inputs   : 
        //      object sender: sender object
        //      RoutedEventArgs e: Contains state information and event data associated with a routed event
        //Outputs   : NONE
        //Returns   : Void
        public void OK_Btn_Click(object sender, RoutedEventArgs e)
        {
            string dataName = "";
            dataName = EnterName_Box.Text;

            page.getUserName(dataName);          

        }
    }
}
