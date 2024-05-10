﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using sda_onsite_2_csharp_backend_teamwork.src.Databases;
using sda_onsite_2_csharp_backend_teamwork.src.Enums;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "role", new[] { "customer", "admin" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("size");

                    b.HasKey("Id")
                        .HasName("pk_inventories");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_inventories_product_id");

                    b.ToTable("inventories", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_orders_user_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("inventory_id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("integer")
                        .HasColumnName("total_price");

                    b.HasKey("Id")
                        .HasName("pk_order_items");

                    b.HasIndex("InventoryId")
                        .HasDatabaseName("ix_order_items_inventory_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_items_order_id");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<Role>("Role")
                        .HasColumnType("role")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Inventory", b =>
                {
                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entities.Product", null)
                        .WithMany("Inventory")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_inventories_products_product_id");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Order", b =>
                {
                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entities.User", null)
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_users_user_id");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.OrderItem", b =>
                {
                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entities.Inventory", null)
                        .WithMany("OrderItem")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_items_inventories_inventory_id");

                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entities.Order", null)
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_items_orders_order_id");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Product", b =>
                {
                    b.HasOne("sda_onsite_2_csharp_backend_teamwork.src.Entities.Category", null)
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_categories_category_id");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Inventory", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Order", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.Product", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("sda_onsite_2_csharp_backend_teamwork.src.Entities.User", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
