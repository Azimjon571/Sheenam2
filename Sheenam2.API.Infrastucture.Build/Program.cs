﻿using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var githubPipeline = new GithubPipeline
{
    Name = "Sheenam2 Build Pipeline",
    OnEvents = new Events
    {
        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "main" }
        },

        Push = new PushEvent
        {
            Branches = new string[] { "main" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.Windows2022,

            Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name="Check Out Code"
                },

                new SetupDotNetTaskV1
                {
                    Name="Seting Up .NET",
                    TargetDotNetVersion=new TargetDotNetVersion
                    {
                        DotNetVersion="7.0.202"
                    }
                },

                new RestoreTask
                {
                    Name= "Restoring Nuget Packages"
                },

                new DotNetBuildTask
                {
                    Name="Bulding Task"
                },

                new TestTask
                {
                    Name = "Running Tests"
                },
            }
        }
    }
};

var client = new ADotNetClient();

client.SerializeAndWriteToFile(
    adoPipeline: githubPipeline,
    path: "../../../../.github/workflows/dotnet.yml");
