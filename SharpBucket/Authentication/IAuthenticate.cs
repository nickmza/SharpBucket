using System.Collections.Generic;
using RestSharp;

namespace SharpBucket.Authentication
{
    public abstract class Authenticate
    {
        protected RestClient client;

        public virtual T GetResponse<T>(string url, Method method, T body, IDictionary<string, object> requestParameters)
        {
            var executeMethod = typeof(RequestExecutor).GetMethod("ExecuteRequest");
            return InvokeGenericMethod(url, method, body, requestParameters, executeMethod);
        }

        private T InvokeGenericMethod<T>(string url, Method method, T body, IDictionary<string, object> requestParameters, System.Reflection.MethodInfo executeMethod)
        {
            var generic = executeMethod.MakeGenericMethod(typeof(T));
            return (T)generic.Invoke(this, new object[] { url, method, body, client, requestParameters });
        }

        public virtual T GetResponseForPostWithJsonBody<T>(string url, Method method, T body, IDictionary<string, object> requestParameters)
        {
            var executeMethod = typeof(RequestExecutor).GetMethod("ExecuteRequestWithJsonBody");
            return InvokeGenericMethod(url, method, body, requestParameters, executeMethod);
        }
    }
}