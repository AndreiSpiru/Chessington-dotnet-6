using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> possibleMoves = new List<Square>();
            int[] dx = {1,1,-1,-1};
            int[] dy = {1,-1,1,-1};
            for(int i = 0 ; i < 4 ; i ++){
                int newRow = currentPosition.Row + 1 * dx[i];
                int newCol = currentPosition.Row + 2 * dy[i];
                if (0 <= newRow && newRow <= 7 && 0 <= newCol && newCol <=7){
                    possibleMoves.Add(Square.At(newRow, newCol));
                }

                newRow = currentPosition.Row + 2 * dx[i];
                newCol = currentPosition.Row + 1 * dy[i];
                if (0 <= newRow && newRow <= 7 && 0 <= newCol && newCol <=7){
                    possibleMoves.Add(Square.At(newRow, newCol));
                }
            }
            return possibleMoves;
        }
    }
}