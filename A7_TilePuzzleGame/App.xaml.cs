/*
* FILE : MainPage.xaml
* PROJECT : PROG2001 - Assignment #7
* PROGRAMMER : Janeth Santos and Hongsik Eom
* FIRST VERSION : December 10, 2020
* DESCRIPTION :
* this file contains logic for the life cycle of the application.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

namespace A7_TilePuzzleGame
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public player players;
        public Tiles tiles;
        public int timeSecs;
        public int timeMins;
        public string topTenList;

        public string[] tags;
        ApplicationDataCompositeValue composite;


        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            tiles = new Tiles();
            players = new player();
            players.topTenPlayers = new List<player>();
            tags = new string[16];
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            //main = (MainPage)rootFrame.Content;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated ||
                    e.PreviousExecutionState == ApplicationExecutionState.ClosedByUser ||
                     e.PreviousExecutionState == ApplicationExecutionState.Suspended)
                {
                    //TODO: Load state from previously suspended application
                    //ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                    composite = (ApplicationDataCompositeValue)localSettings.Values["Tiles"];

                    //main = new MainPage();

                    if (composite == null)
                    {
                        // No data
                    }
                    else
                    {
                        tiles.T1 = composite["t1"].ToString();
                        tiles.T2 = composite["t2"].ToString();
                        tiles.T3 = composite["t3"].ToString();
                        tiles.T4 = composite["t4"].ToString();
                        tiles.T5 = composite["t5"].ToString();
                        tiles.T6 = composite["t6"].ToString();
                        tiles.T7 = composite["t7"].ToString();
                        tiles.T8 = composite["t8"].ToString();
                        tiles.T9 = composite["t9"].ToString();
                        tiles.T10 = composite["t10"].ToString();
                        tiles.T11 = composite["t11"].ToString();
                        tiles.T12 = composite["t12"].ToString();
                        tiles.T13 = composite["t13"].ToString();
                        tiles.T14 = composite["t14"].ToString();
                        tiles.T15 = composite["t15"].ToString();
                        tiles.T16 = composite["t16"].ToString();
                        tiles.Timer = composite["Timer"].ToString();

                        if(topTenList != null)
                        {
                            topTenList = composite[$"playerTopList"].ToString();
                        }
        

                        timeMins =Convert.ToInt32( tiles.timer.Substring(8, 2));
                        timeSecs =Convert.ToInt32(tiles.timer.Substring(11, 2));




                        for (int index = 0; index < tags.Length; index++)
                        {
                            tags[index] = composite[$"tag{index + 1}"].ToString();
                        }


                        int numOfPlayers = Convert.ToInt32(composite["numOfPlayers"]);

                      
                        for (int i = 0; i < numOfPlayers; i++)
                        {
                            player temp = new player();

                            temp.PlayerName = composite[$"playerName{i + 1}"].ToString();
                            temp.Final_time_in_secs = Convert.ToInt32(composite[$"totalSecs{i + 1}"]);
                            temp.Mins = Convert.ToInt32(composite[$"mins{i + 1}"]);
                            temp.Secs = Convert.ToInt32(composite[$"secs{i + 1}"]);

                            players.topTenPlayers.Add(temp);
                        }


                    }
                }
                else
                {
                    tiles.T1 = "/tiles/t1.jpg";
                    tiles.T2 = "/tiles/t2.jpg";
                    tiles.T3 = "/tiles/t3.jpg";
                    tiles.T4 = "/tiles/t4.jpg";
                    tiles.T5 = "/tiles/t5.jpg";
                    tiles.T6 = "/tiles/t6.jpg";
                    tiles.T7 = "/tiles/t7.jpg";
                    tiles.T8 = "/tiles/t8.jpg";
                    tiles.T9 = "/tiles/t9.jpg";
                    tiles.T10 = "/tiles/t10.jpg";
                    tiles.T11 = "/tiles/t11.jpg";
                    tiles.T12 = "/tiles/t12.jpg";
                    tiles.T13 = "/tiles/t13.jpg";
                    tiles.T14 = "/tiles/t14.jpg";
                    tiles.T15 = "/tiles/t15.jpg";
                    tiles.T16 = "/tiles/t16.jpg";
                    tiles.Timer = "Timer : 00:00";
                    timeMins = Convert.ToInt32(tiles.timer.Substring(8, 2));
                    timeSecs = Convert.ToInt32(tiles.timer.Substring(11, 2));

                    for (int i = 0; i < tags.Length; i++)
                    {
                        tags[i] = $"t{i + 1}";
                    }



                    
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);

                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            Frame rootFrame = (Frame)Window.Current.Content;
            MainPage page = (MainPage)rootFrame.Content;

            page.App_Suspending();
            //var deferral = e.SuspendingOperation.GetDeferral();
            //deferral.Complete();
        }
    }
}
