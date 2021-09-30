using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class BusReservationContext : DbContext
    {
        public BusReservationContext()
        {
        }

        public BusReservationContext(DbContextOptions<BusReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminDetail> AdminDetails { get; set; }
        public virtual DbSet<AuthorisedCustomerBookingDetail> AuthorisedCustomerBookingDetails { get; set; }
        public virtual DbSet<AuthorisedCustomerDetail> AuthorisedCustomerDetails { get; set; }
        public virtual DbSet<BusDetail> BusDetails { get; set; }
        public virtual DbSet<CoachReservationDetail> CoachReservationDetails { get; set; }
        public virtual DbSet<CoachResevationBusDetail> CoachResevationBusDetails { get; set; }
        public virtual DbSet<DriverDetail> DriverDetails { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<UnauthorisedCustomerBookingDetail> UnauthorisedCustomerBookingDetails { get; set; }
        public virtual DbSet<UnauthorisedCustomerDetail> UnauthorisedCustomerDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-7HS87IV;database=BusReservation;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminDetail>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__AdminDet__719FE4E8BB1DB029");

                entity.HasIndex(e => e.Email, "UQ__AdminDet__A9D10534141F335D")
                    .IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuthorisedCustomerBookingDetail>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__Authoris__712CC627C265E20F");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.ReturnArrivalDate).HasColumnType("date");

                entity.Property(e => e.ReturnDepartureDate).HasColumnType("date");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.SeatIds)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SeatIDs");

                entity.Property(e => e.TicketType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TripStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.AuthorisedCustomerBookingDetails)
                    .HasForeignKey(d => d.BusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Authorise__BusID__5165187F");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AuthorisedCustomerBookingDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Authorise__Custo__5070F446");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.AuthorisedCustomerBookingDetails)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__Authorise__Drive__534D60F1");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.AuthorisedCustomerBookingDetails)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Authorise__Route__52593CB8");
            });

            modelBuilder.Entity<AuthorisedCustomerDetail>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Authoris__A4AE64B83672667C");

                entity.HasIndex(e => e.LoginId, "UQ__Authoris__4DDA2839B0E77DDD")
                    .IsUnique();

                entity.HasIndex(e => e.ContactNo, "UQ__Authoris__5C667C053C19CBC6")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LoginId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LoginID");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BusDetail>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .HasName("PK__BusDetai__6A0F6095D898443D");

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.Seat1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat10)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat11)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat12)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat13)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat14)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat15)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat16)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat17)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat18)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat19)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat20)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat21)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat22)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat23)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat24)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat25)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat26)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat27)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat28)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat29)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat30)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat31)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat32)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat33)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat34)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat35)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat36)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat37)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat38)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat39)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat40)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat7)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat8)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seat9)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.BusDetails)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__BusDetail__Drive__4BAC3F29");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.BusDetails)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BusDetail__Route__4AB81AF0");
            });

            modelBuilder.Entity<CoachReservationDetail>(entity =>
            {
                entity.HasKey(e => e.ReservationId)
                    .HasName("PK__CoachRes__B7EE5F04764A7C60");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.CoachBusId).HasColumnName("CoachBusID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.Destination)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InDate).HasColumnType("date");

                entity.Property(e => e.OutDate).HasColumnType("date");

                entity.Property(e => e.ReturnArrivalDate).HasColumnType("date");

                entity.Property(e => e.ReturnDepartureDate).HasColumnType("date");

                entity.Property(e => e.SecurityDeposit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WithDriver)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CoachBus)
                    .WithMany(p => p.CoachReservationDetails)
                    .HasForeignKey(d => d.CoachBusId)
                    .HasConstraintName("FK__CoachRese__Coach__47DBAE45");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CoachReservationDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoachRese__Custo__46E78A0C");
            });

            modelBuilder.Entity<CoachResevationBusDetail>(entity =>
            {
                entity.HasKey(e => e.CoachBusId)
                    .HasName("PK__CoachRes__D4BB8A82553832D2");

                entity.Property(e => e.CoachBusId).HasColumnName("CoachBusID");

                entity.Property(e => e.Destination)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.Source)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.CoachResevationBusDetails)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__CoachRese__Drive__403A8C7D");
            });

            modelBuilder.Entity<DriverDetail>(entity =>
            {
                entity.HasKey(e => e.DriverId)
                    .HasName("PK__DriverDe__F1B1CD24B7523E1B");

                entity.HasIndex(e => e.LoginId, "UQ__DriverDe__4DDA2839BB3AEDFD")
                    .IsUnique();

                entity.HasIndex(e => e.ContactNo, "UQ__DriverDe__5C667C05A0FE3DD1")
                    .IsUnique();

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.LoginId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LoginID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("FeedBack");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.BusReachedOnTime)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DriverOverSpeed)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TripDate).HasColumnType("date");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => e.TravelId)
                    .HasName("PK__Records__E931521517261148");

                entity.Property(e => e.TravelId).HasColumnName("TravelID");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.TravelDate).HasColumnType("date");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Records__RouteID__5DCAEF64");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.Destination)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnauthorisedCustomerBookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__Unauthor__73951ACD1B475C45");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.SeatIds).HasColumnName("SeatIDs");

                entity.Property(e => e.TicketType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TripStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.UnauthorisedCustomerBookingDetails)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__Unauthori__Drive__5AEE82B9");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.UnauthorisedCustomerBookingDetails)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__Unauthori__Email__59FA5E80");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.UnauthorisedCustomerBookingDetails)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Unauthori__Route__59063A47");
            });

            modelBuilder.Entity<UnauthorisedCustomerDetail>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Unauthor__A9D10535CE5517D5");

                entity.HasIndex(e => e.ContactNo, "UQ__Unauthor__5C667C05B37C4269")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
