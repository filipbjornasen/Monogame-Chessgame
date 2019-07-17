using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.Models.Pieces
{
    class Knight : Piece
    {
        public Knight(Sprite2D sprite, int row, int col, ChessColor color, Board board)
            : base(sprite, row, col, color, board)
        {
            ChessPiece = ChessPiece.Knight;
        }
        #region  ChessMethods
        public override void CalculateLegalMoves()
        {
            legals.Clear();
            for (int i = Row-2; i <= Row + 2; i+=4)
            {
                for (int j = Col-1; j <= Col+1; j+=2)
                {
                    if (board.InGrid(i, j))
                    {
                        if (board.IsLegalMove(this, i, j))
                        {
                            AddLegalMove(i, j);
                        }
                    }
                }
            }
            for (int j = Col - 2; j <= Col + 2; j += 4)
            {
                for (int i = Row - 1; i <= Row + 1; i += 2)
                {
                    if (board.InGrid(i, j))
                    {
                        if (board.InGrid(i, j))
                        {
                            if (board.IsLegalMove(this, i, j))
                            {
                                AddLegalMove(i, j);
                            }
                        }
                    }
                }
            }
        }

        public override bool SetsCheck()
        {
            for (int i = Row - 2; i <= Row + 2; i += 4)
            {
                for (int j = Col - 1; j <= Col + 1; j += 2)
                {
                    if (board.InGrid(i, j) && !board.IsEmpty(i, j))
                    {
                        Piece p = board.GetPiece(i, j);
                        if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King)
                        {
                            return true;
                        }
                    }
                }
            }
            for (int j = Col - 2; j <= Col + 2; j += 4)
            {
                for (int i = Row - 1; i <= Row + 1; i += 2)
                {
                    if (board.InGrid(i, j) && !board.IsEmpty(i, j))
                    {
                        Piece p = board.GetPiece(i, j);
                        if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
