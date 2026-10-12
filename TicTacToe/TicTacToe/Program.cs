using System;
using System.Threading;

char[] board = new char[9];

for (int i = 0; i < board.Length; i++)
{
    board[i] = '·';
}

char player = 'X';

char computer = 'O';

int boardCount = 0;

Console.WriteLine("===틱택토 게임===");
Console.WriteLine("-1단계-   ");
Console.WriteLine("-2단계-   ");
Level();

void Level()
{
    Console.Clear();
    Console.WriteLine("===틱택토 게임===");
    Console.WriteLine("-1단계-   ");
    Console.WriteLine("-2단계-   ");

    while (true)
    {
        Console.Write("선택: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int levelChoice))
        {
            Console.WriteLine("숫자를 입력하세요");
            continue;

        }
        if (levelChoice < 1 || levelChoice > 2)
        {
            Console.WriteLine("1또는 2단계를 선택하세요.");
            continue;
        }
        if (levelChoice == 1)
        {
            Console.Clear();
            Thread.Sleep(1000);
            Level_1();
            break;
        }
        if (levelChoice == 2)
        {
            Console.Clear();
            Console.WriteLine("컴퓨터가 준비 중 입니다.");
            Thread.Sleep(1000);
            Level_2();
            break;
        }
    }

}


void Level_1()
{
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
}

void Level_2()
{
    while (true)
    {
        PrintBoard_2();
        Console.WriteLine($"플레이어 {player}의 차례입니다.");

        int position = GetPosition(board);
        int index = position - 1;
        board[index] = player;
        boardCount++;

        if (CheckWinner(board, player))
        {
            PrintBoard_2();
            Console.WriteLine($"플레이어{player}의 승리입니다!");
            break;
        }
        if (CheckWinner(board, computer))
        {
            PrintBoard_2();
            Console.WriteLine($"플레이어{computer}의 승리입니다!");
            break;
        }
        if (boardCount == 9)
        {
            PrintBoard_2();
            Console.WriteLine("무승부 입니다.");
            break;
        }

        PrintBoard_2();
        Console.WriteLine($"플레이어 {computer}의 차례입니다.");
        Computer();
        boardCount++;
        Console.WriteLine();
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
        Console.Write($" {i,-2}");
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
        Console.Write($" {board[j],-2}");
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

void PrintBoard_2()
{
    Console.Clear();
    Console.WriteLine("=== 틱택토 게임 ·2단계");
    Console.WriteLine("사람(X)과 컴퓨터(O)가 번갈아 둡니다.");
    Console.WriteLine("사람이 먼저 시작합니다.");
    Console.WriteLine();

    for (int i = 1; i <= board.Length; i++) //숫자 예시 판
    {
        Console.Write($" {i,-2}");
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
        Console.Write($" {board[j],-2}");
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

void Computer()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("컴퓨터가 선택 중 입니다...");
        Thread.Sleep(750);
        Random random = new Random();
        int transPosition = random.Next(1, 10);
        int index = transPosition - 1;
        if (board[index] != 'X' && board[index] == '·' && board[index] != 'O')
        {
            board[index] = computer;
            break;
        }
    }
}