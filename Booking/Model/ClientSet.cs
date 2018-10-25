using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Model
{
    [Table("ClientsSet")]
    public partial class ClientsSet
    {
        public int Id { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        public virtual ICollection<ReservationSet> ReservationsSet { get; set; }
    }
}
