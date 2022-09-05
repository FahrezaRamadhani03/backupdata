// <copyright file="InvoiceDetail.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.ProjectManagement.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class InvoiceDetail : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Id.
        /// </summary>
        [Required]
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Project
        /// </summary>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        [StringLength(maximumLength: 512)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Invoice)
               .WithMany(e => e.InvoiceDetails)
               .HasForeignKey(e => e.InvoiceId);

                entity.Property(e => e.Description)
                .IsRequired();

                entity.Property(e => e.Quantity)
                .IsRequired();

                entity.Property(e => e.Price)
                .IsRequired();

                entity.Property(e => e.Discount);

                entity.Property(e => e.Subtotal)
                .IsRequired();

                entity.ToTable("InvoiceDetails");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
