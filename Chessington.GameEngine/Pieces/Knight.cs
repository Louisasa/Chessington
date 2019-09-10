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
        }

        protected List<StepIncrease> Directions { get; } = new List<StepIncrease>
        {
            new StepIncrease(1, 2),
            new StepIncrease(-1, 2),
            new StepIncrease(1, -2),
            new StepIncrease(-1, -2),
            new StepIncrease(2, 1),
            new StepIncrease(-2, 1),
            new StepIncrease(2, -1),
            new StepIncrease(-2, -1)
        };

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            return Directions.SelectMany(direction => CheckAndGetAvailableMove(currentSquare, direction, board));
        }

        private IEnumerable<Square> CheckAndGetAvailableMove(Square currentSquare, StepIncrease stepIncrease, Board board)
        {
            var resultList = new List<Square>();
            if (board.IsMoveInGameBoardRange(currentSquare + stepIncrease) && (board.SquareEmpty(currentSquare + stepIncrease) || OpposingPieceInSquare(currentSquare + stepIncrease, board)))
            {
                resultList.Add(currentSquare + stepIncrease);
            }

            return resultList;
        }
    }
}