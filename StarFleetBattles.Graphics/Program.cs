using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using System;

namespace StarFleetBattles.Graphics
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game(new GameWindowSettings { RenderFrequency = 60.0, UpdateFrequency = 60.0 }, new NativeWindowSettings { Size = new Vector2i(800, 600) }))
            {
                game.Run();
            }
        }
    }
}
