// <copyright file="InvoicePayment.cs" company="CV Garuda Infinity Kreasindo">
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
    public class InvoicePayment : BaseModel, IEntity, IEntityRegister
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
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Id.
        /// </summary>
        [Required]
        public Guid BankId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Project
        /// </summary>
        public Bank Bank { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [Required]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Payment Term
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string Remarks { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<InvoicePayment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Invoice)
               .WithMany(e => e.InvoicePayments)
               .HasForeignKey(e => e.InvoiceId);

                entity.HasOne(e => e.Bank)
               .WithMany(e => e.InvoicePayments)
               .HasForeignKey(e => e.BankId);

                entity.Property(e => e.AccountName)
                .IsRequired();

                entity.Property(e => e.PaymentAmount)
                .IsRequired();

                entity.Property(e => e.PaymentDate)
                .IsRequired();

                entity.Property(e => e.Remarks);

                entity.ToTable("InvoicePayments");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
