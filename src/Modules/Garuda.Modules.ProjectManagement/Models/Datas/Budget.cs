// <copyright file="Budget.cs" company="CV Garuda Infinity Kreasindo">
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
    public class Budget : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Projection.
        /// </summary>
        public decimal Projection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTermTax.
        /// </summary>
        public IList<BudgetDetail> BudgetDetails { get; set; } = new List<BudgetDetail>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Budget>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Year)
                .IsRequired();

                entity.Property(e => e.Projection)
                .IsRequired();

                entity.ToTable("Budgets");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
