using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace arnoldc {

    class Program {
        
        static void Main(string[] args) {

            StreamReader sr = new StreamReader("../../lexemes.arnoldc");
            StreamWriter writer = new StreamWriter("../../lexemes.txt");

            string data = sr.ReadLine();

            Regex keywords = new Regex(@"\bIT'S SHOWTIME\b|\bTALK TO THE HAND\b|\bYOU HAVE BEEN TERMINATED\b
                                |\b\@I LIED\b|\b\@NO PROBLEMO\b|\bBECAUSE I'M GOING TO SAY PLEASE\b|\bBULLSHIT\b
                                |\bYOU HAVE NO RESPECT FOR LOGIC\b|\bSTICK AROUND\b|\bCHILL\b|\bGET UP\b|\bGET DOWN\b
                                |\bYOU'RE FIRED\b|\bHE HAD TO SPLIT\b|\bI LET HIM GO\b|\bYOU ARE NOT YOU YOU ARE ME\b
                                |\bLET OFF SOME STEAM BENNET\b|\bCONSIDER THAT A DIVORCE\b|\bKNOCK KNOCK\b
                                |\bLISTEN TO ME VERY CAREFULLY\b|\bGIVE THESE PEOPLE AIR\b
                                |\bI NEED YOUR CLOTHES YOUR BOOTS AND YOUR MOTORCYCLE\b
                                |\bI'LL BE BACK\b|\bHASTA LA VISTA, BABY\b|DO IT NOW\b|\bGET YOUR ASS TO MARS\b
                                |\bHEY CHRISTMAS TREE\b|YOU SET US UP\b|\bI WANT TO ASK YOU A BUNCH OF QUESTIONS AND I WANT TO HAVE THEM ANSWERED IMMEDIATELY\b
                                |\bGET TO THE CHOPPER\b|HERE IS MY INVITATION\b|\bENOUGH TALK\b|\bWHAT THE FUCK DID I DO WRONG\b");

            Regex variable_regex = new Regex(@"[a-zA-Z]([a-zA-Z_])*");
            // Regex integer_regex = new Regex(@"\b\d+\b");

            try {

                while (data != null) {  

                    Console.WriteLine(data + "\n");

                    Match keywords_matches = keywords.Match(data);
    
                    MatchCollection string_collection = Regex.Matches(data, @"""(.*?)""");
                    MatchCollection variable_collection = Regex.Matches(data, @"HEY CHRISTMAS TREE (?<var1>[a-z0-9]*[a-z0-9]*)");
                    MatchCollection fxn_name_collection = Regex.Matches(data, @"DO IT NOW (?<f1>[a-z0-9]*)");
                    MatchCollection macro_collection = Regex.Matches(data, @"YOU SET US UP (?<macro>\@I LIED|\@NO PROBLEMO)");
                    MatchCollection integer_collection = Regex.Matches(data, @"YOU SET US UP (?<int>\b\d+\b)|GET UP (?<int>\b\d+\b)|GET DOWN (?<int>\b\d+\b)");
    
                    if (keywords_matches.Success) {
                        Console.WriteLine("Keyword: {0}", keywords_matches.Value);

                    }
    
                    foreach (Match match in string_collection) {
                        Console.WriteLine("String literal: {0}", match.Groups[1].Value);
                    }
    
                    foreach (Match match in variable_collection) {
                        Console.WriteLine("Variable name: {0}", match.Groups["var1"].Value);
                    }
    
                    foreach (Match match in fxn_name_collection) {
                        Console.WriteLine("Function name: {0}", match.Groups["f1"].Value);
                    }
    
                    foreach (Match match in macro_collection) {
                        Console.WriteLine("Macro: {0}", match.Groups["macro"].Value);
                    }
    
                    foreach (Match match in integer_collection) {
                        Console.WriteLine("Integer: {0}", match.Groups["int"].Value);
                    }
    
                    Console.WriteLine("this somehow prints twice before termination");
                    data = sr.ReadLine();

                    // this was supposed to fix the exception on line 72
                    // if (data == null) {
                    //     break;
                    // }

                }

            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}