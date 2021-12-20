using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateBullet : MonoBehaviour
{
    float bulletSpeed;
    float bulletPattern;
    float bulletDelay;
    int bulletDamage;
    public Transform player;

    TopCannon1 cannon3;

    public Vector3 playerPos;

    public GameObject Pirate;

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        bulletPattern = 0;
        bulletDamage = 1;
        bulletSpeed = 5;
    }
    void Update()
    {
        //if (Pirate != null)
        //{
        //    cannon3 = GameObject.Find("TopCannon1").GetComponent<TopCannon1>();
        //}
        this.transform.position += playerPos * bulletSpeed * Time.deltaTime;
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
        bulletDelay += Time.deltaTime;
        if (bulletDelay > 10f)
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
        else if (collision.name == "PantarouBarrier(Clone)")
        {

            damage.Damage(bulletDamage);
            this.gameObject.SetActive(false);
        }
        else if (collision.name == "TacoBarrier(Clone)")
        {

            damage.Damage(bulletDamage);
            this.gameObject.SetActive(false);
        }
    }
}
