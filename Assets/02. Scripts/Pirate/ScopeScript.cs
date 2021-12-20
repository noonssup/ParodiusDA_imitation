using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeScript : MonoBehaviour, IDamage
{

    public int ScopeHp;
    Animator scopeAnim;
    CircleCollider2D scopeCollider;
    private void Awake()
    {
        scopeAnim = GetComponentInChildren<Animator>();
        scopeCollider = GetComponent<CircleCollider2D>();
        ScopeHp = 8;

    }
    void IDamage.Damage(int damage)
    {
        ScopeHp -= damage;
        if (ScopeHp <= 0)
        {
            scopeCollider.enabled = false;
            scopeAnim.SetTrigger("ScopeDown");
        }
    }
}
