using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBucket.V2.Pocos
{
    public class WebhookSubscription
    {
        public string uuid { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string subject_type { get; set; }
        public string subject { get; set; }
        public bool active { get; set; }
        public string create_at { get; set; }
        public IList<string> events { get; set; }
    }
}
