// <copyright file="ExpenseBill.cs" company="CV Garuda Infinity Kreasindo">
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

    public class ExpenseBill : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for OriginalFilename.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string OriginalFilename { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Filename.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ExpenseId.
        /// </summary>
        public Guid ExpenseId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Expense.
        /// </summary>
        public Expense Expense { get; set; }

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ExpenseBill>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OriginalFilename);

                entity.Property(e => e.Filename);

                entity.HasOne(e => e.Expense)
                .WithMany(e => e.ExpenseBills)
                .HasForeignKey(e => e.ExpenseId);

                entity.ToTable("ExpenseBills");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
