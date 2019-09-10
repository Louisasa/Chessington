﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public bool MovedBefore = false;
        public string PieceName;

        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            MovedBefore = true;
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public bool IsOpposingPieceKing(Square newSquare, Board board)
        {
            var piece = board.GetPiece(newSquare);
            return piece.GetType() == typeof(King);
        }

        public bool OpposingPieceInSquare(Square newSquare, Board board)
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
        }
    }
}