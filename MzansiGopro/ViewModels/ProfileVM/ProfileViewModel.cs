using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MzansiGopro.Services.LocalData;

namespace MzansiGopro.ViewModels.ProfileVM
{
   public class ProfileViewModel : BaseViewModel
    {

        bool isLogged = false;
        public bool IsLogged
        {
            get => isLogged;
            set
            {
                SetProperty(ref isLogged, value);
                OnPropertyChanged(nameof(IsLogged));
            }
        }
       

        public Command ToBusiness { get; }
        public Command ToEvents { get; }
        public Command LogOut { get; }

        public ProfileViewModel()
        {
            ToBusiness = new Command(OnToBusiness);
            ToEvents = new Command(OnTOEvent);
            LogOut = new Command(OnLogOut);

        }


        void OnLogOut()
        {
            LocalUserService localUser = new LocalUserService();
            localUser.ClearLocalDB();
        }

        public void OnIsLogged()
        {
            string name;
            try
            {
                if(!string.IsNullOrEmpty(RunTimeUser.Email))
                IsLogged = true;

            }
            catch
            {

                IsLogged = false;
            }

        
           
            
        }


       async void OnToBusiness()
        {
            if(RunTimeUser != null)
            {

                if(RunTimeBusiness != null)
                {
                    await Shell.Current.GoToAsync("CompanyMainPage");
                }
                else
                {
                    await Shell.Current.GoToAsync("StoreSetupPage");
                }



            }
            else
            {
                await Shell.Current.GoToAsync("LoginPage");
            }
        } 
        async void OnTOEvent()
        {
            if(RunTimeUser == null)
            {
                await Shell.Current.GoToAsync("LoginPage");
            }
            else
            {
                await Shell.Current.GoToAsync("MainAdminEventsPage");
            }
        }


    }
}
