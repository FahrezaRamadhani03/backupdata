// <copyright file="Tax.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.ProjectManagement.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class Tax : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Required]
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for IsActive.
        /// </summary>
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTermTax.
        /// </summary>
        public IList<PaymentTermTax> PaymentTermTax { get; set; } = new List<PaymentTermTax>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTermTax.
        /// </summary>
        public IList<InvoiceDetailTax> InvoiceDetailTaxes { get; set; } = new List<InvoiceDetailTax>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Tax>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name);

                entity.HasIndex(e => e.Code);

                entity.Property(e => e.Rate);

                entity.Property(e => e.IsActive);

                entity.ToTable("Taxes");

                entity.HasData(TaxSeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
