// <copyright file="MessageLangDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Infrastructure.Dtos
{
    public class MessageLangDto
    {
        public MessageLangDto(string idn, string eng)
        {
            MessageIdn = idn;
            MessageEng = eng;
        }

        public string MessageIdn { get; set; }

        public string MessageEng { get; set; }
    }
}
