using System;
using System.Collections.Generic;
using System.Text;
using ORANGEOS.Graphics;

namespace ORANGEOS.Commands
{
    public class LaunchGUI : Command
    {
        public LaunchGUI(String name) : base(name) { }

        public override String execute(String[] args)
        {
            if (Kernel.gui != null)
                return "You are already in GUI!";

            Kernel.gui = new GUI();

            return "Launched GUI";
        }
    }
}
