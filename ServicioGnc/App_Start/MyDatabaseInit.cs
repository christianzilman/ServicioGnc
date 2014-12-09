using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace ServicioGnc.App_Start
{
    public class MyDatabaseInit : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", 
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}