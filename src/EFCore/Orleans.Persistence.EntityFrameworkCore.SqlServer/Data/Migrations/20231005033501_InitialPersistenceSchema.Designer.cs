﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orleans.Persistence.EntityFrameworkCore.SqlServer.Data;

#nullable disable

namespace Orleans.Persistence.EntityFrameworkCore.SqlServer.Data.Migrations
{
    [DbContext(typeof(SqlServerGrainStateDbContext))]
    [Migration("20231005033501_InitialPersistenceSchema")]
    partial class InitialPersistenceSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Orleans.Persistence.EntityFrameworkCore.Data.GrainStateRecord", b =>
                {
                    b.Property<string>("ServiceId")
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<string>("GrainType")
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<string>("StateType")
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<string>("GrainId")
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ETag")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ServiceId", "GrainType", "StateType", "GrainId")
                        .HasName("PK_GrainState");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ServiceId", "GrainType", "StateType", "GrainId"), false);

                    b.ToTable("GrainState");
                });
#pragma warning restore 612, 618
        }
    }
}