﻿using System;
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

            Regex rx = new Regex(@"(?<word>ITS SHOWTIME|IT'S SHOWTIME|TALK TO THE HAND|YOU HAVE BEEN TERMINATED|I LIED|NO PROBLEMO|BECAUSE I'M GOING TO SAY PLEASE|BULLSHIT|YOU HAVE NO RESPECT FOR LOGIC|STICK AROUND|CHILL|GET UP|GET DOWN|YOU'RE FIRED|HE HAD TO SPLIT|I LET HIM GO|YOU ARE NOT YOU YOU ARE ME|LET OFF SOME STEAM BENNET|CONSIDER THAT A DIVORCE|KNOCK KNOCK|LISTEN TO ME VERY CAREFULLY|GIVE THESE PEOPLE AIR|I NEED YOUR CLOTHES YOUR BOOTS AND YOUR MOTORCYCLE|I'LL BE BACK|HASTA LA VISTA, BABY|DO IT NOW|GET YOUR ASS TO MARS|HEY CHRISTMAS TREE|YOU SET US UP|I WANT TO ASK YOU A BUNCH OF QUESTIONS AND I WANT TO HAVE THEM ANSWERED IMMEDIATELY|GET TO THE CHOPPER|HERE IS MY INVITATION|ENOUGH TALK|WHAT THE FUCK DID I DO WRONG)",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Define a regular expression for repeated words.


            //Regex rx1 = new Regex(<insert other regex here>);
           

            while (data != null) {
                //Console.WriteLine(data);
                data = sr.ReadLine();
                MatchCollection matches = rx.Matches(data);
               

                foreach (Match match in matches)
                {

                        
                    GroupCollection groups = match.Groups;
                    Console.WriteLine("{0}",
                                      groups["word"].Value);
                }
            }

           


       

        }
    }
}