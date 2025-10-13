using Domain.Models;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace DataAccess;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audit_log> audit_logs { get; set; }

    public virtual DbSet<Booking> bookings { get; set; }

    public virtual DbSet<Payment> payments { get; set; }

    public virtual DbSet<Pc_spec> pc_specs { get; set; }

    public virtual DbSet<Role> roles { get; set; }

    public virtual DbSet<Room> rooms { get; set; }

    public virtual DbSet<Seat> seats { get; set; }

    public virtual DbSet<Tariff> tariffs { get; set; }

    public virtual DbSet<User> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("btree_gist");

        modelBuilder.Entity<Audit_log>(entity =>
        {
            entity.HasKey(e => e.id).HasName("audit_logs_pkey");

            entity.HasIndex(e => e.user_id, "idx_audit_user");

            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.details).HasColumnType("jsonb");

            entity.HasOne(d => d.user).WithMany(p => p.audit_logs)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("audit_logs_user_id_fkey");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.id).HasName("bookings_pkey");

            entity.Property<NpgsqlRange<DateTime>>("period")
                .HasColumnType("tstzrange")
                .HasComputedColumnSql("tstzrange(start_time, end_time, '[]')", stored: true);

            entity.HasIndex("seat_id", "period")
                .HasDatabaseName("ex_seat_time_no_overlap")
                .HasMethod("gist")
                .HasFilter("status = 'active'::text");

            entity.HasIndex("period")
                .HasDatabaseName("idx_bookings_period")
                .HasMethod("gist");

            entity.HasIndex(e => e.seat_id).HasDatabaseName("idx_bookings_seat");
            entity.HasIndex(e => e.user_id).HasDatabaseName("idx_bookings_user");

            entity.Property(e => e.status)
                .HasDefaultValueSql("'active'::text");

            entity.Property(e => e.total_amount)
                .HasPrecision(10, 2);

            entity.HasOne(d => d.seat)
                .WithMany(p => p.bookings)
                .HasForeignKey(d => d.seat_id)
                .HasConstraintName("bookings_seat_id_fkey");
        });


        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.id).HasName("payments_pkey");

            entity.HasIndex(e => e.booking_id, "idx_payments_booking");

            entity.Property(e => e.amount).HasPrecision(10, 2);
            entity.Property(e => e.paid_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.booking).WithMany(p => p.payments)
                .HasForeignKey(d => d.booking_id)
                .HasConstraintName("payments_booking_id_fkey");
        });

        modelBuilder.Entity<Pc_spec>(entity =>
        {
            entity.HasKey(e => e.seat_id).HasName("pc_specs_pkey");

            entity.Property(e => e.seat_id).ValueGeneratedNever();
            entity.Property(e => e.extras).HasColumnType("jsonb");

            entity.HasOne(d => d.seat).WithOne(p => p.pc_spec)
                .HasForeignKey<Pc_spec>(d => d.seat_id)
                .HasConstraintName("pc_specs_seat_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.id).HasName("roles_pkey");

            entity.HasIndex(e => e.code, "roles_code_key").IsUnique();
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.id).HasName("rooms_pkey");

            entity.HasIndex(e => e.name, "rooms_name_key").IsUnique();

            entity.Property(e => e.is_active).HasDefaultValue(true);
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.id).HasName("seats_pkey");

            entity.HasIndex(e => new { e.room_id, e.number }, "uq_seat_room_number").IsUnique();

            entity.Property(e => e.is_active).HasDefaultValue(true);

            entity.HasOne(d => d.room).WithMany(p => p.seats)
                .HasForeignKey(d => d.room_id)
                .HasConstraintName("seats_room_id_fkey");
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tariffs_pkey");

            entity.HasIndex(e => e.name, "tariffs_name_key").IsUnique();

            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.price_per_hour).HasPrecision(10, 2);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.id).HasName("users_pkey");

            entity.HasIndex(e => e.email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.username, "users_username_key").IsUnique();

            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_active).HasDefaultValue(true);

            entity.HasMany(d => d.roles).WithMany(p => p.users)
                .UsingEntity<Dictionary<string, object>>(
                    "user_role",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("role_id")
                        .HasConstraintName("user_roles_role_id_fkey"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("user_id")
                        .HasConstraintName("user_roles_user_id_fkey"),
                    j =>
                    {
                        j.HasKey("user_id", "role_id").HasName("user_roles_pkey");
                        j.ToTable("user_roles");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
