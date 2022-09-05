// <copyright file="UserUnit.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.Common.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Common.Models.Datas
{
    public class UserUnit : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for UserId.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for UnitId.
        /// </summary>
        public Guid UnitId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Unit.
        /// </summary>
        public Unit Unit { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<UserUnit>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.User)
                .WithMany(e => e.UserUnits)
                .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Unit).
                WithMany(e => e.UserUnits)
                .HasForeignKey(e => e.UnitId);

                entity.ToTable("UserUnits");

                entity.HasData(UserUnitSeeder.Seed());
            });
        }
    }
}
