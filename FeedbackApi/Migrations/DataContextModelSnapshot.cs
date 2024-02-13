﻿// <auto-generated />
using System;
using FeedbackApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FeedbackApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FeedbackApi.Models.ChatGPTResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FeedbackId")
                        .HasColumnType("int");

                    b.Property<string>("ResponseMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChatGPTResponses");
                });

            modelBuilder.Entity("FeedbackApi.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedbackMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResponseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResponseId")
                        .IsUnique()
                        .HasFilter("[ResponseId] IS NOT NULL");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("FeedbackApi.Models.Feedback", b =>
                {
                    b.HasOne("FeedbackApi.Models.ChatGPTResponse", "ChatGPTResponse")
                        .WithOne("Feedback")
                        .HasForeignKey("FeedbackApi.Models.Feedback", "ResponseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ChatGPTResponse");
                });

            modelBuilder.Entity("FeedbackApi.Models.ChatGPTResponse", b =>
                {
                    b.Navigation("Feedback");
                });
#pragma warning restore 612, 618
        }
    }
}
