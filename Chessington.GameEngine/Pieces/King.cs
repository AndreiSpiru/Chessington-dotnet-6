using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPosition = board.FindPiece(this);
            List<Square> possibleMoves = new List<Square>();
            int[] dx = {1,1,1,0,0,-1,-1,-1};
            int[] dy = {1,-1,0,1,-1,1,-1,0};
            for(int i = 0 ; i < 8 ; i++){
                int newRow = currentPosition.Row + dx[i];
                int newCol = currentPosition.Row + dy[i];
                if (0 <= newRow && newRow <= 7 && 0 <= newCol && newCol <=7){
                    possibleMoves.Add(Square.At(newRow, newCol));
                }
            }
            return possibleMoves;
        }
    }
}