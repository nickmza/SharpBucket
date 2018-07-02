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

        public List<WebhookSubscription> Get(string username, string repository)
        {
            return _repositoriesEndPoint.GetWebhook(username, repository);
        }
        public WebhookSubscription Post(string username, string repository, string description, string url, bool active, string[] webhookEvents)
        {
            return _repositoriesEndPoint.PostWebhook(username, repository, description, url, active, webhookEvents);
        }
    }
}