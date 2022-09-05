// <copyright file="ProposalHistory.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ProposalHistory : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectId.
        /// </summary>
        [Required]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DocumentNo.
        /// </summary>
        [Required]
        public string ProposalNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectAmount.
        /// </summary>
        [Required]
        public int ProjectAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SentDate.
        /// </summary>
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for FileNameOri.
        /// </summary>
        public string FileNameOri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for FileName.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remark.
        /// </summary>
        public string Remark { get; set; }

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
            modelbuilder.Entity<ProposalHistory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Project)
                .WithMany(e => e.ProposalHistories)
                .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.ProposalNo)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.ProjectAmount)
                .IsRequired();

                entity.Property(e => e.SentDate);

                entity.Property(e => e.FileName);

                entity.Property(e => e.FileNameOri);

                entity.Property(e => e.ProposalNo);

                entity.Property(e => e.Remark)
                .HasMaxLength(512);

                entity.ToTable("ProposalHistories");

                entity.HasQueryFilter(x => x.DeletedDate == null);
            });
        }
    }
}
