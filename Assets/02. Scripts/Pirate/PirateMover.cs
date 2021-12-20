using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateMover : MonoBehaviour
{

    public float moveSpeed;
    float spawnTime;
    bool isLive;

    //public GameObject Pirate;
    private void Start()
    {
        spawnTime = 0;
        isLive = false;

    }
    private void OnEnable()
    {
        moveSpeed = 0;
    }


    //private void Update()
    //{
    //    if (isLive == false)
    //    {
    //        spawnTime += Time.deltaTime;
    //        if (spawnTime > 28)
    //        {
    //            isLive = true;
    //            Pirate = Instantiate(Pirate, new Vector3(-1, -8.5f, 0), Quaternion.identity);
    //        }
    //    }
    //    PirateParent();
    //}

    //void PirateParent()
    //{

    //    if (this.transform.position.x > -207)
    //    {
    //        this.transform.position -= new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
    //    }
    //}

}
