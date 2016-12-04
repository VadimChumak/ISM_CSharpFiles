using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch
{
    class Program
    {

        static bool Comp(string str, string fileName)
        {
            string[] f = str.Split('.');
            string[] name=fileName.Split('.');
            if (f.Length == name.Length)
            {
                if (f[0] == "*" & f[1] != "*")
                {
                    int err = 0;
                    if (f[1].Length == name[1].Length)
                    {
                        for (int i = 0; i < name[1].Length; i++)
                        {
                            if (f[1][i] == '?') { }
                            else
                            {
                                if (f[1][i] == name[1][i]) { }
                                else
                                {
                                    err++;
                                    return false;
                                }
                            }
                        }
                    }
                    else return false;
                    if (err == 0) return true;
                    else return false;
                    //if (f[1] == name[1]) return true;
                    //else return false;
                }
                else if (f[0] != "*" & f[1] == "*")
                {
                     int err = 0;
                     if (f[0].Length == name[0].Length)
                     {
                         for (int i = 0; i < name[0].Length; i++)
                         {
                             if (f[0][i] == '?') { }
                             else
                             {
                                 if (f[0][i] == name[0][i]) { }
                                 else
                                 {
                                     err++;
                                     return false;
                                 }
                             }
                         }
                     }
                     else return false;
                    if (err == 0) return true;
                    else return false;
                    //if (f[0] == name[0]) return true;
                    //else return false;
                }
                else if (f[1] == "*" & f[0] == "*")
                {
                    return true;
                }
                else
                {
                    int err = 0;
                    if (f[0].Length == name[0].Length)
                    {
                        for (int i = 0; i < name[0].Length; i++)
                        {
                            if (f[0][i] == '?') { }
                            else
                            {
                                if (f[0][i] == name[0][i]) { }
                                else
                                {
                                    err++;
                                    return false;
                                }
                            }

                        }
                    }
                    else return false;
                    if (f[1].Length == name[1].Length)
                    {
                        for (int i = 0; i < name[0].Length; i++)
                        {
                            if (f[0][i] == '?') { }
                            else
                            {
                                if (f[0][i] == name[0][i]) { }
                                else
                                {
                                    err++;
                                    return false;
                                }
                            }
                        }
                    }
                    else return false;
                    if (err == 0) return true;
                    else return false;
                }

            }
            else return false;
        }

        static void Print(string path , string FileName)
        {
            string[] f = Directory.GetFiles(path);
            //----------------------------------------------------------------
            if (f.Length > 0)
            {
                foreach (string s in f)
                {
                    if(s.Length>0)if (Comp(FileName, Path.GetFileName(s))) { Console.WriteLine(s); }
                }
            }
            string[] mass = Directory.GetDirectories(path);
            if (mass.Length != 0)
            {
                int i = 0;
            m:
                try
                {
                    for (; i < mass.Length; i++)
                    {
                        string[] file = Directory.GetFiles(mass[i]);
                        if(file.Length>0)
                        foreach (string s in file) 
                        {
                            if(s.Length>0)if (Comp(FileName , Path.GetFileName(s))) { Console.WriteLine(s); }
                        }
                        Print(mass[i] , FileName);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    i++;
                    goto m;
                }
            }
        }

        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            DriveInfo[] drive = DriveInfo.GetDrives();
            foreach (DriveInfo dr in drive) Print(dr.Name, name);
        }
    }
}

