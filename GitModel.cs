using System.Diagnostics;

namespace gitz
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

        public string GetDiff(string fname)
            => Subproc.GetOutput("git", "diff --abbrev " + fname, Path);
        
        public void Populate(string path)
        {
            this.Path = path;
            this.Brances = Subproc.GetOutput("git", RecentBranches, path).Split('\n');
            this.StatusLines = Subproc.GetOutput("git", GitStatus, path).Split('\n');
        }

        public void Stage(string fname)
        {
            Subproc.GetOutput("git", "add " + fname, Path);
        }


        public string Path { get; private set; }
        public string[] Brances { get; set; }
        public string[] StatusLines { get; private set; }

    }
}