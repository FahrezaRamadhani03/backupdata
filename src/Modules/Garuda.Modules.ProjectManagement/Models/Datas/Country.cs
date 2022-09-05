// <copyright file="Country.cs" company="CV Garuda Infinity Kreasindo">
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
    public class Country : BaseModel, IEntity, IEntityRegister
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
        [Required]
        [StringLength(maximumLength: 255)]
        public string Code { get; set; }

        public IList<Province> Provinces { get; set; } = new List<Province>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name);

                entity.Property(e => e.Code);

                entity.ToTable("Countries");

                entity.HasData(CountrySeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
