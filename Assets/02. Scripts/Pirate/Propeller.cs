using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour, IDamage
{
    public int propellerHp;
    Animator propellerAnim;
    CapsuleCollider2D capsuleCollider;
    private void Awake()
    {
        propellerAnim = GetComponentInChildren<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        propellerHp = 8;
    }
    
    void IDamage.Damage(int damage)
    {
        propellerHp -= damage;
        if (propellerHp <= 0)
        {
            capsuleCollider.enabled = false;
            propellerAnim.SetTrigger("PropellerDown");
        }
    }
}
