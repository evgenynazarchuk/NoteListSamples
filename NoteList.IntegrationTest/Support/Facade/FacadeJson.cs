using System;
using System.Net.Http;
using System.Net;
using System.Text.Json;

namespace NoteList.IntegrationTest.Support.Facade
{
    public partial class Facade
    {
        public virtual ActionResult<TResult> GetRequest<TResult>(string? requestUri)
            where TResult : class
        {
            var httpResult = this.GetRequest(requestUri);
            var content = httpResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (httpResult.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonSerializer.Deserialize<TResult>(content);

                if (result is null)
                {
                    throw new ApplicationException("JsonSerializer.Deserialize return null");
                }

                return new ActionResult<TResult>(result);
            }
            else if (httpResult.StatusCode == HttpStatusCode.BadRequest)
            {
                return new ActionResult<TResult>().AddError("Error message");
            }
            else
            {
                throw new ApplicationException("Unknow Status Error");
            }
        }

        public virtual ActionResult<TResult> DeleteRequest<TResult>(string? requestUri)
            where TResult : class
        {
            var httpResult = this.DeleteRequest(requestUri);
            var content = httpResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (httpResult.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonSerializer.Deserialize<TResult>(content);

                if (result is null)
                {
                    throw new ApplicationException("JsonSerializer.Deserialize return null");
                }

                return new ActionResult<TResult>(result);
            }
            else if (httpResult.StatusCode == HttpStatusCode.BadRequest)
            {
                return new ActionResult<TResult>().AddError("Error message");
            }
            else
            {
                throw new ApplicationException("Unknow Status Error");
            }
        }

        public virtual ActionResult<TResult> PostRequest<TResult>(string? requestUri, HttpContent httpContent)
            where TResult : class
        {
            var httpResult = this.PostRequest(requestUri, httpContent);
            var content = httpResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (httpResult.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonSerializer.Deserialize<TResult>(content);

                if (result is null)
                {
                    throw new ApplicationException("JsonSerializer.Deserialize return null");
                }

                return new ActionResult<TResult>(result);
            }
            else if (httpResult.StatusCode == HttpStatusCode.BadRequest)
            {
                return new ActionResult<TResult>().AddError("Error message");
            }
            else
            {
                throw new ApplicationException("Unknow Status Error");
            }
        }

        public virtual ActionResult<TResult> PutRequest<TResult>(string? requestUri, HttpContent httpContent)
            where TResult : class
        {
            var httpResult = this.PutRequest(requestUri, httpContent);
            var content = httpResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (httpResult.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonSerializer.Deserialize<TResult>(content);

                if (result is null)
                {
                    throw new ApplicationException("JsonSerializer.Deserialize return null");
                }

                return new ActionResult<TResult>(result);
            }
            else if (httpResult.StatusCode == HttpStatusCode.BadRequest)
            {
                return new ActionResult<TResult>().AddError("Error message");
            }
            else
            {
                throw new ApplicationException("Unknow Status Error");
            }
        }

        public virtual ActionResult<TResult> PostRequest<TResult, TRequest>(string? requestUri, TRequest value)
            where TResult : class
            where TRequest : class
        {
            var requestContent = JsonSerializer.Serialize<TRequest>(value);
            var httpContent = new StringContent(requestContent);
            return this.PostRequest<TResult>(requestUri, httpContent);
        }

        public virtual ActionResult<TResult> PutRequest<TResult, TRequest>(string? requestUri, TRequest value)
            where TResult : class
            where TRequest : class
        {
            var requestContent = JsonSerializer.Serialize<TRequest>(value);
            var httpContent = new StringContent(requestContent);
            return this.PutRequest<TResult>(requestUri, httpContent);
        }
    }
}
