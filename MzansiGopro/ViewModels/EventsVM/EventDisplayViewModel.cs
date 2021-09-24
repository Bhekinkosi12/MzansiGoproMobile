using System;
using System.Collections.Generic;
using System.Text;

namespace MzansiGopro.ViewModels.EventsVM
{
   public class EventDisplayViewModel : BaseViewModel
    {

        string location;
        string image;


        public EventDisplayViewModel()
        {
            GetEvent();
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


        public string Image
        {
            get => image;
            set
            {
                SetProperty(ref image, value);
                OnPropertyChanged(nameof(Image));
            }
        }




        void GetEvent()
        {
            EventsListViewModel eventsList = new EventsListViewModel();
            var events = eventsList.GetSelectedEvent();

            Location = events.Location;
            Image = events.Cover;
        }


    }
}
