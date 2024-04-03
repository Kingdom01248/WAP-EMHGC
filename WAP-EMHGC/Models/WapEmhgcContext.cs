using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WAP_EMHGC.Models;

public partial class WapEmhgcContext : DbContext
{
    public WapEmhgcContext()
    {
    }

    public WapEmhgcContext(DbContextOptions<WapEmhgcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Anly> Anlies { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Chart> Charts { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<DataStation> DataStations { get; set; }

    public virtual DbSet<Datum> Data { get; set; }

    public virtual DbSet<Forecast> Forecasts { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Pic> Pics { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MQA-12;Database=WAP_EMHGC;TrustServerCertificate=Yes;Trusted_Connection=True;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__Account__91CBC39883F7525C");

            entity.ToTable("Account");

            entity.Property(e => e.AccId)
                .ValueGeneratedNever()
                .HasColumnName("AccID");
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(225);
            entity.Property(e => e.Note).HasMaxLength(2500);
            entity.Property(e => e.Password).HasMaxLength(12);
            entity.Property(e => e.PasswordAconfirmed).HasColumnName("PasswordAConfirmed");
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<Anly>(entity =>
        {
            entity.HasKey(e => e.AnlyId).HasName("PK__Anly__324F3CD475CF2730");

            entity.ToTable("Anly");

            entity.Property(e => e.AnlyId)
                .ValueGeneratedNever()
                .HasColumnName("AnlyID");
            entity.Property(e => e.DataId).HasColumnName("DataID");
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Data).WithMany(p => p.Anlies)
                .HasForeignKey(d => d.DataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anly__DataID__48CFD27E");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B2D81A807");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.NewsId).HasColumnName("NewsID");

            entity.HasOne(d => d.Acc).WithMany(p => p.Categories)
                .HasForeignKey(d => d.AccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Category__AccID__33D4B598");

            entity.HasOne(d => d.News).WithMany(p => p.Categories)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Category__NewsID__32E0915F");
        });

        modelBuilder.Entity<Chart>(entity =>
        {
            entity.HasKey(e => e.ChartId).HasName("PK__Chart__E7B41C4F237BC634");

            entity.ToTable("Chart");

            entity.Property(e => e.ChartId)
                .ValueGeneratedNever()
                .HasColumnName("ChartID");
            entity.Property(e => e.DataId).HasColumnName("DataID");
            entity.Property(e => e.GraphJtwc)
                .HasMaxLength(1500)
                .HasColumnName("GraphJTWC");
            entity.Property(e => e.GraphObj).HasMaxLength(1500);
            entity.Property(e => e.GraphOrther).HasMaxLength(1500);
            entity.Property(e => e.GraphTb)
                .HasMaxLength(1500)
                .HasColumnName("GraphTB");
            entity.Property(e => e.GraphVie).HasMaxLength(1500);
            entity.Property(e => e.GraphWo)
                .HasMaxLength(1500)
                .HasColumnName("GraphWO");
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Data).WithMany(p => p.Charts)
                .HasForeignKey(d => d.DataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chart__DataID__45F365D3");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927A05641C346");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("ClassID");
            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.NewsId).HasColumnName("NewsID");

            entity.HasOne(d => d.Acc).WithMany(p => p.Classes)
                .HasForeignKey(d => d.AccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class__AccID__300424B4");

            entity.HasOne(d => d.News).WithMany(p => p.Classes)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class__NewsID__2F10007B");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFAA71918204");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("CommentID");
            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.NewsId).HasColumnName("NewsID");

            entity.HasOne(d => d.Acc).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__AccID__3B75D760");

            entity.HasOne(d => d.News).WithMany(p => p.Comments)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__NewsID__3A81B327");
        });

        modelBuilder.Entity<DataStation>(entity =>
        {
            entity.HasKey(e => e.DataStationId).HasName("PK__DataStat__CD80A30A25A94AA0");

            entity.ToTable("DataStation");

            entity.Property(e => e.DataStationId)
                .ValueGeneratedNever()
                .HasColumnName("DataStationID");
            entity.Property(e => e.DataId).HasColumnName("DataID");
            entity.Property(e => e.LocationPlace).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Data).WithMany(p => p.DataStations)
                .HasForeignKey(d => d.DataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DataStati__DataI__403A8C7D");
        });

        modelBuilder.Entity<Datum>(entity =>
        {
            entity.HasKey(e => e.DataId).HasName("PK__Data__9D05305D75359133");

            entity.Property(e => e.DataId)
                .ValueGeneratedNever()
                .HasColumnName("DataID");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Pdf).HasColumnName("PDF");
        });

