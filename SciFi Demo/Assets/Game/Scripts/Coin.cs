/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinPickup;

    private UIManager _uiManager;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.Log("UIManager ot found oon the canvas!");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null && player.hasCoin == false)
            {
                if (_uiManager.coinMessageDisplayed == false)
                {
                    _uiManager.InteractWithText("Press E to collect the coin");
                    _uiManager.coinMessageDisplayed = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player != null)
                {
                    player.hasCoin = true;
                    _uiManager.InteractWithText("Coin picked up!");
                    AudioSource.PlayClipAtPoint(_coinPickup, transform.position, 1f);

                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if (uiManager != null)
                    {
                        uiManager.CollectedCoin();
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
