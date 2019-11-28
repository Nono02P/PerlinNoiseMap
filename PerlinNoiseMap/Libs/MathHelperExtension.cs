using Microsoft.Xna.Framework;

namespace Libs
{
    public static class MathHelperExtension
    {
        public static double MapValue(double a0, double a1, double b0, double b1, double a, bool pWithClamp = true)
        {
            double val = a;
            if (pWithClamp)
                val = MathHelper.Clamp((float)a, (float)a0, (float)a1);

            return b0 + (b1 - b0) * ((val - a0) / (a1 - a0));
        }
    }
}
