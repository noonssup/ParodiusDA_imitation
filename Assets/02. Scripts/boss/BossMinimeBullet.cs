using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMinimeBullet : MonoBehaviour
{
    float bulletSpeed; //불렛 속도
    float bulletPattern;
    float bulletDelay;
    int bulletDamage;
    public Transform player;
    Vector3 playerPos;

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        bulletDamage = 1;
        bulletPattern = 0;
        bulletSpeed = 5;

    }
    void Update()
    {
        if (player != null)
        {
            switch (bulletPattern)
            {
                case 0:
                    madeBullet();
                    break;
                case 1:
                    Shot();
                    break;
            }
        }
    }

    void madeBullet()
    {
        playerPos = player.position - this.gameObject.transform.position;
        playerPos = playerPos.normalized;
        bulletPattern = 1;
    }
    void Shot()
    {
        this.transform.position += playerPos * bulletSpeed * Time.deltaTime;
        bulletDelay += Time.deltaTime;
        if(bulletDelay  > 2.5f)
        {
            this.gameObject.SetActive(false);
            bulletDelay = 0;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamage damage = collision.GetComponent<IDamage>();

        if (collision.tag == "Player")
        {
            damage.Damage(bulletDamage);
            this.gameObject.SetActive(false);
        }
         if (collision.name == "PantarouBarrier(Clone)")
        {
            Debug.Log("펭타로보호막타격");
            damage.Damage(bulletDamage);
            this.gameObject.SetActive(false);
        }
        
        if (collision.name == "TacoBarrier(Clone)")
        {
            Debug.Log("타코보호막타격");
            damage.Damage(bulletDamage);
            this.gameObject.SetActive(false);
        }
    }
}
