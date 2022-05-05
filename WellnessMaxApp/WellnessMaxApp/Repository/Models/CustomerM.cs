using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WellnessMaxApp.Repository.Models
{
    [Table("Customer_M")]
    public partial class CustomerM
    {
        public CustomerM()
        {
            EnrollmentTs = new HashSet<EnrollmentT>();
            OrdersTs = new HashSet<OrdersT>();
        }

        [Key]
        [Column("Customer_id")]
        public int CustomerId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        [StringLength(50)]
        public string Phone { get; set; } = null!;
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; } = null!;

        [InverseProperty("Customer")]
        public virtual ICollection<EnrollmentT> EnrollmentTs { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<OrdersT> OrdersTs { get; set; }
    }
}
