using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WellnessMaxApp.Repository.Models
{
    [Table("Enrollment_T")]
    public partial class EnrollmentT
    {
        [Key]
        [Column("Enrollment_id")]
        public int EnrollmentId { get; set; }
        [Column("OnlineCounseling_id")]
        public int? OnlineCounselingId { get; set; }
        [Column("WellnessEvent_id")]
        public int? WellnessEventId { get; set; }
        [Column("WellnessProgram_id")]
        public int? WellnessProgramId { get; set; }
        [Column("Customer_id")]
        public int CustomerId { get; set; }
        [Column("Payment_Status")]
        [StringLength(50)]
        [Unicode(false)]
        public string PaymentStatus { get; set; } = null!;

        [ForeignKey("CustomerId")]
        [InverseProperty("EnrollmentTs")]
        public virtual CustomerM Customer { get; set; } = null!;
        [ForeignKey("OnlineCounselingId")]
        [InverseProperty("EnrollmentTs")]
        public virtual OnlineCounselingM? OnlineCounseling { get; set; }
        [ForeignKey("WellnessEventId")]
        [InverseProperty("EnrollmentTs")]
        public virtual WellnessEventM? WellnessEvent { get; set; }
        [ForeignKey("WellnessProgramId")]
        [InverseProperty("EnrollmentTs")]
        public virtual WellnessProgramM? WellnessProgram { get; set; }
    }
}