        modelBuilder.Entity<Forecast>(entity =>
        {
            entity.HasKey(e => e.ForecastId).HasName("PK__Forecast__7F2744587F194298");

            entity.ToTable("Forecast");

            entity.Property(e => e.ForecastId)
                .ValueGeneratedNever()
                .HasColumnName("ForecastID");
            entity.Property(e => e.DataId).HasColumnName("DataID");
            entity.Property(e => e.ForecastAsia).HasColumnName("Forecast_Asia");
            entity.Property(e => e.ForecastEnso).HasColumnName("Forecast_ENSO");
            entity.Property(e => e.ForecastSea).HasColumnName("Forecast_Sea");
            entity.Property(e => e.ForecastTemp).HasColumnName("Forecast_Temp");
            entity.Property(e => e.ForecastWind).HasColumnName("Forecast_Wind");
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Data).WithMany(p => p.Forecasts)
                .HasForeignKey(d => d.DataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Forecast__DataID__4D94879B");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__News__954EBDD3937AF63E");

            entity.Property(e => e.NewsId)
                .ValueGeneratedNever()
                .HasColumnName("NewsID");
            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Title)
                .HasMaxLength(4000)
                .IsUnicode(false);

            entity.HasOne(d => d.Acc).WithMany(p => p.News)
                .HasForeignKey(d => d.AccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__AccID__29572725");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("PK__Note__EACE357F335ADACB");

            entity.ToTable("Note");

            entity.Property(e => e.NoteId)
                .ValueGeneratedNever()
                .HasColumnName("NoteID");
            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Note1).HasColumnName("Note");
        });

        modelBuilder.Entity<Pic>(entity =>
        {
            entity.HasKey(e => e.PicId).HasName("PK__Pic__B04A93E1B2835766");

            entity.ToTable("Pic");

            entity.Property(e => e.PicId)
                .ValueGeneratedNever()
                .HasColumnName("PicID");
            entity.Property(e => e.NewsId).HasColumnName("NewsID");
            entity.Property(e => e.Title)
                .HasMaxLength(4000)
                .IsUnicode(false);

            entity.HasOne(d => d.News).WithMany(p => p.Pics)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pic__NewsID__2C3393D0");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3ABB8AF00E");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.Role1)
                .HasMaxLength(15)
                .HasColumnName("Role");

            entity.HasOne(d => d.Acc).WithMany(p => p.Roles)
                .HasForeignKey(d => d.AccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Role__AccID__267ABA7A");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__Station__E0D8A6DD5AD88DD5");

            entity.ToTable("Station");

            entity.Property(e => e.StationId)
                .ValueGeneratedNever()
                .HasColumnName("StationID");
            entity.Property(e => e.DataStationId).HasColumnName("DataStationID");
            entity.Property(e => e.Idstation).HasColumnName("IDStation");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(1500);
            entity.Property(e => e.TimeUpdate).HasColumnType("datetime");

            entity.HasOne(d => d.DataStation).WithMany(p => p.Stations)
                .HasForeignKey(d => d.DataStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Station__DataSta__4316F928");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F7D5D7A3022");

            entity.ToTable("Topic");

            entity.Property(e => e.TopicId)
                .ValueGeneratedNever()
                .HasColumnName("TopicID");
            entity.Property(e => e.AccId).HasColumnName("AccID");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.NewsId).HasColumnName("NewsID");

            entity.HasOne(d => d.Acc).WithMany(p => p.Topics)
                .HasForeignKey(d => d.AccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Topic__AccID__37A5467C");

            entity.HasOne(d => d.News).WithMany(p => p.Topics)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Topic__NewsID__36B12243");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
