using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public bool MovedBefore = false;
        public string PieceName;

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

        public List<Square> MultipleMovesInOneDirection(Square currentSquare, Tuple<int, int> stepIncrease, Board board) 
        {
            var resultList = new List<Square>();

            var rowSteps = stepIncrease.Item1;
            var colSteps = stepIncrease.Item2;
            while (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(rowSteps, colSteps)) &&
                   (SquareEmpty(currentSquare, new Tuple<int, int>(rowSteps, colSteps), board) ||
                    OpposingPieceInSquare(currentSquare, new Tuple<int, int>(rowSteps, colSteps), board)))
            {
                var oneMoveResult = this.OneMove(currentSquare, new Tuple<int, int>(rowSteps, colSteps));
                resultList.Add(oneMoveResult);
                if (OpposingPieceInSquare(currentSquare, new Tuple<int, int>(rowSteps, colSteps), board ))
                {
                    break;
                }

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

        public static bool SquareEmpty(Square currentSquare, Tuple<int, int> stepIncrease, Board board)
        {
            var piece = board.GetPiece(new Square(currentSquare.Row + stepIncrease.Item1,
                currentSquare.Col + stepIncrease.Item2));
            return piece == null;
        }

        public static bool OpposingPieceInSquare(Square currentSquare, Tuple<int, int> stepIncrease, Board board)
        {
            var piece = board.GetPiece(new Square(currentSquare.Row + stepIncrease.Item1,
                currentSquare.Col + stepIncrease.Item2));
            if (piece != null) { return piece.Player != board.CurrentPlayer;}

            return false;
        }
    }
}