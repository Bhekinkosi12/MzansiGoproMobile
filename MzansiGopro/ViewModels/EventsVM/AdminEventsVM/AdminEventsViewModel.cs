using System;
using System.Collections.Generic;
using System.Text;
using MzansiGopro.Models;
using MzansiGopro.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using System.IO;


namespace MzansiGopro.ViewModels.EventsVM.AdminEventsVM
{
   public class AdminEventsViewModel : BaseViewModel
    {

        string name = "";
        string location = "";
        DateTime eventDate = new DateTime(2021, 08, 01);
        string cover = "";
        ObservableCollection<Events> hostedEvents = new ObservableCollection<Events>();




        public DateTime EventDate
        {
            get => eventDate;
            set
            {
                SetProperty(ref eventDate, value);
                OnPropertyChanged(nameof(EventDate));
            }
        }
        public string Cover
        {
            get => cover;
            set
            {
                SetProperty(ref cover, value);
                OnPropertyChanged(nameof(Cover));
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
        public string Location
        {
            get => location;
            set
            {
                SetProperty(ref location, value);
                OnPropertyChanged(nameof(Location));
                
            }
        }





        public ObservableCollection<Events> HostedEvents
        {
            get => hostedEvents;
            set
            {
                SetProperty(ref hostedEvents, value);
                OnPropertyChanged(nameof(HostedEvents));
            }
        }

        
        public async void OnLoadPage()
        {
            HostedEvents = new ObservableCollection<Events>();

            ObservableCollection<Events> _events = new ObservableCollection<Events>();

            try
            {

            foreach(var item in RunTimeUser.EventsHoted)
            {
                _events.Add(item);
            }

            HostedEvents = _events;
            }
            catch
            {

                var _user = RunTimeUser;

                _user.EventsHoted = new List<Events>();

                RunTimeUser = _user;



            }

        }



        public async void OnAddEvent()
        {

            var _event = new Events()
            {
                 Location = Location,
                  Name = Name,
                   Cover = Cover,
                    EventDateTime = EventDate
            };


            var _user = RunTimeUser;

            _user.EventsHoted.Add(_event);

            RunTimeUser = _user;


            UserDataBase userData = new UserDataBase();

            try
            {

           await userData.UpdateUserAsync(RunTimeUser);
                await Shell.Current.GoToAsync("..");
            }
            catch
            {
                await Shell.Current.DisplayAlert("Error", "Unexpected Error", "OK");

            }


            IsBusy = false;

        }




       public async void OnAddMediaCover()
        {
            IsBusy = true;

            UserDataStorage storage = new UserDataStorage();

            try
            {
                PickOptions pickOption = new PickOptions()
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Please select images or video"
                };
                var picked = await storage.PickMedia(pickOption, "nameAndemail");

                var file = await picked.OpenReadAsync();

                var link = await storage.AddStoreStream(RunTimeUser.Email, picked.FileName, file as FileStream);



                Cover = link;

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Unexpected Error", "OK");
            }

            IsBusy = false;


        }





    }
}
