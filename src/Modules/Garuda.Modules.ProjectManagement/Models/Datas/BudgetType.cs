// <copyright file="BudgetType.cs" company="CV Garuda Infinity Kreasindo">
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
    public class BudgetType : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for TypeName.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivities.
        /// </summary>
        public IList<BudgetActivity> BudgetActivities { get; set; } = new List<BudgetActivity>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivities.
        /// </summary>
        public IList<BudgetDetail> BudgetDetails { get; set; } = new List<BudgetDetail>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BudgetType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TypeName);

                entity.ToTable("BudgetTypes");

                entity.HasData(BudgetTypeSeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
