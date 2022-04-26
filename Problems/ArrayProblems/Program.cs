// See https://aka.ms/new-console-template for more information
using ArrayProblems;

var text = File.ReadAllText(@"C:\Workspace\Study\Problems\sudokuboard.txt");
text = text.Replace("[", string.Empty).Replace("]", string.Empty);
string[] lines = text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

char[][] chars = new char[lines.Length][];
for (int i = 0; i < lines.Length; i++)
{
    var strs = lines[i].Replace("\"", "").Split(",", StringSplitOptions.RemoveEmptyEntries);
    chars[i] = new char[strs.Length];
    for (int j = 0; j < strs.Length; j++)
    {
        chars[i][j] = strs[j][0];  
    }
}
Solution solution = new Solution();
var result = solution.IsValidSudoku(chars); 
//solution.IsValidSudoku();
//Console.WriteLine(String.Join(",", nums));