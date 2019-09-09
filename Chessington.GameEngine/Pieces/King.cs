using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();
            availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(1, 1)));
            availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(-1, 1)));
            availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(1, -1)));
            availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(-1, -1)));

            availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(1, 0)));
            availableMoves.Add((OneMove(currentSquare, new Tuple<int, int>(-1, 0))));
            availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(0, -1)));
            availableMoves.Add(OneMove(currentSquare, new Tuple<int, int>(0, 1)));

            return availableMoves;
        }
    }
}