// <copyright file="PaymentTermTax.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class PaymentTermTax : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Payment Term Id.
        /// </summary>
        [Required]
        public Guid PaymentTermId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Payment Term.
        /// </summary>
        public PaymentTerm PaymentTerm { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Tax Id.
        /// </summary>
        [Required]
        public Guid TaxId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Tax.
        /// </summary>
        public Tax Tax { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<PaymentTermTax>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.PaymentTerm)
               .WithMany(e => e.PaymentTermTaxes)
               .HasForeignKey(e => e.PaymentTermId);

                entity.HasOne(e => e.Tax)
               .WithMany(e => e.PaymentTermTax)
               .HasForeignKey(e => e.TaxId);

                entity.ToTable("PaymentTermTaxes");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
