using NUnit.Framework;
using SharpBucket.V1;
using SharpBucket.V2;
using SharpBucket.V2.EndPoints;
using SharpBucket.V2.Pocos;

namespace SharBucketTests.V2.EndPoints
{
    [TestFixture]
    public class WebhookResourceTests
    {
        private SharpBucketV2 sharpBucket;
        private RepositoryResource repositoryResource;
        private RepositoriesEndPoint repositoriesEndPoint;
        private const string ACCOUNT_NAME = "agileeducate";
        private const string REPOSITORY_NAME = "hub.crm.core";
        private const string USER_NAME = "jjordaan@gmail.com";
        private const string PASSWORD = "H0rs3cycl376";
        private const string TEST_HOOK_DESCRIPTION = "test hook create 01";
        private const string TEST_HOOK_NOT_FOUND_ASSERT_FAILURE_MESSAGE = "Test Hook Not Found";

        [SetUp]
        public void Init()
        {
            sharpBucket = new SharpBucketV2();
            sharpBucket.BasicAuthentication(USER_NAME, PASSWORD);
            repositoriesEndPoint = new RepositoriesEndPoint(sharpBucket);
            repositoryResource = new RepositoryResource(ACCOUNT_NAME, REPOSITORY_NAME, repositoriesEndPoint);
        }
        [Test]
        public void CallingHooksGetShouldHaveTestHook()
        {
            var webhookResource = repositoryResource.GetWebhookResource();
            WebhookSubscription whs = null;
            bool found = CallWebhookGet(webhookResource, out whs);
            Assert.IsTrue(found, TEST_HOOK_NOT_FOUND_ASSERT_FAILURE_MESSAGE);
        }

        private static bool CallWebhookGet(WebhookResource webhookResource, out WebhookSubscription webhookSubscription)
        {
            var list = webhookResource.Get(ACCOUNT_NAME, REPOSITORY_NAME);
            bool found = false;
            webhookSubscription = new WebhookSubscription();
            foreach (WebhookSubscription wh in list)
            {
                found = (wh.description == TEST_HOOK_DESCRIPTION);
                if (found)
                {
                    webhookSubscription = wh;
                    break;
                }                
            }
            return found;
        }

        [Test]
        public void CallingHooksPostShouldReturnTestHookWithSAmeDescription()
        {
            var webhookResource = repositoryResource.GetWebhookResource();
            WebhookSubscription expected = null;
            bool found = CallWebhookGet(webhookResource, out expected);
            expected.uuid = null;
            expected.description = expected.description + "New";
            WebhookSubscription actual = webhookResource.Post(ACCOUNT_NAME, REPOSITORY_NAME, 
                expected.description, 
                expected.url, expected.active, 
                expected.events.ToArray());
            Assert.IsNotNull(actual, "Result can't be null");
            Assert.AreEqual(expected.description, actual.description, "Webhook Name not Matching"); 
        }
    }
}
