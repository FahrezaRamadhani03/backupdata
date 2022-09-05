// <copyright file="BudgetActivity.cs" company="CV Garuda Infinity Kreasindo">
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
    public class BudgetActivity : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [DefaultValue(false)]
        public bool IsShowInProjectExpense { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetTypeId.
        /// </summary>
        public Guid BudgetTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetType.
        /// </summary>
        public BudgetType BudgetType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Expenses.
        /// </summary>
        public IList<Expense> Expenses { get; set; } = new List<Expense>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetDetails.
        /// </summary>
        public IList<BudgetDetail> BudgetDetails { get; set; } = new List<BudgetDetail>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BudgetActivity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name);

                entity.Property(e => e.IsShowInProjectExpense);

                entity.HasOne(e => e.BudgetType)
                .WithMany(e => e.BudgetActivities)
               .HasForeignKey(e => e.BudgetTypeId);

                entity.ToTable("BudgetActivities");

                entity.HasData(ActivitySeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
