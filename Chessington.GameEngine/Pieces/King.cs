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

            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(1, 1)) && NoPieceInSquare(currentSquare, new Tuple<int, int>(1, 1), board))
            {
                availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(1, 1)));
            }
            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(-1, 1)) && NoPieceInSquare(currentSquare, new Tuple<int, int>(-1, 1), board))
            {
                availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(-1, 1)));
            }
            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(1, -1)) && NoPieceInSquare(currentSquare, new Tuple<int, int>(1, -1), board))
            {
                availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(1, -1)));
            }
            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(-1, -1)) && NoPieceInSquare(currentSquare, new Tuple<int, int>(-1, -1), board))
            {
                availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(-1, -1)));
            }

            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(1, 0)) && NoPieceInSquare(currentSquare, new Tuple<int, int>(1, 0), board))
            {
                availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(1, 0)));
            }
            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(0, 1)) && NoPieceInSquare(currentSquare, new Tuple<int, int>(0, 1), board))
            {
                availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(0, 1)));
            }
            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(0, -1)) && NoPieceInSquare(currentSquare, new Tuple<int, int>(0, -1), board))
            {
                availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(0, -1)));
            }
            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(-1, 0)) && NoPieceInSquare(currentSquare, new Tuple<int, int>(-1, 0), board))
            {
                availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(-1, 0)));
            }

            return availableMoves;
        }
    }
}