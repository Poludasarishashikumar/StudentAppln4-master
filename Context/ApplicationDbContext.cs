using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentAppln4.Models;

namespace StudentAppln4
{
    public class ApplicationDbContext : DbContext
    {
        // Define properties that represent tables in the database
        public DbSet<Student1> Student1s { get; set; }
        public DbSet<Login> Logins { get; set; }


        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if(entry.State==EntityState.Deleted )
                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("RecStatus").SetValue(entity,0);
                }
            }
            return base.SaveChanges();
        }
    }

}