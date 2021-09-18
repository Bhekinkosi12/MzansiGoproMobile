using System;
using System.Collections.Generic;
using System.Text;
using MzansiGopro.Models.CollectiveModel;
using System.Collections.ObjectModel;


namespace MzansiGopro.ViewModels.BusinessVM
{
   public class AdminBusinessViewModel : BaseViewModel
    {


        public AdminBusinessViewModel()
        {
            //NewbusinessStart();
            tempData();
        }

        string name;
        string coverImage;
        string location;
        string email; 
        
        string number;
        BusinessOffers businessOffer;
       ObservableCollection<ProductListModel> productModel;
        ObservableCollection<ProductListModel> productModelList;


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





        void tempData()
        {

            Productmodel = new ObservableCollection<ProductListModel>()
            {
                new ProductListModel
                {
                     ListName = "Kota",
                     Products = new List<Models.Products>()
                     {
                         new Models.Products
                         {
                              Image = "shisa1.jpg",
                               Name="Mandi",
                                Price = 30.5,
                                
                         },
                         new Models.Products
                         {
                              Image = "shisa3.jpg",
                               Name="Mandi",
                                Price = 20.5,
                                
                         },
                     }
                },
                new ProductListModel
                {
                     ListName = "Shisa Nyama",
                     Products = new List<Models.Products>()
                     {
                         new Models.Products
                         {
                              Image = "shisa1.jpg",
                               Name="Mandi",
                                Price = 30.5,
                                
                         },
                         new Models.Products
                         {
                              Image = "shisa3.jpg",
                               Name="Beaf",
                                Price = 20.5,
                                
                         },
                     }
                },
            };
        }






    }
}
