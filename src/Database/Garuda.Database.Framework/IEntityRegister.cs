// <copyright file="IEntityRegister.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

namespace Garuda.Database.Framework
{
  public interface IEntityRegister
  {
    void RegisterEntities(ModelBuilder modelbuilder);
  }
}