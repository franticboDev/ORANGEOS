using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem;
using ORANGEOS.Commands;
using ORANGEOS.Graphics;

namespace ORANGEOS
{
    public class Kernel : Sys.Kernel
    {

        private CommandManager _commandManager;
        private CosmosVFS _vfs;

        public static GUI gui;

        protected override void BeforeRun()
        {
            this._vfs = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this._vfs);
            this._commandManager = new CommandManager();

            Console.WriteLine("Welcome to ORANGEOS!");
        }

        protected override void Run()
        {
            //var currDir = Directory.GetCurrentDirectory();   

            if (Kernel.gui!=null)
            {
                Kernel.gui.handleGUIInputs();
                return;
            }

            Console.WriteLine();
            Console.Write(">> ");
            String response;
            String input = Console.ReadLine().ToLower();
            response = this._commandManager.processInput(input);
            Console.WriteLine(response);
            
        }
    }
}
