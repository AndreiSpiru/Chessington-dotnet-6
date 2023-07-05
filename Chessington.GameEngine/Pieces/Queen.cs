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
            GetAvailableLeftLateralMoves(possibleMoves, currentPosition, 8, board);
            GetAvailableRightLateralMoves(possibleMoves, currentPosition, 8, board);
            GetAvailableUpVerticalMoves(possibleMoves, currentPosition, 8, board);
            GetAvailableDownVerticalMoves(possibleMoves, currentPosition, 8, board);
            GetAvailableDiagonalMoves(possibleMoves, currentPosition, 8 , board);
            return possibleMoves;
        }
    }
}