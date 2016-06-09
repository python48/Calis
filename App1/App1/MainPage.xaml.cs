using App1.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("Navigated");

            Start_timer();

            //await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            //() =>
            //{
            //    // Your UI update code goes here!
            //});
        }

        DispatcherTimer Timer;
        public void Start_timer()
        {
            Timer = new DispatcherTimer();
            Timer.Tick += timer_Tick;
            Timer.Interval = new TimeSpan(00, 0, 2);
            bool enabled = Timer.IsEnabled;
            Timer.Start();
        }
        
        void timer_Tick(object sender, object e)
        {
            Timer.Stop();
            goForward();
        }

        private void goForward()
        {
            Frame.Navigate(typeof(TermsAndConditionsPage));
        }
    }
}
