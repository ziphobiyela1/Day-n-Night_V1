using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day_n_Night.Models
{
    public class Residence
    {
        public Residence()
        {
            DefualtImage = "~/AppFiles/coath.jpg";

        }
        public string DefualtImage { get; set; }

        public byte[] Image { get; set; }

        public string ImageName { get; set; }


        [Key]
        public int ResID { get; set; }

        [Display(Name = "Room")]
        public Nullable<int> RoomNum { get; set; }

        [DisplayName("Property Name")]
        [StringLength(160)]
        [Required]
        public string ResName { get; set; }

        [DisplayName("Opens")]
        [DataType(DataType.Time)]
        [Required]
        public DateTime Open { get; set; }

        [DisplayName("Closes")]
        [DataType(DataType.Time)]
        [Required]
        public DateTime Close { get; set; }

       
        public virtual Room Room { get; set; }


    }
    
    public class Room
    {
        public Room()
        {
            DefualtImage = "~/AppFiles/coath.jpg";

        }
        public string DefualtImage { get; set; }

        public byte[] Image { get; set; }

        public string ImageName { get; set; }

        [Key]
        [DisplayName("Room Number")]
        public int RoomNum { get; set; }

        [DisplayName("Number of people")]
        [Required]
        public string RoomCap { get; set; }

        [DisplayName("Availability")]
        [Required]
        public string RoomAvail { get; set; }

        [DisplayName("Check-In")]
        [Required]
        public DateTime CheckIn { get; set; }

        [DisplayName("Check-Out")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CheckOut { get; set; }

        public virtual ICollection<Residence> Residences { get; set; }

    }
}