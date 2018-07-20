using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float runSpeed = 8.0F;
    public float gravity = 20.0F;

    GameObject canvas;
    public Text pickUpMessage;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private GameObject player;

    //inventory
    public GameObject inventory;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //works but fails when Inventory is open at game start (probably won't be)
        if (Input.GetKeyDown("i") && inventory.activeInHierarchy)
        {
            inventory.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            transform.GetComponent<MouseLook>().enabled = true;
        }
        else if (Input.GetKeyDown("i") && !inventory.activeInHierarchy) 
        {
            inventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            transform.GetComponent<MouseLook>().enabled = false;
        }
    }


public void ReachedItem(GameObject item) {
        if (item.tag == "Flower" && Input.GetKeyDown("e"))
        {
            inventory.GetComponent<Inventory>().addToInventory(item, item.GetComponent<Flower>().getFlowerImage());
            ShowFlowerMessage(item.name);
            GetComponent<Player>().increaseXP(item.GetComponent<Flower>().getFlowerXP());
            Destroy(item);
        }
    }

    void ShowFlowerMessage(string flower)
    {
        Text flowerPickUp;
        flowerPickUp = Instantiate(pickUpMessage);
        flowerPickUp.text = "You just picked up a " + flower;
        flowerPickUp.transform.SetParent(canvas.transform, false);
        Destroy(flowerPickUp.gameObject, 1);
    }
}