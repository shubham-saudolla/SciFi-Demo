/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player _player = other.GetComponent<Player>();

                if (_player != null)
                {
                    if (_player.hasCoin == true)
                    {
                        _player.hasCoin = false;

                        UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if (_uiManager != null)
                        {
                            _uiManager.RemoveCoin();
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
