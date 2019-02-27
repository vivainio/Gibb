using System.Diagnostics;

namespace gitz
{
    public class GitModel
    {
        private const string RecentBranches =
            @"for-each-ref --count=200 --sort=-committerdate refs/heads/ --format=""%(refname:short)""";
            
        public GitModel ()
        {
        }

        public void Populate()
        {
            this.Brances = GetOutput("git", RecentBranches, "c:/p2p").Split('\n');
            
        }

        public string[] Brances { get; set; }

        static string GetOutput(string cmd, string args, string workdir)
        {
            var p = new Process();
            var psi = p.StartInfo;
            
            psi.FileName = cmd;
            psi.Arguments = args;
            psi.RedirectStandardOutput = true;
            psi.WorkingDirectory = workdir;
            psi.UseShellExecute = false;
                
            p.Start();
            var outp = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return outp;
        }

    }
}