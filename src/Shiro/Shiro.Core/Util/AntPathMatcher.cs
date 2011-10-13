using System;
using System.Text;

namespace Apache.Shiro.Util
{
	public class AntPathMatcher : IPatternMatcher
	{
		public const string DEFAULT_PATH_SEPARATOR = "/";
		
		private string _pathSeparator;

		public AntPathMatcher ()
		{
			PathSeparator = DEFAULT_PATH_SEPARATOR;
		}
		
		public string PathSeparator
		{
			get
			{
				return _pathSeparator;
			}
			set
			{
				_pathSeparator = value ?? DEFAULT_PATH_SEPARATOR;
			}
		}
		
		public string ExtractPathWithinPattern(string pattern, string path)
		{
			string[] patternParts = StringUtils.TokenizeToStringArray(pattern, PathSeparator);
			string[] pathParts = StringUtils.TokenizeToStringArray(path, PathSeparator);
			
			var builder = new StringBuilder();
			
			var puts = 0;
			for (var i = 0; i < patternParts.Length; ++i)
			{
				var part = patternParts[i];
				if ((part.Contains("*") || part.Contains("?")) && pathParts.Length >= (i + 1))
				{
					if (puts > 0 || (i == 0 && !pattern.StartsWith(PathSeparator)))
					{
						builder.Append(PathSeparator);
					}
					builder.Append(pathParts[i]);
					++puts;
				}
			}
			
			for (var i = patternParts.Length; i < pathParts.Length; ++i)
			{
				if (puts > 0 || i > 0)
				{
					builder.Append(PathSeparator);
				}
				builder.Append(pathParts[i]);
			}
			
			return builder.ToString();
		}
		
		public bool IsPattern(string path)
		{
			return path.Contains("*") || path.Contains("?");
		}
		
		public bool Match(string pattern, string path)
		{
			return DoMatch(pattern, path, true);
		}
		
		public bool MatchStart(string pattern, string path)
		{
			return DoMatch(pattern, path, false);
		}
		
		public bool Matches(string pattern, string source)
		{
			return Match(pattern, source);
		}
		
		protected bool DoMatch(string pattern, string path, bool fullMatch)
		{
			if (path.StartsWith(PathSeparator) != pattern.StartsWith(PathSeparator))
			{
				return false;
			}
			
			var patternParts = StringUtils.TokenizeToStringArray(pattern, PathSeparator);
			var pathParts = StringUtils.TokenizeToStringArray(path, PathSeparator);
			
			var patternStartIndex = 0;
			var patternEndIndex = patternParts.Length - 1;
			var pathStartIndex = 0;
			var pathEndIndex = pathParts.Length - 1;
			
			// Match all elements up to the first **
	        while (patternStartIndex <= patternEndIndex && pathStartIndex <= pathEndIndex)
			{
	            var patternPart = patternParts[patternStartIndex];
	            if (patternPart == "**")
				{
	                break;
	            }
	            if (!MatchStrings(patternPart, pathParts[pathStartIndex]))
				{
	                return false;
	            }
	            pathStartIndex++;
	            patternStartIndex++;
	        }
	
	        if (pathStartIndex > pathEndIndex)
			{
	            // Path is exhausted, only match if rest of pattern is * or **'s
	            if (patternStartIndex > patternEndIndex)
				{
	                return pattern.EndsWith(PathSeparator) == path.EndsWith(PathSeparator);
	            }
	            if (!fullMatch)
				{
	                return true;
	            }
	            if (patternStartIndex == patternEndIndex &&
					patternParts[patternStartIndex] == "*" &&
					path.EndsWith(PathSeparator))
				{
	                return true;
	            }
	            for (int i = patternStartIndex; i <= patternEndIndex; i++)
				{
	                if (patternParts[i] != "**")
					{
	                    return false;
	                }
	            }
	            return true;
	        }
			else if (patternStartIndex > patternEndIndex)
			{
	            // String not exhausted, but pattern is. Failure.
	            return false;
	        }
			else if (!fullMatch && patternParts[patternStartIndex] == "**")
			{
	            // Path start definitely matches due to "**" part in pattern.
	            return true;
	        }
	
	        // up to last '**'
	        while (patternStartIndex <= patternEndIndex && pathStartIndex <= pathEndIndex)
			{
	            var patternPart = patternParts[patternEndIndex];
	            if ("**" == patternPart)
				{
	                break;
	            }
	            if (!MatchStrings(patternPart, pathParts[pathEndIndex]))
				{
	                return false;
	            }
	            pathEndIndex--;
	            patternEndIndex--;
	        }
	        if (pathStartIndex > pathEndIndex)
			{
	            // String is exhausted
	            for (var i = patternStartIndex; i <= patternEndIndex; i++)
				{
	                if (patternParts[i] != "**")
					{
	                    return false;
	                }
	            }
	            return true;
	        }
	
	        while (patternStartIndex != patternEndIndex && pathStartIndex <= pathEndIndex)
			{
	            int index = -1;
	            for (var i = patternStartIndex + 1; i <= patternEndIndex; i++)
				{
	                if (patternParts[i] == "**")
					{
	                    index = i;
	                    break;
	                }
	            }
	            if (index == patternStartIndex + 1)
				{
	                // '**/**' situation, so skip one
	                patternStartIndex++;
	                continue;
	            }
	            // Find the pattern between padIdxStart & padIdxTmp in str between
	            // strIdxStart & strIdxEnd
	            var patternLength = (index - patternStartIndex - 1);
	            var pathLength = (pathEndIndex - pathStartIndex + 1);
	            var foundIndex = -1;
	
	            for (var i = 0; i <= pathLength - patternLength; i++)
				{
					var found = true;
	                for (var j = 0; j < patternLength; j++) {
	                    var subPat = patternParts[patternStartIndex + j + 1];
	                    var subStr = pathParts[pathStartIndex + i + j];
	                    if (!MatchStrings(subPat, subStr)) {
	                        found = false;
							break;
	                    }
	                }
					
					if (found)
					{
		                foundIndex = pathStartIndex + i;
		                break;
					}
	            }
	
	            if (foundIndex == -1) {
	                return false;
	            }
	
	            patternStartIndex = index;
	            pathStartIndex = foundIndex + patternLength;
	        }
	
	        for (var i = patternStartIndex; i <= patternEndIndex; i++)
			{
	            if (patternParts[i] != "**")
				{
	                return false;
	            }
	        }
	        return true;
		}
		
