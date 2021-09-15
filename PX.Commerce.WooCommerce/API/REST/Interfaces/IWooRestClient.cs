﻿using PX.Commerce.WooCommerce.API.REST.Client.Common;
using PX.Commerce.WooCommerce.API.REST.Domain.Entities;
using RestSharp;
using Serilog;
using System.Collections.Generic;

namespace PX.Commerce.WooCommerce.API.REST.Interfaces
{
    public interface IWooRestClient
    {
        RestRequest MakeRequest(string url, Dictionary<string, string> urlSegments = null);

        T Post<T>(IRestRequest request, T entity) where T : class, IWooEntity, new();
        BatchData<T> Post<T,TE>(
            IRestRequest request,
            TE entities) where T : class, IWooEntity, new() 
            where TE : class, IWooEntity, new();
        T Put<T>(IRestRequest request, T entity) where T : class, new();
        T Get<T>(IRestRequest request) where T : class, new();
        TE GetList<T, TE>(IRestRequest request) where T : class, IWooEntity, new() where TE : IEnumerable<T>, new();
        ILogger Logger { set; get; }
        bool Delete(IRestRequest request);
    }
}