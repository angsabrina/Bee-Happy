using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : Interactible{

    //public GameObject highlighter;
    Text flowerPickUp;
    protected int flowerXP;
    bool highlighted;
    float radius = 0.3f;

    //void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    playerController = player.GetComponent<PlayerController>();
    //}

    //void OnTriggerStay(Collider collision)
    //{
    //    //Debug.Log(flowerXP);
    //    proximityGood = true;
    //}

    //void OnTriggerExit(Collider collision)
    //{
    //    proximityGood = false;
    //}

    public override void OnMouseOver()
    {
        base.OnMouseOver();
        PlayerReach(flowerXP, gameObject.transform.position, radius);
    }

    void PlayerReach(int XP, Vector3 center, float radius)
    {
        Collider[] collisions = Physics.OverlapSphere(center, radius);
        foreach (Collider a in collisions)
        {
                Debug.Log(a.gameObject.tag);
            if (a.gameObject.tag == "Player")
            {
                a.gameObject.GetComponent<PlayerController>().ReachedItem(this.gameObject);
            }
        }
    }

    public int getFlowerXP()
    {
        return flowerXP;
    }

    public Image getFlowerImage()
    {
        return GetComponentInChildren<Image>() == null ? null : GetComponentInChildren<Image>();
    }
}
