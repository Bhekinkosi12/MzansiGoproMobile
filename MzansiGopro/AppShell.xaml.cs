using MzansiGopro.ViewModels;
using MzansiGopro.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MzansiGopro.Views.EventsV;
using MzansiGopro.Views.AuthenticationV;
using MzansiGopro.Views.CompanyV;

namespace MzansiGopro
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //  Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            //  Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
            Routing.RegisterRoute(nameof(StoreSetupPage), typeof(StoreSetupPage));
            Routing.RegisterRoute(nameof(CompanyListPage), typeof(CompanyListPage));
            Routing.RegisterRoute(nameof(EventsListPage), typeof(EventsListPage));
            Routing.RegisterRoute(nameof(CompanyMainPage), typeof(CompanyMainPage));
            Routing.RegisterRoute(nameof(BusinessOfferEditPage), typeof(BusinessOfferEditPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
