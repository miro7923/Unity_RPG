using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour
{
    [SerializeField] private Transform m_Handle; //조이스틱 핸들 

    private Vector3 m_FirstHandlePos; //핸들의 첫 위치 
    public Vector3 HandleDir { get; private set; } //핸들 방향 
    private float m_BackgroundRadius; //조이스틱 배경의 반지름

    public bool TouchInput { get; private set; }

    private void Awake()
    {
        m_BackgroundRadius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        m_FirstHandlePos = m_Handle.transform.position;

        //캔버스 크기에 대한 반지름 조절 
        float can = GetComponent<RectTransform>().localScale.x;
        m_BackgroundRadius *= can;
    }

    public void Drag(BaseEventData eventData)
    {
        TouchInput = true;

        PointerEventData pointerEvent = eventData as PointerEventData;
        Vector3 pos = pointerEvent.position;

        //입력 위치 - 핸들의 첫 위치를 정규화해서 이동시킬 방향을 구한다 
        HandleDir = (pos - m_FirstHandlePos).normalized;

        //양쪽 위치간 거리를 구한다 
        float dist = Vector3.Distance(pos, m_FirstHandlePos);

        if (m_BackgroundRadius > dist)
        {
            //거리가 반지름보다 작으면 핸들을 현재 터치하고 있는 곳으로 이동 
            m_Handle.position = m_FirstHandlePos + HandleDir * dist;
        }
        else
        {
            //거리가 반지름보다 크면 핸들을 조이스틱 반지름 크기만큼만 이동 
            m_Handle.position = m_FirstHandlePos + HandleDir * m_BackgroundRadius;
        }
    }

    public void DragEnd()
    {
        //드래그가 끝나면 핸들을 원래 위치로 보내고 
        m_Handle.position = m_FirstHandlePos;
        //방향을 초기화한다 
        HandleDir = Vector3.zero;

        TouchInput = false;
    }
}
