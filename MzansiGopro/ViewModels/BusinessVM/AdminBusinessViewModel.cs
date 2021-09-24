using System;
using System.Collections.Generic;
using System.Text;
using MzansiGopro.Models.CollectiveModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MzansiGopro.Services.BusinessData;
using MzansiGopro.Services;

namespace MzansiGopro.ViewModels.BusinessVM
{
   public class AdminBusinessViewModel : BaseViewModel
    {

        public static ProductListModel OfferSelected { get; set; }
        public AdminBusinessViewModel()
        {
            //NewbusinessStart();
            // tempData();
            GetAdminShop();
             EditProductList = new Command<ProductListModel>(OnEditOffer);
        }

        string name;
        string coverImage;
        string location;
        string email; 
        string number;
        
       ObservableCollection<ProductListModel> productModel;
        ObservableCollection<ProductListModel> productModelList;

        public Command<ProductListModel> EditProductList { get; set; }



        public ObservableCollection<ProductListModel> ProductModelList
        {
            get => productModelList;
            set
            {
                SetProperty(ref productModelList, value);
                OnPropertyChanged(nameof(ProductModelList));

            }
        }
        public ObservableCollection<ProductListModel> Productmodel
        {
            get => productModel;
            set
            {
                SetProperty(ref productModel, value);
                OnPropertyChanged(nameof(Productmodel));
            }
        }


        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CoverImage
        {
            get => coverImage;
            set
            {
                SetProperty(ref coverImage, value);
                OnPropertyChanged(nameof(CoverImage));
            }
        }

        public string Location
        {
            get => location;
            set
            {
                SetProperty(ref location, value);
                OnPropertyChanged(nameof(Location));
            }
        }
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Number
        {
            get => number;
            set
            {
                SetProperty(ref number, value);
                OnPropertyChanged(nameof(Number));
            }
        }










       public void NewbusinessStart()
        {
            ObservableCollection<ProductListModel> proMV = new ObservableCollection<ProductListModel>();

            foreach (var offer in RunTimeBusiness.Offers)
            {
                var _offer = new ProductListModel()
                {
                     ListID = Guid.NewGuid().ToString(),
                      ListName = offer.Name,
                       Layout = "List"
                };
                proMV.Add(_offer);
            }

            Productmodel = proMV;

        }




      async void OnEditOffer(ProductListModel _productList)
        {
            if(_productList != null)
            {
                OfferSelected = _productList;
                await Shell.Current.GoToAsync("BusinessOfferEditPage");
            }
        }


        public ProductListModel GetSelectedModel()
        {
            return OfferSelected;
        }

        public async void SaveSelectedOffer(ProductListModel _productListModel)
        {
            IsBusy = true;
            Productmodel.Remove(OfferSelected);
            Productmodel.Add(_productListModel);

            RunTimeBusiness.BusinessOffers.OfferList.Add(_productListModel);

            UserDataBase dataBase = new UserDataBase();
            GetAdminShop();
            try
            {

           await dataBase.UpDateBusinessAsync(RunTimeBusiness);
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            


            IsBusy = false;
        }

      




      
        void GetAdminShop()
        {
         
            CoverImage = RunTimeBusiness.Cover_Img;
            Name = RunTimeBusiness.Name;
            Email = RunTimeBusiness.Email;
            Number = RunTimeBusiness.Number;



            ObservableCollection<ProductListModel> listModels = new ObservableCollection<ProductListModel>();

            foreach(var iten in RunTimeBusiness.BusinessOffers.OfferList)
            {
                listModels.Add(iten);
            }


            Productmodel = listModels;

        }



    }
}
