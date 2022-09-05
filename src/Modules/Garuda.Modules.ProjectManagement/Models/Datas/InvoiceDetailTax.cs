// <copyright file="InvoiceDetailTax.cs" company="CV Garuda Infinity Kreasindo">
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
    public class InvoiceDetailTax : BaseModel, IEntity, IEntityRegister
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
        /// Gets or sets a value indicating whether gets or Sets for Project Id.
        /// </summary>
        [Required]
        public Guid TaxId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Project
        /// </summary>
        public Tax Tax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<InvoiceDetailTax>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Invoice)
               .WithMany(e => e.InvoiceDetailTaxes)
               .HasForeignKey(e => e.InvoiceId);

                entity.HasOne(e => e.Tax)
               .WithMany(e => e.InvoiceDetailTaxes)
               .HasForeignKey(e => e.TaxId);

                entity.Property(e => e.TaxRate)
                .IsRequired();

                entity.Property(e => e.TaxAmount)
                .IsRequired();

                entity.ToTable("InvoiceDetailTaxes");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
