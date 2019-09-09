using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> resultList;
            var currentSquare = board.FindPiece(this);
            switch(Player)
            {
                case Player.White:
                    resultList = FindAllMoves(currentSquare, -1);

                    break;
                case Player.Black:
                    resultList = FindAllMoves(currentSquare, 1);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return resultList;
        }

        private List<Square> FindAllMoves(Square currentSquare, int positiveOrNegativeMoves)
        {
            var resultList = new List<Square>();
            if (!this.MovedBefore)
            {
                if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(2 * positiveOrNegativeMoves, 0)))
                {
                    resultList.Add(OneMove(currentSquare, new Tuple<int, int>(2 * positiveOrNegativeMoves, 0)));
                }
            }

            if (IsMoveInGameBoardRange(currentSquare, new Tuple<int, int>(1 * positiveOrNegativeMoves, 0)))
            {
                resultList.Add(OneMove(currentSquare, new Tuple<int, int>(1 * positiveOrNegativeMoves, 0)));
            }

            return resultList;
        }
    }
}