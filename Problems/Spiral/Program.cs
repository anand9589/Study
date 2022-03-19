
Console.WriteLine("Enter row length ");
int row = int.Parse(Console.ReadLine());

Console.WriteLine("Enter col length ");
int col = int.Parse(Console.ReadLine());


int[,] outputarray = spiralMethod(row, col);
printarray(outputarray);


void printarray(int[,] outputarray)
{
    for (int i = 0; i < outputarray.GetLength(0); i++)
    {
        for (int j = 0; j < outputarray.GetLength(1); j++)
        {
            Console.Write($" {outputarray[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] spiralMethod(int r, int c)
{
    int[,] a = new int[r, c];
    int j = 1;

    int x1 = 0, y1 = 0, x2 = c - 1, y2 = r - 1;
    while (j <= r * c)
    {
        for (int i = x1; i <= x2; i++)
        {
            a[y1, i] = j;
            j++;
        }
        y1++;

        for (int i = y1; i <= y2; i++)
        {
            a[i, x2] = j;
            j++;
        }
        x2--;


        for (int i = x2; i >= x1; i--)
        {
            a[y2, i] = j;
            j++;
        }
        y2--;

        for (int i = y2; i >= y1; i--)
        {
            a[i, x1] = j;
            j++;
        }

        x1++;

    }

    return a;
}