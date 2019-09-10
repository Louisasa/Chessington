using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessington.GameEngine.Pieces
{
    abstract class MoveType
    {
        public List<Square> MultipleMovesInOneDirection(Square currentSquare, StepIncrease stepIncrease, Board board)
        {
            var resultList = new List<Square>();
            Square newSquare = currentSquare + stepIncrease;

            while (board.IsMoveInGameBoardRange(newSquare) &&
                   (board.SquareEmpty(newSquare) /*||
                    OpposingPieceInSquare(newSquare, board)*/))
            {
                resultList.Add(newSquare);
                /*if (OpposingPieceInSquare(newSquare, board))
                {
                    break;
                }*/

                newSquare += stepIncrease;
            }

            return resultList;
        }

        /*public bool OpposingPieceInSquare(Square newSquare, Board board)
        {
            var piece = board.GetPiece(newSquare);
            if (piece != null)
            {
                return piece.Player != Player;

            }
            else
            {
                return false;
            }
        }*/
    }
}
