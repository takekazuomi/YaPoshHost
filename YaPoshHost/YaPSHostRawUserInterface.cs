using System;
using System.Management.Automation.Host;

namespace YaPoshHost
{
    class YaPSHostRawUserInterface : PSHostRawUserInterface
    {
        public override KeyInfo ReadKey(ReadKeyOptions options)
        {
            throw new NotImplementedException();
        }

        public override void FlushInputBuffer()
        {
            // Do nothing.
        }

        public override void SetBufferContents(Coordinates origin, BufferCell[,] contents)
        {
            throw new NotImplementedException();
        }

        public override void SetBufferContents(Rectangle rectangle, BufferCell fill)
        {
            throw new NotImplementedException();
        }

        public override BufferCell[,] GetBufferContents(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public override void ScrollBufferContents(Rectangle source, Coordinates destination, Rectangle clip, BufferCell fill)
        {
            throw new NotImplementedException();
        }

        public override ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
        public override ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
        public override Coordinates CursorPosition { get; set; } = new Coordinates(0,0);
        public override Coordinates WindowPosition { get; set; } = new Coordinates(0,0);
        public override int CursorSize { get; set; } = 25;
        public override Size BufferSize { get; set; } = new Size(80,25);
        public override Size WindowSize { get; set; } = new Size(80, 25);
        public override Size MaxWindowSize { get; } = new Size(80, 25);
        public override Size MaxPhysicalWindowSize { get; } = new Size(80, 25);
        public override bool KeyAvailable { get; } = false;
        public override string WindowTitle { get; set; } = "YaPoshHost";
    }
}
