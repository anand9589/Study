// See https://aka.ms/new-console-template for more information
Console.WriteLine("enter the no inputs: ");

int n = int.Parse(Console.ReadLine());

int[,] outputarray = spiralMethod(n);

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

int[,] spiralMethod(int n)
{
    int[,] a = new int[n,n];
    int j = 1;  
     int x1 = 0 ,  y1=0 ,   x2=n-1, y2=n-1 ;
    while(j <= n * n)
    {
        for (int  i = x1; i <=x2; i++)
        {
            a[y1, i] = j;
            j++;
        }
        y1++;

        for (int i =y1; i <= y2 ; i++)
        {
            a[i, x2] = j;
            j++;
        }
        x2--;
 
        for(int  i = x2; i>=x1; i--)
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