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

        public void GetLocalUser()
        {
            try
            {
                var dataPath = Path.Combine(FileSystem.AppDataDirectory, "User.db");
                var connections = new SQLiteConnection(dataPath);

                var table = connections.Table<User>();
                RunTimeUser = table.FirstOrDefault();
                
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
                var dataPath = Path.Combine(FileSystem.AppDataDirectory, "User.db");
               var connections = new SQLiteConnection(dataPath);

                connections.CreateTable<User>();
            connections.Insert(user);
                
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Could not add user to local DB{ex.Message}", "OK");
            }
            
        }





    }
}
