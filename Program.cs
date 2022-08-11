using System;
using System.Collections.Generic;

namespace Badger
{
    struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class TextObject
    {
        public string Text { get; private set; }
        public Position Position { get; private set; }
        public ConsoleColor Color { get; private set; }

        public TextObject(string text = "", int positionX = 0, int positionY = 0)
        {
            Text = text;
            Position = new Position(positionX, positionY);
            Color = ConsoleColor.White;
        }

        public void SetText(string text)
        {
            Text = text;
        }

        public void SetPosition(Position position)
        {
            Position = position;
        }

        public void SetColor(ConsoleColor color)
        {
            Color = color;
        }
    }

    class TextRenderer
    {
        private List<TextObject> _textObjects;
        public ConsoleColor BackgroundColor { get; private set; }

        public TextRenderer()
        {
            _textObjects = new List<TextObject>();
            BackgroundColor = ConsoleColor.Black;
        }

        public void UpdateConsole()
        {
            ConsoleColor previousForegroundConsoleColor = Console.ForegroundColor;
            ConsoleColor previousBackgroundConsoleColor = Console.BackgroundColor;
            int previousCursorX = Console.CursorLeft;
            int previousCursorY = Console.CursorTop;

            Console.Clear();
            Console.BackgroundColor = BackgroundColor;

            foreach (TextObject textObject in _textObjects)
            {
                Console.SetCursorPosition(textObject.Position.X, textObject.Position.Y);
                Console.ForegroundColor = textObject.Color;
                Console.Write(textObject.Text);
            }

            Console.ForegroundColor = previousForegroundConsoleColor;
            Console.BackgroundColor = previousBackgroundConsoleColor;
            Console.SetCursorPosition(previousCursorX, previousCursorY);
        }

        public void AddTextObject(TextObject textObject)
        {
            _textObjects.Add(textObject);
        }
    }
}

