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
    [Table("events")]
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        
        [Required]
        public string EventName { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string EventShortDesc { get; set; }  //Short description

        [NotMapped]
        [JsonIgnore]
        public virtual Clubs Clubs { get; set; }
        [ForeignKey(nameof(Clubs))]
        public int? ClubID { get; set; }
        public virtual ICollection<Guests> Guests { get; set; }

        public override string ToString()
        {
            return ("EventID: "+ EventID +" EventName: " + EventName + " Date: " + Date + " Event Short Description: " +EventShortDesc);
        }
    }
}
