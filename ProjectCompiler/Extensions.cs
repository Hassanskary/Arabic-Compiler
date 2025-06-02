using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectCompiler
{
    internal static class Extensions
    {
        public static string FoundKeyword(this string word)
        {
            return @"\b(اذا|طالما|متغير)\b";
        }

        public static string FoundIdentifier(this string word)
        {
            return @"\b[a-zA-Z_أ-ي][\w_أ-ي]*\b";
        }

        public static string FoundNumber(this string word)
        {
            return @"\b\d+\b";
        }

        public static string FoundOperator(this string word)
        {
            return @"(\+=|-=|\*=|/=|==|!=|<=|>=|<|>|!|&&|\|\||\+|-|\*|/)";
        }

        public static string FoundAssignment(this string word)
        {
            return @"(?<![<>=!])=(?![=])";
        }

        public static string FoundLeftParenthesis(this string word)
        {
            return @"\(";
        }

        public static string FoundRightParenthesis(this string word)
        {
            return @"\)";
        }

        public static string FoundLeftBrace(this string word)
        {
            return @"\{";
        }

        public static string FoundRightBrace(this string word)
        {
            return @"\}";
        }

        public static string FoundSemicolon(this string word)
        {
            return @";";
        }

        private static string GetClassification(this string token)
        {
            if (Regex.IsMatch(token, "".FoundKeyword())) return "Keyword";
            if (Regex.IsMatch(token, "".FoundIdentifier())) return "Identifier";
            if (Regex.IsMatch(token, "".FoundNumber())) return "Number";
            if (Regex.IsMatch(token, "".FoundOperator())) return "Operator";
            if (Regex.IsMatch(token, "".FoundAssignment())) return "Assignment";
            if (Regex.IsMatch(token, "".FoundLeftParenthesis())) return "Left Parenthesis";
            if (Regex.IsMatch(token, "".FoundRightParenthesis())) return "Right Parenthesis";
            if (Regex.IsMatch(token, "".FoundLeftBrace())) return "Left Brace";
            if (Regex.IsMatch(token, "".FoundRightBrace())) return "Right Brace";
            if (Regex.IsMatch(token, "".FoundSemicolon())) return "Semicolon";

            return "Unknown";
        }

        public static List<string> GetAllTokens(this string input)
        {
            List<string> tokens = new List<string>();

            // Combined regex pattern
            string combinedPattern = $@"({input.FoundKeyword()})|({input.FoundOperator()})|({input.FoundAssignment()})|({input.FoundNumber()})|({input.FoundIdentifier()})|({input.FoundLeftParenthesis()})|({input.FoundRightParenthesis()})|({input.FoundLeftBrace()})|({input.FoundRightBrace()})|({input.FoundSemicolon()})";

            foreach (Match match in Regex.Matches(input, combinedPattern))
            {
                string token = match.Value;
                string classification = token.GetClassification();
                tokens.Add($"{token} : {classification}");
            }

            return tokens;
        }
    }
}

