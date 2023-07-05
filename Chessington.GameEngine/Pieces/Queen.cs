using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> possibleMoves = new List<Square>();
            GetAvailableLateralAndVerticalMoves(possibleMoves, currentPosition);
            GetAvailableDiagonalMoves(possibleMoves, currentPosition);
            return possibleMoves;
        }
    }
}