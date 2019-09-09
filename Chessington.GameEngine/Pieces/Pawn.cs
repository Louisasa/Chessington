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
            var resultList = new List<Square>();
            var currentSquare = board.FindPiece(this);
            int moveBy;
            switch(Player)
            {
                case Player.White:
                    if (currentSquare.Row.Equals(7))
                    {
                        resultList.Add(new Square(currentSquare.Row - 2, currentSquare.Col));
                    }
                    resultList.Add(new Square(currentSquare.Row - 1, currentSquare.Col));
                    break;
                case Player.Black:
                    if (currentSquare.Row.Equals(1))
                    {
                        resultList.Add(new Square(currentSquare.Row + 2, currentSquare.Col));
                    }
                    resultList.Add(new Square(currentSquare.Row + 1, currentSquare.Col));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return resultList;
        }
    }
}