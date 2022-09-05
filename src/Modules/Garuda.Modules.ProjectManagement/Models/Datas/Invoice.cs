// <copyright file="Invoice.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.ProjectManagement.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class Invoice : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Invoice No.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Id.
        /// </summary>
        [Required]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Project
        /// </summary>
        public ProjectDetail ProjectDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Payment Term Id.
        /// </summary>
        public Guid? PaymentTermId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public PaymentTerm PaymentTerm { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public string AdditionalNote { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public int OverdueLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public string OverdueUnit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public DateTime OverdueDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public DateTime ReminderDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public decimal DiscountTotal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public bool IsAdditionalDiscount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public decimal AdditionalDiscount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public decimal TotalPayment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public DateTime? SendDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for BillingAddress
        /// </summary>
        public string BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for CompanyName
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTermTax.
        /// </summary>
        public IList<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTermTax.
        /// </summary>
        public IList<InvoiceDetailTax> InvoiceDetailTaxes { get; set; } = new List<InvoiceDetailTax>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTermTax.
        /// </summary>
        public IList<InvoicePayment> InvoicePayments { get; set; } = new List<InvoicePayment>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTermTax.
        /// </summary>
        public IList<InvoiceFileHistory> InvoiceFileHistories { get; set; } = new List<InvoiceFileHistory>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceNo)
                .IsRequired();

                entity.HasOne(e => e.ProjectDetail)
               .WithMany(e => e.Invoices)
               .HasForeignKey(e => e.ProjectId);

                entity.HasOne(e => e.PaymentTerm)
               .WithMany(e => e.Invoices)
               .HasForeignKey(e => e.PaymentTermId);

                entity.Property(e => e.InvoiceDate)
                .IsRequired();

                entity.Property(e => e.AdditionalNote);

                entity.Property(e => e.OverdueLength)
                .IsRequired();

                entity.Property(e => e.OverdueUnit)
                .IsRequired();

                entity.Property(e => e.OverdueDate)
                .IsRequired();

                entity.Property(e => e.ReminderDate);

                entity.Property(e => e.Subtotal);

                entity.Property(e => e.DiscountTotal);

                entity.Property(e => e.IsAdditionalDiscount);

                entity.Property(e => e.AdditionalDiscount);

                entity.Property(e => e.TotalPayment);

                entity.Property(e => e.Status);

                entity.Property(e => e.SendDate);

                entity.Property(e => e.Remarks);

                entity.Property(e => e.Filename);

                entity.Property(e => e.CompanyName);

                entity.Property(e => e.BillingAddress);

                entity.ToTable("Invoices");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
