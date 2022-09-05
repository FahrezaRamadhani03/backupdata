// <copyright file="Employee.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.Common.Models.Datas;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class Employee : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for EmployeeNo.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50)]
        public string EmployeeNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Fullname.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Nickname.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Birth Place.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string BirthPlace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Birth Date.
        /// </summary>
        [Required]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Hire Date.
        /// </summary>
        [Required]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Resign Date.
        /// </summary>
        public DateTime? ResignDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Email.
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Status.
        /// </summary>
        [StringLength(maximumLength: 100)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Married Status.
        /// </summary>
        [StringLength(maximumLength: 100)]
        public string MarriedStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Married Date.
        /// </summary>
        public DateTime? MarriedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Number Of Childern.
        /// </summary>
        public int? NumberOfChildern { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for UserId.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Developers.
        /// </summary>
        public IList<Developer> Developers { get; set; } = new List<Developer>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Notifications.
        /// </summary>
        public IList<Notification> Notifications { get; set; } = new List<Notification>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeNo);

                entity.Property(e => e.Fullname);

                entity.Property(e => e.Nickname);

                entity.Property(e => e.BirthPlace);

                entity.Property(e => e.BirthDate);

                entity.Property(e => e.HireDate);

                entity.Property(e => e.ResignDate);

                entity.Property(e => e.Email);

                entity.Property(e => e.Status);

                entity.Property(e => e.MarriedStatus);

                entity.Property(e => e.MarriedDate);

                entity.Property(e => e.NumberOfChildern);

                entity.HasOne(e => e.User)
               .WithMany()
               .HasForeignKey(e => e.UserId);

                entity.ToTable("Employees");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
