using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WellnessMaxApp.Repository.Models
{
    [Table("WellnessProgram_M")]
    public partial class WellnessProgramM
    {
        public WellnessProgramM()
        {
            EnrollmentTs = new HashSet<EnrollmentT>();
        }

        [Key]
        [Column("WellnessProgram_id")]
        public int WellnessProgramId { get; set; }
        [Column("WellnessProgram_Name")]
        [StringLength(50)]
        public string WellnessProgramName { get; set; } = null!;
        public string Venue { get; set; } = null!;
        public bool IsPaid { get; set; }
        [Column("DateTime_UTC", TypeName = "datetime")]
        public DateTime DateTimeUtc { get; set; }
        public int Fee { get; set; }
        [Column("Total_Members")]
        public int? TotalMembers { get; set; }
        [Column("Duration_in_hours")]
        public int? DurationInHours { get; set; }
        [StringLength(50)]
        public string? HostName { get; set; }
        public string? Description { get; set; }

        [InverseProperty("WellnessProgram")]
        public virtual ICollection<EnrollmentT> EnrollmentTs { get; set; }
    }
}
