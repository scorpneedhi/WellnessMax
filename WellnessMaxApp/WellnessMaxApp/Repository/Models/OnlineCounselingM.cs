using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WellnessMaxApp.Repository.Models
{
    [Table("OnlineCounseling_M")]
    public partial class OnlineCounselingM
    {
        public OnlineCounselingM()
        {
            EnrollmentTs = new HashSet<EnrollmentT>();
        }

        [Key]
        [Column("OnlineCounseling_id")]
        public int OnlineCounselingId { get; set; }
        [Column("OnlineCounseling_Name")]
        [StringLength(50)]
        public string OnlineCounselingName { get; set; } = null!;
        public string Venue { get; set; } = null!;
        public bool IsPaid { get; set; }
        public int Fee { get; set; }
        [Column("Total_Members")]
        public int? TotalMembers { get; set; }
        [StringLength(50)]
        public string? HostName { get; set; }
        public string? Description { get; set; }
        [Column("DateTime_UTC", TypeName = "datetime")]
        public DateTime DateTimeUtc { get; set; }

        [InverseProperty("OnlineCounseling")]
        public virtual ICollection<EnrollmentT> EnrollmentTs { get; set; }
    }
}
