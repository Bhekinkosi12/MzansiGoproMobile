using System;
using System.Collections.Generic;
using System.Text;
using MzansiGopro.Models;

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
        }

        void tempData()
        {

            Eventslist = new List<Events>()
            {
                new Events
                {
                     Cover = "shisa1.jpg",
                      Location = "",
                       ID = Guid.NewGuid().ToString(),
                       
                },new Events
                {
                     Cover = "shisa2.jpg",
                      Location = "",
                       ID = Guid.NewGuid().ToString(),
                       
                },new Events
                {
                     Cover = "shisa1.jpg",
                      Location = "",
                       ID = Guid.NewGuid().ToString(),
                       
                },new Events
                {
                     Cover = "shisa4.jpg",
                      Location = "",
                       ID = Guid.NewGuid().ToString(),
                       
                },new Events
                {
                     Cover = "shisa3.jpg",
                      Location = "",
                       ID = Guid.NewGuid().ToString(),
                       
                },
            };
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
