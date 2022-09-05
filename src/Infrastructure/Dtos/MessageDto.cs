// <copyright file="MessageDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Infrastructure.Dtos
{
    public class MessageDto
    {
        public MessageDto(int status, string title, string messageIdn, string messageEng, object data)
        {
            Title = title;
            Status = status;
            MessageIdn = messageIdn;
            MessageEng = messageEng;
            Data = data;
        }

        public MessageDto(string message)
        {
            Title = string.Empty;
            MessageEng = message;
        }

        /// <summary>
        /// Gets or sets for Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets for Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets for MessageIdn
        /// </summary>
        public string MessageIdn { get; set; }

        /// <summary>
        /// Gets or sets for MessageEng
        /// </summary>
        public string MessageEng { get; set; }

        /// <summary>
        /// Gets or sets for Data
        /// </summary>
        public object Data { get; set; }
    }
}
