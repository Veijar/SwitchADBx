using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SwitchADBx
{
    public partial class principal : Form
    {
        ShellModel shell;
        public principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shell = new ShellModel();
            Collection<PSObject> request;
            request= shell.executeCmd("Get-WmiObject win32_service | Select Name, DisplayName, State, StartMode | Sort State, Name");
            
            foreach(var res in request)
            {

                listBox.Items.Add(res);
                Console.WriteLine(res);
            }                    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
