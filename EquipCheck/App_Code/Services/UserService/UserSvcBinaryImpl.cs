using EquipCheck.Domain;

using System;
using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.EntityClient;

namespace EquipCheck.Services
{
    /// <summary>
    /// Class for implementing an Equipment Checklist Application User Service.
    /// Design Pattern: Plugin - Implementation classes that plug into the Service Interfaces.
    /// </summary>
    public class UserSvcBinaryImpl : IUserSvc
    {
        /// <summary> Method for storing an EquipCheckAppUser to the local database. </summary>
        /// <param name="user"> Specifies the EquipCheckAppUser. </param>
        /// <returns> Returns user if stored successfully. </returns>
        public EquipCheckAppUser StoreEquipCheckAppUser(EquipCheckAppUser appUser)
        {

            using (var db = new EquipCheckEntities())
            {
                var appUsername = appUser.Username;
                var appUserPassword = appUser.Password;

                // Check to see if username already exists
                var userResults = from users in db.app_users
                                  where users.username == appUsername
                                  select users;

                List<app_users> app_user = userResults.ToList<app_users>();

                if (app_user.Count == 0)
                {

                    app_users user = new app_users()
                    {
                        username = appUsername,
                        password = appUserPassword
                    };

                    db.app_users.Add(user);
                    db.SaveChanges();

                    // Retrieve Local User
                    userResults = from users in db.app_users
                                  where users.username == user.username
                                  select users;

                    app_user = userResults.ToList<app_users>();
                    appUser = new EquipCheckAppUser();
                    appUser.UserID = app_user[0].user_id;
                    appUser.Username = app_user[0].username;
                    appUser.Password = app_user[0].password;
                }
                else
                {
                    appUser = null;
                }
            }

            return appUser;
        }

        /// <summary>
        /// Method for retrieving user from the local database.
        /// </summary>
        /// <param name="appUser">Incoming EquipCheckAppUser</param>
        /// <returns>Returns an EquipCheckAppUser or null if user is not found.</returns>
        public EquipCheckAppUser GetLocalUser(EquipCheckAppUser appUser)
        {
            using(var db = new EquipCheckEntities()) {

                var userResults = from users in db.app_users
                                  where users.username == appUser.Username
                                  select users;

                List<app_users> app_user = userResults.ToList<app_users>();

                if (app_user.Count > 0)
                {
                    appUser = new EquipCheckAppUser();
                    appUser.UserID = app_user[0].user_id;
                    appUser.Username = app_user[0].username;
                    appUser.Password = app_user[0].password;
                }
                else
                {
                    appUser = null;
                }
            }

            return appUser;
        }

        /// <summary> Method for getting an EquipCheckAppUser on the Server. </summary>
        /// <param name="appUser"> Specifies the EquipCheckAppUser. </param>
        /// <returns> Returns the GetEquipCheckAppUser found in the database, or null if not found. </returns>
        public EquipCheckAppUser GetEquipCheckAppUser(EquipCheckAppUser appUser)
        {
            EquipCheckLoginService.EquipCheckLoginService loginService = new EquipCheckLoginService.EquipCheckLoginService();
            EquipCheckLoginService.EquipCheckAppUser userAtServer = new EquipCheckLoginService.EquipCheckAppUser();
            userAtServer.Username = appUser.Username;
            userAtServer.Password = appUser.Password;

            userAtServer = loginService.AuthenticateUser(userAtServer);

            if (userAtServer == null) 
            {
                appUser = null;
            }

            return appUser;
        }
    }
}
