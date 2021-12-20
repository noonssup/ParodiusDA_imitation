using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateFace : MonoBehaviour, IDamage
{
    public int pirateFaceHp;
    float hitDelay;
    bool isPirateHit;
    Animator pirateAnim;


    CircleCollider2D faceCollider;
    private void Awake()
    {
        pirateFaceHp = 8;
        isPirateHit = true;
        pirateAnim = GetComponentInChildren<Animator>();
        faceCollider = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (isPirateHit == true)
        {
            hitDelay += Time.deltaTime;
            if (hitDelay > 1)
            {
                isPirateHit = false;
                hitDelay = 0;
            }
        }
    }
    void IDamage.Damage(int damage)
    {
        if (isPirateHit == false)
        {
                pirateFaceHp -= damage;
            if (pirateFaceHp >0 )
            {
                isPirateHit = true;
                pirateAnim.SetInteger("CatFaceHp", pirateFaceHp);
                pirateAnim.SetTrigger("Damaged");
            }
            else if (pirateFaceHp <= 0)
            {

                pirateAnim.SetInteger("CatFaceHp", pirateFaceHp);
                pirateAnim.SetTrigger("isFaceDown");
                faceCollider.enabled = false;
            }
        }
    }

}
