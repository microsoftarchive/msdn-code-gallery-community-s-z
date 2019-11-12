using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Permissions;
using System.Globalization;


namespace System.Web.UI.DataVisualization.Charting.Samples
{
	
    public class SourceRenderer
    {

        const string TAG_FNTRED = "<font color= \"red\">";
        const string TAG_FNTBLUE = "<font color= \"blue\">";
        const string TAG_FNTGRN = "<font color= \"green\">";
        const string TAG_FNTMRN = "<font color=\"maroon\">";
        const string TAG_EFONT = "</font>"; 


        public string ProcessFile(string fileName, string language)
        {
            string err_message = "<p><b>Source Viewer Error: cannot show this file</b></p>";
            try
            {
                if (!String.IsNullOrEmpty(fileName))
                {

                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        StreamReader sr = new StreamReader(fs);
                        StringWriter textBuffer = new StringWriter();
                        String sourceLine;

                        if (language.Equals("c#", StringComparison.OrdinalIgnoreCase) || (fileName.ToLower(CultureInfo.InvariantCulture)).EndsWith(".cs"))
                        {
                            textBuffer.Write("<pre>\r\n");
                            while ((sourceLine = sr.ReadLine()) != null)
                            {
                                textBuffer.Write(FixCSLine(sourceLine));
                                textBuffer.Write("\r\n");
                            }
                            textBuffer.Write("</pre>");
                        }
                        else if (language.Equals("vb", StringComparison.OrdinalIgnoreCase) || (fileName.ToLower(CultureInfo.InvariantCulture)).EndsWith(".vb"))
                        {
                            textBuffer.Write("<pre>\r\n");
                            while ((sourceLine = sr.ReadLine()) != null)
                            {
                                textBuffer.Write(FixVBLine(sourceLine));
                                textBuffer.Write("\r\n");
                            }
                            textBuffer.Write("</pre>");
                        }
                        else
                        {
                            String lang = "c#";
                            bool isInScriptBlock = false;
                            bool isInMultiLine = false;

                            textBuffer.Write("<pre>\r\n");
                            while ((sourceLine = sr.ReadLine()) != null)
                            {
                                // First we want to grab the global language
                                // for this page by a Page directive.  Or
                                // possibly from a script block.
                                lang = GetLangFromLine(sourceLine, lang);
                                if (IsScriptBlockTagStart(sourceLine))
                                {
                                    textBuffer.Write(FixAspxLine(sourceLine));
                                    isInScriptBlock = true;
                                }
                                else if (IsScriptBlockTagEnd(sourceLine))
                                {
                                    textBuffer.Write(FixAspxLine(sourceLine));
                                    isInScriptBlock = false;
                                }
                                else if (IsMultiLineTagStart(sourceLine) && !isInMultiLine)
                                {
                                    isInMultiLine = true;
                                    textBuffer.Write("<font color=blue><b>" + HttpUtility.HtmlEncode(sourceLine));
                                }
                                else if (IsMultiLineTagEnd(sourceLine) && isInMultiLine)
                                {
                                    isInMultiLine = false;
                                    textBuffer.Write(HttpUtility.HtmlEncode(sourceLine) + "</b></font>");
                                }
                                else if (isInMultiLine)
                                {
                                    textBuffer.Write(HttpUtility.HtmlEncode(sourceLine));
                                }
                                else
                                {
                                    if (isInScriptBlock == true)
                                    {
                                        if (lang.ToLower(CultureInfo.InvariantCulture) == "c#")
                                        {
                                            textBuffer.Write(FixCSLine(sourceLine));
                                        }
                                        else if (lang.ToLower(CultureInfo.InvariantCulture) == "vb")
                                        {
                                            textBuffer.Write(FixVBLine(sourceLine));
                                        }
                                        else if (lang.ToLower(CultureInfo.InvariantCulture) == "jscript" || lang.ToLower(CultureInfo.InvariantCulture) == "javascript")
                                        {
                                            textBuffer.Write(FixJSLine(sourceLine));
                                        }
                                    }
                                    else
                                    {
                                        textBuffer.Write(FixAspxLine(sourceLine));
                                    }
                                }
                                textBuffer.Write("\r\n");
                            }
                            textBuffer.Write("</pre>");
                        }
                        return textBuffer.ToString();
                    }
                }
            }
            catch {  }
            return err_message;
        }

