using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApp2.Models
{
    public class WebApp2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public WebApp2Context() : base("name=WebApp2Context")
        {
        }

        public System.Data.Entity.DbSet<WebApp2.Models.Emp> Emps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<WebApp2.Models.PayChk> PayChks { get; set; }
    }

    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WebApp2Context>
    {
        protected override void Seed(WebApp2Context ctx)
        {
            var emps = new List<Emp>
            {
                new Emp {FirstName ="Joe", LastName="Smucker" },
                new Emp {FirstName ="Mary", LastName="Kaduski" },
                new Emp {FirstName ="Henry", LastName="Potts" }
            };
            emps.ForEach(e => ctx.Emps.Add(e));
            ctx.SaveChanges();

            var paychks = new List<PayChk>
            {
                new PayChk {EmpID=1, Payee= "Joe Tuttle" }
            };
            paychks.ForEach(p => ctx.PayChks.Add(p));
            ctx.SaveChanges();
        }
    }
}
