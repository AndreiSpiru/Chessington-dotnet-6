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

        protected void GetAvailableLateralAndVerticalMoves(List<Square> possibleMoves, Square currentPosition){
            for (var i = 0; i < 8; i++){
                if (i != currentPosition.Col){
                    possibleMoves.Add(Square.At(currentPosition.Row, i));
                }
            }

            for (var i = 0; i < 8; i++){
                if (i != currentPosition.Row){
                    possibleMoves.Add(Square.At(i, currentPosition.Col));
                }
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