        string GetLangFromLine(string sourceLine, string defLang)
        {
            if (sourceLine == null)
            {
                return defLang;
            }

            Match langMatch = Regex.Match(sourceLine, "(?i)<%@\\s*Page\\s*.*Language\\s*=\\s*\"(?<lang>[^\"]+)\"");
            if (langMatch.Success)
            {
                return langMatch.Groups["lang"].ToString();
            }

            langMatch = Regex.Match(sourceLine, "(?i)(?=.*runat\\s*=\\s*\"?server\"?)<script.*language\\s*=\\s*\"(?<lang>[^\"]+)\".*>");
            if (langMatch.Success)
            {
                return langMatch.Groups["lang"].ToString();
            }

            langMatch = Regex.Match(sourceLine, "(?i)<%@\\s*WebService\\s*.*Language\\s*=\\s*\"?(?<lang>[^\"]+)\"?");
            if (langMatch.Success)
            {
                return langMatch.Groups["lang"].ToString();
            }

            return defLang;
        }

        string FixCSLine(string sourceLine)
        {
            if (sourceLine == null)
                return null;

            sourceLine = Regex.Replace(sourceLine, "(?i)(\\t)", "    ");
            sourceLine = HttpUtility.HtmlEncode(sourceLine);

            String[] keywords = new String[]
         {
         // these are the C# Keywords according to the C# Language Specification secion 2.4.3:
         "abstract","as","base","bool","break","byte","case","catch","char","checked",
         "class","const","continue","decimal","default","delegate","do","double","else",
         "enum","event","explicit","extern","false","finally","fixed","float","for","foreach",
         "goto","if","implicit","in","int","interface","internal","is","lock","long","namespace",
         "new","null","object","operator","out","override","params","private","protected","public",
         "readonly","ref","return","sbyte","sealed","short","sizeof","stackalloc","static","string",
         "struct","switch","this","throw","true","try","typeof","uint","ulong","unchecked","unsafe",
         "ushort","using","virtual","void","volatile","while",

         // while technically *not* keywords, these are included for color purposes
         // "In some places in the grammar, specific identifiers have special meaning, but are not keywords."
         "get", "set"        
         };

            String[] directives = new String[]
        {
         // preprocessor directives (2.5 of the C# Language Specification)
         "define","undef","if","elif","else","endif","line","error","warning","region","endregion"
        };

            String CombinedKeywords = "(?<keyword>" + String.Join("|", keywords) + ")";
            String CombinedDirectives = "(?<directive>" + String.Join("|", directives) + ")";

            // Checking to see if the line contains double quotes
            // We want to deal with specific issues with keywords in double quotes 
            if (sourceLine.IndexOf("&quot;") > -1)
            {
                sourceLine = ParseDoubleQuotesCSJS(sourceLine, CombinedKeywords, CombinedDirectives);
            }
            else
            {
                sourceLine = Regex.Replace(sourceLine, @"\s*[#]\b" + CombinedDirectives +
                    "\\b(?<!//.*)", TAG_FNTBLUE + "#${directive}" + TAG_EFONT);

                sourceLine = Regex.Replace(sourceLine, "\\b" + CombinedKeywords +
                    "\\b(?<!//.*)", TAG_FNTBLUE + "${keyword}" + TAG_EFONT);
            }

            sourceLine = Regex.Replace(sourceLine, "(?<comment>//.*$)",
                TAG_FNTGRN + "${comment}" + TAG_EFONT);

            return sourceLine;
        }

