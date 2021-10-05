using System;
using System.Collections.Generic;
using System.Text;
using MzansiGopro.Models;
using System.Collections.ObjectModel;

namespace MzansiGopro.Services.EventsSV
{
   public class EventsServices
    {
        List<Events> Eventslist { get; set; }
        List<News> NewsEvents { get; set; }

        


        public EventsServices()
        {
            tempData();
            welcomeNews();
           // eventData();
        }

        void tempData()
        {

            Eventslist = new List<Events>()
            {
                new Events
                {
                     Cover = "event1.jpg",
                     Name = "Enumbeni Launch",
                      Location = "-26.5476126;29.0822674",
                       ID = Guid.NewGuid().ToString(),
                       
                },new Events
                {
                     Cover = "event2.jpg",
                      Location = "-26.5475326;29.0822629",
                      Name = "Enumbeni Launch",
                       ID = Guid.NewGuid().ToString(),
                       
                },new Events
                {
                     Cover = "event3.jpg",
                      Location = "-26.5776126;29.0322674",
                      Name = "Enumbeni Launch",
                       ID = Guid.NewGuid().ToString(),
                       
                }
            };
        }        

       async void eventData()
        {
            List<Events> _events = new List<Events>();
            UserDataBase userData = new UserDataBase();

           var items = await userData.GetAllEvents();

            foreach(var i in items)
            {
                _events.Add(i);
            }

            Eventslist = _events;


        }


        void welcomeNews()
        {
            NewsEvents = new List<News>()
            {
                new News
                {
                     Author = "Mzansi Go pro",
                      Cover = "shisa1.jpg",
                      DatePosted = new DateTime(2021,10,1),
                       ID = "Mzansi",
                        Message = "Welcome to the new launch of our Mzansi Go pro solution",
                        Heading = "Welcome to Mzansi Go pro"
                }
            };
        }





        public List<Events> GetAllEvents()
        {
            return Eventslist;
        }

        public List<News> GetAllNews()
        {
            return NewsEvents;
        }







    }
}
