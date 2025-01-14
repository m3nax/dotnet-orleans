﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orleans.GrainDirectory.EntityFrameworkCore.SqlServer.Data;

#nullable disable

namespace Orleans.GrainDirectory.EntityFrameworkCore.SqlServer.Data.Migrations
{
    [DbContext(typeof(SqlServerGrainDirectoryDbContext))]
    partial class SqlServerGrainDirectoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Orleans.GrainDirectory.EntityFrameworkCore.Data.GrainActivationRecord", b =>
                {
                    b.Property<string>("ClusterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GrainId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActivationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("ETag")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<long>("MembershipVersion")
                        .HasColumnType("bigint");

                    b.Property<string>("SiloAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClusterId", "GrainId")
                        .HasName("PK_Activations");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ClusterId", "GrainId"), false);

                    b.HasIndex("ClusterId", "SiloAddress")
                        .HasDatabaseName("IDX_Activations_CusterId_SiloAddress");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("ClusterId", "SiloAddress"), false);

                    b.HasIndex("ClusterId", "GrainId", "ActivationId")
                        .HasDatabaseName("IDX_Activations_ClusterId_GrainId_ActivationId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("ClusterId", "GrainId", "ActivationId"), false);

                    b.ToTable("Activations");
                });
#pragma warning restore 612, 618
        }
    }
}