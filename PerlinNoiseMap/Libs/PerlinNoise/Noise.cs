using Microsoft.Xna.Framework;
using System;

namespace Libs.PerlinNoise
{
    public static class Noise
    {
        public static float[] Generate2DMap(Vector2 pMapSize, Vector2 pOffset, float pScale, int pOctaves, float pPersistance, float pLacunarity, int? pSeed = null)
        {
            Random rnd;
            if (pSeed.HasValue)
                rnd = new Random(pSeed.Value);
            else
                rnd = new Random();

            Vector2[] octavesOffset = new Vector2[pOctaves];
            for (int o = 0; o < pOctaves; o++)
            {
                octavesOffset[o] = new Vector2(rnd.Next(100000), rnd.Next(100000)) + pOffset;
            }

            if (pScale <= 0)
            {
                pScale = 0.00001f;
            }

            float[] result = new float[(uint)(pMapSize.X * pMapSize.Y)];
            float minNoise = float.MaxValue;
            float maxNoise = float.MinValue;

            Vector2 half = pMapSize / 2;

            for (int x = 0; x < pMapSize.X; x++)
            {
                for (int y = 0; y < pMapSize.Y; y++)
                {
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeight = 1;

                    for (int o = 0; o < pOctaves; o++)
                    {
                        float sampleX = (x - half.X) / pScale * frequency + octavesOffset[o].X;
                        float sampleY = (y - half.Y) / pScale * frequency + octavesOffset[o].Y;

                        float perlinValue = Simplex.Generate(sampleX, sampleY);

                        noiseHeight += perlinValue * amplitude;
                        amplitude *= pPersistance;
                        frequency *= pLacunarity;
                    }

                    if (minNoise > noiseHeight)
                        minNoise = noiseHeight;
                    if (maxNoise < noiseHeight)
                        maxNoise = noiseHeight;

                    result[x + y * (uint)(pMapSize.X)] = noiseHeight;
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (float)MathHelperExtension.MapValue(minNoise, maxNoise, 0, 1, result[i]);
            }

            return result;
        }
    }
}
