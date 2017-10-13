using System;

namespace VersionPacker
{
    public static class MathUtil
    {
        public static int Clamp(int min, int max, int value)
        {
            if (value < min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }
    }
}
