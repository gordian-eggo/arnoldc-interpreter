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
            Regex rx3 = new Regex(@"[a-zA-Z]([a-zA-Z0-9_])*");
    
            while (data != null)
            {
                Match match1 = rx.Match(data);
                Match match2 = rx2.Match(data);
                Match match3 = rx3.Match(data);     

                MatchCollection collect1 = Regex.Matches(data, @"""(.*?)""");
                MatchCollection collect2 = Regex.Matches(data, @"HEY CHRISTMAS TREE (?<var1>[a-z0-9]*)");

                if (match1.Success)
                {
                    Console.WriteLine("Keyword: {0}", match1.Value);

                }
                if (match2.Success)
                {
                    Console.WriteLine("Integer: {0}", match2.Value);

                }




                foreach (Match match in collect1)
                {
                    Console.WriteLine("String literal: {0}", match.Groups[1].Value);
                }

                foreach (Match match in collect2)
                {
                    Console.WriteLine("Variable name: {0}", match.Groups["var1"].Value);
                }




                data = sr.ReadLine();
            }



        }
    }
}