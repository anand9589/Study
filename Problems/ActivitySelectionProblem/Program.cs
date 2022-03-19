// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int[] start = { 1, 3, 0, 5, 8, 5 };
int[] end = { 2, 4, 6, 7, 9, 9 };

int[] result = activitySelection(start, end);

Console.WriteLine(string.Join(' ', result));

int[] activitySelection(int[] start, int[] end)
{
    List<int> list = new List<int>();
    list.Add(1);
    for (int i = 1; i < start.Length; i++)
    {
        if (start[i] > end[list.Last() - 1])
        {
            list.Add(i + 1);
        }
    }
    return list.ToArray();
}