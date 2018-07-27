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
    //private GameObject player;

    //inventory
    public CanvasGroup inventoryCanvas;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //player = GameObject.Find("Player");
        canvas = GameObject.Find("StatsCanvas");
        inventoryCanvas.alpha = 0;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            var horizontalAxis = Input.GetAxis("Horizontal");
            var verticalAxis = Input.GetAxis("Vertical");
            if(inventoryCanvas.alpha == 1)
            {
                horizontalAxis = 0;
                verticalAxis = 0;
            }
            moveDirection = new Vector3(horizontalAxis, 0, verticalAxis);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //works but fails when Inventory is open at game start (probably won't be)
        if (Input.GetKeyDown("i") && inventoryCanvas.alpha == 1)
        {
            inventoryCanvas.alpha = 0;
            Cursor.lockState = CursorLockMode.Locked;
            transform.GetComponent<MouseLook>().enabled = true;
        }
        else if (Input.GetKeyDown("i") && inventoryCanvas.alpha == 0) 
        {
            inventoryCanvas.alpha = 1;
            Cursor.lockState = CursorLockMode.None;
            transform.GetComponent<MouseLook>().enabled = false;

        }
    }


    public void ReachedItem(GameObject item) {
        if (item.tag == "Flower" && Input.GetKeyDown("e"))
        {
            inventoryCanvas.GetComponentInChildren<Inventory>().addToInventory(item, item.GetComponent<Flower>().getFlowerImage());
            ShowFlowerMessage(item.name);
            GetComponent<Player>().increaseXP(item.GetComponent<Flower>().getFlowerXP());
            Destroy(item);
        }

        if (item.tag == "Store" && Input.GetKeyDown("e"))
        {
           Debug.Log(item.tag);
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