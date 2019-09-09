using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player)
        {
            this.PieceName = "king";
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();

            var resultList = CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(1, 1), board);
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(-1, 1), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(1, -1), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(-1, -1), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(1, 0), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(-1, 0), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(0, 1), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(0, -1), board))
                .ToList();

            return resultList;
        }

        private List<Square> CheckAndGetAvailableMove(Square currentSquare, Tuple<int, int> moveTuple, Board board)
        {
            var resultList = new List<Square>();
            if (IsMoveInGameBoardRange(currentSquare, moveTuple) && SquareEmptyOrOpposingPieceInSquare(currentSquare, moveTuple, board))
            {
                resultList.Add(OneMove(currentSquare, moveTuple));
            }

            return resultList;
        }
    }
}