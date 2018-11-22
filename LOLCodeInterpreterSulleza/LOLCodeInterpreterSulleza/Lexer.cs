using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft;

namespace LOLCodeInterpreterSulleza
{
    
    public class Lexer
    {
		public static bool inputFoundEnd = false;
		public static Stack operatorStack = new Stack();
		public static Stack operandStack = new Stack();
        public static Stack parseStack = new Stack();
		public static Stack<bool> booleanStack = new Stack<bool>();
		public static Dictionary<string, string> variables = new Dictionary<string, string>();
        public static List<Tuple<string, string>> keyMatch = new List<Tuple<string, string>>();
        public static String[] keyWords = { "HAI ", "KTHNXBYE", "I HAS A", "ITZ", "BTW", "OBTW", "TLDR", "SUM OF", "DIFF OF", "PRODUKT OF", "QUOSHUNT OF", "MOD OF", "BIGGR OF", "SMALLR OF", "AN", "BOTH OF", "EITHER OF", "WON OF", "NOT", "ALL OF", "ANY OF", "MKAY", "BOTH SAEM", "DIFFRINT", "SMOOSH", "GIMMEH", "^R$", "O RLY?", "YA RLY", "NO WAI", "OIC", "WTF?", "OMG", "OMGWTF" };
        public static String keyWordsRegex = @"(HAI|KTHNXBYE|I HAS A|ITZ|(BTW) (.*)\n|(\n?(OBTW) (.*)\n)|TLDR|SUM OF|DIFF OF|PRODUKT OF|QUOSHUNT OF|MOD OF|BIGGR OF|SMALLR OF|^AN$|BOTH OF|EITHER OF|WON OF|NOT|ALL OF|ANY OF|MKAY|BOTH SAEM|DIFFRINT|SMOOSH|GIMMEH|VISIBLE|R|O RLY\?|YA RLY|NO WAI|OIC|WTF\?|^OMG$|^OMGWTF$|GTFO|([a-zA-Z]+[0-9_]*)|(-?[0-9]*\.[0-9]+)|(\042)(.*)(\042)|WIN|FAIL|-?[0-9]+)";
        public static string filePath;
        public static string codeBlock;
        public static System.IO.StreamReader file;
        public static void openFileProcedure(String filePath)
        {
            
            if (filePath != null)
            {
                file = new System.IO.StreamReader(filePath);
            }
            else
            {
                MessageBox.Show("File not specified!");
            }
        }
        public static void getLexemes(String text)
        {
            bool multiCommentEnd = true;
            foreach(Match matched in Regex.Matches(text, keyWordsRegex))
            {
                if (Regex.Match(matched.Value, @"^TLDR$").Success)
                {
                    keyMatch.Add(Tuple.Create(matched.Value, "Multi-line Comment Delimiter"));
                    multiCommentEnd = true;

                }
                if (multiCommentEnd == true)
                {
					if (Regex.Match(matched.Value, @"(\t| |\n)?(OBTW) ?(.*)?\n?").Success)
                    {
                        keyMatch.Add(Tuple.Create(matched.Groups[1].Value, "Multi-line Comment Delimiter"));
                        if (matched.Groups[6].Value != "") keyMatch.Add(Tuple.Create(matched.Groups[3].Value, "Comment"));
                        multiCommentEnd = false;
                        continue;
                    }
                    if (Regex.Match(matched.Value, @"^HAI").Success) keyMatch.Add(Tuple.Create(matched.Value, "Code Delimiter"));
                    if (Regex.Match(matched.Value, @"^KTHXBYE$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Code Delimiter"));
                    if (Regex.Match(matched.Value, @"^I HAS A$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Variable Declaration"));
                    if (Regex.Match(matched.Value, @"^ITZ$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Variable Initialization"));
                    if (Regex.Match(matched.Value, @"(BTW) (.*)\n").Success)
                    {
                        keyMatch.Add(Tuple.Create(matched.Groups[2].Value, "Single Line Comment Keyword"));
                        keyMatch.Add(Tuple.Create(matched.Groups[3].Value, "Comment"));
                        continue;
                    }
                    if (Regex.Match(matched.Value, @"^SUM OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Addition Operator"));
                    if (Regex.Match(matched.Value, @"^DIFF OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Subtraction Operator"));
                    if (Regex.Match(matched.Value, @"^PRODUKT OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Multiplication Operator"));
                    if (Regex.Match(matched.Value, @"^QUOSHUNT OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Division Operator"));
                    if (Regex.Match(matched.Value, @"^MOD OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Modulo Operator"));
                    if (Regex.Match(matched.Value, @"^BIGGR OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Max Operator"));
                    if (Regex.Match(matched.Value, @"^SMALLR OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Min Operator"));
                    if (Regex.Match(matched.Value, @"^AN$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Concatenation"));
                    if (Regex.Match(matched.Value, @"^BOTH OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "AND Operator"));
                    if (Regex.Match(matched.Value, @"^EITHER OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "OR Operator"));
                    if (Regex.Match(matched.Value, @"^WON OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "XOR Operator"));
                    if (Regex.Match(matched.Value, @"^NOT$").Success) keyMatch.Add(Tuple.Create(matched.Value, "NOT Operator"));
                    if (Regex.Match(matched.Value, @"^ALL OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Infinite Arity AND Operator"));
                    if (Regex.Match(matched.Value, @"^ANY OF$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Infinite Arity OR Operator"));
                    if (Regex.Match(matched.Value, @"^MKAY$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Arrity Delimiter"));
                    if (Regex.Match(matched.Value, @"^BOTH SAEM$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Equality Operator"));
                    if (Regex.Match(matched.Value, @"^DIFFRINT$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Not Equal Operator"));
                    if (Regex.Match(matched.Value, @"^SMOOSH$").Success) keyMatch.Add(Tuple.Create(matched.Value, "String Concatenation Operator"));
                    if (Regex.Match(matched.Value, @"^GIMMEH$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Input Keyword"));
                    if (Regex.Match(matched.Value, @"^VISIBLE$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Output Keyword"));
                    if (Regex.Match(matched.Value, @"^R$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Value Assignment"));
                    if (Regex.Match(matched.Value, @"^O RLY\?$").Success) keyMatch.Add(Tuple.Create(matched.Value, "If-Else Delimiter"));
                    if (Regex.Match(matched.Value, @"^YA RLY$").Success) keyMatch.Add(Tuple.Create(matched.Value, "If Clause"));
                    if (Regex.Match(matched.Value, @"^NO WAI$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Else Clause"));
                    if (Regex.Match(matched.Value, @"^OIC$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Selection Statement Delimiter"));
                    if (Regex.Match(matched.Value, @"^WTF\?$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Switch Case Delimiter"));
                    if (Regex.Match(matched.Value, @"^OMG$").Success)
                    {
                        keyMatch.Add(Tuple.Create(matched.Value, "Case Keyword"));
                        continue;
                    }
                    if (Regex.Match(matched.Value, @"^OMGWTF$?").Success) keyMatch.Add(Tuple.Create(matched.Value, "Default Case Keyword"));
                    if (Regex.Match(matched.Value, @"^GTFO$").Success) keyMatch.Add(Tuple.Create(matched.Value, "Break Keyword"));
                    if (Regex.Match(matched.Value, @"([a-zA-Z]+[0-9_]*)").Success)

                    {
                        if (matched.Value.Equals("HAI") || matched.Value.Equals("KTHXBYE") || matched.Value.Equals("I HAS A") 
                            || matched.Value.Equals("ITZ") || matched.Value.Equals("BTW") || matched.Value.Equals("OBTW") 
                            || matched.Value.Equals("TLDR") || matched.Value.Equals("SUM OF") || matched.Value.Equals("DIFF OF") 
                            || matched.Value.Equals("PRODUKT OF") || matched.Value.Equals("QUOSHUNT OF") || matched.Value.Equals("MOD OF") 
                            || matched.Value.Equals("BIGGR OF") || matched.Value.Equals("SMALLER OF") || matched.Value.Equals("BOTH OF") 
                            || matched.Value.Equals("EITHER OF") || matched.Value.Equals("WON OF") || matched.Value.Equals("NOT") 
                            || matched.Value.Equals("ALL OF") || matched.Value.Equals("ANY OF") || matched.Value.Equals("MKAY") 
                            || matched.Value.Equals("SMOOSH") || matched.Value.Equals("GIMMEH") || matched.Value.Equals("VISIBLE") 
                            || matched.Value.Equals("R") || matched.Value.Equals("O RLY?") || matched.Value.Equals("YA RLY") || matched.Value.Equals("NO WAI") 
                            || matched.Value.Equals("OIC") || matched.Value.Equals("GTFO") || matched.Value.Equals("WTF?") || matched.Value.Equals("OMG") 
                            || matched.Value.Equals("OMGWTF") || matched.Value.Equals("BTW") || matched.Value.Equals("AN") || matched.Value.Contains('"')
                            || matched.Value.Equals("WIN") || matched.Value.Equals("FAIL") || matched.Value.Equals("BOTH SAEM") || matched.Value.Equals("DIFFRINT")
                            || matched.Value.Equals("SMALLR OF")){ }
                        else keyMatch.Add(Tuple.Create(matched.Value, "Variable"));

                        

                    }
                    if (Regex.Match(matched.Value, @"(-?[0-9]*\.[0-9]+)").Success && matched.Value.Contains('"') == false)
                    {
                        keyMatch.Add(Tuple.Create(matched.Value, "NUMBAR"));
                        continue;
                    }
                    if (Regex.Match(matched.Value, @"WIN").Success) keyMatch.Add(Tuple.Create(matched.Value, "Boolean True"));
                    if (Regex.Match(matched.Value, @"FAIL").Success) keyMatch.Add(Tuple.Create(matched.Value, "Boolean False"));
                    if (Regex.Match(matched.Value, @"^(-?[0-9]+)$").Success) keyMatch.Add(Tuple.Create(matched.Value, "NUMBR"));
                    if (Regex.Match(matched.Value, @"(\042)(.*)(\042)").Success)
                    {
                        keyMatch.Add(Tuple.Create("\"", "String Delimiter"));
                        keyMatch.Add(Tuple.Create(matched.Value.Replace("\"", ""), "Yarn"));
                        keyMatch.Add(Tuple.Create("\"", "String Delimiter"));
                        continue;
                    }
                }
                else keyMatch.Add(Tuple.Create(matched.Value, "Comment"));
            }
        }


		public static void ifElse()
		{
			foreach (Tuple<string, string> iterator in keyMatch)
			{
				
			}
		}

        public static void smoosh(string text)
        {
            
        }
		public static void gimmeh()
		{
			bool inputFound = false;
			foreach (Tuple<string, string> iterator in keyMatch)
			{
                if (inputFound == true && iterator.Item2 == "Variable")
                {
                    if (variables.ContainsKey(iterator.Item1)) variables[iterator.Item1] = Microsoft.VisualBasic.Interaction.InputBox("", "Input", "", -1, -1);
                    
                    else
                    {
                        variables.Add(iterator.Item1, Microsoft.VisualBasic.Interaction.InputBox("", "Input", "", -1, -1));
                    }
                    
                    inputFound = false;
                }
				if (iterator.Item2 == "Input Keyword")
				{
					inputFound = true;
				}
			}
		}
		public static void varInit(string text)
		{
			foreach (string lines in text.Split('\n'))
			{ 
				string patternIHASA = @"(\t| |\n)?I HAS A ([a-zA-Z]+[0-9_]*)$";
				string patternIHASAITZ = @"(\t| |\n)?I HAS A ([a-zA-Z]+[0-9_]*) ITZ ([^\n]*)";
                string patternR = @"(\t| |\n)?([a-zA-Z]+[0-9_]*) R ([^\n]*)";

                Match matched = Regex.Match(lines, patternIHASAITZ);
				Match matched2 = Regex.Match(lines, patternIHASA);
                Match matched3 = Regex.Match(lines, patternR);

				if (matched.Success)
				{ 
					if (variables.ContainsKey(matched.Groups[2].Value)) variables[matched.Groups[2].Value] = matched.Groups[3].Value;
					else variables.Add(matched.Groups[2].Value, matched.Groups[3].Value);
				}

				if (matched2.Success)
				{ 
					if (variables.ContainsKey(matched2.Groups[2].Value) && variables[matched2.Groups[2].Value] == "NOOB") variables[matched2.Groups[2].Value] = "NOOB";
					else variables.Add(matched2.Groups[2].Value, "NOOB");
				}

                if (matched3.Success)
                {
                    if (variables.ContainsKey(matched3.Groups[2].Value))variables[matched3.Groups[2].Value] = matched3.Groups[3].Value;
                }
			}
		}



		public static void itVALUE(string text)
		{
			string prev_line = null;
			List<Tuple<string, string>> keyMatchRev = new List<Tuple<string, string>>();
			keyMatchRev = keyMatch;
            keyMatchRev.Reverse();
			foreach (Tuple<string, string> iterator in keyMatchRev)
			{
                if (prev_line != "VISIBLE" || prev_line != "I HAS A" || prev_line != "ITZ" || prev_line != "R")
                {
                    if (iterator.Item1 == "BOTH OF" || iterator.Item1 == "EITHER OF" || iterator.Item1 == "ALL OF" || iterator.Item1 == "ANY OF" 
                        || iterator.Item1 == "NOT" || iterator.Item1 == "WON OF")
                    {
                        if (variables.ContainsKey("IT")) variables["IT"] = booleanOp();
                        else variables.Add("IT", booleanOp());
                    }
                    else if (iterator.Item1 == "SUM OF" || iterator.Item1 == "DIFF OF" || iterator.Item1 == "PRODUKT OF" || iterator.Item1 == "QUOSHUNT OF"
                        || iterator.Item1 == "MOD OF" || iterator.Item1 == "BIGGR OF" || iterator.Item1 == "SMALLR OF")
                    {
                        if (variables.ContainsKey("IT")) variables["IT"] = arithmeticOps();
                        else variables.Add("IT", arithmeticOps());
                    }
                    
                }
			}
		}

		public static void visibleOps(string text)
		{
			foreach (string lines in text.Split('\n'))
			{
				string patternVISIBLE = @"(\t| |\n)?VISIBLE ([^\n]*)";
				Match matched = Regex.Match(lines, patternVISIBLE);
				if (matched.Success)
				{
					if (matched.Groups[2].Value.Contains('"') && matched.Groups[2].Value.Contains("SMOOSH") == false)
					{
						MainForm.consoleTextBox.AppendText(matched.Groups[2].Value);
						MainForm.consoleTextBox.AppendText("\n");
					}
					if (matched.Groups[2].Value.Contains("SUM OF") || matched.Groups[2].Value.Contains("DIFF OF") || matched.Groups[2].Value.Contains("PRODUKT OF")
					   || matched.Groups[2].Value.Contains("QUOSHUNT OF") || matched.Groups[2].Value.Contains("MOD OF") || matched.Groups[2].Value.Contains("BIGGR OF")
					   || matched.Groups[2].Value.Contains("SMALLR OF")) 
					{
						MainForm.consoleTextBox.AppendText(arithmeticOps());
						MainForm.consoleTextBox.AppendText("\n");
					}
					if (matched.Groups[2].Value.Contains("BOTH OF") || matched.Groups[2].Value.Contains("EITHER OF") || matched.Groups[2].Value.Contains("WON OF")
					   || matched.Groups[2].Value.Contains("ALL OF") || matched.Groups[2].Value.Contains("NOT") || matched.Groups[2].Value.Contains("ANY OF"))
					{
						MainForm.consoleTextBox.AppendText(booleanOp().ToString());
						MainForm.consoleTextBox.AppendText("\n");
					}
                }
                if (lines.Contains("GIMMEH")) gimmeh();
            }
		}

		public static string booleanOp()
		{
			List<Tuple<string, string>> keyMatchReverse = new List<Tuple<string, string>>();
			keyMatchReverse = keyMatch;
			bool arity_and = false;
			bool arity_or = false;
			foreach (Tuple<string, string> iterator in keyMatchReverse)
			{
                //MessageBox.Show("NOW AT: " + iterator.Item1);
				if (iterator.Item1 == "I HAS A" || iterator.Item1 == "VISIBLE" || iterator.Item1 == "R")
				{
					if (booleanStack.Pop() == true) return "WIN";
					else return "FAIL";
				}
				if (iterator.Item2 == "Variable")
				{
					if (variables.ContainsKey(iterator.Item1))
					{
						if (variables[iterator.Item1] == "WIN") booleanStack.Push(true);
						if (variables[iterator.Item1] == "FAIL") booleanStack.Push(false);
					}
				}
				if (iterator.Item2 == "Boolean True" || iterator.Item2 == "Boolean False")
				{
					//MessageBox.Show("Found boolean: " + iterator.Item1);
					if (iterator.Item2 == "Boolean True") booleanStack.Push(true);
					else if (iterator.Item2 == "Boolean False") booleanStack.Push(false);
				}
				if (iterator.Item2 == "AND Operator" || iterator.Item2 == "OR Operator" || iterator.Item2 == "XOR Operator"
				   || iterator.Item2 == "NOT Operator" || iterator.Item2 == "Infinit Arity AND Operator" || iterator.Item2 == "Infinite Arity OR Operator")
				{
					if (iterator.Item2 != "Infinite Arity AND Operator" || iterator.Item2 != "Infinite Arity OR Operator"
						|| iterator.Item2 != "NOT Operator")
					{
						bool x = booleanStack.Pop();
						bool y = booleanStack.Pop();
						if (iterator.Item2 == "AND Operator") booleanStack.Push(x && y);
						else if (iterator.Item2 == "OR Operator") booleanStack.Push(x || y);
						else if (iterator.Item2 == "XOR Operator") booleanStack.Push(x ^ y);
					}
					else if (iterator.Item2 == "NOT Operator")
					{
						bool x = booleanStack.Pop();
						booleanStack.Push(!x);
					}
					else if (iterator.Item2 == "Infinite Arity AND Operator" || iterator.Item2 == "Infinite Arity OR Operator")
					{
						if (iterator.Item2 == "Infinite Arity AND Operator") arity_and = true;
						else if (iterator.Item2 == "Infinite Arity OR Operator") arity_or = true;
					}
					
				}
			}
			if (booleanStack.Pop() == true) return "WIN";
			else return "FAIL";
		
		}
		public static string arithmeticOps()
		{
			bool opFound = false;
			bool xint = false;
			bool yint = false;
			int x1 = 0;
			int y1 = 0;
			double x2 = 0;
			double y2 = 0;

			List<Tuple<string, string>> keyMatchReverse = new List<Tuple<string, string>>();
			keyMatchReverse = keyMatch;

			foreach (Tuple<string, string> iterator in keyMatchReverse)
			{
				//MessageBox.Show("Currently at: " + iterator.Item1);

				if (iterator.Item1 == "I HAS A" || iterator.Item1 == "VISIBLE" || iterator.Item1 == "R" && parseStack.Peek() != null)
				{
					return parseStack.Pop().ToString();
				}
				if (opFound == false && (iterator.Item2 == "NUMBR" || iterator.Item2 == "NUMBAR" || iterator.Item2 == "Variable" || iterator.Item2 == "Yarn"))
				{
					Console.WriteLine("Current line: " + iterator.Item1);
					Console.WriteLine("Current line: " + iterator.Item2);

					if (iterator.Item2 == "Variable")
					{
						if (variables.ContainsKey(iterator.Item1))
						{
							Console.WriteLine("INSIDE PARSE Pushed: " + variables[iterator.Item1]);
							//MessageBox.Show("INSIDE GOT THE VALUE OF A VARIABLE! " + iterator.Item1 + " THAT IS: " + variables[iterator.Item1] );
							parseStack.Push(variables[iterator.Item1].Replace("\"", ""));
						}

					}
					
					else 
					{
						parseStack.Push(iterator.Item1.Replace("\"", ""));
						//MessageBox.Show("OUTSIDE GOT A VALUE OF: " + iterator.Item1 + "THAT IS A: " + iterator.Item2);
					}
				}
				if (iterator.Item2.Equals("Addition Operator") || iterator.Item2.Equals("Multiplication Operator") 
				         || iterator.Item2.Equals("Division Operator") || iterator.Item2.Equals("Max Operator")
				         || iterator.Item2.Equals("Min Operator") || iterator.Item2.Equals("Modulo Operator") 
				         || iterator.Item2.Equals("Subtraction Operator")&& iterator.Item2 != "String Concatenation Operator" 
				         && iterator.Item2 != "Equality Operator" && iterator.Item2 != "AND Operator" 
				        && iterator.Item2 != "OR Operator" && iterator.Item2 != "XOR Operator" && iterator.Item2 != "NOT Operator"
				        && iterator.Item2 != "Infinite Arity AND Operator" && iterator.Item2 != "Infinite Arity OR Operator"
				         && iterator.Item2 != "Not Equal Operator" && iterator.Item2 != "Infinite Arity AND Operator")
				{
					var x = parseStack.Pop().ToString();
					var y = parseStack.Pop().ToString();
					if (iterator.Item2 == "Addition Operator")
					{
						if (x.Contains(".") == false)
						{
							x1 = Convert.ToInt32(x);
							xint = true;
						}
						else x2 = Convert.ToDouble(x);
						if (y.Contains(".") == false)
						{
							y1 = Convert.ToInt32(y);
							yint = true;
						}
						else y2 = Convert.ToDouble(y);

						if (xint == true)
						{
							if (yint == true) parseStack.Push(x1 + y1);
							else parseStack.Push(Convert.ToDouble(x1.ToString()) + y2);
						}
						else
						{
							if (yint == true) parseStack.Push(x2 + Convert.ToDouble(y1.ToString()));
							else parseStack.Push(x2 + y2);
						}
						opFound = false;

					}
					else if (iterator.Item2 == "Subtraction Operator")
					{
						if (x.Contains(".") == false)
						{
							x1 = Convert.ToInt32(x);
							xint = true;
						}
						else x2 = Convert.ToDouble(x);
						if (y.Contains(".") == false)
						{
							y1 = Convert.ToInt32(y);
							yint = true;
						}
						else y2 = Convert.ToDouble(y);

						if (xint == true)
						{
							if (yint == true) parseStack.Push(x1 - y1);
							else parseStack.Push(Convert.ToDouble(x1.ToString()) - y2);
						}
						else
						{
							if (yint == true) parseStack.Push(x2 - Convert.ToDouble(y1.ToString()));
							else parseStack.Push(x2 - y2);
						}
						opFound = false;
					}
					else if (iterator.Item2 == "Division Operator")
					{
						if (x.Contains(".") == false)
						{
							x1 = Convert.ToInt32(x);
							xint = true;
						}
						else x2 = Convert.ToDouble(x);
						if (y.Contains(".") == false)
						{
							y1 = Convert.ToInt32(y);
							yint = true;
						}
						else y2 = Convert.ToDouble(y);

						if (xint == true)
						{

							if (yint == true)
							{
								if (y1 == 0) return "Indeterminate";
								else parseStack.Push(x1 / y1);
							}
							else
							{
								if (y2.Equals(0)) return "Indeterminate";
								else parseStack.Push(Convert.ToDouble(x1.ToString()) / y2);
							}
						}
						else
						{
							if (yint == true)
							{
								if (y1 == 0) return "Indeterminate";
								else parseStack.Push(x2 / Convert.ToDouble(y1.ToString()));
							}
							else
							{
								if (y2.Equals(0)) return "Indeterminate";
								else parseStack.Push(x2 / y2);
							}
						}
						opFound = false;
					}
					else if (iterator.Item2 == "Modulo Operator")
					{
						if (x.Contains(".") == false)
						{
							x1 = Convert.ToInt32(x);
							xint = true;
						}
						else x2 = Convert.ToDouble(x);
						if (y.Contains(".") == false)
						{
							y1 = Convert.ToInt32(y);
							yint = true;
						}
						else y2 = Convert.ToDouble(y);

						if (xint == true)
						{
							if (yint == true) parseStack.Push(x1 % y1);
							else parseStack.Push(Convert.ToDouble(x1.ToString()) % y2);
						}
						else
						{
							if (yint == true) parseStack.Push(x2 % Convert.ToDouble(y1.ToString()));
							else parseStack.Push(x2 % y2);
						}
						opFound = false;
					}
					else if (iterator.Item2 == "Multiplication Operator")
					{
						if (x.Contains(".") == false)
						{
							x1 = Convert.ToInt32(x);
							xint = true;
						}
						else x2 = Convert.ToDouble(x);
						if (y.Contains(".") == false)
						{
							y1 = Convert.ToInt32(y);
							yint = true;
						}
						else y2 = Convert.ToDouble(y);

						if (xint == true)
						{
							if (yint == true) parseStack.Push(x1 * y1);
							else parseStack.Push(Convert.ToDouble(x1.ToString()) * y2);
						}
						else
						{
							if (yint == true) parseStack.Push(x2 * Convert.ToDouble(y1.ToString()));
							else parseStack.Push(x2 * y2);
						}
						opFound = false;
					}
					else if (iterator.Item2 == "Max Operator")
					{
						if (x.Contains(".") == false)
						{
							x1 = Convert.ToInt32(x);
							xint = true;
						}
						else x2 = Convert.ToDouble(x);
						if (y.Contains(".") == false)
						{
							y1 = Convert.ToInt32(y);
							yint = true;
						}
						else y2 = Convert.ToDouble(y);

						if (xint == true)
						{
							if (yint == true)
							{
								if (x1 > y1) parseStack.Push(x1);
								else parseStack.Push(y1);
							}
							else
							{
								if(x1 > y2) parseStack.Push(x1);
								else parseStack.Push(y2);
							}
						}
						else
						{
							if (yint == true)
							{
								if (x2 > y1) parseStack.Push(x2);
								else parseStack.Push(y1);

							}
							else
							{
								if (x2 > y2) parseStack.Push(x2);
								else parseStack.Push(y2);

							}
						}
						opFound = false;
					}
					else if (iterator.Item2 == "Min Operator")
					{
						if (x.Contains(".") == false)
						{
							x1 = Convert.ToInt32(x);
							xint = true;
						}
						else x2 = Convert.ToDouble(x);
						if (y.Contains(".") == false)
						{
							y1 = Convert.ToInt32(y);
							yint = true;
						}
						else y2 = Convert.ToDouble(y);

						if (xint == true)
						{
							if (yint == true)
							{
								if (x1 < y1) parseStack.Push(x1);
								else parseStack.Push(y1);
							}
							else
							{
								if (x1 < y2) parseStack.Push(x1);
								else parseStack.Push(y2);
							}
						}
						else
						{
							if (yint == true)
							{
								if (x2 < y1) parseStack.Push(x2);
								else parseStack.Push(y1);

							}
							else
							{
								if (x2 < y2) parseStack.Push(x2);
								else parseStack.Push(y2);

							}
						}
						opFound = false;
					}
				}
			}

			return parseStack.Pop().ToString();
		}
        public static string comparison()
        {
            foreach (Tuple<string, string> iterator in keyMatch)
            {
                if (iterator.Item2 == "NUMBR" || iterator.Item2 == "NUMBAR" || iterator.Item2 == "YARN" || iterator.Item2.Contains("Boolean"))
                {
                    if (iterator.Item2 == "NUMBR" || iterator.Item2 == "NUMBAR" || iterator.Item2 == "YARN") parseStack.Push(iterator.Item1.Replace("\"", ""));
                    else if (iterator.Item2.Contains("Boolean"))
                    {
                        if (iterator.Item2 == "Boolean True") parseStack.Push(true);
                        else parseStack.Push(false);
                    }

                }
                if (iterator.Item1 == "BOTH SAEM" || iterator.Item1 == "DIFFRINT")
                {
                    var x = parseStack.Pop().ToString();
                    var y = parseStack.Pop().ToString();
                    if (x == y) parseStack.Push("WIN");
                    else parseStack.Push("FAIL");
                }
                if (iterator.Item1 == "BIGGR OF" || iterator.Item1 == "SMALLR OF")
                {
                    parseStack.Push(arithmeticOps());
                }
            }

            return parseStack.Pop().ToString();
        }
		public static void evaluateValue()
		{
			string[] key = variables.Keys.ToArray();
			for (int i = 0; i < variables.Count; i++)
			{
				if (variables[key[i]].Contains("SUM OF") || variables[key[i]].Contains("DIFF OF") || variables[key[i]].Contains("PRODUKT OF") || variables[key[i]].Contains("MOD OF")
				   || variables[key[i]].Contains("QUOSHUNT OF") || variables[key[i]].Contains("BIGGR OF") || variables[key[i]].Contains("SMALLR OF"))
				{
					variables.Remove(key[i]);
					variables.Add(key[i], arithmeticOps());
				}
				if (variables[key[i]].Contains("BOTH OF") || variables[key[i]].Contains("EITHER OF") || variables[key[i]].Contains("NOT") || variables[key[i]].Contains("WON OF")
				   || variables[key[i]].Contains("ALL OF") || variables[key[i]].Contains("ANY OF"))
				{
					variables.Remove(key[i]);
					variables.Add(key[i], booleanOp());
				}
			}
		}
    }
}
