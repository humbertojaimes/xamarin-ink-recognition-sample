using System;
using InkRecognizer.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InkRecognizer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SignaturePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
