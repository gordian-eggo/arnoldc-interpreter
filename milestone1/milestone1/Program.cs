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
            // Define a regular expression for repeated words.


            //Regex rx1 = new Regex(<insert other regex here>);

            Regex keywords = new Regex(@"ITS SHOWTIME|IT'S SHOWTIME|TALK TO THE HAND|
                                YOU HAVE BEEN TERMINATED|I LIED|NO PROBLEMO|
                                BECAUSE I'M GOING TO SAY PLEASE|BULLSHIT|
                                YOU HAVE NO RESPECT FOR LOGIC|STICK AROUND|CHILL|
                                GET UP|GET DOWN|YOU'RE FIRED|HE HAD TO SPLIT|
                                I LET HIM GO|YOU ARE NOT YOU YOU ARE ME|
                                LET OFF SOME STEAM BENNET|CONSIDER THAT A DIVORCE|
                                KNOCK KNOCK|LISTEN TO ME VERY CAREFULLY|GIVE THESE PEOPLE AIR|
                                I NEED YOUR CLOTHES YOUR BOOTS AND YOUR MOTORCYCLE|
                                I'LL BE BACK|HASTA LA VISTA, BABY|DO IT NOW|GET YOUR ASS TO MARS|
                                HEY CHRISTMAS TREE|YOU SET US UP|
                                I WANT TO ASK YOU A BUNCH OF QUESTIONS AND I WANT TO HAVE THEM ANSWERED IMMEDIATELY|
                                GET TO THE CHOPPER|HERE IS MY INVITATION|ENOUGH TALK|WHAT THE FUCK DID I DO WRONG");

            Regex integer_regex = new Regex(@"\b\d+\b");
            Regex variable_regex = new Regex(@"[a-zA-Z][a-zA-Z0-9_]*");

            while (data != null) {
                Match keyword_matches = keywords.Match(data);
                Match integer_matches = integer_regex.Match(data);
                Match variable_matches = variable_regex.Match(data);

                try {

                    while (data != null) {
                        // Console.WriteLine(data + "\n");
                        // data = sr.ReadLine();
             
                        MatchCollection collect1 = Regex.Matches(data, @"""(.*?)""");

                        if (keyword_matches.Success)
                        {
                            Console.WriteLine("Keyword: {0}", keyword_matches.Value);
    
                        }

                        if (integer_matches.Success)
                        {
                            Console.WriteLine("Integer: {0}", integer_matches.Value);
    
                        }

                        if (variable_matches.Success) {
                            Console.WriteLine("Variable: {0}", variable_matches.Value);
                        }
    
    
                        foreach (Match match in collect1)
                        {
                            Console.WriteLine("String literal: {0}", match.Groups[1].Value);
                        }
    
    
                        data = sr.ReadLine();
    
                    }

                } catch (Exception e) {

                    //Console.WriteLine("Error: " + e.Message);

                }
            }
        }
    }
}