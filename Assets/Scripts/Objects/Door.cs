using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    
    private void Update()
    {
        if(Input.GetButtonDown("attack"))
        {
            if(playerInRange && thisDoorType == DoorType.key)
            {
                // Does the player have a key?
                if(playerInventory.numberOfKeys > 0)
                {
                    // remove a player key
                    playerInventory.numberOfKeys--;
                    // True = call Open();
                    Open();
                }
            }
        }
    }

    public void Open()
    {
        // Turn off the door's sprite renderer
        doorSprite.enabled = false;
        // set Open to true
        open = true;
        // turn off door's box collider (physics)
        physicsCollider.enabled = false;
    }

    public void Close()
    {
        // Turn off the door's sprite renderer
        doorSprite.enabled = true;
        // set Open to true
        open = false;
        // turn off door's box collider (physics)
        physicsCollider.enabled = true;
    }
}
