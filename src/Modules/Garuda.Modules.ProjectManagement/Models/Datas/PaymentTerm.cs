// <copyright file="PaymentTerm.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class PaymentTerm : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Id.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Detail.
        /// </summary>
        public ProjectDetail ProjectDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Term No.
        /// </summary>
        [Required]
        public int TermNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Title.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remarks.
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Percentage.
        /// </summary>
        [Required]
        public decimal Percentage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Amount.
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Invoice Id.
        /// </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Invoice Date.
        /// </summary>
        [Required]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Reminder Date.
        /// </summary>
        public DateTime ReminderDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Invoice Note.
        /// </summary>
        public string InvoiceNote { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTermTax.
        /// </summary>
        public IList<PaymentTermTax> PaymentTermTaxes { get; set; } = new List<PaymentTermTax>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Invoice.
        /// </summary>
        public IList<Invoice> Invoices { get; set; } = new List<Invoice>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<PaymentTerm>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.ProjectDetail)
               .WithMany(e => e.PaymentTerms)
               .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.TermNo);

                entity.Property(e => e.Title);

                entity.Property(e => e.Remarks);

                entity.Property(e => e.Percentage);

                entity.Property(e => e.Amount);

                entity.Property(e => e.InvoiceId);

                entity.Property(e => e.InvoiceDate);

                entity.Property(e => e.ReminderDate);

                entity.Property(e => e.InvoiceNote);

                entity.ToTable("PaymentTerms");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
