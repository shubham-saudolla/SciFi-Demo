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

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();

                if (player != null)
                {
                    player.hasCoin = true;
                    AudioSource.PlayClipAtPoint(_coinPickup, transform.position, 1f);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
