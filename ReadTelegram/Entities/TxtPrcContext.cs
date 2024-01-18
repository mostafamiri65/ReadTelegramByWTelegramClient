﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReadTelegram.Entities;

public partial class TxtPrcContext : DbContext
{
    public TxtPrcContext()
    {
    }

    public TxtPrcContext(DbContextOptions<TxtPrcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EstimateNews> EstimateNews { get; set; }

    public virtual DbSet<EvaluatedResult> EvaluatedResults { get; set; }

    public virtual DbSet<FieldOfUse> FieldOfUses { get; set; }

    public virtual DbSet<KeyWord> KeyWords { get; set; }

    public virtual DbSet<KeyWordsDtl> KeyWordsDtls { get; set; }

    public virtual DbSet<KeyWordsMain> KeyWordsMains { get; set; }

    public virtual DbSet<MedName> MedNames { get; set; }

    public virtual DbSet<NegativeOilNewsForSendingSm> NegativeOilNewsForSendingSms { get; set; }

    public virtual DbSet<NegativeReason> NegativeReasons { get; set; }

    public virtual DbSet<NewsCount> NewsCounts { get; set; }

    public virtual DbSet<NewsInserted> NewsInserteds { get; set; }

    public virtual DbSet<NewsInsertedsCmd> NewsInsertedsCmds { get; set; }

    public virtual DbSet<NewsLike> NewsLikes { get; set; }

    public virtual DbSet<NewsRelevance> NewsRelevances { get; set; }

    public virtual DbSet<NewsRssReed> NewsRssReeds { get; set; }

    public virtual DbSet<NewsRssReed2> NewsRssReed2s { get; set; }

    public virtual DbSet<NewsRssReedProc> NewsRssReedProcs { get; set; }

    public virtual DbSet<NewsSource> NewsSources { get; set; }

    public virtual DbSet<NewsSourceDetail> NewsSourceDetails { get; set; }

    public virtual DbSet<NotOilReason> NotOilReasons { get; set; }

    public virtual DbSet<SendMob> SendMobs { get; set; }

    public virtual DbSet<SendMobTyp> SendMobTyps { get; set; }

    public virtual DbSet<SendSm> SendSms { get; set; }

    public virtual DbSet<SendingSmsType> SendingSmsTypes { get; set; }

    public virtual DbSet<StatisticalSource> StatisticalSources { get; set; }

    public virtual DbSet<TbCaln> TbCalns { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbUserRole> TbUserRoles { get; set; }

    public virtual DbSet<TelegramChannel> TelegramChannels { get; set; }

    public virtual DbSet<TelegramPost> TelegramPosts { get; set; }

    public virtual DbSet<TempKeyWord> TempKeyWords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=2.181.250.24;Database=TxtPrc2;User Id = sa;Password = M13961221@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<EvaluatedResult>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

            entity.HasOne(d => d.Estimate).WithMany(p => p.EvaluatedResults).HasForeignKey(d => d.EstimateId);

            entity.HasOne(d => d.FieldOfUse).WithMany(p => p.EvaluatedResults).HasForeignKey(d => d.FieldOfUseId);

            entity.HasOne(d => d.News).WithMany(p => p.EvaluatedResults).HasForeignKey(d => d.NewsId);

            entity.HasOne(d => d.Relevance).WithMany(p => p.EvaluatedResults)
                .HasForeignKey(d => d.RelevanceId)
                .HasConstraintName("FK_EvaluatedResults_NewsRelevance");

            entity.HasOne(d => d.StatisticalSource).WithMany(p => p.EvaluatedResults).HasForeignKey(d => d.StatisticalSourceId);
        });

        modelBuilder.Entity<FieldOfUse>(entity =>
        {
            entity.ToTable("FieldOfUse");
        });

