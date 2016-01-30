using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TimeTracker.Model;

namespace TimeTracker.Migrations
{
    [DbContext(typeof(TimeTrackerContext))]
    [Migration("20160129145251_Invoices")]
    partial class Invoices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeTracker.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TimeTracker.Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("From");

                    b.Property<int>("InvoiceNumber");

                    b.Property<bool>("Paid");

                    b.Property<DateTime>("To");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TimeTracker.Model.TimeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<DateTime?>("End");

                    b.Property<int?>("OnInvoiceId");

                    b.Property<DateTime>("Start");

                    b.Property<int>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TimeTracker.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TimeTracker.Model.Invoice", b =>
                {
                    b.HasOne("TimeTracker.Model.Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("TimeTracker.Model.TimeLog", b =>
                {
                    b.HasOne("TimeTracker.Model.Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("TimeTracker.Model.Invoice")
                        .WithMany()
                        .HasForeignKey("OnInvoiceId");

                    b.HasOne("TimeTracker.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
