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
            this.PieceName = "pawn";
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
            var moveOneTuple = new Tuple<int, int>(1 * positiveOrNegativeMoves, 0);
            if (IsMoveInGameBoardRange(currentSquare, moveOneTuple) && SquareEmpty(currentSquare, moveOneTuple, board))
            {
                resultList.Add(OneMove(currentSquare, moveOneTuple));

                if (!this.MovedBefore)
                {
                    var moveTwoTuple = new Tuple<int, int>(2 * positiveOrNegativeMoves, 0);
                    if (IsMoveInGameBoardRange(currentSquare, moveTwoTuple) && SquareEmpty(currentSquare, moveTwoTuple, board))
                    {
                        resultList.Add(OneMove(currentSquare, moveTwoTuple));
                    }
                }
            }

            return resultList;
        }

        /*private bool PieceToTake(Square currentSquare, int positiveOrNegativeMove, int leftOrRight, Board board)
        {
            //todo:check left/right isn't out of bounds
        }*/
    }
}