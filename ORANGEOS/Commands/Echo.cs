using System;
using System.Collections.Generic;
using System.Text;

namespace ORANGEOS.Commands
{
    class Echo : Command
    {
        public Echo(String name) : base(name) { }

        public override String execute(String[] args)
        {

            String res = "";
            int i = 0;
            foreach (String arg in args)
            {
                int temp = 0;

                if (i != 0)
                {
                    temp = 1;
                    args[i] = arg;
                }

                if (temp == 0)
                    res += arg;
                else
                    res += " " + arg;

                ++i;
            }

            return res;
        }
    }
}
