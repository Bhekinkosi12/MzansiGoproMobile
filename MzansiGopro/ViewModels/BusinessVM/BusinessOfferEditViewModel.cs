using System;
using System.Collections.Generic;
using System.Text;
using MzansiGopro.Models;
using MzansiGopro.Models.microModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MzansiGopro.ViewModels.BusinessVM
{
   public class BusinessOfferEditViewModel : BaseViewModel
    {

        string offerName;
        string layout;
        List<Products> products;
        Products selectedProduct;



        string selectedImage;
        string selectedName;
        string selectedPrice;
        bool isSelected = false;

        string offerInput;



        ObservableCollection<offer> offer;



        public Command<Products> SelectItem { get; set; }
        public Command AddItem { get; }
        public BusinessOfferEditViewModel()
        {
            defaultItem();
            GetData();
            SelectItem = new Command<Products>(OnSelectItem);
            AddItem = new Command(onAddItem);
          
            
        }

        public string OfferInput
        {
            get => offerInput;
            set
            {
                SetProperty(ref offerInput, value);
                OnPropertyChanged(nameof(OfferInput));
            }
        }

        public ObservableCollection<offer> Offer
        {
            get => offer;
            set
            {
                SetProperty(ref offer, value);
                OnPropertyChanged(nameof(Offer));
            }
        }


        public bool IsSelected
        {
            get => isSelected;
            set
            {
                SetProperty(ref isSelected, value);
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public string SelectedImage
        {
            get => selectedImage;
            set
            {
                SetProperty(ref selectedImage, value);
                OnPropertyChanged(nameof(SelectedImage));

            }
        }
        public string SelectedName
        {
            get => selectedName;
            set
            {
                SetProperty(ref selectedName, value);
                OnPropertyChanged(nameof(SelectedName));
            }
        }
        public string SelectedPrice
        {
            get => selectedPrice;
            set
            {
                SetProperty(ref selectedPrice, value);
                OnPropertyChanged(nameof(SelectedPrice));
            }
        }


        public Products SelectedProduct
        {
            get => selectedProduct;
            set
            {
                SetProperty(ref selectedProduct, value);
                OnPropertyChanged(nameof(SelectedProduct));
            }
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
            Layout = main.Layout;

                
        }
        

        void OnSelectItem(Products product)
        {
            if (products == null)
                return;

            IsSelected = true;
            SelectedImage = product.Image;
            SelectedName = product.Name;
            SelectedPrice = product.Price.ToString();

        }



        void defaultItem()
        {
            if (Offer == null)
            {
                Offer = new ObservableCollection<offer>()
                {
                    new offer
                    {
                        Name = "Add"
                    }
                };
            }

          

        }




        void onAddItem()
        {

            var item = new offer()
            {
                Name = "Add"
            };

            ObservableCollection<offer> _offer = new ObservableCollection<offer>();


            if (OfferInput != null || OfferInput.Length > 0)
            {
                var Currentitem = new offer()
                {
                    Name = OfferInput
                };

                var firstItem = Offer[0];

                if (firstItem.Name == "Add")
                {
                    Offer.Clear();
                    Offer = _offer;
                    Offer.Add(Currentitem);



                }
                else
                {
                    Offer.Add(Currentitem);


                }



                OfferInput = "";


            }
            else
            {

            }

        }


    }
}
