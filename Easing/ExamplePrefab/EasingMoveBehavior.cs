using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EasingMoveBehavior : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Move());
    }

    
    private IEnumerator Move() {

        float startTime = Time.time;
        float duration = 10f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + (Vector3.right * 3);

        while(true) {
            transform.position = Vector3.Lerp(
                startPosition, 
                endPosition,
                Easing.SingleAxisBezier.CubicBezier(Easing.Preset.Bounce, Time.time - startTime, duration)
            );


            // 아래 코드는 CubicBazier의 원형을 적용한 예제입니다.

            // transform.position = Vector3.Lerp(
            //     startPosition, 
            //     endPosition,
            //     Easing.SingleAxisBezier.CubicBazier(0f, 1f, 1f, 0f, 1f, 1.33333f, (Time.time - startTime)/duration)
            // );

            if(Time.time - startTime > duration) {
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
