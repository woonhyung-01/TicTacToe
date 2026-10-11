using System;

char[] board = new char[9];

for (int i = 0; i < board.Length; i++)
{
    board[i] = '·';
}

char player = 'X';

int boardCount = 0;

Console.WriteLine("=== 틱택토 게임 ·1단계===");
Console.WriteLine("두 사람이 X와 O를 번갈아 놓습니다.");
Console.WriteLine("X가 먼저 시작합니다.");
Console.WriteLine();

while (true)
{
    PrintBoard();
    Console.WriteLine($"플레이어 {player}의 차례입니다.");
    int position = GetPosition(board);
    int index = position - 1;
    board[index] = player;
    boardCount++;
    Console.WriteLine();
    if (CheckWinner(board, player))
    {
        PrintBoard();
        Console.WriteLine($"플레이어{player}의 승리입니다!");
        break;
    }
    if (boardCount == 9)
    {
        PrintBoard();
        Console.WriteLine("무승부 입니다.");
        break;
    }
    if (player == 'X')
    {
        player = 'O';
    }
    else
    {
        player = 'X';
    }
}


void PrintBoard() 
{
    Console.Clear();
    Console.WriteLine("=== 틱택토 게임 ·1단계");
    Console.WriteLine("두 사람이 X와 O를 번갈아 놓습니다.");
    Console.WriteLine("X가 먼저 시작합니다.");
    Console.WriteLine();

    for (int i = 1; i <= board.Length; i++) //숫자 예시 판
    {
        Console.Write($" {i, -2}");
        if (i % 3 == 0)
        {
            Console.WriteLine();
            if (i < 7)
            {
                Console.WriteLine("---+---+---");
            }
        }
        else
        {
            Console.Write("|");
        }
    }
    Console.WriteLine();

    for (int j = 0; j < board.Length; j++)
    {
        Console.Write($"{board[j], -2}");
        if (j % 3 == 2)
        {
            Console.WriteLine();
            if (j < 6)
            {
                Console.WriteLine("---+---+---");
            }
        }
        else
        {
            Console.Write("|");
        }
    }

    Console.WriteLine();
}

int GetPosition(char[] board) 
{
    while (true)
    {
        Console.Write("위치를 선택하세요. (1 ~ 9): ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int position))
        {
            Console.WriteLine("숫자를 입력하세요.");
            continue;
        }
        else if (position < 0 || position > 9)
        {
            Console.WriteLine("1 ~ 9 사이의 숫자를 입력하세요");
            continue;
        }
        int index = position - 1;
        if (board[index] != '·')
        {
            Console.WriteLine("이미 선택된 번호입니다. 다른 번호를 선택하세요.");
            continue;
        }
        return position;
    }
}


bool CheckWinner(char[] board, char player) 
{
    if (CheckLine(board, player, 0, 1, 2)) return true;
    if (CheckLine(board, player, 3, 4, 5)) return true;
    if (CheckLine(board, player, 6, 7, 8)) return true;

    if (CheckLine(board, player, 0, 3, 6)) return true;
    if (CheckLine(board, player, 1, 4, 7)) return true;
    if (CheckLine(board, player, 2, 5, 8)) return true;

    if (CheckLine(board, player, 0, 4, 8)) return true;
    if (CheckLine(board, player, 2, 4, 6)) return true;

    return false;
}



bool CheckLine(char[] board, char player, int x, int y, int z)
{
    return board[x] == player && board[y] == player
        && board[z] == player;
}