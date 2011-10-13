namespace Apache.Shiro.Util
{
    public interface IPatternMatcher
    {
        bool Matches(string pattern, string source);
    }
}
