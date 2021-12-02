using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIndicator : MonoBehaviour
{
    private Projector m_Projector;

    private void Awake()
    {
        m_Projector = GetComponent<Projector>();
    }

    public void SetMeteorRange()
    {
        m_Projector.orthographicSize = Camera.main.orthographicSize;
    }
}
