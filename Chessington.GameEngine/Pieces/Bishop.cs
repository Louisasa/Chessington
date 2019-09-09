using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(1, 1));
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(-1, 1))).ToList();
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(1, -1))).ToList();
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(-1, -1))).ToList();

            return availableMoves;
        }
    }
}