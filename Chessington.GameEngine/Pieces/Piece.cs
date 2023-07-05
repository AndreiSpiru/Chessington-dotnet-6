using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected bool hasMoved = false;
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            hasMoved = true;
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        protected void GetAvailableLeftLateralMoves(List<Square> possibleMoves, Square currentPosition, int distance,
            Board board)
        {
            for (var i = 1; i <= distance; i++){
                int newCol = currentPosition.Col - i;
                if (0 > newCol || newCol > 7) break;
                if (board.GetPiece(Square.At(currentPosition.Row, newCol)) != null) break;
                possibleMoves.Add(Square.At(currentPosition.Row, newCol));
            }        
        }

        protected void GetAvailableRightLateralMoves(List<Square> possibleMoves, Square currentPosition, int distance, Board board){
            for (var i = 1; i <= distance; i++){
                int newCol = currentPosition.Col + i;
                if (0 > newCol || newCol > 7) break;
                if (board.GetPiece(Square.At(currentPosition.Row, newCol)) != null) break;
                possibleMoves.Add(Square.At(currentPosition.Row, newCol));
            }
        }

        protected void GetAvailableUpVerticalMoves(List<Square> possibleMoves, Square currentPosition, int distance, Board board){
            for (var i = 1; i <= distance; i++){
                int newRow = currentPosition.Row - i;
                if (0 > newRow || newRow > 7) break;
                if (board.GetPiece(Square.At(newRow, currentPosition.Col)) != null) break;
                possibleMoves.Add(Square.At(newRow, currentPosition.Col));
            }
        }
        
        protected void GetAvailableDownVerticalMoves(List<Square> possibleMoves, Square currentPosition, int distance, Board board){
            for (var i = 1; i <= distance; i++)
            {
                int newRow = currentPosition.Row + i;
                if (0 > newRow || newRow > 7) break;
                if (board.GetPiece(Square.At(newRow, currentPosition.Col)) != null) break;
                possibleMoves.Add(Square.At(newRow, currentPosition.Col));
            }
        }


        protected void GetAvailableDiagonalMoves(List<Square> possibleMoves, Square currentPosition){
            int[] dx = {1,1,-1,-1};
            int[] dy = {1,-1,1,-1};
            for (var i = 1; i < 8; i++){
                for (int j = 0; j < 4; j++){
                    int newRow = currentPosition.Row + i*dx[j];
                    int newCol = currentPosition.Row + i*dy[j];
                    if (0 <= newRow && newRow <= 7 && 0 <= newCol && newCol <=7){
                        possibleMoves.Add(Square.At(newRow, newCol));
                    }
                }
            }
        }
    }

}