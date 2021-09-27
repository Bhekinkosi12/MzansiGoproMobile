using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MzansiGopro.ViewModels.EventsVM.AdminEventsVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MzansiGopro.Views.EventsV.AdminEventsV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAddEventPage : ContentPage
    {
        public MainAddEventPage()
        {
            InitializeComponent();
        }

        private async void cancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            var model = BindingContext as AdminEventsViewModel;

            if (!string.IsNullOrEmpty(model.Cover) && !string.IsNullOrEmpty(model.Name) && !string.IsNullOrEmpty(model.Location) )
            {
                model.OnAddEvent();
            }
            else
            {

            }
            


        }
    }
}