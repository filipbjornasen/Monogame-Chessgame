using Chess.Animations;
using Chess.IO;
using Chess.Managers;
using Chess.Models.Pieces;
using Chess.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    enum ChessPiece
    {
        Pawn,
        King,
        Bishop,
        Knight,
        Rook,
        Queen
    }

    abstract class Piece : OptionsButton
    {
        public int NumberOfMoves { get; private set; } = 0;
        protected List<Button> legals;
        protected Texture2D legalsTexture;
        public int Row { get; set; }
        public int Col { get; set; }
        public ChessPiece ChessPiece { get; protected set; }
        protected Board board;
        ChessColor color;
        internal ChessColor ChessColor { get => color; private set => color = value; }

        public Piece(Sprite2D sprite, int row, int col, ChessColor color, Board board)
            : base(sprite)
        {
            legals = new List<Button>();
            this.Row = row;
            this.Col = col;
            legalsTexture = ContentService.Instance.Textures["Circle"];
            this.ChessColor = color;
            this.board = board;
            Marked += (s, e) => { Center(new Rectangle(Col * Constants.TILESIZE, Row * Constants.TILESIZE, Constants.TILESIZE, Constants.TILESIZE)); };
            UnMarked += (s, e) => { Center(new Rectangle(Col * Constants.TILESIZE, Row * Constants.TILESIZE, Constants.TILESIZE, Constants.TILESIZE)); };
        }

        public override void Update(Input currentInput, Input previousInput)
        {
            if (MarkedState == OptionButtonState.Marked)
            {
                for (int i = 0; i < legals.Count; i++)
                {
                    legals[i].Update(currentInput, previousInput);
                }
            }
            base.Update(currentInput, previousInput);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.MarkedState == OptionButtonState.Marked)
            {
                DrawLegalMoves(spriteBatch);
            }
            base.Draw(spriteBatch);
        }

        public void Move(int row, int col)
        {
            NumberOfMoves++;
            board.Move(this, row, col);
            Bounds = new Rectangle(col * Constants.TILESIZE, row * Constants.TILESIZE, Constants.PIESESIZE, Constants.PIESESIZE);
            Center(new Rectangle(col * Constants.TILESIZE, row * Constants.TILESIZE, Constants.TILESIZE, Constants.TILESIZE));
        }

        protected void AddLegalMove(int r, int c)
        {
            Button b = new Button(new Sprite2D(legalsTexture, new Rectangle(c * Constants.TILESIZE, r * Constants.TILESIZE, Constants.TILESIZE, Constants.TILESIZE), Color.DarkSlateGray));
            b.Click += (s, e) => { Move(r, c); };
            b.Hover += (s, e) => { b.Color = Color.Black; };
            b.UnHover += (s, e) => { b.Color = Color.DarkSlateGray; };
            legals.Add(b);
        }

        public abstract void CalculateLegalMoves();

        public abstract bool SetsCheck();

        public void DrawLegalMoves(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < legals.Count; i++)
            {
                legals[i].Draw(spriteBatch);
            }
        }
    }
}
