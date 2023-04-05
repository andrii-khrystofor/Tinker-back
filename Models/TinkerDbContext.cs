using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tinker_Back.Models;

public partial class TinkerDbContext : DbContext
{
    public TinkerDbContext()
    {
    }

    public TinkerDbContext(DbContextOptions<TinkerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserToChat> UserToChats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=165.22.85.146;TrustServerCertificate=true;" +
            "Initial Catalog=Tinker_DB;User ID=SA;Password=AndreyKrutiyProjectManagerUNyogoVseViydeYakshodastMeniStick1," +
            "mozhe2AleNeProstoTakAZaKrasivi%");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.IsGroupChat).HasColumnName("isGroupChat");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.IsPinned)
                .HasColumnName("isPinned");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstUserId).HasColumnName("firstUserId");
            entity.Property(e => e.SecondUserId).HasColumnName("secondUserId");

            entity.HasOne(d => d.FirstUser).WithMany(p => p.ContactFirstUsers)
                .HasForeignKey(d => d.FirstUserId)
                .HasConstraintName("FK_Contacts_Users");

            entity.HasOne(d => d.SecondUser).WithMany(p => p.ContactSecondUsers)
                .HasForeignKey(d => d.SecondUserId)
                .HasConstraintName("FK_Contacts_Users1");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ChatId).HasColumnName("chatId");
            entity.Property(e => e.IsPinned).HasColumnName("isPinned");
            entity.Property(e => e.SenderId).HasColumnName("senderId");
            entity.Property(e => e.SentTime)
                .HasColumnName("sentTime");
            entity.Property(e => e.isSeen)
                .HasColumnName("isSeen");
            entity.Property(e => e.isForwarded)
                .HasColumnName("isForwarded");
            entity.Property(e => e.RepliesToMessageId)
            .HasColumnName("RepliedMessageId");
            entity.Property(e => e.Text).HasColumnName("text");

            entity.HasOne(d => d.Chat).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ChatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Chats");

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<UserToChat>(entity =>
        {
            entity.ToTable("UserToChat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChatId).HasColumnName("chatId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Chat).WithMany(p => p.UserToChats)
                .HasForeignKey(d => d.ChatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToChat_Chats");

            entity.HasOne(d => d.User).WithMany(p => p.UserToChats)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToChat_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
