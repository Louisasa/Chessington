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
            switch(Player)
            {
                case Player.White:
                    if (!this.MovedBefore)
                    {
                        resultList.Add(new Square(currentSquare.Row - 2, currentSquare.Col));
                    }
                    resultList.Add(new Square(currentSquare.Row - 1, currentSquare.Col));
                    break;
                case Player.Black:
                    if (!this.MovedBefore)
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