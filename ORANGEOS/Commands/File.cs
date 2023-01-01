using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;

namespace ORANGEOS.Commands
{
    class File : Command
    {
        public File(String name) : base(name) { }

        public override String execute(String[] args)
        {
            String res = "";

            switch (args[0])
            {
                case "touch":
                    try
                    {
                        if (Sys.FileSystem.VFS.VFSManager.FileExists(args[1]))
                            Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);

                        Sys.FileSystem.VFS.VFSManager.CreateFile(args[1]);
                        res = "Sucessfully created file " + args[1];
                    }
                    catch (Exception ex)
                    {
                        res = ex.ToString();
                        break;
                    }

                    break;

                case "mkdir":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(args[1]);
                        res = "Sucessfully created directory " + args[1];
                    }
                    catch (Exception ex)
                    {
                        res = ex.ToString();
                        break;
                    }
                    break;

                case "rm":
                    if (args[1].Equals("-rf"))
                        try
                        {
                            Sys.FileSystem.VFS.VFSManager.DeleteDirectory(args[2], true);
                            res = "Sucessfully deleted directory " + args[2];
                        }
                        catch (Exception ex)
                        {
                            res = ex.ToString();
                            break;
                        }
                    else
                        try
                        {
                            Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);
                            res = "Sucessfully deleted file " + args[1];
                        }
                        catch (Exception ex)
                        {
                            res = ex.ToString();
                            break;
                        }
                    break;

                case "writestr":
                    try
                    {
                        FileStream fs = (FileStream)
                            Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                        if (fs.CanWrite)
                        {
                            int ctr = 0;
                            StringBuilder sb = new StringBuilder();

                            foreach (String arg in args)
                            {
                                if (ctr > 1)
                                    sb.Append(arg + ' ');

                                ++ctr;
                            }

                            String tempStr = sb.ToString();
                            Byte[] data = Encoding.ASCII.GetBytes(tempStr.Substring(0, tempStr.Length-1));

                            fs.Write(data, 0, data.Length);
                            fs.Close();

                            res = "File edited sucessfully";
                        }
                        else
                        {
                            res = "Unable to write to the file! Not open for W(write). \n" +
                                    "Try giving it permision or check 'help'. ";
                        }
                    }

                    catch (Exception ex)
                    {
                        res = ex.ToString();
                        break;
                    }
                    break;

                case "cat":
                    try
                    {
                        FileStream fs = (FileStream)
                            Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                        if (fs.CanRead)
                        {
                            Byte[] data = new Byte[256];

                            fs.Read(data, 0, data.Length);
                            res = Encoding.ASCII.GetString(data);
                        }
                        else
                        {
                            res = "Unable to write to the file! Not open for R(read). \n" +
                                  "Try giving it permision or check 'help'. ";
                        }
                    }
                    catch (Exception ex)
                    {
                        res = ex.ToString();
                        break;
                    }
                    break;

                case "rname":
                    try
                    {

                        if (Sys.FileSystem.VFS.VFSManager.FileExists(args[1]))
                        {
                            FileStream fs = (FileStream)
                                Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                            Sys.FileSystem.VFS.VFSManager.CreateFile(args[2]);

                            FileStream tempFs = (FileStream)
                                Sys.FileSystem.VFS.VFSManager.GetFile(args[2]).GetFileStream();     

                            fs.CopyTo(tempFs);

                            Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);

                            fs.Close();
                            tempFs.Close();

                            res = "File edited sucessfully";
                        }

                        else
                        {
                            res = "Unable to write to the file! Not open for R(read). \n" +
                                  "Try giving it permision or check 'help'. ";
                        }
                    }
                    catch (Exception ex)
                    {
                        res = ex.ToString();
                        break;
                    }
                    break;

                default:
                    res = "Unexpected argument: " + args[0];
                    break;
            }

            return res;
        }
    }
}
