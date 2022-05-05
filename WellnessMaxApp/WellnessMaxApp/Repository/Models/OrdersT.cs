using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WellnessMaxApp.Repository.Models
{
    [Table("Orders_T")]
    public partial class OrdersT
    {
        [Key]
        [Column("Order_id")]
        public int OrderId { get; set; }
        [Column("Product_id")]
        public int ProductId { get; set; }
        [Column("Customer_id")]
        public int CustomerId { get; set; }
        [Column("Order_Status")]
        [StringLength(50)]
        [Unicode(false)]
        public string OrderStatus { get; set; } = null!;

        [ForeignKey("CustomerId")]
        [InverseProperty("OrdersTs")]
        public virtual CustomerM Customer { get; set; } = null!;
        [ForeignKey("ProductId")]
        [InverseProperty("OrdersTs")]
        public virtual WellnessProductM Product { get; set; } = null!;
    }
}
