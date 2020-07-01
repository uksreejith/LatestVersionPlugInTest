using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LatestVersion;
using Xamarin.Forms;

namespace LatestVersionPlugInTest
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void btnTest_Clicked(object sender, EventArgs e)
        {
            try
            {
                string latestVersionNumber = await CrossLatestVersion.Current.GetLatestVersionNumber();
                string installedVersionNumber = CrossLatestVersion.Current.InstalledVersionNumber;
                bool isLatest = await CrossLatestVersion.Current.IsUsingLatestVersion();

                var displayText = $"Latest Version: {latestVersionNumber} | Installed Version: {installedVersionNumber} | Is Latest: {isLatest}";

                await DisplayAlert("Test", displayText, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Test", ex.Message, "OK");
            }
        }

        private async void btnOpenStore_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossLatestVersion.Current.OpenAppInStore();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Test", ex.Message, "OK");
            }
        }
    }
}
