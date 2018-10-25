using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Model
{
    [Table("ReservationSet")]
    public partial class ReservationSet
    {
        public int Id { get; set; }

        [Required]
        public DateTime dateDebut { get; set; }

        [Required]
        public DateTime dateFin { get; set; }

        public int ClientsSetId { get; set; }

        public ClientsSet Client { get; set; }

        public int ChambresSetId { get; set; }

        public ChambresSet Chambres { get; set; }
    }
}
