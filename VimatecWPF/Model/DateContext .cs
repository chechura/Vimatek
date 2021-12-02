using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class DateContext : DbContext
    {
        public DateContext()
            : base("name=TestContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<DateContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        public DbSet<ReceptDb> Reciepts { get; set; }
        public DbSet<RecepParam> RecepParams { get; set; }
    }
}
