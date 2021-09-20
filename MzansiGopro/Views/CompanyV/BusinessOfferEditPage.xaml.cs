using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MzansiGopro.ViewModels.BusinessVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MzansiGopro.Views.CompanyV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessOfferEditPage : ContentPage
    {
        public BusinessOfferEditPage()
        {
            InitializeComponent();
        }

        private void editName_Tapped(object sender, EventArgs e)
        {
            if(labelEdit.Text == "Edit")
            {
                labelEdit.Text = "Done";
                labelOfferFrame.IsVisible = false;
                editNameFrame.IsVisible = true;
            }
            else
            {
                labelEdit.Text = "Edit";
                labelOfferFrame.IsVisible = true;
                editNameFrame.IsVisible = false;
            }
        }

        private void productsave_Clicked(object sender, EventArgs e)
        {
            var model = BindingContext as BusinessOfferEditViewModel;

            model.IsSelected = false;
        }

        private void productCancel_Clicked(object sender, EventArgs e)
        {
            var model = BindingContext as BusinessOfferEditViewModel;

            model.IsSelected = false;
        }
    }
}