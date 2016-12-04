using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextFilesAndWeb
{
    class Program
    {

        static bool AreVisited(string url)
        {
            string str = File.ReadAllText(@"" + Environment.CurrentDirectory.ToString() + "\\URL.txt");
            string[] mass = str.Split('\n');
            bool mitka = false;
            for(int i=0 ; i<mass.Length ; i++)
            {
                string[] arr = mass[i].Split(' ');
                if (arr.Length == 2)
                {
                    if (arr[0] == "-" & arr[1] == url + "\r")
                    {
                        string compare = "+ " + arr[1];
                        mass[i] = compare;
                        mitka = true;
                    }
                    if (arr[0] == "+" & arr[1] == url + "\r")
                    {
                        mitka = false;
                    }
                }
            }
            File.WriteAllText(@"" + Environment.CurrentDirectory.ToString() + "\\URL.txt", "");
            File.WriteAllLines(@"" + Environment.CurrentDirectory.ToString() + "\\URL.txt", mass);
            return mitka;
        }

        static void Save(string url)
        {
            WebRequest web = WebRequest.Create(@"" + url);
            WebResponse resp = web.GetResponse();
            HttpWebResponse response = (HttpWebResponse)web.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string http = @"href=(.)(https?.+?)\1";
            Regex regHttp = new Regex(http);
            MatchCollection httpMatch = regHttp.Matches(responseFromServer);
            Random rnd = new Random();
            string pathURL=@"" + Environment.CurrentDirectory.ToString()+"\\URL.txt";
           string UrL = "";
           string[] AllLines = File.ReadAllLines(pathURL);
           foreach (Match i in httpMatch) 
           {
               //bool istina = false;
               //foreach (string c in AllLines)
               //{
                   
               //    string[] sqwe = c.Split('\n');
               //    if (sqwe.Length == 2)
               //    {
               //        if (i.Groups[2].Value == sqwe[1] + "\r") istina = true;
               //    }
               //}
               //if (istina == false)
               //{
                   Console.WriteLine(i.Value);
                   UrL += "- " + i.Groups[2].Value + Environment.NewLine;
               //}
           }
           
            
               File.AppendAllText(pathURL, UrL);
               string email = @"([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}";
               Regex regEmail = new Regex(email );
               MatchCollection emailMatch = regEmail.Matches(responseFromServer);
               string pathEMAIL = @"" + Environment.CurrentDirectory.ToString() + "\\EMAIL.txt";
               string EMAIL = "";
               if (emailMatch.Count != 0)
               {
                   foreach (Match e in emailMatch) {  EMAIL += e.Groups[0].Value + Environment.NewLine; }
                   File.AppendAllText(pathEMAIL, EMAIL);
               }
            int index = rnd.Next(0, httpMatch.Count);
            if (httpMatch.Count != 0)
            {

                //do
                //{
                //    index = rnd.Next(0, httpMatch.Count);
                //    if (AreVisited(httpMatch[index].Groups[2].Value))
                //    {
                //        Save(httpMatch[rnd.Next(0, httpMatch.Count)].Groups[2].Value);
                //    }
                //} while (!AreVisited(httpMatch[index].Groups[2].Value));
            mitk:
                index = rnd.Next(0, httpMatch.Count);
            if (AreVisited(httpMatch[index].Groups[2].Value))
            {
                Save(httpMatch[rnd.Next(0, httpMatch.Count)].Groups[2].Value);
            }
            else goto mitk;
            }
            
        }
        static void Main(string[] args)
        {
            string url=Console.ReadLine();
            Save(url);
        }
    }
}
