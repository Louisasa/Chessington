using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player)
        {
            this.PieceName = "knight";
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var resultList = CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(2, 1), board);
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(-2, 1), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(2, -1), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(-2, -1), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(1, 2), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(1, -2), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(-1, 2), board))
                .ToList();
            resultList = resultList.Concat(CheckAndGetAvailableMove(currentSquare, new Tuple<int, int>(-1, -2), board))
                .ToList();

            return resultList;
        }

        private List<Square> CheckAndGetAvailableMove(Square currentSquare, Tuple<int, int> moveTuple, Board board)
        {
            var resultList = new List<Square>();
            if (IsMoveInGameBoardRange(currentSquare, moveTuple) && (SquareEmpty(currentSquare, moveTuple, board) || OpposingPieceInSquare(currentSquare, moveTuple, board)))
            {
                resultList.Add(OneMove(currentSquare, moveTuple));
            }

            return resultList;
        }
    }
}