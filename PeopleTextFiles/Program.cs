using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string AllInformation = @"";
            string[] aboutPeople;
            string path=Console.ReadLine();
            FileInfo AboutPeople = new FileInfo(path);
            StreamWriter stream=new StreamWriter(@"C:\Users\vadim\Documents\Visual Studio 2012\Projects\CSharpFiles\PeopleTextFiles\People.txt");
            StreamWriter stream_borg = new StreamWriter(@"C:\Users\vadim\Documents\Visual Studio 2012\Projects\CSharpFiles\PeopleTextFiles\Borg.txt");
            if (AboutPeople.Exists & File.Exists(@"C:\Users\vadim\Documents\Visual Studio 2012\Projects\CSharpFiles\PeopleTextFiles\People.txt"))
            {
                AllInformation = AboutPeople.OpenText().ReadToEnd();
                Console.WriteLine(AllInformation);
                aboutPeople = AllInformation.Split('\n');
                foreach (string s in aboutPeople) Console.WriteLine(s);
                string[] Borg;
                for (int i = 0; i < aboutPeople.Length; i++)
                {
                    Borg = aboutPeople[i].Split(' ');
                    for (int j = 1; j < Borg.Length - 4; j+=2)
                    {
                        Console.WriteLine("Ім'я - {0}{1}    Квартира - {2}", Borg[j],Borg[j+1], Borg[0]);
                        stream.WriteLine("Ім'я - " + Borg[j] +" "+ "Квартира - " + Borg[0]);
                    }
                }
                for (int i = 0; i < aboutPeople.Length; i++)
                {
                    string[] mass = aboutPeople[i].Split(' ');
                    for (int j = 0; j < aboutPeople.Length; j++)
                    {
                        string[] arr = aboutPeople[j].Split(' ');
                        if (int.Parse(arr[arr.Length - 2]) > int.Parse(mass[mass.Length - 2])) 
                        {
                            string tmp = aboutPeople[i];
                            aboutPeople[i] = aboutPeople[j];
                            aboutPeople[j] = tmp;
                        }
                    }
                }
                double sum = 0;
                foreach (string s in aboutPeople) {
                    string[] str = s.Split(' ');
                    string about="";
                    for(int i=0 ; i<str.Length-4;i++)
                    {
                        about+=str[i]+" ";
                    }
                    sum += double.Parse(str[str.Length - 2]);
                    stream_borg.WriteLine(about);   
                }
                stream_borg.WriteLine(sum.ToString());
                stream_borg.Close();
                stream.Close();

            }   
            else Console.WriteLine("ERRORR");
        }
    }
}
