using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player)
        {
        }

        protected List<StepIncrease> Directions { get; } = new List<StepIncrease>
        {
            new StepIncrease(1, 1),
            new StepIncrease(-1, 1),
            new StepIncrease(1, -1),
            new StepIncrease(-1, -1)
        };

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            return Directions.SelectMany(direction => MultipleMovesInOneDirection(currentSquare, direction, board));
        }
    }
}