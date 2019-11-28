using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PerlinNoiseMap
{
    public class AssetManager
    {
        #region Font
        public static SpriteFont MainFont { get; private set; }
        #endregion
        
        #region Load
        public static void Load(ContentManager pContent)
        {
            #region Font
            MainFont = pContent.Load<SpriteFont>("_Font/MainFont");
            #endregion
        }
        #endregion
    }
}