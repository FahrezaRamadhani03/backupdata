// <copyright file="BudgetDetail.cs" company="CV Garuda Infinity Kreasindo">
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
    public class BudgetDetail : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetId.
        /// </summary>
        public Guid BudgetId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Budget.
        /// </summary>
        public Budget Budget { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivityId.
        /// </summary>
        public Guid BudgetTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivity.
        /// </summary>
        public BudgetType BudgetType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivityId.
        /// </summary>
        public Guid BudgetActivityId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivity.
        /// </summary>
        public BudgetActivity BudgetActivity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetPercentage.
        /// </summary>
        public decimal BudgetPercentage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetAmount.
        /// </summary>
        public decimal BudgetAmount { get; set; }

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BudgetDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Budget)
               .WithMany(e => e.BudgetDetails)
               .HasForeignKey(e => e.BudgetId);

                entity.HasOne(e => e.BudgetType)
               .WithMany(e => e.BudgetDetails)
               .HasForeignKey(e => e.BudgetTypeId);

                entity.HasOne(e => e.BudgetActivity)
               .WithMany(e => e.BudgetDetails)
               .HasForeignKey(e => e.BudgetActivityId);

                entity.Property(e => e.BudgetPercentage)
                .IsRequired();

                entity.Property(e => e.BudgetAmount)
                .IsRequired();

                entity.ToTable("BudgetDetails");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
