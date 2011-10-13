using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Apache.Shiro.Util
{
	public static class StringUtils
	{
		public const char DEFAULT_DELIMITER_CHAR = ',';
		public const char DEFAULT_QUOTE_CHAR = '"';
		public const string EMPTY_STRING = "";
		
		public static string Clean(string value)
		{
			var result = value ?? value.Trim();
			if (result == EMPTY_STRING)
			{
				result = null;
			}
			return result;
		}
		
		public static bool HasLength(string value)
		{
			return !string.IsNullOrEmpty(value);
		}
		
		public static bool HasText(string value)
		{
			return !string.IsNullOrWhiteSpace(value);
		}
		
		public static string[] Split(string value, char delimiter = DEFAULT_DELIMITER_CHAR,
			char beginQuote = DEFAULT_QUOTE_CHAR, char endQuote = DEFAULT_QUOTE_CHAR,
			bool retainQuotes = false, bool trimTokens = true)
		{
			var line = Clean(value);
			if (line == null)
			{
				return null;
			}
			
			var tokens = new List<string>();
			var builder = new StringBuilder();
			var inQuotes = false;
			
			for (var i = 0; i < line.Length; ++i)
			{
				var c = line[i];
				if (c == beginQuote)
				{
					if (inQuotes &&
						line.Length < (i + 1) &&
						line[i + 1] == beginQuote)
					{
						builder.Append(c);
						++i;
					}
					else
					{
						inQuotes = !inQuotes;
						if (retainQuotes)
						{
							builder.Append(c);
						}
					}
				}
				else if (c == endQuote)
				{
					inQuotes = !inQuotes;
					if (retainQuotes)
					{
						builder.Append(c);
					}
				}
				else if (c == delimiter && !inQuotes)
				{
					var s = builder.ToString();
					if (trimTokens)
					{
						s = s.Trim();
					}
					tokens.Add(s);
					builder = new StringBuilder();
				}
				else
				{
					builder.Append(c);
				}
			}
			
			if (builder.Length > 0)
			{
				var s = builder.ToString();
				if (trimTokens)
				{
					s = s.Trim();
				}
				tokens.Add(s);
			}
			
			return tokens.ToArray();
		}
		
		public static string[] SplitKeyValue(string keyValue)
		{
			var line = Clean(keyValue);
			if (line == null)
			{
				return null;
			}
			
			string[] split = line.Split(" ".ToCharArray(), 2);
			if (split.Length != 2)
			{
				split = line.Split("=".ToCharArray(), 2);
				if (split.Length != 2)
				{
					throw new ArgumentException("Unable to determine Key/Value pair from line [" + line + "]. There is no space from " +
						"which the split location could be determined");
				}
			}
			
			var key = Clean(split[0]);
			if (key == null)
			{
				throw new ArgumentException("No valid key could be found in line [" + line + "] to form a key/value pair");
			}
			
			var value = Clean(split[1]);
			if (value == null)
			{
				throw new ArgumentException("No corresponding value could be found in line [" + line + "] for key [" + key + "]");
			}
			if (value.StartsWith("="))
			{
				value = Clean(value.Substring(1));
				if (value == null)
				{
					throw new ArgumentException("No corresponding value could be found in line [" + line + "] for key [" + key + "]");
				}
			}
			
			return new string[] {key, value};
		}
		
		public static bool StartsWithIgnoreCase(string value, string prefix)
		{
			if (value == null || prefix == null)
			{
				return false;
			}
			return value.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);
		}
		
		public static string ToDelimitedString(string delimiter, params object[] args)
		{
			if (args == null || args.Length == 0)
			{
				return EMPTY_STRING;
			}
			
			var builder = new StringBuilder();
			foreach (var arg in args)
			{
				if (builder.Length > 0)
				{
					builder.Append(delimiter);
				}
				builder.Append(arg);
			}
			return builder.ToString();
		}
		
		public static string ToString(params object[] args)
		{
			return ToDelimitedString(",", args);
		}
		
		public static string[] ToStringArray(ICollection collection)
		{
			if (collection == null)
			{
				return null;
			}
			
			return collection.Cast<string>().ToArray();
		}
		
		public static string[] TokenizeToStringArray(string value, string delimiters,
			bool trimTokens = true, bool ignoreEmptyTokens = true)
		{
			if (value == null)
			{
				return null;
			}
			
			var options = ignoreEmptyTokens ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
			var tokens = value.Split(value.ToCharArray(), options);
			if (trimTokens)
			{
				var accepted = new List<string>(tokens.Length);
				foreach (var token in tokens)
				{
					var tweaked = token.Trim();
					if (!ignoreEmptyTokens || tweaked.Length > 0)
					{
						accepted.Add(tweaked);
					}
				}
				tokens = accepted.ToArray();
			}
			return tokens;
		}
	}
}

