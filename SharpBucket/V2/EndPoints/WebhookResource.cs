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
    }
}