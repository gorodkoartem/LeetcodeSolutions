namespace LeetcodeSolutions;

public partial class Solutions
{
    // Task: https://leetcode.com/problems/two-sum/
    
    public static int[] TwoSum(int[] nums, int target)
    {
        var arrayLength = nums.Length;
        for(var i = 0; i < arrayLength; i++)
        {
            for(var j = i + 1; j < arrayLength; j++)
            {
                if(nums[i] + nums[j] == target)
                    return new[]{i, j};
            }
        }

        return null;
    }
}