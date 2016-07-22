using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using teste_web_api.DataAccess;

namespace teste_web_api.Migrations
{
    [DbContext(typeof(WebApiContext))]
    [Migration("20160722132326_DbV1")]
    partial class DbV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("teste_web_api.Models.ValuesModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("BusinessValue");

                    b.Property<int>("OtherBussinessValue");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });
        }
    }
}
