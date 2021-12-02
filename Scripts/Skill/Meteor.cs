using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Skill
{
    [SerializeField] private float Range = 10f;
    private SphereCollider m_Collider; //공격범위 

    private void Awake()
    {
        //몬스터와 충돌확인용 collider 세팅 
        m_Collider = gameObject.AddComponent<SphereCollider>();
        m_Collider.radius = Range;
        m_Collider.isTrigger = true;

        NeededMp = 20f;
        m_fDamage = 1.6f;
        CoolTime = 7f;

        gameObject.SetActive(false);
    }
}
