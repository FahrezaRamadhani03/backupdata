
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class Notification : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Messages.
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for EmployeeId.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for EmployeeName.
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Messages.
        /// </summary>
        public ProjectDetail Project { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Messages.
        /// </summary>
        public Guid? ProjectId { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Message);

                entity.HasOne(e => e.Project)
               .WithMany(e => e.Notifications)
               .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId);

                entity.Property(e => e.EmployeeId);

                entity.HasOne(e => e.Employee)
                .WithMany(e => e.Notifications)
                .HasForeignKey(e => e.EmployeeId);

                entity.ToTable("Notifications");

                entity.HasQueryFilter(e => e.DeletedDate == null);

            });
        }
    }
}
