using System;
using System.Collections.Generic;

namespace Task_D_OneHungryHorse
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = int.Parse(Console.ReadLine());
            var startCoords = Console.ReadLine().Split(' ');
            var startX = int.Parse(startCoords[0]);
            var startY = int.Parse(startCoords[1]);
            var endCoords = Console.ReadLine().Split(' ');
            var endX = int.Parse(endCoords[0]);
            var endY = int.Parse(endCoords[1]);

            var chessBoard = new ChessBoard(boardSize);
            var path = chessBoard.FindShortestPath(startX, startY, endX, endY);
            var steps = path.Split('\n').Length - 1;
            Console.WriteLine(steps);
            Console.Write(path);
            Console.ReadLine();
        }
    }

    public class ChessBoard
    {
        private int boardSize;
        public Cell[,] Cells { get; set; }

        public ChessBoard(int size)
        {
            boardSize = size;
            Cells = new Cell[size + 1, size + 1];
        }

        public string FindShortestPath(int startX, int startY, int endX, int endY)
        {
            var visited = new bool[boardSize + 1, boardSize + 1];
            var queue = new Queue<Cell>();
            var startCell = new Cell(startX, startY);
            queue.Enqueue(startCell);
            
            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                var x = currentCell.X;
                var y = currentCell.Y;
                
                foreach (var nextPos in GetValidMoves(x, y))
                {
                    var nextX = nextPos[0];
                    var nextY = nextPos[1];
                    
                    if (nextX == endX && nextY == endY)
                    {
                        return currentCell.Path != null 
                            ? $"{currentCell.Path}\n{x} {y}\n{nextX} {nextY}" 
                            : $"{x} {y}\n{nextX} {nextY}";
                    }
                    
                    if (visited[nextX, nextY])
                        continue;
                    
                    queue.Enqueue(new Cell(nextX, nextY, currentCell));
                    visited[x, y] = true;
                }
            }
            return null;
        }

        private List<int[]> GetValidMoves(int x, int y)
        {
            var dx = new[] { 1, 2, -1, -2 };
            var dy = new[] { 2, 1, -2, -1 };
            var moves = new List<int[]>();

            foreach (var deltaX in dx)
            {
                foreach (var deltaY in dy)
                {
                    if (Math.Abs(deltaX) == Math.Abs(deltaY))
                        continue;
                    
                    var newX = x + deltaX;
                    var newY = y + deltaY;
                    
                    if (newX > 0 && newX <= boardSize && newY > 0 && newY <= boardSize)
                        moves.Add(new[] { newX, newY });
                }
            }
            return moves;
        }
    }

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Cell Previous { get; set; }
        public string Path { get; set; }

        public Cell(int x, int y, Cell previous = null)
        {
            X = x;
            Y = y;
            Previous = previous;
            Path = previous != null 
                ? (previous.Path != null ? $"{previous.Path}\n{previous.X} {previous.Y}" : $"{previous.X} {previous.Y}") 
                : null;
        }
    }
}
