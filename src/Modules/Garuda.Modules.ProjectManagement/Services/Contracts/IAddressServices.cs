// <copyright file="IAddressServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Address Service contract
    /// </summary>
    public interface IAddressServices
    {
        /// <summary>
        /// Get Client Cities
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetCities();

        /// <summary>
        /// Get Client Contries
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetContries();

        /// <summary>
        /// Get Client Districts
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetDistricts();

        /// <summary>
        /// Get Client Proviences
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetProvinces();

        /// <summary>
        /// Create Client Proviences
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateCity(AddressRequest model);

        /// <summary>
        /// Create Client Proviences
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateContry(AddressRequest model);

        /// <summary>
        /// Create Client Proviences
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateDistrict(AddressRequest model);

        /// <summary>
        /// Create Client Proviences
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateProvince(AddressRequest model);
    }
}
