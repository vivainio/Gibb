using System;
using System.Diagnostics;

namespace Gibb
{

    public static class Subproc
    {
        public static string GetOutput(string cmd, string args, string workdir)
        {
            var p = new Process();
            var psi = p.StartInfo;

            psi.FileName = cmd;
            psi.Arguments = args;
            psi.RedirectStandardOutput = true;
            psi.WorkingDirectory = workdir;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            p.Start();
            var outp = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return outp;
        }


    }

    public class GitModel
    {
        private const string RecentBranches =
            @"for-each-ref --count=200 --sort=-committerdate refs/heads/ --format=""%(refname:short)""";

        private const string GitStatus =
            @"status -s";


        public GitModel ()
        {
        }

        public string[] RunGit(string arg) =>
            Subproc.GetOutput("git", arg, Path).Split('\n');

        public string GetDiff(string fname)
            => Subproc.GetOutput("git", "diff --abbrev " + fname, Path);

        public void UpdateStatus()
        {
            this.StatusLines = RunGit(GitStatus);

        }

        public void CheckoutBranch(string branchName)
        {
            Subproc.GetOutput("git", "checkout " + branchName, Path);
            Populate(Path);
        }

        public void Populate(string path)
        {
            this.Path = path;

            this.Brances = RunGit(RecentBranches);
            UpdateStatus();
        }

        public void FileStage(string fname)
            => RunGit("add " + fname);
        public void FileUnstage(string fname)
            => RunGit("reset HEAD " + fname);

        public void FileRevert(string fname)
            => RunGit("checkout " + fname);

        public string Path { get; private set; }
        public string[] Brances { get; set; }
        public string[] StatusLines { get; private set; }

        public void Commit() => RunGit("commit");
    }
}