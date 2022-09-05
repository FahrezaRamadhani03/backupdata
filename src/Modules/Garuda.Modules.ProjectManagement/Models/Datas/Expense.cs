// <copyright file="Expense.cs" company="CV Garuda Infinity Kreasindo">
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
    public class Expense : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ActivityId.
        /// </summary>
        public Guid? ActivityId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivity.
        /// </summary>
        public BudgetActivity BudgetActivity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Description.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 512)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for TransactionDate.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 512)]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BillAmount.
        /// </summary>
        [Required]
        public decimal BillAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectId.
        /// </summary>
        public Guid? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectDetail.
        /// </summary>
        public ProjectDetail ProjectDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ExpenseBills.
        /// </summary>
        public IList<ExpenseBill> ExpenseBills { get; set; } = new List<ExpenseBill>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.BudgetActivity)
                .WithMany(e => e.Expenses)
                .HasForeignKey(e => e.ActivityId);

                entity.Property(e => e.Description);

                entity.Property(e => e.TransactionDate);

                entity.Property(e => e.BillAmount);

                entity.HasOne(e => e.ProjectDetail)
                  .WithMany(e => e.Expenses)
                  .HasForeignKey(e => e.ProjectId);

                entity.ToTable("Expenses");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
