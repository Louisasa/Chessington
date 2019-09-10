using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessington.GameEngine.Pieces
{
    public abstract class MoveType : Piece
    {
        protected MoveType(Player player) : base(player) { }
        public List<Square> MultipleMovesInOneDirection(Square currentSquare, StepIncrease stepIncrease, Board board)
        {
            var resultList = new List<Square>();
            Square newSquare = currentSquare + stepIncrease;

            while (board.IsMoveInGameBoardRange(newSquare) &&
                   (board.SquareEmpty(newSquare) ||
                    OpposingPieceInSquare(newSquare, board)))
            {
                resultList.Add(newSquare);
                if (OpposingPieceInSquare(newSquare, board))
                {
                    if (IsOpposingPieceKing(newSquare, board))
                    {
                        Console.WriteLine("CHECK");
                    }

                    break;
                }

                newSquare += stepIncrease;
            }

            return resultList;
        }
    }
}
