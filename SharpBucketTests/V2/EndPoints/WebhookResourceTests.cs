using NUnit.Framework;
using SharpBucket.V2;
using SharpBucket.V2.EndPoints;

namespace SharBucketTests.V2.EndPoints
{
    [TestFixture]
    public class WebhookResourceTests
    {
        private SharpBucketV2 sharpBucket;
        private RepositoryResource repositoryResource;
        private RepositoriesEndPoint repositoriesEndPoint;
        private const string ACCOUNT_NAME = "mirror";
        private const string REPOSITORY_NAME = "mercurial";
        [SetUp]
        public void Init()
        {
            sharpBucket = TestHelpers.GetV2ClientAuthenticatedWithOAuth();
            repositoriesEndPoint = new RepositoriesEndPoint(sharpBucket);
            repositoryResource = new RepositoryResource(ACCOUNT_NAME, REPOSITORY_NAME, repositoriesEndPoint);
        }
    }
}
