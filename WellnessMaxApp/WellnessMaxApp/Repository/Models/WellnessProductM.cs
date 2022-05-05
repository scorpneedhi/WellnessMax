using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WellnessMaxApp.Repository.Models
{
    [Table("WellnessProduct_M")]
    public partial class WellnessProductM
    {
        public WellnessProductM()
        {
            OrdersTs = new HashSet<OrdersT>();
        }

        [Key]
        [Column("Product_id")]
        public int ProductId { get; set; }
        [Column("Product_Name")]
        [StringLength(50)]
        [Unicode(false)]
        public string ProductName { get; set; } = null!;
        public double Price { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrdersT> OrdersTs { get; set; }
    }
}
