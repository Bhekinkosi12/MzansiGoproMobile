using System;
using System.Collections.Generic;
using System.Text;
using MzansiGopro.Services.EventsSV;
using System.Collections.ObjectModel;
using MzansiGopro.Models;
using Xamarin.Forms;

namespace MzansiGopro.ViewModels.EventsVM
{
   public class EventsListViewModel
    {

       public ObservableCollection<Events> EventsList { get; set; }
        public ObservableCollection<News> NewsList { get; set; }

        static Events SelectedEvent { get; set; }

        public Command<Events> SelectEvent { get; set; }

        public EventsListViewModel()
        {
            getData();
            getNews();

            SelectEvent = new Command<Events>(OnSelectEvent);
        }




        void getData()
        {
            EventsServices servers = new EventsServices();
            ObservableCollection<Events> events = new ObservableCollection<Events>();


            foreach(var even in servers.GetAllEvents())
            {
                events.Add(even);
            }

            EventsList = events;


        }

        void getNews()
        {
            EventsServices servers = new EventsServices();
            ObservableCollection<News> newslist = new ObservableCollection<News>();

            foreach(var news in servers.GetAllNews())
            {
                newslist.Add(news);
            }


            NewsList = newslist;

        }



        public Events GetSelectedEvent()
        {
            return SelectedEvent;
        }


       async void OnSelectEvent(Events _events){
            SelectedEvent = _events;
            await Shell.Current.GoToAsync("DisplayEventPage");
        }



    }
}
