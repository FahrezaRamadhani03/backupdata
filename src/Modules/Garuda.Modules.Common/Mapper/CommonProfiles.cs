// <copyright file="CommonProfiles.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using AutoMapper;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Dtos.Responses.Details;
using Garuda.Modules.Common.Models.Datas;

namespace Garuda.Modules.Common.Mapper
{
    /// <summary>
    /// Mapper.
    /// </summary>
    public class CommonProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonProfiles"/> class.
        /// </summary>
        public CommonProfiles()
        {
            CreateMap<Unit, UnitResponses>().ReverseMap();
            CreateMap<User, UserResponses>().ReverseMap();
            CreateMap<User, UsersResponses>().ReverseMap();
            CreateMap<Group, GroupResponses>().ReverseMap();
            CreateMap<Menu, MenuResponses>()
                .ForMember(
                    dst => dst.Link,
                    opt => opt.MapFrom(src => src.Slug))
                .ForMember(
                    dst => dst.Name,
                    opt => opt.MapFrom(src => src.DisplayName))
                .ReverseMap();
            CreateMap<GroupMenuPermission, MenuPermissionsResponses>().ReverseMap();
           }
    }
}
