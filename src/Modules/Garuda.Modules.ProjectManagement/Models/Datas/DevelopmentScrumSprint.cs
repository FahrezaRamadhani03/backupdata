// <copyright file="DevelopmentScrumSprint.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class DevelopmentScrumSprint : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentScrumId.
        /// </summary>
        public Guid DevelopmentScrumId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentScrum.
        /// </summary>
        public DevelopmentScrum DevelopmentScrum { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Sprintname.
        /// </summary>
        [StringLength(maximumLength: 100)]
        public string Sprintname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintStart.
        /// </summary>
        public DateTime SprintStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintEnd.
        /// </summary>
        public DateTime SprintEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DayLength.
        /// </summary>
        public int DayLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for HolidayLength.
        /// </summary>
        public int HolidayLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remark.
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for IsExtendDays.
        /// </summary>
        [DefaultValue(false)]
        public bool IsExtendDays { get; set; }

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<DevelopmentScrumSprint>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DevelopmentScrumId);

                entity.HasOne(e => e.DevelopmentScrum)
               .WithMany(e => e.DevelopmentScrumSprints)
               .HasForeignKey(e => e.DevelopmentScrumId);

                entity.Property(e => e.Sprintname);

                entity.Property(e => e.SprintStart);

                entity.Property(e => e.SprintEnd);

                entity.Property(e => e.DayLength);

                entity.Property(e => e.HolidayLength);

                entity.Property(e => e.Remark);

                entity.Property(e => e.IsExtendDays);

                entity.ToTable("DevelopmentScrumSprint");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
