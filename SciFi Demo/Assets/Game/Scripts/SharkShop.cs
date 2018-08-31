/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    // public UIManager _uiManager;

    // void Start()
    // {
    //     UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    //     if (_uiManager == null)
    //     {
    //         Debug.Log("UIManager not found at the SharkShop!");
    //     }
    // }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player _player = other.GetComponent<Player>();
            UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

            if (_player != null && _player.hasCoin == false)
            {
                if (_uiManager != null)
                {
                    if (_uiManager.getOutDisplayed == false)
                    {
                        _uiManager.InteractWithText("Get outta here!");
                        _uiManager.getOutDisplayed = true;
                    }
                }
            }
            else if (_player != null && _player.hasCoin == true)
            {
                if (_uiManager != null)
                {
                    if (_uiManager.weaponMessageDisplayed == false)
                    {
                        _uiManager.InteractWithText("Press E to purchase weapon");
                        _uiManager.weaponMessageDisplayed = true;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_player != null)
                {
                    if (_player.hasCoin == true)
                    {
                        _player.hasCoin = false;

                        if (_uiManager != null)
                        {
                            _uiManager.RemoveCoin();
                            _uiManager.InteractWithText("Weapon purchased!");
                        }

                        AudioSource _audio = GetComponent<AudioSource>();
                        _audio.Play();
                        _player.EnableWeapons();
                    }
                    else
                    {
                        Debug.Log("Get outta here!");
                    }
                }
            }
        }
    }
}
