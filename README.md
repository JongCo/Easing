# JongCo Easing
&ensp;Jongco가 만든 Easing 툴입니다. 해당 소스코드는 UnityEngine 네임스페이스를 참조합니다. 그러므로 Unity상의 스크립트로 사용하기를 추천합니다. 아래 내용은 해당 기능을 어떻게 활용하는지에 대해 안내합니다.

## Single Axis Bezier 란?
&ensp;하나의 축으로만 구현한 베지어 곡선입니다. 

&ensp;2차원 베지어 곡선 그래프를 **함수**로 적용하는데 어려움이 있어서 그냥 축 하나만 가지고 함수를 만들었습니다. 그래서 일반적인 베지어 그래프를 사용하는 것과는 모양이 많이 다릅니다.


## Easing.SingleAxisBezier.CubicBezier( )
&ensp;실질적으로 애니메이션이나 이동, 회전에서 부드러운 움직임을 적용하기 위해서는 `Easing.SingleAxisBezier` 클래스가 제공하는 함수 중 `CubicBezier`를 사용하면 됩니다. `CubicBezier` 함수는 여러 오버라이딩이 존재합니다. 가장 기본적으로 `Easing.Preset`에 정의된 여러 프리셋을 활용할 수 있습니다. 

### 예시
```csharp
this.transform.position = Vector3.Lerp(
	startPosition,
	endPosition,
	Easing.SingleAxisBezier.CubicBezier(Easing.Preset.FastInSlowOut, t, 2f)
);
```
아래는 각 `CubicBezier`함수 오버라이딩에 대한 설명입니다.

---

#### Preset Type
```csharp
Easing.SingleAxisBezier.CubicBezier(easingOption, t, duration=1)
```
parameters

 - `EasingOption easingOption` : 4개 점의 위치와 제곱수, 배수가 정의된 객체
 - `float t` : 진행도
 - `float duration` : 진행도의 최대 값 (기본 값 : 1)

return
 - `float` : 진행도 t에 대한 값



&ensp;이 함수는 `EasingOption` 타입의 객체를 받아 `duration` 범위에서 `t` 위치의 값을 반환하는 함수입니다. 기본적으로 제공되는 `EasingOption` 객체들은 `Easing.Preset` 클래스에 정의되어 있습니다.

---
#### Simple Type
```csharp
Easing.SingleAxisBezier.CubicBezier(p2, p3, exponential, t, multiplier=1, duration=1)
```
parameters
 - `float p2`
 - `float p3`
 - `float exponential`
 - `float t`
 - `float multiplier` : (기본 값 : 1)
 - `float duration` : (기본 값 : 1)

return
 - `float` : 진행도 t에 대한 값

&ensp;이 함수는 Full Type을 간단하게 만든 함수입니다. 베지어 곡선을 만들 기준점 두개를 받아 `duration` 범위에서 `t` 위치의 값을 반환하는 함수입니다. 이 오버라이딩 함수에서는 베지어 함수를 만드는데 필요한 첫번째 기준점 p1, 네번째 기준점 p4의 값을 각각 0, 1 로 설정합니다. 0으로 시작하고 1로 끝나는 그래프를 만들 때 사용하기 적합합니다. 
&ensp;`exponential`은 함수값의 지수를 결정합니다. `multiplier`는 함수값의 배수를 결정합니다. 식으로 표현하면 다음과 같습니다. ($exp$ = `exponential`, $mul$ = `multiplier`)
$$mul\cdot B(t)^{exp}$$

---

#### Full Type
```csharp
Easing.SingleAxisBezier.CubicBezier(p1, p2, p3, p4, exponential, multiplier, t)
```

parameters
 - `float p1`
 - `float p2`
 - `float p3`
 - `float p4`
 - `float exponential`
 - `float multiplier`
 - `float t`

return
 - `float` : 진행도 t에 대한 값

&ensp;이 함수는 베지어 곡선을 만들 기준점 4개(`p1`, `p2`, `p3`, `p4`)를 받아 `duration` 범위에서 `t` 위치의 값을 반환하는 함수입니다. 해당 오버라이딩은 duration 인자를 제공하지 않습니다. 자신이 직접 베지어 그래프를 정의하여 사용하려는 경우 해당 함수를 사용하는 것 보다, `EasingOption` 객체를 정의하여 Preset Type의 오버라이딩 함수를 호출하여 사용하는걸 권장합니다.
&ensp;`exponential`은 함수값의 지수를 결정합니다. `multiplier`는 함수값의 배수를 결정합니다. 식으로 표현하면 다음과 같습니다. ($exp$ = `exponential`, $mul$ = `multiplier`)
$$mul\cdot B(t)^{exp}$$

## Easing.EasingOption
&ensp;이 클래스는 Single Axis Cubic Bezier 함수를 구성하기 위한 정보를 담고있는 클래스입니다.
```csharp
new Easing.EasingOption(p1, p2, p3, p4, exp, mul);
```

Constructor Parameters
 - `float p1` : 베지어 함수를 정의할 첫번째 점
 - `float p2` : 베지어 함수를 정의할 첫번째 점
 - `float p3` : 베지어 함수를 정의할 첫번째 점
 - `float p4` : 베지어 함수를 정의할 첫번째 점
 - `float exp` : 베지어 함수의 지수 값
 - `float mul` : 베지어 함수의 배수 값

&ensp;이 클래스는 메서드가 없습니다.

&ensp;이 클래스의 멤버변수는 전부 `readonly`입니다. 따라서, 생성한 뒤에 수정할 수 없습니다.

&ensp;자신이 필요한 베지어 함수를 만드려면 [이 링크(Desmos)](https://www.desmos.com/calculator/nszuu8wv2q)를 참조하여 값을 조정할 수 있습니다. x1,2,3,4은 p1,2,3,4에 대응합니다. E는 exp 에 대응합니다. m은 mul에 대응합니다. 여기에서 다루는 함수는 $0\leq t \leq 1$ 사이의 값만 유효합니다.
