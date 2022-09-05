// <copyright file="DevelopmentHoliday.cs" company="CV Garuda Infinity Kreasindo">
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
    public class DevelopmentHoliday : BaseModel, IEntity, IEntityRegister
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
        /// Gets or sets a value indicating whether gets or Sets for HolidayDate.
        /// </summary>
        public DateTime HolidayDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentScrumSprintId.
        /// </summary>
        public Guid DevelopmentScrumSprintId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentScrumSprint.
        /// </summary>
        public DevelopmentScrumSprint DevelopmentScrumSprint { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Description.
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string Description { get; set; }

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<DevelopmentHoliday>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProjectId);

                entity.HasOne(e => e.ProjectDetail)
               .WithMany(e => e.DevelopmentHolidays)
               .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.HolidayDate);

                entity.Property(e => e.Description);

                entity.ToTable("DevelopmentHoliday");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
