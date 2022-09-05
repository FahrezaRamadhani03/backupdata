// <copyright file="SchemeUnit.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.Common.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Common.Models.Datas
{
    public class SchemeUnit : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for UnitId
        /// </summary>
        public Guid UnitId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Unit
        /// </summary>
        public Unit Unit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for SchemeId
        /// </summary>
        public Guid SchemeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Scheme
        /// </summary>
        public Scheme Scheme { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<SchemeUnit>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Unit)
                .WithMany(e => e.SchemeUnits)
                .HasForeignKey(e => e.UnitId);

                entity.HasOne(e => e.Scheme)
                .WithMany(e => e.SchemeUnits)
                .HasForeignKey(e => e.SchemeId);

                entity.ToTable("SchemeUnits");

                entity.HasData(SchemeUnitSeeder.Seed());
            });
        }
    }
}
