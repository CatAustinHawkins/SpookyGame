using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject TerryImageUI;
    public bool isTerryCollected;
    public GameObject ItemRotationRoom;

    public GameObject InventoryMenu;
    public GameObject MenuButton;

    public GameObject ItemDescriptions;

    public GameObject Image;
    public GameObject Player;

    public float timer;
    public bool timeractive;

    public bool InventoryOpen;
    public bool TerryInspection;

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.I) && timeractive == false && InventoryOpen == false)
        {
            InventoryMenu.SetActive(true);
            MenuButton.SetActive(true);
            timeractive = true;
            InventoryOpen = true;
        }

        if (Input.GetKey(KeyCode.I) && timeractive == false && InventoryOpen)
        {
            InventoryMenu.SetActive(false);
            MenuButton.SetActive(false);
            timeractive = true;
            ItemRotationRoom.SetActive(false);
            ItemDescriptions.SetActive(false);
            Image.SetActive(true);
            Player.SetActive(true);
            TerryInspection = false;
            InventoryOpen = false;
        }

        if (timeractive)
        {
            timer = timer + 1 * Time.deltaTime;
        }

        if(timer > 0.5f)
        {
            timeractive = false;
            timer = 0;
        }

    }


    public void TerryCollected()
    {
        TerryImageUI.SetActive(true);
        isTerryCollected = true;
    }

    public void TerryButton()
    {
        if (isTerryCollected && timeractive == false && TerryInspection == false)
        {
            ItemRotationRoom.SetActive(true);
            ItemDescriptions.SetActive(true);
            Image.SetActive(false);
            Player.SetActive(false);
            timeractive = true;
            TerryInspection = true;
        }

        if (isTerryCollected && timeractive == false && TerryInspection == true)
        {
            ItemRotationRoom.SetActive(false);
            ItemDescriptions.SetActive(false);
            Image.SetActive(true);
            Player.SetActive(true);
            TerryInspection = false;
            timeractive = true;

        }
    }
}
