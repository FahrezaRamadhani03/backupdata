// <copyright file="ProjectFile.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ProjectFile : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectId.
        /// </summary>
        [Required]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DocumentName.
        /// </summary>
        [Required]
        public string DocumentName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DocumentDesc.
        /// </summary>
        public string DocumentDesc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for FileSource.
        /// </summary>
        /// [Required]
        public string FileSource { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for FileNameOri.
        /// </summary>
        public string FileNameOri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for FileName.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Link.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project.
        /// </summary>
        public ProjectDetail Project { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProjectFile>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Project)
                .WithMany(e => e.ProjectFiles)
                .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.DocumentName)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.DocumentDesc)
                .HasMaxLength(1024);

                entity.Property(e => e.FileSource)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.FileName)
                .HasMaxLength(512);

                entity.Property(e => e.FileNameOri)
                .HasMaxLength(512);

                entity.Property(e => e.Link);

                entity.ToTable("ProjectFiles");

                entity.HasQueryFilter(x => x.DeletedDate == null);
            });
        }
    }
}
