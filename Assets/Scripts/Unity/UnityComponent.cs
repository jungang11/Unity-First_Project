using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityComponent : MonoBehaviour
{
    /************************************************************************
	 * 컴포넌트 (Component)
	 * 
	 * 특정한 기능을 수행할 수 있도록 구성한 작은 기능적 단위
	 * 게임오브젝트의 작동과 관련한 부품
	 * 게임오브젝트에 추가, 삭제하는 방식의 조립형 부품
	 * 
	 * 컴포넌트를 뗀다고 해서 오브젝트의 다른 컴포넌트에 영향이 가는 것은 없음. -> 가장 큰 장점
     * -> 컴포넌트끼리 독립적. 기능의 +, - 가 쉽다. 코드의 의존성을 줄이고 재활용성을 높임
     * ex) Player has a inventory. 
     * 
     * <컴포넌트란?>
     * -> 로직을 기능별로 컴포넌트화 하는 것. 기능들을 나누어 각각 독립적인 클래스로 분리.
     * 문제가 생길 시 컴포넌트만 수정하면 되기 때문에 요구사항에 대한 대처가 빨라 유지보수가 편함.
     * 유니티는 컴포넌트 구조를 사용하고 있음. -> 메시지 방식 사용
     * -> 메시지와 같은 이름의 기능이 있다면 반응하고 없다면 무시하는 방식
     * 캡슐화를 더 살려줌.
	 ************************************************************************/

    /************************************************************************
	 * MonoBehaviour
	 * 
	 * 컴포넌트를 기본클래스로 하는 클래스로 유니티 스크립트가 파생되는 기본 클래스
	 * 게임 오브젝트에 스크립트를 컴포넌트로서 연결할 수 있는 구성을 제공
	 * 스크립트 직렬화 기능, 유니티메시지 이벤트를 받는 기능, 코루틴 기능을 포함함
	 ***********************************************************************/

    // <스크립트 직렬화 기능>
    // 인스펙터 창에서 컴포넌트의 맴버변수 값을 확인하거나 변경하는 기능
    // 컴포넌트의 값형식 데이터를 확인하거나 변경
    // 컴포넌트의 참조형식 데이터를 드래그 앤 드랍 방식으로 연결

    // <인스펙터창 직렬화가 가능한 자료형>
    [Header("C# Type")]
    public bool boolValue;
    public int intValue;
    public float floatValue;
    public string stringValue;
    // 그 외 기본 자료형

    // 기본 자료형의 선형자료구조
    public int[] array;
    public List<int> list;

    [Header("Unity Type")]
    public Vector3 vector3;
    public Color color;
    public LayerMask layerMask;
    public AnimationCurve curve;
    public Gradient gradient;

    [Header("Unity GameObject")]
    public GameObject obj;

    [Header("Unity Component")]
    public new Transform transform;
    public new Rigidbody rigidbody;
    public new Collider collider;

    [Header("Unity Event")]
    public UnityEvent OnEvent;

    // <어트리뷰트>
    // 클래스, 프로퍼티 또는 함수 위에 명시하여 특별한 동작을 나타낼 수 있는 마커

    [Space(30)]

    [Header("Unity Attribute")]
    [SerializeField]
    private int privateValue;
    [HideInInspector]
    public int publicValue;

    [Range(0, 10)]
    public float rangeValue;

    [TextArea(3, 5)]
    public string textField;
}