        string FixJSLine(string sourceLine)
        {
            if (sourceLine == null)
                return null;

            sourceLine = Regex.Replace(sourceLine, "(?i)(\\t)", "    ");
            sourceLine = HttpUtility.HtmlEncode(sourceLine);

            String[] keywords = new String[]
        {
        // JScript protected reserved words
        "break","case","catch","class","const","continue","debugger","default","delete","do","else","export",
        "extends","false","finally","for","function","if","import","in","instanceof","new","null","protected","return",
        "super","switch","this","throw","true","try","typeof","var","while","with",

        // JScript New Reserved words
        "abstract","boolean","byte","char","decimal","double","enum","final","float","get","implements","int","interface",
        "internal","long","package","private","protected","public","sbyte","set","short","static","uint","ulong","ushort","void",

        // JScript Future Reserved words
        "assert","ensure","event","goto","invariant","namespace","native","require","synchronized","throws","transient","use","volatile"
        };

            String CombinedKeywords = "(?<keyword>" + String.Join("|", keywords) + ")";

            // Checking to see if the line contains double quotes
            // We want to deal with specific issues with keywords in double quotes 
            if (sourceLine.IndexOf("&quot;") > -1)
            {
                sourceLine = ParseDoubleQuotesCSJS(sourceLine, CombinedKeywords, "");
            }
            else
            {
                sourceLine = Regex.Replace(sourceLine, "\\b" + CombinedKeywords +
                    "\\b(?<!//.*)", TAG_FNTBLUE + "${keyword}" + TAG_EFONT);
            }

            sourceLine = Regex.Replace(sourceLine, "(?<comment>//.*$)",
                TAG_FNTGRN + "${comment}" + TAG_EFONT);

            return sourceLine;
        }
        /*
        string FixVJSLine(string sourceLine)
        {
            if (sourceLine == null)
                return null;

            sourceLine = Regex.Replace(sourceLine, "(?i)(\\t)", "    ");
            sourceLine = HttpUtility.HtmlEncode(sourceLine);

            String[] keywords = new String[]
         {
         // these are the J# Keywords (support for JDK level 1.1.4 class libraries)
         "abstract","boolean","break","byte","case","case","catch","char",
         "class","continue","default","delegate","do","double","else","extends",
         "false","final","finally","float","for",
         "if","implements","import","instanceof","int","interface","long","multicast",
         "native","new","null","package","private","protected","public",
         "return","short","static","super","switch","synchronized",
         "this","throw","throws","transient","true","try",
         "void","volatile","while",

         // while technically *not* keywords, these are included for color purposes
         // "In some places in the grammar, specific identifiers have special meaning, but are not keywords."
         
         //
         "get_", "set_"        
         };

            String[] directives = new String[]
        {
         // preprocessor and conditional compilation directives_
         "define","if","elif","endif","line","error","warning"
        };

            String CombinedKeywords = "(?<keyword>" + String.Join("|", keywords) + ")";
            String CombinedDirectives = "(?<directive>" + String.Join("|", directives) + ")";

            // Checking to see if the line contains double quotes
            // We want to deal with specific issues with keywords in double quotes 
            if (sourceLine.IndexOf("&quot;") > -1)
            {
                sourceLine = ParseDoubleQuotesCSJS(sourceLine, CombinedKeywords, CombinedDirectives);
            }
            else
            {
                sourceLine = Regex.Replace(sourceLine, @"\s*[#]\b" + CombinedDirectives +
                    "\\b(?<!//.*)", TAG_FNTBLUE + "#${directive}" + TAG_EFONT);

                sourceLine = Regex.Replace(sourceLine, "\\b" + CombinedKeywords +
                    "\\b(?<!//.*)", TAG_FNTBLUE + "${keyword}" + TAG_EFONT);
            }

            sourceLine = Regex.Replace(sourceLine, "(?<comment>//.*$)",
                TAG_FNTGRN + "${comment}" + TAG_EFONT);

            return sourceLine;
        }
        */
        string ParseDoubleQuotesCSJS(string sourceLine, String keywords, String directives)
        {
            // Create a regular expressing to partition out items separated by &quot.
            Regex quoteRegex = new Regex("(&quot;.*?&quot;)");

            // This will return a string array separated by the quotes
            String[] sepSource = quoteRegex.Split(sourceLine);

            for (int curPos = 0; curPos <= sepSource.Length - 1; curPos++)
            {
                if (sepSource[curPos].IndexOf("&quot;") < 0)
                {
                    // get the #directives colored
                    if (directives != "")
                        sepSource[curPos] = Regex.Replace(sepSource[curPos], @"(?i)\s*[#]\b" +
                                 directives + "\\b(?<!'.*)",
                                 TAG_FNTBLUE + "#${directive}" + TAG_EFONT);

                    sepSource[curPos] = Regex.Replace(sepSource[curPos], "\\b" +
                        keywords + "\\b(?<!//.*)",
                        TAG_FNTBLUE + "${keyword}" + TAG_EFONT);
                }
            }

            return String.Join("", sepSource);
        }

