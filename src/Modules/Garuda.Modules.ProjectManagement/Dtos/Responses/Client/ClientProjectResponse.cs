// <copyright file="ClientProjectResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Client
{
    public class ClientProjectResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Periode { get; set; }

        public string Status { get; set; }
    }
}
