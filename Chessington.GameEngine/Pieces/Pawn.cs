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
            int direction = Player == Player.White ? -1 : 1;
            List<Square> possibleMoves = new List<Square>();
            possibleMoves.Add(new Square(currentPosition.Row + direction, currentPosition.Col));
            if(!hasMoved){
                possibleMoves.Add(new Square(currentPosition.Row + 2 * direction, currentPosition.Col));
            }
            return possibleMoves;
        }
    }
}