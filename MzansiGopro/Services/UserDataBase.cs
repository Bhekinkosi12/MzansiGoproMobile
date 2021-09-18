using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using MzansiGopro.Models;
using MzansiGopro.Models.microModel;
using SQLite;
using Xamarin.Forms;

namespace MzansiGopro.Services
{
   public class UserDataBase
    {
        FirebaseClient client;

        public UserDataBase()
        {
          //  var auth = "kasiT";

            /*
            client = new FirebaseClient("https://mzansi-go-pro-default-rtdb.firebaseio.com/", new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(auth)
            }) ;
            */

            client = new FirebaseClient("https://mzansi-go-pro-default-rtdb.firebaseio.com/");
        }



        public async Task<List<User>> GetAllPersons()
        {

            return (await client
              .Child("Users")
              .OnceAsync<User>()).Select(item => new User
              {
                  Name = item.Object.Name,
                  
              }).ToList();
        }

        public async Task AddPerson(string user)
        {

            await client
              .Child("Users")
              .PostAsync(new User() {  Name = "Bheki", Email = "ndumiso@gmail.com" });
        }


        public async Task<bool> AddUserAsync(User user)
        {
            try
            {


               
                    await client
                   .Child("Users")
                   .Child("NotBusiness")
                   .PostAsync(user);
                
                    return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }

        }


        public async Task AddEmailAndPassword(string email,string password,bool isShop)
        {
            var auth = new Authentication()
            {
                 Email = email,
                 Password = password,
                 IsShop = isShop
            };

            await client
                .Child("Authentications")
                .PostAsync(auth);
        }

     
        public async Task<Authentication> CheckEmailAndPass(string email, string password)
        {

           var user = (await client
                 .Child("Authentications")
                 .OnceAsync<Authentication>()).Where(x => x.Object.Email == email && x.Object.Password == password).FirstOrDefault();

            return user.Object;
           
        }
        
        public async Task<bool> CheckEmailAndPasswordAsync(string email, string password)
        {
            Authentication userAuth = new Authentication();

            try
            {

           var  user = (await client
                 .Child("Authentications")
                 .OnceAsync<Authentication>()).Where(x => x.Object.Email == email && x.Object.Password == password).FirstOrDefault();

                if(user != null)
                {
                    userAuth = user.Object;
                }
                else
                {
                    userAuth = null;
                }
              
            }
            catch(Exception ex)
            {
                
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");

            }


            if(userAuth.Password != null)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
           
           
        }




        public async Task<User> GetUserAsync(string autoID,bool isShop)
        {
            string shop;
            if (isShop)
            {
                shop = "IsBusiness";
            }
            else
            {
                shop = "NotBusiness";
            }

            var user = (await client
                            .Child("Users")
                            .Child(shop)
                            .OnceAsync<User>()).Where(x => x.Object.AutomatedId == autoID).FirstOrDefault();

            return user.Object;
                    
        }


        public async Task<User> GetUserByEmail(string email)
        {
            User user = new User();
            try
            {

                var users = (await client
                    .Child("Users")
                    .Child("IsBusiness")
                    .OnceAsync<User>()).FirstOrDefault(x => x.Object.Email == email);
                
                var _users = (await client
                    .Child("Users")
                    .Child("NotBusiness")
                    .OnceAsync<User>()).FirstOrDefault(x => x.Object.Email == email);

                if(users.Object == null)
                {
                    await Shell.Current.DisplayAlert("Error", "doesnt exit in business", "OK");
                }
                else
                {
                    user = users.Object;
                }
                if(_users == null)
                {
                    await Shell.Current.DisplayAlert("Error", "doesnt exit in not business", "OK");
                }
                else
                {
                    user = _users.Object;
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }


            return user;


        }


        public async Task<List<Authentication>> GetAllAuths()
        {
            List<Authentication> auths = new List<Authentication>();

            try
            {
                var authList = (await client
                       .Child("Authentications")
                       .OnceAsync<Authentication>()).ToList();

                foreach(var _auth in authList)
                {
                    auths.Add(_auth.Object);
                }
            }
            catch
            {
                auths = null;
            }

            return await Task.FromResult(auths);


        }




        public async Task<bool> AddBusinessAsync(Shop shop)
        {
            try
            {


             
                    await client
                        .Child("Users")
                        .Child("IsBusiness")
                        .PostAsync(shop);


              
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }

        }

        public async Task<List<Shop>> GetAllBusiness()
        {
            try
            {

                List<Shop> shopList = new List<Shop>();
                var items = (await client
                     .Child("Users")
                     .Child("IsBusiness")
                     .OnceAsync<Shop>()).ToList();

                foreach (var shop in items)
                {
                    shopList.Add(shop.Object);
                }


                return shopList;
            }
            catch
            {
                return null;
            }
            

        }






    }
}
