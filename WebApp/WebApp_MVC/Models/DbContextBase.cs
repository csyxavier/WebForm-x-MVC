using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_MVC.Models
{
    public abstract class DbContextBase
    {
        private static DbEntities _dbEntities = new DbEntities();

        protected static DbEntities dbEntities { get => _dbEntities; }
    }
}