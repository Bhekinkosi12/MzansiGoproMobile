using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MzansiGopro.Models
{
   public class User
    {

        public int ID { get; set; }
        public string AutomatedId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public string PasswordConfigID { get; set; }
        public bool IsShop { get; set; }
        public string Location { get; set; }
        public string CompanyName { get; set; }
        public string ProfilePicture { get; set; }
        public string Poster { get; set; }
        public string EventsID { get; set; }
        public string Bio { get; set; }
        public string Layout { get; set; }
        public string AppVersion { get; set; }
        public bool IsDemo { get; set; }
        public string BusinessID { get; set; }
        public List<string> StoreImage { get; set; }
        public Dictionary<string, DateTime> Dates { get; set; }
        public Hashtable PuductsList { get; set; }
    }
}
