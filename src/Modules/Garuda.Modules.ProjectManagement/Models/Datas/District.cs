// <copyright file="District.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.ProjectManagement.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class District : BaseModel, IEntity, IEntityRegister
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
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for City Id.
        /// </summary>
        public Guid CityId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for City.
        /// </summary>
        public City City { get; set; }

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name);

                entity.Property(e => e.Code);

                entity.HasOne(e => e.City)
                .WithMany(e => e.Districts)
                .HasForeignKey(e => e.CityId);

                entity.ToTable("Districts");

                entity.HasData(DistrictSeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
