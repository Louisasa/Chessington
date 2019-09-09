using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
        }

        protected StepIncrease OneStepDirections()
        {
            if (this.Player == Player.Black)
            {
                return new StepIncrease(1, 0);
            }
            else
            {
                return new StepIncrease(-1, 0);
            }
        }

        protected StepIncrease TwoStepDirections()
        {
            if (this.Player == Player.Black)
            {
                return new StepIncrease(2, 0);
            }
            else
            {
                return new StepIncrease(-2, 0);
            }
        }

        protected List<StepIncrease> OpposingPieceDirections()
        {
            if (this.Player == Player.Black)
            {
                return new List<StepIncrease>
                {
                    new StepIncrease(1, 1),
                    new StepIncrease(1, -1)
                };
            }
            else
            {
                return new List<StepIncrease>
                {
                    new StepIncrease(-1, 1),
                    new StepIncrease(-1, -1)
                };
            }
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> resultList;
            var currentSquare = board.FindPiece(this);
            switch(Player)
            {
                case Player.White:
                    resultList = FindAllMoves(currentSquare, -1, board);

                    break;
                case Player.Black:
                    resultList = FindAllMoves(currentSquare, 1, board);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return resultList;
        }

        private List<Square> FindAllMoves(Square currentSquare, int positiveOrNegativeMoves, Board board)
        {
            var resultList = new List<Square>();
            var moveOne = OneStepDirections();

            if (IsMoveInGameBoardRange(currentSquare + moveOne) &&
                SquareEmpty(currentSquare + moveOne, board))
            {
                resultList.Add(currentSquare + moveOne);

                if (!this.MovedBefore)
                {
                    var moveTwo = TwoStepDirections();
                    if(IsMoveInGameBoardRange(currentSquare + moveTwo) &&
                      SquareEmpty(currentSquare + moveTwo, board))
                    {
                        resultList.Add(currentSquare + moveTwo);
                    }
                }
            }

            var toTakeMoves = OpposingPieceDirections();
            foreach (var direction in toTakeMoves)
            {
                if (IsMoveInGameBoardRange(currentSquare + direction) &&
                    OpposingPieceInSquare(currentSquare + direction, board))
                {
                    resultList.Add(currentSquare + direction);
                }
            }

            return resultList;
        }
    }
}