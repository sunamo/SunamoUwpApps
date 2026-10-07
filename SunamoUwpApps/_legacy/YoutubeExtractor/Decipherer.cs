using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YoutubeExtractor

    public static class Decipherer
    {
static Type type = typeof(Decipherer);
        public static string DecipherWithVersion(string cipher, string cipherVersion)
        {
            string jsUrl = .Format2("http://s.ytimg.com/yts/jsbin/html5player-{0}.js", cipherVersion);
            string json = HttpHelper.DownloadString(jsUrl);
            //Find "C" in this: var A = B.sig||C (B.s)
            string functNamePattern = @"\.sig\s*\|\|([a-zA-Z0-9\$]+)\("; //Regex Formed To Find Word or DollarSign
            var funcName = Regex.Match(json, functNamePattern).Groups[1].Value;
            
            if (funcName.Contains("$")) 
            {
                funcName = AllStrings.bs + funcName; //Due To Dollar Sign Introduction, Need To Escape
            }
            string funcBodyPattern = @"(?<brace>{([^{}]| ?(brace))*})";  //Match nested angle braces
            string funcPattern = .Format2(@"{0}\(\w+\){1}", @funcName, funcBodyPattern); //Escape funcName string
            var funcBody = Regex.Match(json, funcPattern).Groups["brace"].Value; //Entire sig function
            var lines = funcBody.Split(AllChars.sc); //Each line in sig function
            string idReverse = "", idSlice = "", idCharSwap = ""; //Hold name for each cipher method
            string functionIdentifier = "";
            string operations = "";
            foreach (var line in lines.Skip(1).Take(lines.Length - 2)) //Matches the funcBody with each cipher method. Only runs till all three are defined.
            {
                if (!string.IsNullOrEmpty(idReverse) && !string.IsNullOrEmpty(idSlice) &&
                    !string.IsNullOrEmpty(idCharSwap))
                {
                    break; //Break loop if all three cipher methods are defined
                }
                functionIdentifier = GetFunctionFromLine(line);
                string reReverse = .Format2(@"{0}:\bfunction\b\(\w+\)", functionIdentifier); //Regex for reverse (one parameter)
                string reSlice = .Format2(@"{0}:\bfunction\b\([a],b\).(\breturn\b)?.?\w+\.", functionIdentifier); //Regex for slice (return or not)
                string reSwap = .Format2(@"{0}:\bfunction\b\(\w+\,\w\).\bvar\b.\bc=a\b", functionIdentifier); //Regex for the char swap.
                if (Regex.Match(json, reReverse).Success)
                {
                    idReverse = functionIdentifier; //If def matched the regex for reverse then the current function is a defined as the reverse
                }
                if (Regex.Match(json, reSlice).Success)
                {
                    idSlice = functionIdentifier; //If def matched the regex for slice then the current function is defined as the slice.
                }
                if (Regex.Match(json, reSwap).Success)
                {
                    idCharSwap = functionIdentifier; //If def matched the regex for charSwap then the current function is defined as swap.
                }
            }
            foreach (var line in lines.Skip(1).Take(lines.Length - 2))
            {
                Match match;
                functionIdentifier = GetFunctionFromLine(line);
                if ((match = Regex.Match(line, @"\(\w+,(?<index>\d+)\)")).Success && functionIdentifier == idCharSwap)
                {
                    operations += "w" + match.Groups["index"].Value + AllStrings.space; //operation is a swap (w)
                }
                if ((match = Regex.Match(line, @"\(\w+,(?<index>\d+)\)")).Success && functionIdentifier == idSlice)
                {
                    operations += "s" + match.Groups["index"].Value + AllStrings.space; //operation is a slice
                }
                if (functionIdentifier == idReverse) //No regex required for reverse (reverse method has no parameters)
                {
                    operations += "r "; //operation is a reverse
                }
            }
            operations = operations.Trim();
            return DecipherWithOperations(cipher, operations);
        }
        private static string ApplyOperation(string cipher, string operation)
        {
            switch (operation[0])
            {
                case 'r':
                    return new string(cipher.ToCharArray().Reverse().ToArray());
                case 'w':
                    {
                        int index = GetOpIndex(operation);
                        return SwapFirstChar(cipher, index);
                    }
                case 's':
                    {
                        int index = GetOpIndex(operation);
                        return cipher.Substring(index);
                    }
                default:
                    ThrowEx.Custom(NotImplementedException("Couldn't find cipher operation.");
            }
        }
        private static string DecipherWithOperations(string cipher, string operations)
        {
            return operationsSH.Split(new[] { AllStrings.space }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(cipher, ApplyOperation);
        }
        private static string GetFunctionFromLine(string currentLine)
        {
            Regex matchFunctionReg = new Regex(@"\w+\.(?<functionID>\w+)\("); //lc.ac(b,c) want the ac part.
            Match rgMatch = matchFunctionReg.Match(currentLine);
            string matchedFunction = rgMatch.Groups["functionID"].Value;
            return matchedFunction; //return 'ac'
        }
        private static int GetOpIndex(string operation)
        {
            string parsed = new Regex(@".(\d+)").Match(operation).Result("$1");
            int index = Int32.Parse(parsed);
            return index;
        }
        private static string SwapFirstChar(string cipher, int index)
        {
            var builder = new StringBuilder(cipher);
            builder[0] = cipher[index];
            builder[index] = cipher[0];
            return builder.ToString();
        }
    }
}