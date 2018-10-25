namespace Booking.Model
{
    using System.Data.Entity;

    public partial class Booking : DbContext
    {
        public Booking()
            : base("name=Booking")
        {
        }

        public virtual DbSet<ChambresSet> ChambresSet { get; set; }
        public virtual DbSet<HotelsSet> HotelsSet { get; set; }
        public virtual DbSet<ClientsSet> ClientsSet { get; set; }
        public virtual DbSet<ReservationSet> ReservationSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
