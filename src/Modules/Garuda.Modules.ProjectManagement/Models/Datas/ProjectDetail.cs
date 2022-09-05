// <copyright file="ProjectDetail.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class ProjectDetail : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Client Id.
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Detail.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [StringLength(maximumLength: 4)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Key.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for InitState.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string TypeOfCoorporation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for InitState.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string InitState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Status.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ShortDescription.
        /// </summary>
        [StringLength(maximumLength: 1024)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Technology.
        /// </summary>
        [JsonField]
        public string Technology { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PICName.
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string PICName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PICPhone.
        /// </summary>
        [StringLength(maximumLength: 50)]
        public string PICPhone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PICEmail.
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string PICEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Overdue Length.
        /// </summary>
        public int OverdueLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Overdue Unit.
        /// </summary>
        [StringLength(maximumLength: 100)]
        public string OverdueUnit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for KickoffDate.
        /// </summary>
        public DateTime? KickoffDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentStart.
        /// </summary>
        public DateTime? DevelopmentStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentEnd.
        /// </summary>
        public DateTime? DevelopmentEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceLength.
        /// </summary>
        public int MaintenanceLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceStart.
        /// </summary>
        public DateTime? MaintenanceStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceEnd.
        /// </summary>
        public DateTime? MaintenanceEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for MaintenanceUnit.
        /// </summary>
        [StringLength(maximumLength: 100)]
        public string MaintenanceUnit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentMethod.
        /// </summary>
        [StringLength(maximumLength: 100)]
        public string DevelopmentMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectResources.
        /// </summary>
        public IList<ProjectResources> ProjectResources { get; set; } = new List<ProjectResources>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentHolidays.
        /// </summary>
        public IList<DevelopmentHoliday> DevelopmentHolidays { get; set; } = new List<DevelopmentHoliday>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentHolidays.
        /// </summary>
        public IList<DevelopmentScrum> DevelopmentScrums { get; set; } = new List<DevelopmentScrum>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Proposal
        /// </summary>
        public IList<Proposal> Proposals { get; set; } = new List<Proposal>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for ContractInfo
        /// </summary>
        public IList<ContractInfo> ContractInfo { get; set; } = new List<ContractInfo>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTerms.
        /// </summary>
        public IList<PaymentTerm> PaymentTerms { get; set; } = new List<PaymentTerm>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for PaymentTerms.
        /// </summary>
        public IList<ProjectDevelopmentTeam> ProjectDevelopmentTeams { get; set; } = new List<ProjectDevelopmentTeam>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for ProjectFile
        /// </summary>
        public IList<ProjectFile> ProjectFiles { get; set; } = new List<ProjectFile>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for ProjectFile
        /// </summary>
        public IList<ProjectScrumTeam> ProjectScrumTeams { get; set; } = new List<ProjectScrumTeam>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Invoice.
        /// </summary>
        public IList<Invoice> Invoices { get; set; } = new List<Invoice>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for ProjectHistories
        /// </summary>
        public IList<ProjectHistory> ProjectHistories { get; set; } = new List<ProjectHistory>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for ProposalHistories
        /// </summary>
        public IList<ProposalHistory> ProposalHistories { get; set; } = new List<ProposalHistory>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Expenses
        /// </summary>
        public IList<Expense> Expenses { get; set; } = new List<Expense>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Notifications
        /// </summary>
        public IList<Notification> Notifications { get; set; } = new List<Notification>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProjectDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ClientId);

                entity.HasOne(e => e.Client)
                .WithMany(e => e.ProjectDetails)
                .HasForeignKey(e => e.ClientId);

                entity.Property(e => e.Code);

                entity.Property(e => e.Name);

                entity.Property(e => e.Key);

                entity.Property(e => e.InitState);

                entity.Property(e => e.TypeOfCoorporation);

                entity.Property(e => e.Status);

                entity.Property(e => e.ShortDescription);

                entity.Property(e => e.Description);

                entity.Property(e => e.Technology);

                entity.Property(e => e.PICName);

                entity.Property(e => e.PICPhone);

                entity.Property(e => e.PICEmail);

                entity.Property(e => e.OverdueLength);

                entity.Property(e => e.OverdueUnit);

                entity.Property(e => e.KickoffDate);

                entity.Property(e => e.DevelopmentStart);

                entity.Property(e => e.DevelopmentEnd);

                entity.Property(e => e.MaintenanceLength);

                entity.Property(e => e.MaintenanceStart);

                entity.Property(e => e.MaintenanceEnd);

                entity.Property(e => e.MaintenanceUnit);

                entity.Property(e => e.DevelopmentMethod);

                entity.ToTable("Projects");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
