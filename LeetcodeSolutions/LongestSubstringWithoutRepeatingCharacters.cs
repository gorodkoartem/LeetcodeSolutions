namespace LeetcodeSolutions;

public partial class Solutions
{
    // Task: https://leetcode.com/problems/longest-substring-without-repeating-characters/
    
    public static int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        var maxSubstringLength = 0;
        var currentSubstring = new List<char>(s.Length);
        foreach (var character in s)
        {
            if (currentSubstring.Contains(character))
            {
                maxSubstringLength = Math.Max(maxSubstringLength, currentSubstring.Count);

                var charIndex = currentSubstring.IndexOf(character);
                currentSubstring = currentSubstring.Skip(charIndex + 1).ToList();
                currentSubstring.Add(character);
            }
            else
                currentSubstring.Add(character);
        }

        return Math.Max(maxSubstringLength, currentSubstring.Count);
    }
}