        string FixVBLine(string sourceLine)
        {
            if (sourceLine == null)
                return null;

            sourceLine = Regex.Replace(sourceLine, "(?i)(\\t)", "    ");
            sourceLine = HttpUtility.HtmlEncode(sourceLine);

            String[] keywords = new String[]
        {
        // Visual Basic keywords according to section 2.3 of the Visual Basic Language Specification
        "AddHandler","AddressOf","AndAlso","Alias","And","Ansi","As","Assembly","Auto","Boolean","ByRef","Byte",
        "ByVal","Call","Case","Catch","CBool","CByte","CChar","CDate","CDec","CDbl","Char","CInt","Class","CLng",
        "CObj","Const","CShort","CSng","CStr","CType","Date","Decimal","Declare","Default","Delegate","Dim",
        "DirectCast","Do","Double","Each","Else","ElseIf","End","Enum","Erase","Error","Event","Exit","False","Finally",
        "For","Friend","Function","Get","GetType","GoSub","GoTo","Handles","If","Implements","Imports","In",
        "Inherits","Integer","Interface","Is","Let","Lib","Like","Long","Loop","Me","Mod","Module","MustInherit",
        "MustOverride","MyBase","MyClass","Namespace","New","Next","Not","Nothing","NotInheritable","NotOverridable",
        "Object","On","Option","Optional","Or","OrElse","Overloads","Overridable","Overrides","ParamArray","Preserve",
        "Private","Property","Protected","Public","RaiseEvent","ReadOnly","ReDim","REM","RemoveHandler","Resume",
        "Return","Select","Set","Shadows","Shared","Short","Single","Static","Step","Stop","String","Structure",
        "Sub","SyncLock","Then","Throw","To","True","Try","TypeOf","Unicode","Until","Variant","When","While",
        "With","WithEvents","WriteOnly","Xor",

        // added in the directives that don't necessary have a # in front of them all the time that aren't already
        // keywords since VB has a different syntax for these types of things then C#/C/C++
        "Region", "ExternalSource"
        };

            String[] directives = new String[]
        {
        // VB preprocessor directives from section 3 of the Visual Basic Language Specification
        "Const","ExternalSource","If","Then","Else","Region", "End", "ElseIf"
        };

            String CombinedKeywords = "(?<keyword>" + String.Join("|", keywords) + ")";
            String CombinedDirectives = "(?<directive>" + String.Join("|", directives) + ")";

            // Checking to see if the line contains double quotes
            // We want to deal with specific issues with comments "'" and keywords in double quotes 
            if (sourceLine.IndexOf("&quot;") > -1)
            {
                // Create a regular expressing to partition out items separated by &quot.
                Regex quoteRegex = new Regex("(&quot;.*?&quot;)");

                // This will return a string array separated by the quotes
                String[] sepSource = quoteRegex.Split(sourceLine);

                // Setting to add the ending font (for comments)
                bool addEndComment = false;

                for (int curPos = 0; curPos <= sepSource.Length - 1; curPos++)
                {
                    if (sepSource[curPos].IndexOf("&quot;") < 0)
                    {
                        // get the #directives colored
                        sepSource[curPos] = Regex.Replace(sepSource[curPos], @"(?i)\s*[#]\b" +
                            CombinedDirectives + "\\b(?<!'.*)",
                            TAG_FNTBLUE + "#${directive}" + TAG_EFONT);

                        sepSource[curPos] = Regex.Replace(sepSource[curPos], "(?i)\\b" +
                            CombinedKeywords + "\\b(?<!'.*)",
                            TAG_FNTBLUE + "${keyword}" + TAG_EFONT);

                        // check for comment quote
                        if (sepSource[curPos].IndexOf("'") > -1)
                        {
                            sepSource[curPos] = Regex.Replace(sepSource[curPos],
                                "(?<comment>'(?![^']*&quot;).*$)", TAG_FNTGRN + "${comment}");
                            addEndComment = true;
                            break;
                        }
                    }
                }
                sourceLine = string.Join("", sepSource);
                if (addEndComment)
                {
                    sourceLine += TAG_EFONT;
                }
            }
            else
            {
                sourceLine = Regex.Replace(sourceLine, @"\s*[#]\b" + CombinedDirectives +
                    "\\b(?<!//.*)", TAG_FNTBLUE + "#${directive}" + TAG_EFONT);

                sourceLine = Regex.Replace(sourceLine, "(?i)\\b" + CombinedKeywords +
                    "\\b(?<!'.*)", TAG_FNTBLUE + "${keyword}" + TAG_EFONT);

                sourceLine = Regex.Replace(sourceLine, "(?<comment>'(?![^']*&quot;).*$)",
                    TAG_FNTGRN + "${comment}" + TAG_EFONT);
            }

            return sourceLine;
        }

