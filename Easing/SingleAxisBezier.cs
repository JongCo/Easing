using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easing{
    public class SingleAxisBezier {

        public static float LinearBezier(float p1, float p2, float t) {
            if(t < 0) {
                return p1;
            } else if(t > 1) {
                return p2;
            }

            return ( (1-t)*p1 ) + ( t*p2 ); 
        }

        public static float QuadraticBezier(float p1, float p2, float p3, float t) {
            if(t < 0) {
                return p1;
            } else if(t > 1) {
                return p3;
            }

            return ( (1-t) * LinearBezier(p1, p2, t) ) + ( t * LinearBezier(p2, p3, t) );
        }

        public static float CubicBezier(float p2, float p3, float exponential, float t, float multiplier = 1, float duration = 1) {
            return CubicBezier(0f, p2, p3, 1f, exponential, multiplier, t/duration);
        }

        public static float CubicBezier(EasingOption easing, float t, float duration = 1){
            return CubicBezier(easing.p1, easing.p2, easing.p3, easing.p4, easing.exp, easing.multiplier, t/duration);
        }

        public static float CubicBezier(float p1, float p2, float p3, float p4, float exponential, float multiplier, float t) {
            if(t < 0) {
                return p1;
            } else if(t > 1) {
                return p4;
            }

            return Mathf.Pow(
                ((1-t) * QuadraticBezier(p1, p2, p3, t) ) + ( t * QuadraticBezier(p2, p3, p4, t)),
                exponential
            ) * multiplier;
        }
    }

}


