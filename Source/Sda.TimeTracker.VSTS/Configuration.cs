using System;

namespace Sda.TimeTracker.VSTS
{
    public class Configuration : IConfiguration
    {
        public string AccountName { get; set; }
        public Uri CollectionUri { get { return new Uri(UriString); } }
        public string UriString { get { return string.Format("https://{0}.visualstudio.com", AccountName); } }
        public string ApplicationId { get; set; }
        public string CollectionId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PersonalAccessToken { get; set; }
        public string Project { get; set; }
        public string Team { get; set; }
        public string MoveToProject { get; set; }
        public string Query { get; set; }
        public string Identity { get; set; }
        public string WorkItemIds { get; set; }
        public Int32 WorkItemId { get; set; }
        public string FilePath { get; set; }
    }

    public class VSTSContext : IConfiguration   
    {
        private static VSTSContext instance;
        public static VSTSContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VSTSContext();
                }
                return instance;
            }
        }

        // Used
        public string AccountName { get; set; }
        public string UriString { get { return string.Format("https://{0}.visualstudio.com", AccountName); } }
        public Uri CollectionUri { get { return new Uri(UriString); } }
        public string ApplicationId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }



        // Not Used

        public string CollectionId { get; set; }
        
        public string PersonalAccessToken { get; set; }
        public string Project { get; set; }
        public string Team { get; set; }
        public string MoveToProject { get; set; }
        public string Query { get; set; }
        public string Identity { get; set; }
        public string WorkItemIds { get; set; }
        public Int32 WorkItemId { get; set; }
        public string FilePath { get; set; }


    }
}
