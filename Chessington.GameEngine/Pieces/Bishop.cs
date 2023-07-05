using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> possibleMoves = new List<Square>();
            GetAvailableDiagonalMoves(possibleMoves, currentPosition);
            return possibleMoves;
        }

    
    }
}