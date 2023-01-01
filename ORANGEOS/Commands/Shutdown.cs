using System;
using System.Collections.Generic;
using System.Text;

namespace ORANGEOS.Commands
{
    public class Shutdown : Command
    {
        public Shutdown(String name) : base(name) { }

        public override String execute(String[] args)
        {
            Environment.Exit(0);
            return "Shutdown NOW!";
        }
    }
}
