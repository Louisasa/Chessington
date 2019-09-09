﻿using System;
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
            var currentSquare = board.FindPiece(this);
            int moveBy;
            switch(Player)
            {
                case Player.White:
                    moveBy = -1;
                    break;
                case Player.Black:
                    moveBy = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var newSquare = new Square(currentSquare.Row + moveBy, currentSquare.Col);
            return new List<Square> { newSquare };
        }
    }
}