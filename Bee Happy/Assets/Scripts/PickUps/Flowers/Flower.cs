using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour {

    public GameObject highlighter;
    Text flowerPickUp;
    protected int flowerXP;
    GameObject player;
    bool highlighted;
    bool proximityGood;
    PlayerController playerController;
    float radius = 0.3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void OnTriggerStay(Collider collision)
    {
        //Debug.Log(flowerXP);
        proximityGood = true;
    }

    void OnTriggerExit(Collider collision)
    {
        proximityGood = false;
    }

    void OnMouseOver()
    {
        if(proximityGood)
        {
            //Debug.Log("Mouse entered");
            //Debug.Log(gameObject.name);
            if (!highlighted)
            {
                Instantiate(highlighter, gameObject.transform);
                highlighted = true;
            }
            PlayerReach(flowerXP, gameObject.transform.position, radius);
        } 
    }

    void PlayerReach(int XP, Vector3 center, float radius)
    {
        Collider[] collisions = Physics.OverlapSphere(center, radius);
        foreach (Collider a in collisions)
        {
            //Debug.Log("Collision a: " + a);
            if (a.gameObject.tag == "Flower")
            {
                player.GetComponent<PlayerController>().ReachedItem(a.gameObject);
            }
        }
    }


    void OnMouseExit()
    {
        //if (proximityGood)
        //{
        //    if(highlighted)
        //    {
        //        Destroy(highlighter);
        //    }
        //}
    }

    public int getFlowerXP()
    {
        return flowerXP;
    }
}
