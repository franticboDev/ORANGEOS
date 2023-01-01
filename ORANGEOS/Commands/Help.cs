using System;
using System.Collections.Generic;
using System.Text;

namespace ORANGEOS.Commands
{
    class Help : Command
    {
        public Help(String name) : base(name) { }

        public override String execute(String[] args)
        {
            return  "ORANGEOS - Help. Here are all the posible command: \n" +
                    "HELP                         Lists you all the commands \n" +
                    "ECHO <STRING>                Echo the words you say \n" +
                    "SHUTDOWN                     Shutdown the computer \n" +
                    "LAUNCHGUI                    Starts GUI \n" +
                    "FILE CMDS: \n" +
                    "1) TOUCH <FILE>              Creates a file \n" +
                    "2) MKDIR <DIR>               Creates a directory \n" +
                    "3) RM <FILE>                 Deletes a file \n" +
                    "4) RM -RF <DIR>              Deletes a directory \n" +
                    "5) CAT <FILE>                Lists the content in a file \n" +
                    "6) WRITESTR <FILE> <STRING>  Writes a string to a file \n" +
                    "7) REM <FILE> <NAME>         Renames a file to a string \n";
        }
    }
}
