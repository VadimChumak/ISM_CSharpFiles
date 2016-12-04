using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncriprion
{
    class Program
    {

        static string decr(string line , string cey)
        {
            string result = line;
            byte[] mass = Encoding.Default.GetBytes(line);
            byte[] key = Encoding.Default.GetBytes(cey);
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    mass[i] ^= key[j];
                }
            }
            result = Encoding.Default.GetString(mass);
            return result;
        }


        static void Derciprion(string FileName)
        {
            string key = "";
            Console.WriteLine("Enter a Key : ");
            key = Console.ReadLine();
            try
            {
                FileStream stream = new FileStream(FileName, FileMode.Open);
                byte[] mass = new byte[stream.Length];
                stream.Read(mass, 0, mass.Length);
                string line = Encoding.Default.GetString(mass);
                string line_Incoder = decr(line , key);
                Console.WriteLine(line_Incoder);
                string currDir = Environment.CurrentDirectory.ToString() + "\\" + Path.GetFileNameWithoutExtension(FileName)+"_Decription" + ".txt";
                FileInfo cod = new FileInfo(currDir);
                if (!cod.Exists) cod.Create();
                else
                {
                    FileStream write = new FileStream(currDir, FileMode.Open);
                    byte[] str = Encoding.Default.GetBytes(line_Incoder);
                    write.Write(str , 0 , str.Length);
                    write.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            String FileName = @"";
            FileName = Console.ReadLine();
            Derciprion(FileName);

        }
    }
}
