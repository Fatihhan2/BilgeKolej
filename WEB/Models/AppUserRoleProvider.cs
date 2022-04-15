using DataAccess.Context;
using Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DataAccess.Entity;

namespace WEB.Models
{
    public class AppUserRoleProvider : RoleProvider
    {
        AppDbContext db = Singelton.Context;
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            bool Öğretmen = false;
            
            foreach (var item in db.Öğretmenler.ToList())
            {
                if (item.Ad == username)
                {
                    Öğretmen = true;
                }

            }



            if (Öğretmen == true)
            {
               var  UserRoleList = from user in db.Öğretmenler join rol in db.Roller on user.RolID equals rol.ID where user.Ad == username select rol.Yetki;
                return UserRoleList.ToArray();
            }
            else
            {
                var UserRoleList = from user in db.Öğrenciler join rol in db.Roller on user.RolID equals rol.ID where user.Ad == username select rol.Yetki;
                return UserRoleList.ToArray();
            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}