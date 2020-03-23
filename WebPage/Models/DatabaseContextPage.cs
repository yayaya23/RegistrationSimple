using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPage.Models
{
    public class DatabaseContextPage : DbContext
    {
        public DatabaseContextPage() : base("WebPageContext")
        {
        }

        public DbSet<UserEntity> UserEntities { get; set; }
    }
}