using RG35XX.Core.Drawing;
using RG35XX.Core.Extensions;
using RG35XX.Core.Fonts;
using RG35XX.Libraries;

namespace FPS
{
    public class FPSTester
    {
        private readonly ConsoleRenderer _consoleRenderer;

        private readonly GamePadReader _gamePadReader;

        public FPSTester()
        {
            _gamePadReader = new GamePadReader();
            _gamePadReader.Initialize();

            _consoleRenderer = new ConsoleRenderer(ConsoleFont.Px437_IBM_VGA_8x16);
            _consoleRenderer.Initialize(640, 480);
        }

        public void Execute()
        {

            Bitmap[] bitmaps = [
                 new Bitmap(_consoleRenderer.FrameBuffer.Width, _consoleRenderer.FrameBuffer.Height, Color.Red),
                 new Bitmap(_consoleRenderer.FrameBuffer.Width, _consoleRenderer.FrameBuffer.Height, Color.Green),
                 new Bitmap(_consoleRenderer.FrameBuffer.Width, _consoleRenderer.FrameBuffer.Height, Color.Blue),
            ];

            int frameCount = 120;

            DateTime startTime = DateTime.Now;

            for (int i = 0; i < frameCount; i++)
            {
                _consoleRenderer.FrameBuffer.Draw(bitmaps[i % 3], 0, 0);
            }

            TimeSpan duration = DateTime.Now - startTime;

            int fps = (int)(frameCount / duration.TotalSeconds);

            _consoleRenderer.FrameBuffer.Clear();

            _consoleRenderer.WriteLine($"FPS: {fps}");

            _gamePadReader.ClearBuffer();

            _gamePadReader.WaitForInput();

            System.Environment.Exit(0);
        }
    }
}