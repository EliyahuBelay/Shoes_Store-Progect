using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace big_project_practiceToFinal_test.Models
{
    public partial class ShoesShopDB : DbContext
    {
        public ShoesShopDB()
            : base("name=ShoesShopDB")
        {
        }

        public DbSet<GoingOutShoes> GoingOutShoeses { get;set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
