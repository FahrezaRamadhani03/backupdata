// <copyright file="GenerateDocument.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Garuda.Modules.ProjectManagement.Dtos;

namespace Garuda.Modules.ProjectManagement.Helper
{
    public class GenerateDocument
    {
        private string year = DateTime.Now.ToString("yyyy");
        private int month = DateTime.Now.Month;

        public GenerateDocumentNo GenerateInvoiceNumber(string projectKey, int termNo)
        {
            var generator = new GenerateDocumentNo();
            var doc = "INV-" + projectKey + "/" + termNo.ToString("D2") + "/GIK/" + IntToRoman(month) + "/" + year;
            generator.StrDocNo = doc;
            return generator;
        }

        public string IntToRoman(int num)
        {
            var result = string.Empty;
            var map = new Dictionary<string, int>
            {
                { "X", 10 },
                { "IX", 9 },
                { "V", 5 },
                { "IV", 4 },
                { "I", 1 },
            };

            foreach (var pair in map)
            {
                result += string.Join(string.Empty, Enumerable.Repeat(pair.Key, num / pair.Value));
                num %= pair.Value;
            }

            return result;
}
    }
}
