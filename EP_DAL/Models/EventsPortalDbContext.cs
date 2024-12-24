using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EP_DAL.Models;

public partial class EventsPortalDbContext : DbContext
{
    public EventsPortalDbContext()
    {
    }

    public EventsPortalDbContext(DbContextOptions<EventsPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userwithevent> Userwithevents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-94N82HG;Database=EventsPortalDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EventName).HasMaxLength(50);
            entity.Property(e => e.EventType).HasMaxLength(50);
            entity.Property(e => e.FkOrganizerId).HasColumnName("FK_OrganizerID");
            entity.Property(e => e.Location).HasMaxLength(255);

            entity.HasOne(d => d.FkOrganizer).WithMany(p => p.Events)
                .HasForeignKey(d => d.FkOrganizerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_User");
        });

        modelBuilder.Entity<EventRegistration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId);

            entity.ToTable("EventRegistration");

            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.CheckedInAt)
                .HasColumnType("datetime")
                .HasColumnName("CheckedInAT");
            entity.Property(e => e.FkEventId).HasColumnName("FK_EventID");
            entity.Property(e => e.FkUserId).HasColumnName("FK_UserID");
            entity.Property(e => e.RegistredAt)
                .HasColumnType("datetime")
                .HasColumnName("RegistredAT");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.FkEvent).WithMany(p => p.EventRegistrations)
                .HasForeignKey(d => d.FkEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventRegistration_Event");

            entity.HasOne(d => d.FkUser).WithMany(p => p.EventRegistrations)
                .HasForeignKey(d => d.FkUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventRegistration_User");
        });

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.ToTable("Invitation");

            entity.Property(e => e.InvitationId).HasColumnName("InvitationID");
            entity.Property(e => e.AttendedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FkEventId).HasColumnName("FK_EventID");
            entity.Property(e => e.FkUserId).HasColumnName("FK_UserID");
            entity.Property(e => e.InvitedAt)
                .HasColumnType("datetime")
                .HasColumnName("InvitedAT");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.FkEvent).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.FkEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invitation_Event");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.FkUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invitation_User");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");

            entity.Property(e => e.PermissionId)
                .ValueGeneratedNever()
                .HasColumnName("PermissionID");
            entity.Property(e => e.FkRoleId).HasColumnName("FK_RoleID");
            entity.Property(e => e.PermissionName).HasMaxLength(50);

            entity.HasOne(d => d.FkRole).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.FkRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_Role");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId)
                .ValueGeneratedNever()
                .HasColumnName("TicketID");
            entity.Property(e => e.FkEventId).HasColumnName("FK_EventID");
            entity.Property(e => e.FkUserId).HasColumnName("FK_UserID");
            entity.Property(e => e.IsCheckedIn).HasColumnName("IsCheckedIN");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PurchasedAt)
                .HasColumnType("datetime")
                .HasColumnName("PurchasedAT");
            entity.Property(e => e.TicketType).HasMaxLength(50);

            entity.HasOne(d => d.FkEvent).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.FkEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Event");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.FkUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FkRoleId).HasColumnName("FK_RoleID");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("Last_Login");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.FkRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.FkRoleId)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Userwithevent>(entity =>
        {
            entity.ToTable("userwithevent");

            entity.Property(e => e.UserwitheventId).HasColumnName("userwithevent_Id");
            entity.Property(e => e.FkEventId).HasColumnName("Fk_EventId");
            entity.Property(e => e.FkUserId).HasColumnName("Fk_UserId");

            entity.HasOne(d => d.FkEvent).WithMany(p => p.Userwithevents)
                .HasForeignKey(d => d.FkEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userwithevent_Event");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Userwithevents)
                .HasForeignKey(d => d.FkUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userwithevent_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
