using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flower : MonoBehaviour {

    public GameObject highlighter;
    public Text pickUpMessage;
    GameObject canvas;
    Text flowerPickUp;
    protected int flowerXP;
    GameObject player;
    bool highlighted;
    bool proximityGood;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.Find("Canvas");
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
            PlayerReach(flowerXP, gameObject.transform.position, 10);
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

    void PlayerReach(int XP, Vector3 center, float radius)
    {
        Collider[] collisions = Physics.OverlapSphere(center, radius);
        foreach (Collider a in collisions)
        {
            if (a.gameObject.tag == "Player" && Input.GetKeyDown("e"))
            {
                //Player.Instance.inventory.AddFlowerInventory(gameObject);
                //Inventory.Instance.AddFlowerInventory(gameObject);
                ShowFlowerMessage(gameObject.name);
                player.GetComponent<Player>().increaseXP(XP);
                Destroy(gameObject);
            }
        }
    }

    void ShowFlowerMessage(string flower)
    {
        flowerPickUp = Instantiate(pickUpMessage);
        flowerPickUp.text = "You just picked up a " + flower;
        flowerPickUp.transform.SetParent(canvas.transform, false);
        Destroy(flowerPickUp.gameObject, 1);
    }

    public int getFlowerXP()
    {
        return flowerXP;
    }
}
