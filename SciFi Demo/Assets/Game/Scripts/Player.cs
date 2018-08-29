﻿/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float speed = 3.5f;
    private float _gravity = 9.8f;
    [SerializeField]
    private GameObject _muzzleFlash;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        // hiding the mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _muzzleFlash.SetActive(true);

            // Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
            }
        }
        else
        {
            _muzzleFlash.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // as this is a 3D game we only move in x and z axis and y axis is for gravity
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        Vector3 velocity = direction * speed;

        velocity.y -= _gravity;     // we don't want to subtract gravity from the user input thus we subtract it from the velocity

        // changing from locl space to world space
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
}
