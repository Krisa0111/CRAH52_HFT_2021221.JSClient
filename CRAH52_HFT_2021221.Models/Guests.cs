using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Models
{
    [Table("guests")]
    public class Guests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuestID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int BirthYear { get; set; }

        [JsonIgnore]
        public virtual Events Event { get; set; }     // ˇ
        [ForeignKey(nameof(Events))]        // Navigation property 1 side ( GUESTS TABLE)
        public int EventID { get; set; }    // ^
        public override string ToString()
        {
            return ("GuestID: " + GuestID + " Name: " + Name + " Email: " + Email + " Birthyear: " + BirthYear);
        }
    }

}
