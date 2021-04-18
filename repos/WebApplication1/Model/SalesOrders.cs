using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class SalesOrders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int OrderID { get; set; }

        public int OrderNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }

        public virtual SalesOrderDetails SalesOrderDetails { get; set; }

    }

    public class SalesOrderDetails
    {
       public int OrderID { get; set; }
       public int Sequence { get; set; }
        
       [Column(TypeName = "varchar(200)")]
       public string Description { get; set; }
        
       [Column(TypeName = "decimal(18,5)")]
       public decimal Price { get; set; }

    }

    public class SalesContext : DbContext
    {

        public SalesContext() : base()
        {
        }

        public DbSet<SalesOrders> SalesOrders { get; set; }
        public DbSet<SalesOrderDetails> SalesOrderDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderDetails>().HasKey(t => new { t.OrderID, t.Sequence });

            modelBuilder.Entity<SalesOrders>().HasOptional(dataSet => dataSet.SalesOrderDetails)
                .WithMany().HasForeignKey(details => details.OrderID);
        }
    }
    


}
