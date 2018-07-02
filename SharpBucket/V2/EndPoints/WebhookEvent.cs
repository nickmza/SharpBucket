namespace SharpBucket.V2.EndPoints
{
    public static class WebhookEvent
    {
        public const string PullrequestUnapproved = "pullrequest:unapproved";
        public const string IssueCommentCreated = "issue:comment_created";
        public const string PullrequestApproved = "pullrequest:approved";
        public const string RepoCreated = "repo:created";
        public const string RepoDeleted = "repo:deleted";
        public const string RepoImported = "repo:imported";
        public const string PullrequestCommentUpdated = "pullrequest:comment_updated";
        public const string IssueUpdated = "issue:updated";
        public const string ProjectUpdated = "project:updated";
        public const string PullrequestCommentCreated = "pullrequest:comment_created";
        public const string RepoCommitStatusUpdated = "repo:commit_status_updated";
        public const string PullrequestUpdated = "pullrequest:updated";
        public const string IssueCreated = "issue:created";
        public const string RepoFork = "repo:fork";
        public const string PullrequestCommentDeleted = "pullrequest:comment_deleted";
        public const string RepoCommitStatusCreated = "repo:commit_status_created";
        public const string RepoUpdated = "repo:updated";
        public const string PullrequestRejected = "pullrequest:rejected";
        public const string PullrequestFulfilled = "pullrequest:fulfilled";
        public const string RepoPush = "repo:push";
        public const string PullrequestCreated = "pullrequest:created";
        public const string RepoTransfer = "repo:transfer";
        public const string RepoCommitCommentCreated = "repo:commit_comment_created";
    }
}