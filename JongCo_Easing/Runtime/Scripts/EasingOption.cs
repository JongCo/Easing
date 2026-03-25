namespace Easing {
    public struct EasingOption
    {
        public float p1;
        public float p2;
        public float p3;
        public float p4;
        public float exp;
        public float multiplier;

        public EasingOption(float p1, float p2, float p3, float p4, float exp, float multiplier = 1){
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.exp = exp;
            this.multiplier = multiplier;
        }
    }
}
