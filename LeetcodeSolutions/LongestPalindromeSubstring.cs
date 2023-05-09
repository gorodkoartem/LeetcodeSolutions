namespace LeetcodeSolutions;

public partial class Solutions
{
    // Task: https://leetcode.com/problems/longest-palindromic-substring/
    public static string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;
        
        (int Left, int Right) maxPalindrome = (0, 0);
        int maxPalindromeLength = 1;
        for (var i = 1; i < s.Length; i++)
        {
            var isPalindrome = TryGetPalindromeCenter(s, i, out var palindromeCenter);
            if (isPalindrome)
            {
                var palindrome = palindromeCenter.Select(c => GetPalindrome(s, c)).MaxBy(GetPalindromeLength);
                var palindromeLength = GetPalindromeLength(palindrome);
                if (palindromeLength > maxPalindromeLength)
                {
                    maxPalindrome = palindrome;
                    maxPalindromeLength = palindromeLength;
                }
            }
        }

        return s.Substring(maxPalindrome.Left, maxPalindromeLength);
    }

    private static (int From, int To) GetPalindrome(string source, (int Left, int Right) center)
    {
        var from = center.Left;
        var to = center.Right;
        while (from >= 0 && to < source.Length)
        {
            if (source[from] != source[to])
                return (from + 1, to - 1);
            
            from--;
            to++;
        }

        return (from + 1, to - 1);
    }

    private static bool TryGetPalindromeCenter(string source, int currentIndex, out IList<(int Left, int Right)> centers)
    {
        centers = new List<(int Left, int Right)>();
        if (AreCharsTheSame(source, currentIndex, currentIndex - 1))
            centers.Add((currentIndex - 1, currentIndex));

        if (AreCharsTheSame(source, currentIndex, currentIndex - 2))
            centers.Add((currentIndex - 2, currentIndex));

        return centers.Any();
    }

    private static bool AreCharsTheSame(string source, int index1, int index2)
    {
        if (index1 < 0 || index1 >= source.Length || index2 < 0 || index2 >= source.Length)
            return false;

        return source[index1] == source[index2];
    }

    private static int GetPalindromeLength((int Left, int Right) palindrome) => palindrome.Right - palindrome.Left + 1;
}