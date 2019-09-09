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
        }

        protected List<StepIncrease> Directions { get; } = new List<StepIncrease>
        {
            new StepIncrease(1, 1),
            new StepIncrease(-1, 1),
            new StepIncrease(1, -1),
            new StepIncrease(-1, -1),
            new StepIncrease(1, 0),
            new StepIncrease(-1, 0),
            new StepIncrease(0, 1),
            new StepIncrease(0, -1)
        };

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            return Directions.SelectMany(direction => CheckAndGetAvailableMove(currentSquare, direction, board));
        }

        private IEnumerable<Square> CheckAndGetAvailableMove(Square currentSquare, StepIncrease stepIncrease, Board board)
        {
            var resultList = new List<Square>();
            if (IsMoveInGameBoardRange(currentSquare + stepIncrease) && (SquareEmpty(currentSquare + stepIncrease, board) || OpposingPieceInSquare(currentSquare + stepIncrease, board)))
            {
                resultList.Add(currentSquare + stepIncrease);
            }

            return resultList;
        }
    }
}