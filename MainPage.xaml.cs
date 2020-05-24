using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using memoryTest.Models;
using System.Threading;

namespace memoryTest.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool runTestBool = true;
        public MainPage()
        {
            InitializeComponent();
            runTest();
        }

        private void runTest()
        {
            new Thread(() => 
            {
                while (runTestBool)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        for (int i = 0; i < 200; i++)
                        {
                            layout.Children.Add(new OuterFrame());
                        }
                    });
                    Thread.Sleep(4000);

                    Device.BeginInvokeOnMainThread(() => 
                    { 
                        //while (layout.Children.Count > 0)
                        //{
                        //    layout.Children.RemoveAt(0);
                        //}
                        layout.Children.Clear(); 
                    });

                    Thread.Sleep(4000);
                }
            }).Start();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            runTestBool = !runTestBool;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    layout.Children.Add(new OuterFrame());
                }
            });
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => 
            { 
                foreach (View item in layout.Children)
                {
                    OuterFrame frame = (OuterFrame)item;
                    frame.goodClean();
                }
                layout.Children.Clear();
            });
        }
    }
}