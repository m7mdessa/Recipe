using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Recipe.Core.Data;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeBank> RecipeBanks { get; set; }

    public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }

    public virtual DbSet<RecipeContact> RecipeContacts { get; set; }

    public virtual DbSet<RecipePage> RecipePages { get; set; }

    public virtual DbSet<RecipePayment> RecipePayments { get; set; }

    public virtual DbSet<RecipeRole> RecipeRoles { get; set; }

    public virtual DbSet<RecipeTestimonial> RecipeTestimonials { get; set; }

    public virtual DbSet<RecipeUser> RecipeUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("USER ID=mohammad;PASSWORD=mohammad1999;DATA SOURCE=localhost:1521/orcl");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("MOHAMMAD")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007728");

            entity.ToTable("RECIPE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Categoryid)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Price)
                .HasColumnType("FLOAT")
                .HasColumnName("PRICE");
            entity.Property(e => e.Quantity)
                .HasColumnType("NUMBER")
                .HasColumnName("QUANTITY");
            entity.Property(e => e.Recipedescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RECIPEDESCRIPTION");
            entity.Property(e => e.Recipename)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RECIPENAME");
            entity.Property(e => e.Sale)
                .HasColumnType("NUMBER")
                .HasColumnName("SALE");
            entity.Property(e => e.Startdate)
                .HasColumnType("DATE")
                .HasColumnName("STARTDATE");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Category).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007729");

            entity.HasOne(d => d.User).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007730");
        });

        modelBuilder.Entity<RecipeBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007726");

            entity.ToTable("RECIPE_BANK");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Cardholdername)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CARDHOLDERNAME");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CARDNUMBER");
            entity.Property(e => e.Cvv)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CVV");
            entity.Property(e => e.Expirationddate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EXPIRATIONDDATE");
        });

        modelBuilder.Entity<RecipeCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007721");

            entity.ToTable("RECIPE_CATEGORY");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(255)
                .HasColumnName("CATEGORYNAME");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("IMAGE");
        });

        modelBuilder.Entity<RecipeContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007718");

            entity.ToTable("RECIPE_CONTACT");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Datecreated)
                .HasColumnType("DATE")
                .HasColumnName("DATECREATED");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasColumnName("MESSAGE");
            entity.Property(e => e.Pagesid)
                .HasColumnType("NUMBER")
                .HasColumnName("PAGESID");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("PHONE");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("SUBJECT");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Pages).WithMany(p => p.RecipeContacts)
                .HasForeignKey(d => d.Pagesid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007719");
        });

        modelBuilder.Entity<RecipePage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007669");

            entity.ToTable("RECIPE_PAGES");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("CONTENT");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasColumnName("LOGO");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.Slide1)
                .HasMaxLength(255)
                .HasColumnName("SLIDE1");
            entity.Property(e => e.Slide2)
                .HasMaxLength(255)
                .HasColumnName("SLIDE2");
            entity.Property(e => e.Slide3)
                .HasMaxLength(255)
                .HasColumnName("SLIDE3");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TITLE");
        });

        modelBuilder.Entity<RecipePayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007723");

            entity.ToTable("RECIPE_PAYMENT");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CARDNUMBER");
            entity.Property(e => e.Paymentamount)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PAYMENTAMOUNT");
            entity.Property(e => e.Paymentdate)
                .HasColumnType("DATE")
                .HasColumnName("PAYMENTDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("STATUS");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.RecipePayments)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007724");
        });

        modelBuilder.Entity<RecipeRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007656");

            entity.ToTable("RECIPE_ROLE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(255)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<RecipeTestimonial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007695");

            entity.ToTable("RECIPE_TESTIMONIAL");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Datetestimonial)
                .HasColumnType("DATE")
                .HasColumnName("DATETESTIMONIAL");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("STATUS");
            entity.Property(e => e.Testimonial)
                .HasMaxLength(255)
                .HasColumnName("TESTIMONIAL");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.RecipeTestimonials)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007696");
        });

        modelBuilder.Entity<RecipeUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007658");

            entity.ToTable("RECIPE_USER");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Passwordd)
                .HasMaxLength(255)
                .HasColumnName("PASSWORDD");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("STATUS");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Role).WithMany(p => p.RecipeUsers)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007659");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
