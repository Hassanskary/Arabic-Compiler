using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectCompiler
{
    internal static class ParserExtensions
    {
        public static bool ParseProgram(this string input, out List<string> errors, out List<string> parseTree)
        {
            errors = new List<string>();
            parseTree = new List<string>();

            string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Stack<string> blockStack = new Stack<string>();

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("طالما") || trimmedLine.StartsWith("اذا"))
                {
                    blockStack.Push(trimmedLine);
                }
                else if (trimmedLine.EndsWith("}"))
                {
                    if (blockStack.Count > 0)
                    {
                        string block = blockStack.Pop();
                        block += " " + trimmedLine;
                        ProcessBlock(block, parseTree, errors);
                    }
                    else
                    {
                        errors.Add("Syntax error: Unmatched closing brace '}'.");
                    }
                }
                else if (blockStack.Count > 0)
                {
                    string block = blockStack.Pop();
                    block += " " + trimmedLine;
                    blockStack.Push(block);
                }
                else
                {
                    ProcessBlock(trimmedLine, parseTree, errors);
                }
            }

            if (blockStack.Count > 0)
            {
                errors.Add("Syntax error: Block missing closing '}'.");
            }

            return errors.Count == 0;
        }

        private static void ProcessBlock(string block, List<string> parseTree, List<string> errors)
        {
            if (!AreBracesBalanced(block))
            {
                errors.Add("Syntax error: Unmatched '{' or missing '}'.");
                return;
            }

            string[] blockLines = block.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in blockLines)
            {
                string trimmedLine = line.Trim();

                if (string.IsNullOrWhiteSpace(trimmedLine)) continue;

                if (trimmedLine.StartsWith("متغير"))
                {
                    if (!trimmedLine.ParseDeclaration(parseTree, errors))
                        errors.Add($"Syntax error in declaration: {trimmedLine}");
                }
                else if (Regex.IsMatch(trimmedLine, @"^\w+\s*=\s*.*;"))
                {
                    if (!trimmedLine.ParseAssignment(parseTree, errors))
                        errors.Add($"Syntax error in assignment: {trimmedLine}");
                }
                else if (trimmedLine.StartsWith("اذا"))
                {
                    if (!trimmedLine.ParseIfStatement(parseTree, errors))
                        errors.Add($"Syntax error in if-statement: {trimmedLine}");
                }
                else if (trimmedLine.StartsWith("طالما"))
                {
                    if (!trimmedLine.ParseWhileStatement(parseTree, errors))
                        errors.Add($"Syntax error in while-statement: {trimmedLine}");
                }
                else
                {
                    errors.Add($"Unrecognized statement: {trimmedLine}");
                }
            }
        }

        private static bool ParseDeclaration(this string line, List<string> parseTree, List<string> errors)
        {
            string pattern = @"^متغير\s+(\w+)\s*=\s*(.*);$";
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string value = match.Groups[2].Value.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    errors.Add($"Syntax error: Incomplete declaration statement: {line}");
                    return false;
                }

                parseTree.Add($"<declaration> → متغير {match.Groups[1].Value} = {value};");
                return true;
            }
            else
            {
                errors.Add($"Syntax error: Invalid declaration format: {line}");
                return false;
            }
        }

        private static bool ParseAssignment(this string line, List<string> parseTree, List<string> errors)
        {
            string pattern = @"^(\w+)\s*=\s*(.*);$";
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string value = match.Groups[2].Value.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    errors.Add($"Syntax error: Incomplete assignment statement: {line}");
                    return false;
                }

                parseTree.Add($"<assignment> → {match.Groups[1].Value} = {value};");
                return true;
            }
            else
            {
                errors.Add($"Syntax error: Invalid assignment format: {line}");
                return false;
            }
        }

        private static bool ParseIfStatement(this string line, List<string> parseTree, List<string> errors)
        {
            string pattern = @"^اذا\s*\((.+)\)\s*\{([\s\S]*)\}$";
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string condition = match.Groups[1].Value.Trim();
                string body = match.Groups[2].Value.Trim();

                if (!IsValidCondition(condition))
                {
                    errors.Add($"Syntax error: Invalid condition '{condition}' in if-statement.");
                    return false;
                }

                parseTree.Add($"<if_statement> → اذا ({condition}) {{ {body} }}");

                ProcessNestedBlock(body, parseTree, errors);
                return true;
            }

            errors.Add($"Syntax error in if-statement: {line}");
            return false;
        }

        private static bool ParseWhileStatement(this string line, List<string> parseTree, List<string> errors)
        {
            string pattern = @"^طالما\s*\((.+)\)\s*\{([\s\S]*)\}$";
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string condition = match.Groups[1].Value.Trim();
                string body = match.Groups[2].Value.Trim();

                if (!IsValidCondition(condition))
                {
                    errors.Add($"Syntax error: Invalid condition '{condition}' in while-statement.");
                    return false;
                }

                parseTree.Add($"<while_statement> → طالما ({condition}) {{ {body} }}");

                ProcessNestedBlock(body, parseTree, errors);
                return true;
            }

            errors.Add($"Syntax error in while-statement: {line}");
            return false;
        }

        private static void ProcessNestedBlock(string body, List<string> parseTree, List<string> errors)
        {
            string[] bodyLines = body.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var bodyLine in bodyLines)
            {
                ProcessBlock(bodyLine.Trim(), parseTree, errors);
            }
        }

        private static bool IsValidCondition(string condition)
        {
            string pattern = @"^\s*\w+\s*(==|!=|<=|>=|<|>)\s*\w+(\s*(\+|\-|\*|\/)\s*\w+)*\s*$";
            return Regex.IsMatch(condition, pattern);
        }

        private static bool AreBracesBalanced(string block)
        {
            int openBraces = 0;
            foreach (char c in block)
            {
                if (c == '{') openBraces++;
                if (c == '}') openBraces--;
                if (openBraces < 0) return false;
            }
            return openBraces == 0;
        }
    }
}
