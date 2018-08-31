/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private GameObject _coin;

    [SerializeField]
    private Text _interactionText;

    public bool coinMessageDisplayed = false;
    public bool coinPickedupDisplayed = false;

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;
    }

    public void CollectedCoin()
    {
        _coin.SetActive(true);
    }

    public void RemoveCoin()
    {
        _coin.SetActive(false);
    }

    public void InteractWithText(string action)
    {
        _interactionText.gameObject.SetActive(true);
        _interactionText.text = action;
        StartCoroutine(LeaveInteractableArea());
    }

    IEnumerator LeaveInteractableArea()
    {
        yield return new WaitForSeconds(5f);
        _interactionText.gameObject.SetActive(false);
    }
}
