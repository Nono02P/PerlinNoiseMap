using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerlinNoiseMap.MyGame;

namespace Libs
{
    public class GameState
    {
        private static GameState _instance;

        public Color BackgroundColor { get; set; }
        public static Viewport Screen { get; private set; }
        public static GraphicsDeviceManager Graphics { get; private set; }
        public static BasicEffect Effect { get; private set; }
        public static Camera Camera { get; private set; }
        public static Scene CurrentScene { get; private set; }
        public static readonly bool UsingMouse = true;
        public static readonly bool UsingKeyboard = true;
        public static readonly bool UsingGamePad = false;
        public static readonly int GamePadMaxPlayer = 0;

        private GameState(GraphicsDeviceManager pGraphics)
        {
            Graphics = pGraphics;
            Screen = pGraphics.GraphicsDevice.Viewport;
            Camera = new Camera(Screen, Vector3.Zero);
            Camera.LimitOnTop = false;
            Camera.MouseFollowOnTop = false;
            Effect = new BasicEffect(pGraphics.GraphicsDevice);
        }

        public static GameState GetInstance(GraphicsDeviceManager pGraphics)
        {
            if (_instance == null)
                _instance = new GameState(pGraphics);
            return _instance;
        }

        #region Gestion des scènes
        public void ChangeScene(SceneType pSceneType)
        {
            if (CurrentScene != null)
            {
                CurrentScene.UnLoad();
                CurrentScene = null;
            }
            switch (pSceneType)
            {
                case SceneType.PerlinEditorScene:
                    CurrentScene = new PerlinEditorScene();
                    break;
                default:
                    break;
            }
            Camera.Enable = false;
            Camera.Position = Vector3.Zero;
            CurrentScene.Load();
        }
        #endregion

        public void Update(GameTime gameTime)
        {
            Input.Update();
            Camera.Update();
            if (CurrentScene != null)
                CurrentScene.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Camera.Transformation);
            if (CurrentScene != null)
                CurrentScene.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            var cameraPosition = new Vector3(15, 10, 10);
            var cameraLookAtVector = Vector3.Zero;
            var cameraUpVector = Vector3.UnitZ;

            Effect.View = Matrix.CreateLookAt(cameraPosition, cameraLookAtVector, cameraUpVector);

            float aspectRatio = Graphics.PreferredBackBufferWidth / (float)Graphics.PreferredBackBufferHeight;
            float fieldOfView = MathHelper.PiOver4;
            float nearClipPlane = 1;
            float farClipPlane = 200;

            Effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                fieldOfView, aspectRatio, nearClipPlane, farClipPlane);

            if (CurrentScene != null)
                CurrentScene.Draw(Graphics.GraphicsDevice, Effect, gameTime);
        }
    }
}
