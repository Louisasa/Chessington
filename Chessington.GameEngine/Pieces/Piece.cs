using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public bool MovedBefore = false;

        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            MovedBefore = true;
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public Square OneMove(Square currentSquare, Tuple<int, int> stepIncrease)
        {
            return new Square(currentSquare.Row + stepIncrease.Item1, currentSquare.Col + stepIncrease.Item2);
        }

        public List<Square> MultipleMovesInOneDirection(Square currentSquare, Tuple<int, int> stepIncrease) 
        {
            var resultList = new List<Square>();

            var rowSteps = stepIncrease.Item1;
            var colSteps = stepIncrease.Item2;
            while (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>( rowSteps, colSteps)))
            {
                var oneMoveResult = this.OneMove(currentSquare, new Tuple<int, int>(rowSteps, colSteps));
                resultList.Add(oneMoveResult);
                rowSteps += stepIncrease.Item1;
                colSteps += stepIncrease.Item2;
            }

            return resultList;
        }

        public static bool IsMoveInGameBoardRange(Square currentSquare, Tuple<int, int> stepIncrease)
        {
            return currentSquare.Row + stepIncrease.Item1 < GameSettings.BoardSize && currentSquare.Row + stepIncrease.Item1 >= 0 &&
                   currentSquare.Col + stepIncrease.Item2 < GameSettings.BoardSize && currentSquare.Col + stepIncrease.Item2 >= 0;
        }
    }
}