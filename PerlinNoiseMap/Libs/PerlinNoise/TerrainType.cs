using Microsoft.Xna.Framework;

namespace Libs.PerlinNoise
{
    public struct TerrainType
    {
        public string Name;
        public float Height;
        public Color Color;

        public TerrainType(string pName, float pHeight, Color pColor)
        {
            Name = pName;
            Height = pHeight;
            Color = pColor;
        }
    }
}
