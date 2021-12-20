using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoot : MonoBehaviour
{
    PirateFace pirateFace;
    int i;
    int index;
    public GameObject FootExplosionEff;
    Transform[] footPos = new Transform[3];
    bool isLive;
    void Awake()
    {
        isLive = true;
        i = 0;
        index = 3;
        pirateFace = GameObject.Find("CatFace").GetComponent<PirateFace>();

    }

    private void Update()
    {
        if (pirateFace.pirateFaceHp <= 0)
        {
            for (i = 0; i < index; i++)
            {
                footPos[i] = transform.GetChild(i);
                Explosion();
                this.transform.GetChild(i).GetComponent<Animator>().SetInteger("Face'sHp", pirateFace.pirateFaceHp);
                //var tmp = transform.GetChild(i);
            }
            isLive = false;
        }
    }

    void Explosion()
    {
        if (isLive)
        {
            Debug.Log("Àü : i" + i);

            FootExplosionEff = Instantiate(FootExplosionEff, footPos[i].position, Quaternion.identity);
            Destroy(FootExplosionEff, 0.7f);
            Debug.Log("ÈÄ : i" + i);
        }
    }
}
