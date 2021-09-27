using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using MzansiGopro.Models.microModel;

namespace MzansiGopro.ViewModels.EventsVM
{
   public class EventDisplayViewModel : BaseViewModel
    {

        string location;
        string image;
        string name;
        ObservableCollection<Pin> pins = new ObservableCollection<Pin>();

        public EventDisplayViewModel()
        {
            GetEvent();
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


        public string Image
        {
            get => image;
            set
            {
                SetProperty(ref image, value);
                OnPropertyChanged(nameof(Image));
            }
        }

       public ObservableCollection<Pin> Pins
        {
            get => pins;
            set
            {
                SetProperty(ref pins, value);
                OnPropertyChanged(nameof(Pins));
            }
        }



        void GetEvent()
        {
            EventsListViewModel eventsList = new EventsListViewModel();
            ObservableCollection<Pin> _pins = new ObservableCollection<Pin>();
            var events = eventsList.GetSelectedEvent();

            Location = events.Location;
            Image = events.Cover;


            var location = events.Location.Split(';');
            Pin pin = new Pin()
            {
                Address = "Upcoming",
                Label = "Endubeni",
                Position = new Position(double.Parse(location[0]), double.Parse(location[1])),
                Type = PinType.Place


            };

            _pins.Add(pin);
            Pins = _pins;

            


        }


    }
}
