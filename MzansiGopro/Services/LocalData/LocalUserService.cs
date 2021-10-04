using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Essentials;
using System.IO;
using MzansiGopro.Models;
using MzansiGopro.ViewModels;
using Xamarin.Forms;

namespace MzansiGopro.Services.LocalData
{
   public class LocalUserService : BaseViewModel
    {

        SQLiteConnection connection;

        public  LocalUserService()
        {


            var dataPath = Path.Combine(FileSystem.AppDataDirectory ,"User.db");
            connection = new SQLiteConnection(dataPath);
            
           


        }

       async void Init()
        {
            try
            {

                if (connection == null)
                {
                    connection.CreateTable<User>();
                    
                }
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Cant create local DB", "OK");
            }
        }

        public async void GetLocalUser()
        {
            try
            {
               var id = Preferences.Get("UserID", string.Empty);
                UserDataBase dataBase = new UserDataBase();

                var user = await dataBase.GetUserById(id);

                if(user != null)
                {

                RunTimeUser = user;
                }

            }
            catch
            {
                RunTimeUser = null;
            }
        }

        public void UpdateUser(User user)
        {
            connection.DeleteAll<User>();
            connection.Insert(user);
        }

        public async void AddUser(User user)
        {
            try
            {
                Preferences.Set("UserID", user.AutomatedId);
                

                
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Could not add user to local DB{ex.Message}", "OK");
            }
            
        }





    }
}
