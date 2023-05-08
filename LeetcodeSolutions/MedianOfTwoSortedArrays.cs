namespace LeetcodeSolutions;

public partial class Solutions
{
    // Task: https://leetcode.com/problems/median-of-two-sorted-arrays/
    
    /// <summary>
    /// Complexity O(n + m)
    /// where n - length of nums1 array
    /// m - length of nums2 array
    /// </summary>
    public static double FindMedianSortedArrays1(int[] nums1, int[] nums2)
    {
        var mergedArray = MergeArrays(nums1, nums2);

        var medianIndex = mergedArray.Length / 2;
        if (mergedArray.Length % 2 != 0)
            return mergedArray[medianIndex];

        return (mergedArray[medianIndex - 1] + mergedArray[medianIndex]) / 2d;
    }
    
    /// <summary>
    /// Complexity O(log(n + m))
    /// where n - length of nums1 array
    /// m - length of nums2 array
    /// </summary>
    public static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
    {
        var smallerArray = nums1.Length > nums2.Length ? nums2 : nums1;
        var biggerArray = nums1.Length > nums2.Length ? nums1 : nums2;
        
        var smallerArrayLeftBorder= 0;
        var smallerArrayRightBorder = smallerArray.Length - 1;
        
        var expectedMiddleIndex = (smallerArray.Length + biggerArray.Length + 1) / 2;
        
        while (smallerArrayLeftBorder <= smallerArrayRightBorder)
        {
            var smallerArrayMiddleIndex = (smallerArrayLeftBorder + smallerArrayRightBorder) / 2;
            var biggerArrayMiddleIndex = expectedMiddleIndex - smallerArrayMiddleIndex;
            
            var smallerArrayLeftValue = smallerArrayMiddleIndex > 0 ? smallerArray[smallerArrayMiddleIndex - 1] : Int32.MinValue;
            var smallerArrayRightValue = smallerArrayMiddleIndex < smallerArray.Length ? smallerArray[smallerArrayMiddleIndex] : Int32.MaxValue;
            var biggerArrayLeftValue = biggerArrayMiddleIndex > 0 ? biggerArray[biggerArrayMiddleIndex - 1] : Int32.MinValue;
            var biggerArrayRightValue = biggerArrayMiddleIndex < biggerArray.Length ? smallerArray[biggerArrayMiddleIndex] : Int32.MaxValue;

            if (smallerArrayLeftValue <= biggerArrayRightValue && smallerArrayRightValue >= biggerArrayLeftValue)
            {
                if ((smallerArray.Length + biggerArray.Length) % 2 != 0)
                    return Math.Max(smallerArrayLeftValue, biggerArrayLeftValue);

                return (Math.Max(smallerArrayLeftValue, biggerArrayLeftValue) + Math.Min(smallerArrayRightValue, biggerArrayRightValue)) / 2d;
            }

            if (smallerArrayLeftValue > biggerArrayRightValue)
                smallerArrayLeftBorder = smallerArrayMiddleIndex - 1;
            else
                smallerArrayRightBorder = smallerArrayMiddleIndex + 1;
        }

        throw new InvalidOperationException();
    }
    

    private static int[] MergeArrays(int[] nums1, int[] nums2)
    {
        var mergedArray = new int[nums1.Length + nums2.Length];
        var nums1Index = 0;
        var nums2Index = 0;
        for (var i = 0; i < mergedArray.Length; i++)
        {
            int? nums1Value = null;
            if (nums1Index < nums1.Length)
            {
                nums1Value = nums1[nums1Index];
            }
            
            int? nums2Value = null;
            if (nums2Index < nums2.Length)
            {
                nums2Value = nums2[nums2Index];
            }

            if (nums1Value != null && (nums2Value == null || nums1Value.Value < nums2Value.Value))
            {
                nums1Index++;
                mergedArray[i] = nums1Value.Value;
            }
            else
            {
                nums2Index++;
                mergedArray[i] = nums2Value.Value;
            }
        }
        
        return mergedArray;
    }
}