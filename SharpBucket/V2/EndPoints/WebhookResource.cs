using SharpBucket.V2.Pocos;
using System;
using System.Collections.Generic;

namespace SharpBucket.V2.EndPoints
{
    public class WebhookResource
    {
        private string _accountName;
        private string _repository;
        private RepositoriesEndPoint _repositoriesEndPoint;

        public WebhookResource(string accountName, string repository, RepositoriesEndPoint repositoriesEndPoint)
        {
            _accountName = accountName;
            _repository = repository;
            _repositoriesEndPoint = repositoriesEndPoint;
        }

        public List<WebhookSubscription> Get(string accountName, string repository)
        {
            return _repositoriesEndPoint.GetWebhook(accountName, repository);
        }
        public WebhookSubscription Post(string accountName, string repository, string description, string url, bool active, string[] events)
        {
            return _repositoriesEndPoint.PostWebhook(accountName, repository, description, url, active, events);
        }
    }
}