using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{

    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        raiseItem.Raise();
        context.Raise();
        isOpen = true;
        anim.SetBool("opened", true);
    }

    public void ChestAlreadyOpen()
    {
        dialogBox.SetActive(false);
        raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
