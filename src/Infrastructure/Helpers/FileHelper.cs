// <copyright file="FileHelper.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Text.RegularExpressions;
using Garuda.Infrastructure.Constants;

namespace Garuda.Infrastructure.Helpers
{
    public class FileHelper
    {
        public static string UploadBase64File(string identity, string base64, string fileRootFolder)
        {
            var (bytes, type) = GetFileDetail(base64);

            var filename = string.Concat(identity, type);
            var directory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(directory, FileConstant.WWWROOT, fileRootFolder);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath = Path.Combine(filePath, filename);

            if (bytes.Length > 0)
            {
                using var stream = new FileStream(filePath, FileMode.Create);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }

            return Path.Combine(fileRootFolder, filename);
        }

        public static void DeleteImage(string filename)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), FileConstant.WWWROOT, filename);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void DeleteFile(string filename, string filepath)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), filepath, filename);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static (byte[] bytes, string type) GetFileDetail(string base64)
        {
            var type = GetFileExtension(base64);
            var result = Regex.Replace(base64.Trim(), "^data:([a-zA-Z]+/[a-zA-Z.-]+);base64,", string.Empty).Trim();
            var bytes = Convert.FromBase64String(result);
            return (bytes, type);
        }

        public static bool IsBase64(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
            {
                return false;
            }

            var base64String = Regex.Replace(base64.Trim(), "^data:([a-zA-Z]+/[a-zA-Z.-]+);base64,", string.Empty).Trim();
            if (base64String.Length % 4 != 0 || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
            {
                return false;
            }

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 7)
                      + Path.GetExtension(fileName);
        }

        public static void RemoveDirectory(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                Directory.Delete(dirPath, true);
            }
        }

        public static string GetBase64File(string path)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path);
            var fileByte = File.ReadAllBytes(filePath);
            string file = Convert.ToBase64String(fileByte);

            return file;
        }

        private static string GetFileExtension(string base64)
        {
            var match = Regex.Match(base64, "^data:([a-zA-Z]+/[a-zA-Z.-]+);base64,");
            if (match.Groups.Count < 2)
            {
                return string.Empty;
            }

            return match.Groups[1].Value.ToLower() switch
            {
                "image/png" => ".png",
                "image/jpeg" => ".jpg",
                "application/pdf" => ".pdf",
                "application/msword" => ".doc",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document" => ".docx",
                "application/vnd.ms-excel" => ".xls",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" => ".xlsx",
                "text/csv" => ".csv",
                _ => string.Empty,
            };
        }

        public static string GetFileContextType(string fileExt)
        {
            return fileExt switch
            {
                ".csv" => "text/csv",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".gif" => "image/gif",
                ".jpeg" => "image/jpeg",
                ".jpg" => "image/jpeg",
                ".pdf" => "application/pdf",
                ".png" => "image/png",
                ".xls" => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => string.Empty,
            };
        }
    }
}
