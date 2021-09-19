using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MzansiGopro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

using Plugin.Geolocator;

namespace MzansiGopro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //a();
            currentLocation();
           
            
        }
        

        private async void login_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }


       async void currentLocation()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
        }


        void a()
        {

            var locator = CrossGeolocator.Current;

            




        }

        private void Pin_InfoWindowClicked(object sender, PinClickedEventArgs e)
        {
            
        }

        private void visit_Clicked(object sender, EventArgs e)
        {
          


        }

        private void shopT_Tapped(object sender, EventArgs e)
        {
            var vm = BindingContext as ShopViewModel;
            var location = vm.CurrentLocation.Split(';');
            
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(double.Parse(location[0]), double.Parse(location[1])), Distance.FromMeters(3)));


        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {

             if(e.ScrollY < 0)
            {
                mapRow.Height = 200;
            }
            else
            {


                double height = 200 - e.ScrollY;

                if(height > 120)
                {
                mapRow.Height = height;

                }
                else
                {
                    mapRow.Height = 120;
                }






            }
        }

        private void showStores_Tapped(object sender, EventArgs e)
        {
            showStoresFrame.IsVisible = false;
            storesFrame.IsVisible = true;
            storesRow.Height = 250;
        }

        private void hideStores_Clicked(object sender, EventArgs e)
        {
            if (storesRow.Height.Value != 520)
            {


                showStoresFrame.IsVisible = true;
                storesFrame.IsVisible = false;
                storesRow.Height = 50;
            }
            else
            {
        
                storesRow.Height = 250;
               
                
            }
        }

        private void search_Clicked(object sender, EventArgs e)
        {
            if(searchBar.IsVisible == true)
            {

            searchBar.IsVisible = false;
                searchRow.Height = 0;
                
            }
            else
            {
                searchBar.IsVisible = true;
                searchRow.Height = 80;
            }
            
        }

        private async void growBTN_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CompanyListPage");

        }
    }
}