using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible: MonoBehaviour {

    public GameObject highlighter;
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
        proximityGood = true;
    }

    void OnTriggerExit(Collider collision)
    {
        proximityGood = false;
    }

    public virtual void OnMouseOver()
    {
        if(proximityGood)
        {
            if (!highlighted)
            {
                Instantiate(highlighter, gameObject.transform);
                highlighted = true;
            }
        } 
    }

    //void OnMouseExit()
    //{
    //    if (proximityGood)
    //    {
    //        if (highlighted)
    //        {
    //            highlighted = false;
    //            highlighter.SetActive(false);
    //            //Destroy(highlighter);
    //        }
    //    }
    //}
}