        modelBuilder.Entity<KeyWord>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Par01).HasMaxLength(250);
            entity.Property(e => e.Par02).HasMaxLength(250);
            entity.Property(e => e.Par03).HasMaxLength(250);
            entity.Property(e => e.Par04).HasMaxLength(250);
            entity.Property(e => e.Par05).HasMaxLength(250);
            entity.Property(e => e.Par06).HasMaxLength(250);
            entity.Property(e => e.Par07).HasMaxLength(250);
            entity.Property(e => e.Par08).HasMaxLength(250);
            entity.Property(e => e.Par09).HasMaxLength(250);
            entity.Property(e => e.Par10).HasMaxLength(250);
            entity.Property(e => e.Par11).HasMaxLength(250);
            entity.Property(e => e.Par12).HasMaxLength(250);
            entity.Property(e => e.Par13).HasMaxLength(250);
            entity.Property(e => e.Par14).HasMaxLength(250);
            entity.Property(e => e.Par15).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<KeyWordsDtl>(entity =>
        {
            entity.ToTable("KeyWordsDtl");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Par01).HasMaxLength(250);
            entity.Property(e => e.Par02).HasMaxLength(250);
            entity.Property(e => e.Par03).HasMaxLength(250);
            entity.Property(e => e.Par04).HasMaxLength(250);
            entity.Property(e => e.Par05).HasMaxLength(250);
            entity.Property(e => e.Par06).HasMaxLength(250);
            entity.Property(e => e.Par07).HasMaxLength(250);
            entity.Property(e => e.Par08).HasMaxLength(250);
            entity.Property(e => e.Par09).HasMaxLength(250);
            entity.Property(e => e.Par10).HasMaxLength(250);
            entity.Property(e => e.Par11).HasMaxLength(250);
            entity.Property(e => e.Par12).HasMaxLength(250);
            entity.Property(e => e.Par13).HasMaxLength(250);
            entity.Property(e => e.Par14).HasMaxLength(250);
            entity.Property(e => e.Par15).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<KeyWordsMain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PrimaryKeyWords");

            entity.ToTable("KeyWordsMain");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<MedName>(entity =>
        {
            entity.ToTable("MedName");

            entity.Property(e => e.EnName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FrName).HasMaxLength(200);
        });

        modelBuilder.Entity<NegativeOilNewsForSendingSm>(entity =>
        {
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(CONVERT([bigint],(0)))");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            entity.Property(e => e.UniqueCode).HasMaxLength(6);
        });

        modelBuilder.Entity<NegativeReason>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<NewsCount>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<NewsInserted>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EstimateDscp).HasMaxLength(400);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp).HasMaxLength(20);
            entity.Property(e => e.NewsPublishedDate).HasMaxLength(50);
            entity.Property(e => e.NewsTitle).HasMaxLength(500);
            entity.Property(e => e.NewsUrl)
                .HasMaxLength(150)
                .HasColumnName("NewsURL");
            entity.Property(e => e.UserCreatedIp).HasMaxLength(20);
        });

        modelBuilder.Entity<NewsInsertedsCmd>(entity =>
        {
            entity.ToTable("NewsInsertedsCmd");

            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<NewsRelevance>(entity =>
        {
            entity.ToTable("NewsRelevance");

            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<NewsRssReed>(entity =>
        {
            entity.ToTable("NewsRssReed");

            entity.HasIndex(e => e.CreateDate, "Ix_NewsRssReed_CreateDate");

            entity.HasIndex(e => e.CreateDate, "Ix_NewsRssReed_CreateDate_In_ProcDate_IsOil");

            entity.HasIndex(e => e.LinkUrl, "Ix_NewsRssReed_LinkUrl").IsUnique();

            entity.HasIndex(e => e.ProcDate, "Ix_NewsRssReed_LinkUrl_ProcDate");

            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Enclosure).HasMaxLength(100);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LinkUrl).HasMaxLength(200);
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProcDate).HasColumnType("datetime");
            entity.Property(e => e.PublishedDate).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(1000);
        });

        modelBuilder.Entity<NewsRssReed2>(entity =>
        {
            entity.ToTable("NewsRssReed2");

            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Enclosure).HasMaxLength(100);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LinkUrl).HasMaxLength(200);
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NotOil).HasDefaultValueSql("((0))");
            entity.Property(e => e.ProcDate).HasColumnType("datetime");
            entity.Property(e => e.PublishedDate).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(1000);
        });

        modelBuilder.Entity<NewsRssReedProc>(entity =>
        {
            entity.ToTable("NewsRssReedProc");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KeyWordsDtlTitle).HasMaxLength(200);
            entity.Property(e => e.KeyWordsMainTitle).HasMaxLength(200);
            entity.Property(e => e.KeyWordsTitle).HasMaxLength(200);
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NewsSource>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SiteUri)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SourceDescription).HasMaxLength(1000);
            entity.Property(e => e.SourceTitle).HasMaxLength(200);
        });

        modelBuilder.Entity<NewsSourceDetail>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SourceTitle).HasMaxLength(200);
            entity.Property(e => e.SourceUrl)
                .HasMaxLength(500)
                .HasColumnName("SourceURL");

            entity.HasOne(d => d.NewsSource).WithMany(p => p.NewsSourceDetails).HasForeignKey(d => d.NewsSourceId);

            entity.HasOne(d => d.SourceDetail).WithMany(p => p.InverseSourceDetail).HasForeignKey(d => d.SourceDetailId);
        });

        modelBuilder.Entity<SendMob>(entity =>
        {
            entity.ToTable("SendMob");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsSend).HasDefaultValueSql("((1))");
            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SendMobTyp>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("SendMobTyp");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<SendSm>(entity =>
        {
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Detail).HasMaxLength(200);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SendedText).HasMaxLength(2000);
        });

        modelBuilder.Entity<TbCaln>(entity =>
        {
            entity.ToTable("TbCaln");

            entity.Property(e => e.DateEn).HasColumnType("date");
            entity.Property(e => e.DateEn1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateEn2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateFa1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateFa2)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsPrivateInList)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Username).HasMaxLength(200);
        });

        modelBuilder.Entity<TbUserRole>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);

            entity.HasOne(d => d.Role).WithMany(p => p.TbUserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.TbUserRoles).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<TelegramChannel>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TelegramChannelName).HasMaxLength(50);
        });

        modelBuilder.Entity<TelegramPost>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("Tr_TelegramPosts"));

            entity.HasIndex(e => e.CreateDate, "Ix_TelegramPosts_CreateDate");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PostDate).HasMaxLength(50);
            entity.Property(e => e.PostEditedDate).HasMaxLength(50);
            entity.Property(e => e.PostUsername).HasMaxLength(50);

            entity.HasOne(d => d.TelegramChannel).WithMany(p => p.TelegramPosts)
                .HasForeignKey(d => d.TelegramChannelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TelegramPosts_TelegramChannels");
        });

        modelBuilder.Entity<TempKeyWord>(entity =>
        {
            entity.Property(e => e.KeyWordsDtlTitle).HasMaxLength(200);
            entity.Property(e => e.KeyWordsMainTitle).HasMaxLength(200);
            entity.Property(e => e.KeyWordsTitle).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