		private bool MatchStrings(string pattern, string path)
		{
			var patternChars = pattern.ToCharArray();
			var pathChars = path.ToCharArray();
			var patternEndIndex = patternChars.Length;
			var pathEndIndex = pathChars.Length;
			char c;
			
			if (pattern.IndexOf('*') < 0)
			{
	            // No '*'s, so we make a shortcut
				if (patternEndIndex != pathEndIndex)
				{
					return false; // Pattern and string do not have the same size
				}
				for (var i = 0; i <= patternEndIndex; ++i)
				{
					c = patternChars[i];
					if (c != '?' && c != pathChars[i])
					{
						return false; // Character mismatch
					}
				}
				return true; // String matches against pattern
			}
			
			if (patternEndIndex == 0)
			{
				return true; // Pattern contains only '*', which matches anything
			}

	        // Process characters before first star
			var patternStartIndex = 0;
			var pathStartIndex = 0;
			while ((c = patternChars[patternStartIndex]) != '*' && pathStartIndex <= pathEndIndex)
			{
				if (c != '?' && c != pathChars[pathStartIndex])
				{
					return false; // Character mismatch
				}
				++pathStartIndex;
				++patternStartIndex;
			}
			if (pathStartIndex > pathEndIndex)
			{
	            // All characters in the string are used. Check if only '*'s are
	            // left in the pattern. If so, we succeeded. Otherwise failure.
				for (var i = patternStartIndex; i <= patternEndIndex; ++i)
				{
					if (patternChars[i] != '*')
					{
						return false;
					}
				}
				return true;
			}
			
	        // Process characters after last star
			while ((c = patternChars[patternEndIndex]) != '*' && pathStartIndex <= pathEndIndex)
			{
	            if (c != '?')
				{
	                if (c != pathChars[pathEndIndex])
					{
	                    return false; // Character mismatch
	                }
	            }
	            patternEndIndex--;
	            pathEndIndex--;
	        }
	        if (pathStartIndex > pathEndIndex)
			{
	            // All characters in the string are used. Check if only '*'s are
	            // left in the pattern. If so, we succeeded. Otherwise failure.
	            for (var i = patternStartIndex; i <= patternEndIndex; i++)
				{
	                if (patternChars[i] != '*')
					{
	                    return false;
	                }
	            }
	            return true;
	        }
	
	        // process pattern between stars. padIdxStart and patternEndIndex point
	        // always to a '*'.
	        while (patternStartIndex != patternEndIndex && pathStartIndex <= pathEndIndex)
			{
	            int index = -1;
	            for (var i = patternStartIndex + 1; i <= patternEndIndex; i++)
				{
	                if (patternChars[i] == '*')
					{
	                    index = i;
	                    break;
	                }
	            }
	            if (index == patternStartIndex + 1)
				{
	                // Two stars next to each other, skip the first one.
	                patternStartIndex++;
	                continue;
	            }
				
	            // Find the pattern between padIdxStart & padIdxTmp in str between
	            // pathStartIndex & pathEndIndex
	            var patternLength = (index - patternStartIndex - 1);
	            var pathLength = (pathEndIndex - pathStartIndex + 1);
	            var foundIndex = -1;
	            for (var i = 0; i <= pathLength - patternLength; i++)
				{
					var found = true;
	                for (var j = 0; j < patternLength; j++)
					{
	                    c = patternChars[patternStartIndex + j + 1];
	                    if (c != '?')
						{
	                        if (c != pathChars[pathStartIndex + i + j])
							{
	                            found = false;
								break;
	                        }
	                    }
	                }
					
					if (found)
					{
						foundIndex = pathStartIndex + i;
		                break;
					}
	            }
	
	            if (foundIndex == -1) {
	                return false;
	            }
	
	            patternStartIndex = index;
	            pathStartIndex = foundIndex + patternLength;
	        }
	
	        // All characters in the string are used. Check if only '*'s are left
	        // in the pattern. If so, we succeeded. Otherwise failure.
	        for (var i = patternStartIndex; i <= patternEndIndex; i++)
			{
	            if (patternChars[i] != '*')
				{
	                return false;
	            }
	        }
	
	        return true;
		}
	}
}

