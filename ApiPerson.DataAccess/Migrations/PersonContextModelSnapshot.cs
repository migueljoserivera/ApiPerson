﻿// <auto-generated />
using System;
using ApiPerson.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiPerson.DataAccess.Migrations
{
    [DbContext(typeof(PersonContext))]
    partial class PersonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("ApiPerson.Entities.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("PersonId");

                    b.Property<bool>("Verified");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("ApiPerson.Entities.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Lastname");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ApiPerson.Entities.Models.Email", b =>
                {
                    b.HasOne("ApiPerson.Entities.Models.Person")
                        .WithMany("Emails")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}