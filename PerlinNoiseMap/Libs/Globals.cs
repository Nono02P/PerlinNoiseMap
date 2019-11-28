using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Libs
{
    #region Delegate
    public delegate void onBoolChange(object sender, bool previous, bool actual);
    public delegate void onByteChange(object sender, byte previous, byte actual);
    public delegate void onSbyteChange(object sender, sbyte previous, sbyte actual);
    public delegate void onUshortChange(object sender, ushort previous, ushort actual);
    public delegate void onShortChange(object sender, short previous, short actual);
    public delegate void onUintChange(object sender, uint previous, uint actual);
    public delegate void onIntChange(object sender, int previous, int actual);
    public delegate void onUlongChange(object sender, ulong previous, ulong actual);
    public delegate void onLongChange(object sender, long previous, long actual);
    public delegate void onFloatChange(object sender, float previous, float actual);
    public delegate void onDoubleChange(object sender, double previous, double actual);
    public delegate void onDecimalChange(object sender, decimal previous, decimal actual);
    public delegate void onCharChange(object sender, char previous, char actual);
    public delegate void onStringChange(object sender, string previous, string actual);
    public delegate void onVector2Change(object sender, Vector2 previous, Vector2 actual);
    public delegate void onVector3Change(object sender, Vector3 previous, Vector3 actual);
    public delegate void onVector4Change(object sender, Vector4 previous, Vector4 actual);
    public delegate void onRectangleChange(object sender, Rectangle previous, Rectangle actual);
    public delegate void onTexture2DChange(object sender, Texture2D previous, Texture2D actual);
    public delegate void onSpriteEffectsChange(object sender, SpriteEffects previous, SpriteEffects actual);
    #endregion

    #region Enumérations
    public enum eDirection : byte { Top, Right, Bottom, Left }
    public enum VAlign : byte { None, Top, Middle, Bottom }
    public enum HAlign : byte { None, Left, Center, Right }
    public enum SceneType : byte { MainScene, }
    #endregion
}
