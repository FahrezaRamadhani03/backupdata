// <copyright file="ContractInfo.cs" company="CV Garuda Infinity Kreasindo">
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
    public class ContractInfo : BaseModel, IEntity, IEntityRegister
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
        /// Gets or sets a value indicating whether gets or Sets for GikContractNo.
        /// </summary>
        public string GikContractNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for GikFileName.
        /// </summary>
        public string GikFileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for GikFileNameOri.
        /// </summary>
        public string GikFileNameOri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ClientContractNo.
        /// </summary>
        public string ClientContractNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ClientFileName.
        /// </summary>
        public string ClientFileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ClientFileNameOri.
        /// </summary>
        public string ClientFileNameOri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for OtherInfo.
        /// </summary>
        public string OtherInfo { get; set; }

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
            modelbuilder.Entity<ContractInfo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Project)
                .WithMany(e => e.ContractInfo)
                .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.GikContractNo)
                .HasMaxLength(255);

                entity.Property(e => e.GikFileName)
                .HasMaxLength(512);

                entity.Property(e => e.GikFileNameOri)
                .HasMaxLength(512);

                entity.Property(e => e.ClientContractNo)
                .HasMaxLength(255);

                entity.Property(e => e.ClientFileName)
                .HasMaxLength(512);

                entity.Property(e => e.ClientFileNameOri)
                .HasMaxLength(512);

                entity.Property(e => e.OtherInfo)
                .HasMaxLength(512);

                entity.ToTable("ContractInfo");

                entity.HasQueryFilter(x => x.DeletedDate == null);
            });
        }
    }
}
