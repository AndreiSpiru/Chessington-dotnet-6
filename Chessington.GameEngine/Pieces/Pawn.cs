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
            Square currentPosition = board.FindPiece(this);
            int distance = 1;
            int direction = Player == Player.White ? -1 : 1;
            List<Square> possibleMoves = new List<Square>();
            if(!hasMoved)
            {
                distance *= 2;
            }

            if (direction == -1)
            {
                GetAvailableUpVerticalMoves(possibleMoves, currentPosition, distance, board);
            }
            else
            {
                GetAvailableDownVerticalMoves(possibleMoves, currentPosition, distance, board);
            }
            return possibleMoves;
        }
    }
}