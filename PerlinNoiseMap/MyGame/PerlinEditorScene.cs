using Microsoft.Xna.Framework;
using Libs;
using Libs.GUI;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Libs.PerlinNoise;

namespace PerlinNoiseMap.MyGame
{
    public class PerlinEditorScene : Scene
    {
        private Vector2 _mapSize;
        private float[] _map;
        private Texture2D _mapTexture;
        private Dictionary<eSliderType, Group> _sliders;
        private enum eSliderType
        {
            Scale, Persistance, Octaves, Lacunarity, OffsetX, OffsetY,
        }


        public override void Load()
        {
            Viewport screen = GameState.Screen;
            _mapSize = new Vector2(screen.Width - 200, screen.Height);
            _mapTexture = new Texture2D(GameState.GraphicsDevice, (int)_mapSize.X, (int)_mapSize.Y);

            _sliders = new Dictionary<eSliderType, Group>();
            AddSlider(eSliderType.Scale);
            AddSlider(eSliderType.Persistance);
            AddSlider(eSliderType.Octaves);
            AddSlider(eSliderType.Lacunarity);
            AddSlider(eSliderType.OffsetX);
            AddSlider(eSliderType.OffsetY);

            GenerateMap();
            base.Load();
        }

        private Slider AddSlider(eSliderType pSliderType)
        {
            Group g = new Group();
            int width = 150;
            int yOffset = 10;
            int ySpace = 40;
            string name = pSliderType.ToString();

            Slider slider = new Slider(new Vector2(0, 25), Vector2.Zero, new Vector2(width, 5), new Vector2(5, 10));
            g.AddElement(slider);

            slider.OnValueChange += Slider_OnValueChange;

            SpriteFont font = AssetManager.MainFont;
            g.AddElement(new Textbox(Vector2.Zero, font, name));

            g.Position = new Vector2(GameState.Screen.Width - (width + 20), yOffset + ySpace * _sliders.Count);
            _sliders.Add(pSliderType, g);

            return slider;
        }

        private float GetSliderValue(eSliderType pSliderType, float pMin, float pMax)
        {
            return (float)MathHelperExtension.MapValue(0, 100, pMin, pMax, ((Slider)_sliders[pSliderType].Elements[0]).Value);
        }

        private void Slider_OnValueChange(object sender, int previous, int actual)
        {
            GenerateMap();
        }

        private void GenerateMap()
        {
            float scale = GetSliderValue(eSliderType.Scale, 0.1f, 100);
            int octaves = (int)GetSliderValue(eSliderType.Octaves, 1, 10);
            float persistance = GetSliderValue(eSliderType.Persistance, 0, 1);
            float lacunarity = GetSliderValue(eSliderType.Lacunarity, 0, 4);
            float offsetX = GetSliderValue(eSliderType.OffsetX, 0, 10);
            float offsetY = GetSliderValue(eSliderType.OffsetY, 0, 10);
            _map = Noise.Generate2DMap(_mapSize, new Vector2(offsetX, offsetY), scale, octaves, persistance, lacunarity, 1);
            Color[] colors = new Color[_map.Length];
            for (int i = 0; i < _map.Length; i++)
            {
                colors[i] = Color.White * _map[i];
            }
            _mapTexture.SetData(colors);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_mapTexture, Vector2.Zero, null, Color.White);
            base.Draw(spriteBatch, gameTime);
        }
    }
}