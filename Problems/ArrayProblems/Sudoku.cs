namespace ArrayProblems
{
    internal class Sudoku
    {

        public void SolveSudoku(char[][] board)
        {
            bool needToCheckAgain = false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char c = board[i][j];

                    if (c == '.')
                    {
                        needToCheckAgain = true;

                        fillValueForCell(board, i, j);
                        fiilBox(board, i, j);
                    }
                    else
                    {
                        Console.WriteLine($"{i} {j} {c}");
                    }
                }
            }
            if (needToCheckAgain)
            {
                SolveSudoku(board);
            }
        }

        private void fiilBox(char[][] board, int i, int j)
        {
            List<int> possValues = Enumerable.Range(1, 9).ToList();
            int x1 = getX1(i);
            int y1 = getX1(j);
            for (int i1 = x1; i1 < x1 + 3; i1++)
            {
                for (int j1 = y1; j1 < y1 + 3; j1++)
                {
                    char c = board[i1][j1];
                    if (c != '.')
                    {
                        int num = c - '0';

                        possValues.Remove(num);
                    }
                }
            }
        }

        private void fillValueForCell(char[][] board, int i, int j)
        {
            List<int> possValues = Enumerable.Range(1, 9).ToList();

            checkBox(board, i, j, possValues);
            checkRow(board, i, j, possValues);
            checkCol(board, i, j, possValues);
            if (possValues.Count == 1)
            {
                board[i][j] = (char)((int)'0' + possValues[0]);
            }
        }

        private void checkRow(char[][] boards, int row, int col, List<int> pvalues)
        {
            for (int i = 0; i < 9; i++)
            {
                char c = boards[row][i];

                int num = c - '0';

                pvalues.Remove(num);
            }
        }

        private void checkCol(char[][] boards, int row, int col, List<int> pvalues)
        {
            for (int i = 0; i < 9; i++)
            {
                char c = boards[i][col];

                int num = c - '0';

                pvalues.Remove(num);
            }
        }

        private void checkBox(char[][] boards, int row, int col, List<int> possibleValues)
        {
            int i1 = getX1(row);
            int j1 = getX1(col);

            for (int i = i1; i < i1 + 3; i++)
            {
                for (int j = j1; j < j1 + 3; j++)
                {
                    int num = boards[i][j] - '0';

                    possibleValues.Remove(num);
                }
            }
        }

        private static int getX1(int x)
        {
            if (x < 3)
            {
                return 0;
            }
            else if (x < 6)
            {
                return 3;
            }
            else
            {
                return 6;
            }
        }

        //private static List<int> getMissValueFromCols(char[][] boards, int col)
        //{
        //    List<int> miss = Enumerable.Range(1, 9).ToList();

        //    for (int i = 0; i < boards.Length; i++)
        //    {
        //        int num = boards[i][col] - '0';

        //        miss.Remove(num);
        //    }

        //    return miss;
        //}

        //private void fillTheValueBasedOnRows(char[][] boards, int row)
        //{
        //    List<int> miss = Enumerable.Range(1, 9).ToList();

        //    for (int i = 0; i < boards.Length; i++)
        //    {

        //    }
        //}

        //private void fillTheValueBasedOnCols(char[][] boards, int col)
        //{
        //    List<int> miss = getMissValueFromCols(boards, col);

        //    while (miss.Count > 0)
        //    {
        //        for (int i = 0; i < boards.Length; i++)
        //        {
        //            char c = boards[i][col];
        //            if (c == '.')
        //            {
        //                if (miss.Count == 1)
        //                {

        //                    boards[i][col] = (char)((int)'0' + miss[0]);
        //                    miss.Clear();
        //                }
        //                else
        //                {
        //                    int val = fillPossibleValueForCol(boards, i, col, miss);
        //                    if (val > 0)
        //                    {
        //                        miss.Remove(val);
        //                        boards[i][col] = (char)((int)'0' + val);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private int fillPossibleValueForCol(char[][] boards, int row, int col, List<int> possibleValues)
        //{
        //    //1st check in the box
        //    List<int> pvalues = new List<int>(possibleValues);
        //    checkBox(boards, row, col, pvalues);
        //    checkRow(boards, row, col, pvalues);
        //    if (pvalues.Count == 1)
        //    {
        //        return pvalues[0];
        //        //boards[row][col] = (char)((int)'0' + pvalues[0]);
        //        //possibleValues.Remove(pvalues[0]);
        //        //rows[row]++;
        //        //cols[col]++;
        //        //updateBoardsCount(row, col);
        //    }

        //    return -1;
        //    //2nd check in the row
        //}

        //private void fillTheValueBasedOnBox(char[][] boards, int boxid)
        //{
        //    List<int> miss = Enumerable.Range(1, 9).ToList();

        //    for (int i = 0; i < boards.Length; i++)
        //    {

        //    }
        //}

        //private void updateBoardsCount(int i, int j)
        //{
        //    switch (i)
        //    {
        //        case 0:
        //        case 1:
        //        case 2:
        //            switch (j)
        //            {
        //                case 0:
        //                case 1:
        //                case 2:
        //                    box[0]++;
        //                    break;

        //                case 3:
        //                case 4:
        //                case 5:
        //                    box[1]++;
        //                    break;

        //                case 6:
        //                case 7:
        //                case 8:
        //                    box[2]++;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            break;

        //        case 3:
        //        case 4:
        //        case 5:
        //            switch (j)
        //            {
        //                case 0:
        //                case 1:
        //                case 2:
        //                    box[3]++;
        //                    break;

        //                case 3:
        //                case 4:
        //                case 5:
        //                    box[4]++;
        //                    break;

        //                case 6:
        //                case 7:
        //                case 8:
        //                    box[5]++;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            break;

        //        case 6:
        //        case 7:
        //        case 8:
        //            switch (j)
        //            {
        //                case 0:
        //                case 1:
        //                case 2:

        //                    box[6]++;
        //                    break;

        //                case 3:
        //                case 4:
        //                case 5:

        //                    box[7]++;
        //                    break;

        //                case 6:
        //                case 7:
        //                case 8:

        //                    box[8]++;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}


        //private int[] rows;
        //private int[] cols;
        //private int[] box;

        //private void initRowColsBox()
        //{
        //    rows = Enumerable.Repeat(0, 9).ToArray();
        //    cols = Enumerable.Repeat(0, 9).ToArray();
        //    box = Enumerable.Repeat(0, 9).ToArray();
        //}
    }
}
