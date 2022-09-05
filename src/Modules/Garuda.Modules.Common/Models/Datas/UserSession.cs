// <copyright file="UserSession.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Common.Models.Datas
{
    public partial class UserSession : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for RefreshToken.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for UserId.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DateRevoked.
        /// </summary>
        public DateTime? DateRevoked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DateExpired.
        /// </summary>
        public DateTime DateExpired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Jti.
        /// </summary>
        public string Jti { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<UserSession>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("UserSessions");

                entity.Property(e => e.UserId);

                entity.Property(e => e.DateExpired);

                entity.Property(e => e.DateRevoked);

                entity.Property(e => e.Jti)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshToken)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });
        }
    }
}