        string FixAspxLine(string sourceLine)
        {
            string searchExpr;      // search string
            string replaceExpr;     // replace string

            if ((sourceLine == null) || (sourceLine.Length == 0))
                return sourceLine;

            // Search for \t and replace it with 4 spaces.
            sourceLine = Regex.Replace(sourceLine, "(?i)(\\t)", "    ");
            sourceLine = HttpUtility.HtmlEncode(sourceLine);


            // Single line comment or #include references.
            searchExpr = "(?i)(?<a>(^.*))(?<b>(&lt;!--))(?<c>(.*))(?<d>(--&gt;))(?<e>(.*))";
            replaceExpr = "${a}" + TAG_FNTGRN + "${b}${c}${d}" + TAG_EFONT + "${e}";

            if (Regex.IsMatch(sourceLine, searchExpr))
                return Regex.Replace(sourceLine, searchExpr, replaceExpr);

            // Colorize <%@ <type>
            searchExpr = "(?i)" + "(?<a>(&lt;%@))" + "(?<b>(.*))" + "(?<c>(%&gt;))";
            replaceExpr = "<font color=blue><b>${a}${b}${c}</b></font>";

            if (Regex.IsMatch(sourceLine, searchExpr))
                sourceLine = Regex.Replace(sourceLine, searchExpr, replaceExpr);

            // Colorize <%# <type>
            searchExpr = "(?i)" + "(?<a>(&lt;%#))" + "(?<b>(.*))" + "(?<c>(%&gt;))";
            replaceExpr = "${a}" + "<font color=red><b>" + "${b}" + "</b></font>" + "${c}";

            if (Regex.IsMatch(sourceLine, searchExpr))
                sourceLine = Regex.Replace(sourceLine, searchExpr, replaceExpr);

            // Colorize tag <type>
            searchExpr = "(?i)" + "(?<a>(&lt;)(?!%)(?!/?asp:)(?!/?template)(?!/?property)(?!/?ibuyspy:)(/|!)?)" + "(?<b>[^;\\s&]+)" + "(?<c>(\\s|&gt;|\\Z))";
            replaceExpr = "${a}" + TAG_FNTMRN + "${b}" + TAG_EFONT + "${c}";

            if (Regex.IsMatch(sourceLine, searchExpr))
                sourceLine = Regex.Replace(sourceLine, searchExpr, replaceExpr);

            // Colorize asp:|template for runat=server tags <type>
            searchExpr = "(?i)(?<a>&lt;/?)(?<b>(asp:|template|property|IBuySpy:).*)(?<c>&gt;)?";
            replaceExpr = "${a}<font color=blue><b>${b}</b></font>${c}";

            if (Regex.IsMatch(sourceLine, searchExpr))
                sourceLine = Regex.Replace(sourceLine, searchExpr, replaceExpr);

            //colorize begin of tag char(s) "<","</","<%"
            searchExpr = "(?i)(?<a>(&lt;)(/|!|%)?)";
            replaceExpr = TAG_FNTBLUE + "${a}" + TAG_EFONT;

            if (Regex.IsMatch(sourceLine, searchExpr))
                sourceLine = Regex.Replace(sourceLine, searchExpr, replaceExpr);

            // Colorize end of tag char(s) ">","/>"
            searchExpr = "(?i)(?<a>(/|%)?(&gt;))";
            replaceExpr = TAG_FNTBLUE + "${a}" + TAG_EFONT;

            if (Regex.IsMatch(sourceLine, searchExpr))
                sourceLine = Regex.Replace(sourceLine, searchExpr, replaceExpr);

            return sourceLine;
        }

        bool IsScriptBlockTagStart(String source)
        {
            if (Regex.IsMatch(source, "<script.*runat=\"?server\"?.*>"))
            {
                return true;
            }
            if (Regex.IsMatch(source, "(?i)<%@\\s*WebService"))
            {
                return true;
            }
            if (source.Trim() == "<%")
            {
                return true;
            }
            return false;
        }

        bool IsScriptBlockTagEnd(String source)
        {
            if (Regex.IsMatch(source, "</script.*>"))
            {
                return true;
            }
            if (source.Trim() == "%>")
            {
                return true;
            }
            return false;
        }

        bool IsMultiLineTagStart(String source)
        {
            String searchExpr = "(?i)(?!.*&gt;)(?<a>&lt;/?)(?<b>(asp:|template|property|IBuySpy:).*)";

            source = HttpUtility.HtmlEncode(source);
            if (Regex.IsMatch(source, searchExpr))
            {
                return true;
            }
            return false;
        }

        bool IsMultiLineTagEnd(String source)
        {
            String searchExpr = "(?i)&gt;";

            source = HttpUtility.HtmlEncode(source);
            if (Regex.IsMatch(source, searchExpr))
            {
                return true;
            }
            return false;
        }

    }

}

