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

        public bool isInCheck = false;
        private bool kingThere;

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
            return Directions.SelectMany(direction => CheckAndGetAvailableMove(currentSquare, direction, board, true));
        }

        private IEnumerable<Square> CheckAndGetAvailableMove(Square currentSquare, StepIncrease stepIncrease, Board board, bool fromOriginalPosition)
        {
            var resultList = new List<Square>();
            if (CheckLegalMove(board, currentSquare, stepIncrease))
            {
                var newSquare = currentSquare + stepIncrease;
                resultList.Add(currentSquare + stepIncrease);

                if (!fromOriginalPosition)
                {
                    if (OpposingPieceInSquare(newSquare, board) && IsOpposingPieceKing(newSquare, board))
                    {
                        kingThere = true;
                        return resultList;
                    }
                }
                else
                {
                    MovingIntoCheck(newSquare, board);
                    if (kingThere)
                    {
                        resultList.Remove(newSquare);
                    }
                }

            }

            return resultList;
        }

        private bool CheckLegalMove(Board board, Square currentSquare, StepIncrease stepIncrease)
        {
            return board.IsMoveInGameBoardRange(currentSquare + stepIncrease) &&
                (board.SquareEmpty(currentSquare + stepIncrease) ||
                 OpposingPieceInSquare(currentSquare + stepIncrease, board));
        }

        private void MovingIntoCheck(Square potentialSquare, Board board)
        {
            //because only checking if a king can check you only need to check surrounding pieces
            // this is concating lists together
            kingThere = false;
            Directions.ForEach(direction => CheckAndGetAvailableMove(potentialSquare, direction, board, false));
            /*Console.WriteLine("initial");
            Console.WriteLine(potentialSquare);
            Console.WriteLine("Newbies");*/
        }
    }
}