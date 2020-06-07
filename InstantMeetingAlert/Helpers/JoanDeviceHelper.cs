﻿using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net.Security;

namespace InstantMeetingAlert.Helpers
{
    internal static class JoanDeviceHelper
    {
        internal static void RefreshDevice(IConfiguration configuration)
        {
            var joanConfig = configuration.GetSection("JoanServer");

            var joanHost = joanConfig.GetValue<string>("Host");
            var joanUsername = joanConfig.GetValue<string>("Username");
            var joanPassword = joanConfig.GetValue<string>("Password");
            var joanDeviceId = joanConfig.GetValue<string>("DeviceId");

            var restClient = new RestClient(joanHost);
            restClient.RemoteCertificateValidationCallback += new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; });

            var loginRequest = new RestRequest("login", Method.POST);
            var refreshRequest = new RestRequest($"api/session/{joanDeviceId}/restart", Method.POST);

            loginRequest.AddParameter("username", joanUsername);
            loginRequest.AddParameter("password", joanPassword);

            var loginResponse = restClient.Execute(loginRequest);
            foreach (var cookie in loginResponse.Cookies)
            {
                refreshRequest.AddCookie(cookie.Name, cookie.Value);
            }

            restClient.Execute(refreshRequest);
        }
    }
}