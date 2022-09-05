// <copyright file="InvoiceFileHistory.cs" company="CV Garuda Infinity Kreasindo">
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

    public class InvoiceFileHistory : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for OriginalFilename.
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Invoice
        /// </summary>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Filename.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string Filename { get; set; }

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<InvoiceFileHistory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Filename);

                entity.HasOne(e => e.Invoice)
                .WithMany(e => e.InvoiceFileHistories)
                .HasForeignKey(e => e.InvoiceId);

                entity.ToTable("InvoiceFileHistories");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
