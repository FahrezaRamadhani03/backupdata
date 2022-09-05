// <copyright file="DevelopmentScrum.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class DevelopmentScrum : BaseModel, IEntity, IEntityRegister
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
        /// Gets or sets a value indicating whether gets or Sets for Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DaysInSprint.
        /// </summary>
        public string DaysInSprint { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentHolidays.
        /// </summary>
        public IList<DevelopmentScrumSprint> DevelopmentScrumSprints { get; set; } = new List<DevelopmentScrumSprint>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<DevelopmentScrum>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProjectId);

                entity.HasOne(e => e.ProjectDetail)
               .WithMany(e => e.DevelopmentScrums)
               .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.Quantity);

                entity.Property(e => e.DaysInSprint);

                entity.ToTable("DevelopmentScrum");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
