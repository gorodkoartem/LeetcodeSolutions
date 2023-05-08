namespace LeetcodeSolutions;

public static partial class Solutions
{
    // Task: https://leetcode.com/problems/add-two-numbers/
    
    // Given by leetcode
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var result = new ListNode();
        
        var currentNode = result;
        var prevNode = currentNode;
        var extraTen = 0;
        do
        {
            var sum = GetNodeValue(l1) + GetNodeValue(l2) + extraTen;
            currentNode.val = sum % 10;
            currentNode.next = new ListNode();

            extraTen = sum / 10;
            prevNode = currentNode;
            currentNode = currentNode.next;
            l1 = l1?.next;
            l2 = l2?.next;
        } while (l1 != null || l2 != null);

        if (extraTen != 0)
            currentNode.val = extraTen;
        else
            prevNode.next = null;

        return result;
    }
    
    private static int GetNodeValue(ListNode node) => node?.val ?? 0;
}