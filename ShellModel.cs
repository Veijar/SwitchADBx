using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace SwitchADBx
{
    class ShellModel
    {
        private static RunspaceConfiguration runspaceConfiguration;
        private Runspace runspace;
        private Pipeline pipeline;

        public ShellModel()
        {
            runspaceConfiguration = RunspaceConfiguration.Create();
            runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            pipeline = runspace.CreatePipeline();
        }
        public Collection<PSObject> executeCmd(string cmd)
        {
            Collection<PSObject> request;
            using (runspace)
            {
                runspace.Open();
                using (pipeline)
                {                    
                    pipeline.Commands.AddScript(cmd);
                    request = pipeline.Invoke();
                    Console.WriteLine("___");
                   /* foreach (var res in request)
                    {
                        Console.Write("-->");
                        Console.WriteLine(res);
                    }*/
                }
                runspace.Close();
            }
            return request;
        }

    }
}
