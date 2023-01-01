using System;
using System.Collections.Generic;
using System.Text;

namespace ORANGEOS.Commands
{
    public class CommandManager
    {

        private List<Command> commands;

        public CommandManager()
        {
            this.commands = new List<Command>(5);
            this.commands.Add(new Help("help"));
            this.commands.Add(new Shutdown("shutdown"));
            this.commands.Add(new Echo("echo"));
            this.commands.Add(new File("file"));
            this.commands.Add(new LaunchGUI("launchgui"));
        }

        public String processInput (String input)
        {
            String[] split = input.Split(' ');

            String label = split[0];

            List<String> args = new List<string>();

            int ctr = 0;
            foreach (String s in split)
            {
                if(ctr!=0)
                    args.Add(s);

                ++ctr;
            }

            foreach (Command cmd in this.commands) 
            {
                if (cmd.name == label)
                    return cmd.execute(args.ToArray());
            }

            return "The command \""+label+"\" was not found as a internal / external command \n" +
                "or executable program. Use 'help' command for help.";

        }
    }
}
