using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MzansiGopro.Views.CompanyV;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MzansiGopro.Views.ProfileV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainUserProfilePage : ContentPage
    {
        public MainUserProfilePage()
        {
            InitializeComponent();
        }

        private async void business_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CompanyMainPage");
        }

        private async void events_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MainAdminEventsPage");
        }
    }
}