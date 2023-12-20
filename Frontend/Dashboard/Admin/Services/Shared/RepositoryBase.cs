﻿using Admin.Features;
using Admin.Models;
using Admin.Parameter;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Json;

namespace Admin.Services.Shared
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
	{
		private readonly HttpClient _client;
		private readonly JsonSerializerOptions _options;

		public RepositoryBase(HttpClient client)
		{
			_client = client;
			_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; ;
		}

		public async Task Add(string service, T entity)
		{
			var content = JsonSerializer.Serialize(entity);
			var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

			var postResult = await _client.PostAsync(service, bodyContent);
			var postContent = await postResult.Content.ReadAsStringAsync();

			if (!postResult.IsSuccessStatusCode)
			{
				throw new ApplicationException(postContent);
			}
		}

		public async Task Delete(string service, int id)
		{
			var url = Path.Combine(service, id.ToString());

			var deleteResult = await _client.DeleteAsync(url);
			var deleteContent = await deleteResult.Content.ReadAsStringAsync();

			if (!deleteResult.IsSuccessStatusCode)
			{
				throw new ApplicationException(deleteContent);
			}
		}

		public async Task<T> Get(string service, int id)
		{
			var url = Path.Combine($"{service}/", id.ToString());
			var response = await _client.GetAsync(url);
			var content = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				throw new ApplicationException(content);
			}
			var entity = JsonSerializer.Deserialize<T>(content, _options);
			return entity;
		}

		public async Task<PagingResponse<T>> GetAll(string service, QueryStringParameters parameters)
		{
			var queryStringParam = new Dictionary<String, String>
			{
				["pageNumber"] = parameters.PageNumber.ToString(),
				["searchTerm"] = parameters.SearchTerm == null ? "" : parameters.SearchTerm
			};
			var response = await _client.GetAsync(QueryHelpers.AddQueryString($"{service}/", queryStringParam));
			var content = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				throw new ApplicationException(content);
			}
			var pagingResponse = new PagingResponse<T>
			{
				Items = JsonSerializer.Deserialize<List<T>>(content, _options),
				MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
			};
			return pagingResponse;
		}

		public async Task Update(string service, T entity)
		{
			var content = JsonSerializer.Serialize(entity);
			var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
			var url = Path.Combine(service, entity.Id.ToString());

			var postResult = await _client.PutAsync(url, bodyContent);
			var postContent = await postResult.Content.ReadAsStringAsync();

			if (!postResult.IsSuccessStatusCode)
			{
				throw new ApplicationException(postContent);
			}
		}
	}
}
