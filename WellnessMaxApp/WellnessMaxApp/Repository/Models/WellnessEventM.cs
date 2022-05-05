using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WellnessMaxApp.Repository.Models
{
    [Table("WellnessEvent_M")]
    public partial class WellnessEventM
    {
        public WellnessEventM()
        {
            EnrollmentTs = new HashSet<EnrollmentT>();
        }

        [Key]
        [Column("WellnessEvent_id")]
        public int WellnessEventId { get; set; }
        [Column("Event_Name")]
        [StringLength(50)]
        public string EventName { get; set; } = null!;
        public string Venue { get; set; } = null!;
        public bool IsPaid { get; set; }
        [Column("DateTime_UTC", TypeName = "datetime")]
        public DateTime DateTimeUtc { get; set; }
        public int Fee { get; set; }
        [Column("Total_Members")]
        public int? TotalMembers { get; set; }
        [StringLength(50)]
        public string? HostName { get; set; }
        public string? Description { get; set; }

        [InverseProperty("WellnessEvent")]
        public virtual ICollection<EnrollmentT> EnrollmentTs { get; set; }
    }
}
