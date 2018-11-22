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

            StreamReader arnoldc_reader = new StreamReader("../../lexemes.arnoldc");
            string data = arnoldc_reader.ReadLine();
            var symbol_table = new Dictionary<int, Tuple<string, string>>();
            int i = 1;          // fuse this later as an index for putting lexemes into symbol_table

            Regex keyword_regex = new Regex(@"\bIT'S SHOWTIME\b|\bYOU HAVE BEEN TERMINATED\b|\bTALK TO THE HAND\b
                                |\bI LET HIM GO\b|\bYOU ARE NOT YOU YOU ARE ME\b|\bLET OFF SOME STEAM BENNET\b
                                |\bCONSIDER THAT A DIVORCE\b|\bKNOCK KNOCK\b
                                |\bLISTEN TO ME VERY CAREFULLY\b|\bGIVE THESE PEOPLE AIR\b
                                |\bI NEED YOUR CLOTHES YOUR BOOTS AND YOUR MOTORCYCLE\b
                                |\bI'LL BE BACK\b|\bHASTA LA VISTA, BABY\b|DO IT NOW\b|\bGET YOUR ASS TO MARS\b
                                |\bI WANT TO ASK YOU A BUNCH OF QUESTIONS AND I WANT TO HAVE THEM ANSWERED IMMEDIATELY\b
                                |\bWHAT THE FUCK DID I DO WRONG\b");

            Regex reassign_variable = new Regex(@"\bGET TO THE CHOPPER\b|HERE IS MY INVITATION\b|\bENOUGH TALK\b");
            Regex assign_variable = new Regex(@"\bHEY CHRISTMAS TREE\b|YOU SET US UP\b");
            Regex arithmetic_operations_regex = new Regex(@"\bGET DOWN\b|\bGET UP\b|
                                |\bYOU'RE FIRED\b|\bHE HAD TO SPLIT\b");

            Regex print_regex = new Regex(@"\bTALK TO THE HAND\b");
            Regex if_loop_regex = new Regex(@"\bBULLSHIT\b|\bBECAUSE I'M GOING TO SAY PLEASE\b|\bYOU HAVE NO RESPECT FOR LOGIC\b");
            Regex macro_regex = new Regex(@"\b\@I LIED\b|\b\@NO PROBLEMO\b");
            Regex while_regex = new Regex(@"\bSTICK AROUND\b|\bCHILL\b");
            Regex integer_regex = new Regex(@"\b\d+\b");
            Regex variable_name_regex = new Regex(@"([a-zA-Z0-9]*[a-z0-9]+)");

            while (data != null) {

                MatchCollection string_literals = Regex.Matches(data, @"""(.*?)""");

                Match keyword_match = keyword_regex.Match(data);
                Match rv_match = reassign_variable.Match(data);
                Match av_match = assign_variable.Match(data);
                Match math_ops_match = arithmetic_operations_regex.Match(data);
                Match if_statement_match = if_loop_regex.Match(data);
                Match while_match = while_regex.Match(data);
                Match print_match = print_regex.Match(data);
                Match integer_match = integer_regex.Match(data);
                Match variable_name_match = variable_name_regex.Match(data);
                Match macro_match = macro_regex.Match(data);

                if (while_match.Success) {                  // matches lexemes inside while loops

                    var token_input = Tuple.Create("Keyword", while_match.Value);
                    symbol_table.Add(i, token_input);
                    i = i + 1;

                    if (av_match.Success) {

                        var av_token = Tuple.Create("Keyword", av_match.Value);
                        symbol_table.Add(i, av_token);
                        i = i + 1;

                        if (integer_match.Success) {

                            var integer_token = Tuple.Create("Integer literal", integer_match.Value);
                            symbol_table.Add(i, integer_token);
                            i = i + 1;

                        } else if (variable_name_match.Success) {

                            var variable_token = Tuple.Create("Variable name", variable_name_match.Value);
                            symbol_table.Add(i, variable_token);
                            i = i + 1;

                        } else if (macro_match.Success) {

                            var macro_token = Tuple.Create("Macro", macro_match.Value);
                            symbol_table.Add(i, macro_token);
                            i = i + 1;

                        } else if (print_match.Success) {

                            var print_token = Tuple.Create("Keyword", print_match.Value);
                            symbol_table.Add(i, print_token);
                            i = i + 1;


                            if (integer_match.Success) {

                                var integer_token = Tuple.Create("Integer literal", integer_match.Value);
                                symbol_table.Add(i, integer_token);
                                i = i + 1;

                            } else if (variable_name_match.Success) {

                                var variable_token = Tuple.Create("Variable name", variable_name_match.Value);
                                symbol_table.Add(i, variable_token);
                                i = i + 1;

                            } else if (macro_match.Success) {

                                var macro_token = Tuple.Create("Macro", macro_match.Value);
                                symbol_table.Add(i, macro_token);
                                i = i + 1;

                            }

                        }

                    }

                }

                if (keyword_match.Success) {
                    var token_input = Tuple.Create("Keyword", keyword_match.Value);
                    symbol_table.Add(i, token_input);
                    i = i + 1;
                }

                if (print_match.Success) {

                    var print_token = Tuple.Create("Keyword", print_match.Value);
                    symbol_table.Add(i, print_token);
                    i = i + 1;

                    
                    if (integer_match.Success) {

                        var integer_token = Tuple.Create("Integer literal", integer_match.Value);
                        symbol_table.Add(i, integer_token);
                        i = i + 1;

                    } else if (variable_name_match.Success) {

                        var variable_token = Tuple.Create("Variable name", variable_name_match.Value);
                        symbol_table.Add(i, variable_token);
                        i = i + 1;

                    } else if (macro_match.Success) {

                        var macro_token = Tuple.Create("Macro", macro_match.Value);
                        symbol_table.Add(i, macro_token);
                        i = i + 1;

                    }

                }

                if (av_match.Success) {

                    var token_input = Tuple.Create("Keyword", av_match.Value);
                    symbol_table.Add(i, token_input);
                    i = i + 1;

                    if (integer_match.Success) {
                        var integer_token = Tuple.Create("Integer literal", integer_match.Value);
                        symbol_table.Add(i, integer_token);
                        i = i + 1;
                    } else if (variable_name_match.Success) {
                        var variable_token = Tuple.Create("Variable name", variable_name_match.Value);
                        symbol_table.Add(i, variable_token);
                        i = i + 1;
                    } else if (macro_match.Success) {
                        var macro_token = Tuple.Create("Macro", macro_match.Value);
                        symbol_table.Add(i, macro_token);
                        i = i + 1;
                    }

                }


                if (rv_match.Success) {

                    var token_input = Tuple.Create("Keyword", rv_match.Value);
                    symbol_table.Add(i, token_input);
                    i = i + 1;

                    if (integer_match.Success) {
                        var integer_token = Tuple.Create("Integer literal", integer_match.Value);
                        symbol_table.Add(i, integer_token);
                        i = i + 1;
                    } else if (variable_name_match.Success) {
                        var variable_token = Tuple.Create("Variable name", variable_name_match.Value);
                        symbol_table.Add(i, variable_token);
                        i = i + 1;
                    } else if (macro_match.Success) {
                        var macro_token = Tuple.Create("Macro", macro_match.Value);
                        symbol_table.Add(i, macro_token);
                        i = i + 1;
                    }                  

                }

                if (math_ops_match.Success) {
                    var token_input = Tuple.Create("Keyword", math_ops_match.Value);
                    symbol_table.Add(i, token_input);
                    i = i + 1;

                    if (integer_match.Success) {
                        var integer_token = Tuple.Create("Integer literal", integer_match.Value);
                        symbol_table.Add(i, integer_token);
                        i = i + 1;
                    }

                }

                if (if_statement_match.Success) {
                    var token_input = Tuple.Create("Keyword", if_statement_match.Value);
                    symbol_table.Add(i, token_input);
                    i = i + 1;
                }


                // if (.Success) {
                //     var token_input = Tuple.Create("Keyword", .Value);
                //     symbol_table.Add(i, token_input);
                //     i = i + 1;
                // }
                

                foreach (Match string_literal in string_literals) {
                    var token_input = Tuple.Create("String literal", string_literal.Groups[1].Value);
                    symbol_table.Add(i, token_input);
                    i = i + 1;
                }

                data = arnoldc_reader.ReadLine();
            }

            foreach (KeyValuePair<int, Tuple<string, string>> item in symbol_table) {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }

        }
    }
}