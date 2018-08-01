﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using VisualStudioOnline.Api.Rest.Test.Properties;
using VisualStudioOnline.Api.Rest.V1.Client;

namespace VisualStudioOnline.Api.Rest.Test.V1
{
    [TestClass]
    public class GitRestClientTests : VsoTestBase
    {
        private IVsoGit _client;

        protected override void OnInitialize(VsoClient vsoClient)
        {
            _client = vsoClient.GetService<IVsoGit>();
        }

        [TestMethod]
        public void TestRepositories()
        {
            var repos = _client.GetRepositories().Result;
            var repo = _client.GetRepository(repos.Items[0].Id).Result;

            var commits = _client.GetCommits(repo.Id).Result;

            var stats = _client.GetBranchStatistics(repo.Id).Result;
            var stat = _client.GetBranchStatistics(repo.Id, "master").Result;

            var refs = _client.GetRefs(repo.Id).Result;

            var diffs = _client.GetDiffs(repo.Id, GitVersionType.Commit, Settings.Default.CommitId, GitVersionType.Branch, "master").Result;

            var item = _client.GetItemMetadata(repo.Id, Settings.Default.FilePath, true, true).Result;

            var fileContent = _client.GetItem(repo.Id, Settings.Default.FilePath).Result;
            var folderContent = _client.GetFolder(repo.Id, Settings.Default.FolderPath).Result;

            File.WriteAllBytes("file", fileContent);
            File.WriteAllBytes("folder.zip", folderContent);

            var newRepo = _client.CreateRepository("MyRepo", Settings.Default.ProjectId).Result;
            newRepo = _client.RenameRepository(newRepo.Id, "MyRepoRenamed").Result;
            string result = _client.DeleteRepository(newRepo.Id).Result;
        }
    }
}
