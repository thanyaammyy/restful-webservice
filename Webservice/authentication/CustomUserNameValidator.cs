﻿using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using DataModelLib.Page;
using System.DirectoryServices;

namespace Webservice.authentication
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {

        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }
            var strAuthorize = ConfigurationManager.AppSettings["admin"];
            if (userName.Contains(strAuthorize))
            {
                if (!AuthenticateActiveDirectory(userName, password))
                {
                    throw new SecurityTokenException("You are not authorized to access this service.");
                }
            }
            else
            {
                if (!Authentication(userName, password))
                {
                    throw new SecurityTokenException("You are not authorized to access this service.");
                }
            }
        }

        public bool AuthenticateActiveDirectory(string userName, string password)
        {
            var strLdap = ConfigurationManager.AppSettings["ldap"];
            try
            {
                var entry = new DirectoryEntry(strLdap, userName, password);
                var nativeObject = entry.NativeObject;
                LogHelper.StoreConsumeService(GetIp(), GetFullUrl(), userName, GetService());
                return true;
            }
            catch (DirectoryServicesCOMException)
            {
                return false;
            }
        }

        private bool Authentication(string userName, string password)
        {
            var ip = GetIp();
            var url = GetUrl();
            var service = GetService();
            var fullUrl = GetFullUrl();
            if(string.IsNullOrEmpty(ip)||string.IsNullOrEmpty(url))
            {
                throw new SecurityTokenException("You are not authorized to access this service.");
            }
            if (UserServiceHelper.AuthorizeUserService(userName, password, ip, url, service))
            {
                LogHelper.StoreConsumeService(ip, fullUrl, userName, service);
            }
            else
            {
                var userId = UserHelper.Authentication(userName, password);
                var serviceId = ServiceHelper.GetServiceFromUrl(url, service);
                var userServiceId = UserServiceHelper.CountUserService(userId, serviceId);
                var usfService = UserServiceHelper.UserFuckService(userServiceId, ip);
                LogHelper.StoreConsumeService(ip, fullUrl, userName, service + " UserId= " + userId + " ServiceId=" + serviceId + " UserServiceId=" + userServiceId + " result= " + usfService);
            }

            return UserServiceHelper.AuthorizeUserService(userName, password,ip,url,service);
        }

        private string GetFullUrl()
        {
            var props = OperationContext.Current.IncomingMessageProperties;
            var via = props.Via;
            return GetUrl() +"/"+via.Segments[3].ToString()+ via.Segments[4].ToString() + via.Segments[5].ToString();
        }

        private string GetUrl()
        {
            var oc = OperationContext.Current;
            var host = oc.IncomingMessageHeaders.To.Host;
            var domain = ConfigurationManager.AppSettings["domain"];
            var uri = oc.EndpointDispatcher.EndpointAddress.Uri.ToString();
            var url = uri.Contains(host) ? uri.Replace(host, domain) : uri;
            return url;
        }

        private string GetIp()
        {
            var ip = "";
            var props = OperationContext.Current.IncomingMessageProperties;
            var endpointProperty = props[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            if (endpointProperty != null)
            {
                ip = endpointProperty.Address;
            }
            return ip;
        }

        private static string GetService()
        {
            var props = OperationContext.Current.IncomingMessageProperties;
            var via = props.Via;
            var service = via.Segments[3].ToString();
            return service.Remove(service.Length-1);
        }
    }
}