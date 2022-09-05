// <copyright file="ProjectSPK.cs" company="CV Garuda Infinity Kreasindo">
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
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class ProjectSPK : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectHistoryId.
        /// </summary>
        [Required]
        public Guid ProjectHistoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectHistory.
        /// </summary>
        public ProjectHistory ProjectHistory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SPKNo.
        /// </summary>
        [Required]
        public string SPKNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SPKDate.
        /// </summary>
        [Required]
        public DateTime? SPKDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for FileNameOri.
        /// </summary>
        public string FileNameOri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for FileName.
        /// </summary>
        public string FileName { get; set; }


        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProjectSPK>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.ProjectHistory)
                .WithMany(e => e.ProjectSPKs)
                .HasForeignKey(e => e.ProjectHistoryId);

                entity.Property(e => e.SPKNo)
                .IsRequired();

                entity.Property(e => e.SPKDate)
                .IsRequired();

                entity.Property(e => e.FileName)
                .HasMaxLength(512);

                entity.Property(e => e.FileNameOri)
                .HasMaxLength(512);

                entity.ToTable("ProjectSPK");

                entity.HasQueryFilter(x => x.DeletedDate == null);
            });
        }
    }
}
