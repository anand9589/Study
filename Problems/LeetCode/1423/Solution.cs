namespace LeetCode._1423
{
    internal class Solution
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            int sum = cardPoints.Sum();
            int length = cardPoints.Length;

            if (length == k) return sum;

            int frame = 0;
            int res = 0;

            for (int i = 0; i < length - k - 1; i++)
            {
                frame += cardPoints[i];
            }

            for (int i = length - k - 1; i < length; i++)
            {
                frame += cardPoints[i];

                res = Math.Max(res, sum - frame);

                frame -= cardPoints[i - (length - k - 1)];
            }

            return res;
        }
    }
}
