using System;
using System.Collections.Generic;
using System.Text;
using MzansiGopro.Models;

namespace MzansiGopro.ViewModels.BusinessVM
{
   public class BusinessOfferEditViewModel : BaseViewModel
    {

        string offerName;
        string layout;
        List<Products> products;

        public BusinessOfferEditViewModel()
        {
            GetData();
        }




        public string OfferName
        {
            get => offerName;
            set
            {
                SetProperty(ref offerName, value);
                OnPropertyChanged(nameof(OfferName));
            }
        }
        public string Layout
        {
            get => layout;
            set
            {
                SetProperty(ref layout, value);
                OnPropertyChanged(nameof(Layout));
            }
        }

        public List<Products> Products
        {
            get => products;
           
            set
            {
                SetProperty(ref products, value);
                OnPropertyChanged(nameof(Products));
            }
        }





        void GetData()
        {
            AdminBusinessViewModel admin = new AdminBusinessViewModel();
          var main =  admin.GetSelectedModel();

            OfferName = main.ListName;
            Products = main.Products;

                
        }

    }
}
