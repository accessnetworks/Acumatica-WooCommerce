﻿using System;
using System.Collections.Generic;
using ACSC.Tests.ShopifyRest.Domain.Entities.Common;
using ACSC.Tests.ShopifyRest.Domain.Entities.Products;
using ACSC.Tests.ShopifyRest.Interfaces;
using RestSharp;
using RestSharp.Extensions;
using ACSC.Tests.ShopifyRest.Client.DataRepository.Refund;

namespace ACSC.Tests.ShopifyRest.Client.Common
{
    public abstract class RestDataProviderBase
    {
        protected const string ID_STRING = "id";
        protected const string PARENT_ID_STRING = "parent_id";
        //protected const string ApiPrefix = "api";

        protected IWooCommerceRestClient WooCommerceRestClient;
       // private RefundRestDataProvider refundRestDataProvider;

        //Default WooCommerce API version, if you want to use different API version, please overwrite in your detail DataProvider
        protected string ApiVersion { get => "v3"; }

        protected abstract string GetListUrl { get; }
        protected abstract string GetSingleUrl { get; }
        protected abstract string GetCountUrl { get; }
        protected abstract string GetSearchUrl { get; }

        //public RestDataProviderBase(IWooCommerceRestClient restClient)
        //{
        //    WooCommerceRestClient = restClient;
        //    refundRestDataProvider = new RefundRestDataProvider(restClient);
        //}

        public T Create<T>(T entity, UrlSegments urlSegments = null) where T : class, new()
        {
            var request = BuildRequest(GetListUrl, nameof(this.Create), urlSegments, null);
            WooCommerceRestClient.Logger?.Debug($"Create: {entity.GetType()}");
            HandleRequesetHeader<T>(request);
            return WooCommerceRestClient.Post<T>(request, entity);
        }
        public T CreateRefund<T>(T entity, UrlSegments urlSegments = null) where T : class, new()
        {
            var request = BuildRequest(GetSingleUrl, nameof(this.CreateRefund), urlSegments, null);
            WooCommerceRestClient.Logger?.Debug($"CreateRefund: {entity.GetType()}");
            HandleRequesetHeader<T>(request);
            return WooCommerceRestClient.Post<T>(request, entity);
        }

        public T Create<T, TR>(T entity, UrlSegments urlSegments = null) where T : class, new() where TR :class, IEntityResponse<T>, new()
        {
            throw new NotImplementedException();
        }

        public virtual T Update<T, TR>(T entity, UrlSegments urlSegments) where T : class, new() where TR : class, IEntityResponse<T>, new()
        {
            var request = BuildRequest(GetSingleUrl, nameof(this.Update), urlSegments, null);
            WooCommerceRestClient.Logger?.Debug($"Update: {entity.GetType()}");
            HandleRequesetHeader<T>(request);
            return WooCommerceRestClient.Put<T, TR>(request, entity);
        }

        public virtual bool Delete(UrlSegments urlSegments)
        {
            var request = BuildRequest(GetSingleUrl, nameof(this.Delete), urlSegments, null);
            return WooCommerceRestClient.Delete(request);
        }

        public virtual ItemCount GetCount(UrlSegments urlSegments = null) => GetCount(null, urlSegments);

        public virtual ItemCount GetCount(IFilter filter, UrlSegments urlSegments = null)
        {
            var request = BuildRequest(GetCountUrl, nameof(this.GetCount), urlSegments, filter);
            var count = WooCommerceRestClient.GetCount<ItemCount>(request);
            return count;
        }

        public virtual T GetByID<T, TR>(UrlSegments urlSegments) where T : class, new() where TR : class, IEntityResponse<T>, new()
        {
            var request = BuildRequest(GetSingleUrl, nameof(this.GetByID), urlSegments, null);
            var entity = WooCommerceRestClient.Get<T, TR>(request);
            return entity.Data;
        }

        public virtual List<T> GetCurrentList<T, TR>(out string previousList, out string nextList, IFilter filter = null, UrlSegments urlSegments = null) where T : class, new() where TR : class, IEntitiesResponse<T>, new()
        {
            var request = BuildRequest(GetListUrl, nameof(this.GetCurrentList), urlSegments, filter);
            var entities = WooCommerceRestClient.GetCurrentList<T, TR>(request, out previousList, out nextList);
            return entities;
        }

        public virtual List<T> GetAll<T, TR>(IFilter filter = null, UrlSegments urlSegments = null) where T : class, new() where TR : class, IEntitiesResponse<T>, new()
        {
            var request = BuildRequest(GetListUrl, nameof(this.GetAll), urlSegments, filter);
            var entities = WooCommerceRestClient.GetAll<T, TR>(request);
            return entities;
        }

        protected static UrlSegments MakeUrlSegments(long id) => MakeUrlSegments(id.ToString());

        protected static UrlSegments MakeUrlSegments(string id)
        {
            var segments = new UrlSegments();
            segments.Add(ID_STRING, id);
            return segments;
        }

        protected static UrlSegments MakeParentUrlSegments(long parentId) => MakeParentUrlSegments(parentId.ToString());

        protected static UrlSegments MakeParentUrlSegments(string parentId)
        {
            var segments = new UrlSegments();
            segments.Add(PARENT_ID_STRING, parentId);
            return segments;
        }

        protected static UrlSegments MakeUrlSegments(long id, long parentId) => MakeUrlSegments(id.ToString(), parentId.ToString());

        protected static UrlSegments MakeUrlSegments(string id, string parentId)
        {
            var segments = new UrlSegments();
            segments.Add(PARENT_ID_STRING, parentId);
            segments.Add(ID_STRING, id);
            return segments;
        }

        protected void ValidationUrl(string url, string methodName)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException ($"URL is null or whitespace, type: {this.GetType().Name},  method:  {methodName}" );
        }

        protected virtual string BuildUrl(string url)
        {
            return "/" + ApiVersion + "/" + url.TrimStart('/');
        }

        protected void HandleRequesetHeader<T>(IRestRequest request) where T : class
        {
            foreach (var propertyInfo in typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                var attr = propertyInfo.GetAttribute<ApiHeaderRequestAttribute>();
                if (attr == null) continue;
                String name = attr.HeaderParameterName;
                String value = attr.HeaderParameterValue;
                if (!string.IsNullOrEmpty(name))
                {
                    request.AddHeader(name, value);
                }
            }
        }

        protected RestRequest BuildRequest(string url, string methodName, UrlSegments urlSegments = null, IFilter filter = null)
        {
            var builtUrl = BuildUrl(url);
            ValidationUrl(builtUrl, methodName);
            var request = WooCommerceRestClient.MakeRequest(builtUrl, urlSegments?.GetUrlSegments());
            if (filter != null)
                filter?.AddFilter(request);
            return request;
        }
    }
}