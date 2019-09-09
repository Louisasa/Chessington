using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player)
        {
            this.PieceName = "queen";
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(1, 1), board);
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(-1, 1), board)).ToList();
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(1, -1), board)).ToList();
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(-1, -1), board)).ToList();

            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(1, 0), board)).ToList();
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(-1, 0), board)).ToList();
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(0, -1), board)).ToList();
            availableMoves = availableMoves.Concat(MultipleMovesInOneDirection(currentSquare, new Tuple<int, int>(0, 1), board)).ToList();

            return availableMoves;
        }
    }
}