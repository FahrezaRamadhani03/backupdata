// <copyright file="GroupMenuPermission.cs" company="CV Garuda Infinity Kreasindo">
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
    public class GroupMenuPermission : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MenuId.
        /// </summary>
        public Guid MenuId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Menu.
        /// </summary>
        public Menu Menu { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for GroupId.
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Group.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for CanView.
        /// </summary>
        public bool CanView { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for CanUpdate.
        /// </summary>
        public bool CanUpdate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for CanCreate.
        /// </summary>
        public bool CanCreate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for CanDelete.
        /// </summary>
        public bool CanDelete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for CanSubmit.
        /// </summary>
        public bool CanSubmit { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<GroupMenuPermission>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Group)
                .WithMany(e => e.GroupMenuPermissions)
                .HasForeignKey(e => e.GroupId);

                entity.HasOne(e => e.Menu)
                .WithMany(e => e.GroupMenuPermissions)
                .HasForeignKey(e => e.MenuId);

                entity.Property(e => e.CanCreate);

                entity.Property(e => e.CanDelete);

                entity.Property(e => e.CanSubmit);

                entity.Property(e => e.CanUpdate);

                entity.Property(e => e.CanView);

                entity.ToTable("GroupMenuPermissions");

                entity.HasData(GroupMenuPermissionSeeder.Seed());
            });
        }
    }
}
