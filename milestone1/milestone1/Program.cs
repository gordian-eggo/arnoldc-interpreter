using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace arnoldc
{
    class Program
    {
        static void Main(string[] args)
        {


            StreamReader sr = new StreamReader("../../lexemes.arnoldc");
            string data = sr.ReadLine();
            var dict1 = new Dictionary<int, Tuple<string, string>>();
            int i = 1;

            Regex rx = new Regex(@"\bIT'S SHOWTIME\b|\bTALK TO THE HAND\b|\bYOU HAVE BEEN TERMINATED\b
                                |\bI LIED\b|\bNO PROBLEMO\b|\bBECAUSE I'M GOING TO SAY PLEASE\b|\bBULLSHIT\b
                                |\bYOU HAVE NO RESPECT FOR LOGIC\b|\bSTICK AROUND\b|\bCHILL\b|\bGET UP\b|\bGET DOWN\b
                                |\bYOU'RE FIRED\b|\bHE HAD TO SPLIT\b|\bI LET HIM GO\b|\bYOU ARE NOT YOU YOU ARE ME\b
                                |\bLET OFF SOME STEAM BENNET\b|\bCONSIDER THAT A DIVORCE\b|\bKNOCK KNOCK\b
                                |\bLISTEN TO ME VERY CAREFULLY\b|\bGIVE THESE PEOPLE AIR\b
                                |\bI NEED YOUR CLOTHES YOUR BOOTS AND YOUR MOTORCYCLE\b
                                |\bI'LL BE BACK\b|\bHASTA LA VISTA, BABY\b|DO IT NOW\b|\bGET YOUR ASS TO MARS\b
                                |\bHEY CHRISTMAS TREE\b|YOU SET US UP\b|\bI WANT TO ASK YOU A BUNCH OF QUESTIONS AND I WANT TO HAVE THEM ANSWERED IMMEDIATELY\b
                                |\bGET TO THE CHOPPER\b|HERE IS MY INVITATION\b|\bENOUGH TALK\b|\bWHAT THE FUCK DID I DO WRONG\b");
            Regex rx2 = new Regex(@"\b\d+\b");
            Regex rx3 = new Regex(@"[a-z0-9]*[a-z0-9]+");

            while (data != null)
            {
                MatchCollection collect1 = Regex.Matches(data, @"""(.*?)""");

                Match match1 = rx.Match(data);
                Match match2 = rx2.Match(data);
                Match match3 = rx3.Match(data);

                if (match1.Success)
                {
                    var t1 = Tuple.Create("Keyword ", match1.Value);
                    dict1.Add(i, t1);
                    i = i + 1;
                }
                if (match2.Success)
                {
                    var t1 = Tuple.Create("Integer literal", match2.Value);
                    dict1.Add(i, t1);
                    i = i + 1;
                }
                if (match3.Success)
                {
                    var t1 = Tuple.Create("Identifier", match3.Value);
                    dict1.Add(i, t1);
                    i = i + 1;
                }

                foreach (Match match in collect1)
                {
                    var t1 = Tuple.Create("String literal", match.Groups[1].Value);
                    dict1.Add(i, t1);
                    i = i + 1;
                }











                data = sr.ReadLine();
            }

            foreach (KeyValuePair<int, Tuple<string, string>> item in dict1)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);

            }




        }
    }
}