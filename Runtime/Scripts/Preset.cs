

namespace Easing{
    public class Preset
    {
        public static readonly EasingOption SlowInSlowOut = new(0f, 0.71f, 1f, 1f, 2.6f);
        public static readonly EasingOption SlowInSlowOut2 = new(0f, 1f, 1f, 1f, 5.2f);

        public static readonly EasingOption FastInSlowOut = new(0f, 1f, 1f, 1f, 1f);
        public static readonly EasingOption FastInSlowOut2 = new(0f, 1f, 1f, 1f, 0.6f);

        public static readonly EasingOption SlowInFastOut = new(0f, 0f, 0f, 1f, 1f);
        public static readonly EasingOption SlowInFastOut2 = new(0f, 0f, 0f, 1f, 1.6f);

        public static readonly EasingOption FastInFastOut = new(0f, 0.58f, 0.41f, 1f, 1f);
        public static readonly EasingOption FastInFastOut2 = new(0f, 1f, 0f, 1f, 1f);

        public static readonly EasingOption Linear = new(0f, 0f, 0.33f, 1f, 0.5f);

        public static readonly EasingOption Bounce = new(0f, 1f, 1f, 0f, 1f, 4f/3f);
    }
}
