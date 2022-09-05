// <copyright file="GoogleCalendarSender.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.GoogleAp.Configurations;
using Garuda.Modules.GoogleAp.Models;
using Garuda.Modules.GoogleAp.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace Garuda.Modules.GoogleAp.Services.Repositories
{
    public class GoogleCalendarSender : IGoogleCalendarSender
    {
        private readonly IConfiguration configuration;
        private readonly CalendarAPIConfig calendarAPIConfig = new CalendarAPIConfig();

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleCalendarSender"/> class.
        /// </summary>
        /// <param name="iconfiguration"></param>
        public GoogleCalendarSender(
            IConfiguration iconfiguration,
            IOptions<CalendarAPIConfig> icalendarAPIConfig)
        {
            this.configuration = iconfiguration;
            this.calendarAPIConfig = icalendarAPIConfig.Value;
        }

        public void Callback(string code, string error, string state)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                this.GetTokens(code);
            }
        }

        public async Task CreateEvent(Event calendarEvent)
        {
            try
            {
                await RefreshToken();
                var tokenFile = Path.Combine(Directory.GetCurrentDirectory(), "tokens.json");
                var tokens = JObject.Parse(File.ReadAllText(tokenFile));

                RestClient restClient = new RestClient(this.calendarAPIConfig.Create);
                RestRequest request = new RestRequest();

                calendarEvent.Start.DateTime = DateTime.Parse(calendarEvent.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
                calendarEvent.End.DateTime = DateTime.Parse(calendarEvent.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");

                var model = JsonConvert.SerializeObject(calendarEvent, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });

                request.AddQueryParameter("key", this.calendarAPIConfig.Key);
                request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", model, ParameterType.RequestBody);

                var response = restClient.Post(request);
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public MessageDto Redirect()
        {
            var credentialsFile = Path.Combine(Directory.GetCurrentDirectory(), "credentials.json");

            JObject credentials = JObject.Parse(File.ReadAllText(credentialsFile));

            var redirectUrl = this.calendarAPIConfig.RedirectUrl;

            return new MessageDto(redirectUrl);
        }

        public async Task<MessageDto> RefreshToken()
        {
            var tokenFile = Path.Combine(Directory.GetCurrentDirectory(), "tokens.json");
            var credentialsFile = Path.Combine(Directory.GetCurrentDirectory(), "credentials.json");
            var credentials = JObject.Parse(File.ReadAllText(credentialsFile));
            var tokens = JObject.Parse(File.ReadAllText(tokenFile));

            RestClient restClient = new RestClient(this.calendarAPIConfig.RefreshToken);
            RestRequest request = new RestRequest();

            request.AddQueryParameter("client_id", credentials["client_id"].ToString());
            request.AddQueryParameter("client_secret", credentials["client_secret"].ToString());
            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", tokens["refresh_token"].ToString());

            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject newTokens = JObject.Parse(response.Content);
                newTokens["refresh_token"] = tokens["refresh_token"].ToString();
                System.IO.File.WriteAllText(tokenFile, newTokens.ToString());
                return new MessageDto("Success");
            }

            return new MessageDto("Error");
        }

        public MessageDto RevokeToken()
        {
            var tokenFile = Path.Combine(Directory.GetCurrentDirectory(), "tokens.json");
            var tokens = JObject.Parse(System.IO.File.ReadAllText(tokenFile));

            RestClient restClient = new RestClient(this.calendarAPIConfig.RevokeToken);
            RestRequest request = new RestRequest();

            request.AddQueryParameter("token", tokens["access_token"].ToString());

            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new MessageDto("Success");
            }

            return new MessageDto("Error");
        }

        public string GetTokens(string code)
        {
            var tokenFile = Path.Combine(Directory.GetCurrentDirectory(), "tokens.json");
            var credentialsFile = Path.Combine(Directory.GetCurrentDirectory(), "credentials.json");
            var credentials = JObject.Parse(File.ReadAllText(credentialsFile));

            RestClient restClient = new RestClient(this.calendarAPIConfig.RefreshToken);
            RestRequest request = new RestRequest();

            request.AddQueryParameter("client_id", credentials["client_id"].ToString());
            request.AddQueryParameter("client_secret", credentials["client_secret"].ToString());
            request.AddQueryParameter("code", code);
            request.AddQueryParameter("grant_type", "authorization_code");
            request.AddQueryParameter("redirect_uri", this.calendarAPIConfig.RedirectUri);

            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                File.WriteAllText(tokenFile, response.Content);
                return "Success";
            }

            return "Error";
        }
    }
}
