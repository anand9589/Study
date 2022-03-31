// See https://aka.ms/new-console-template for more information
using QueueProblems.LRU;

Console.WriteLine("Hello, World!");
var lines = File.ReadAllLines(@"C:\Workspace\Study\Problems\LRUCache.txt");

#region LRUCache
int cap = int.Parse(lines[0]);
int queries = int.Parse(lines[1]);
LRUCache_V1 lRUCache = new LRUCache_V1(cap);

string[] strings = lines[2].Trim().Split(' ');

for (int i = 0; i < strings.Length; i++)
{
    switch (strings[i])
    {
        case "GET":
            i++;
            lRUCache.get(int.Parse(strings[i]));
            break;
        case "SET":
            i++;
            int key = int.Parse(strings[i]);
            i++;
            int value = int.Parse(strings[i]);
            lRUCache.set(key, value);
            break;
        default:
            break;
    }
}

#endregion
