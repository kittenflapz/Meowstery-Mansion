﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelAnimalsPC : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidBody;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    //void ControllPlayer()
    //{
    //    float moveHorizontal = Input.GetAxisRaw("Horizontal");
    //    float moveVertical = Input.GetAxisRaw("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    //    if (movement != Vector3.zero)
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
    //        anim.SetInteger("Walk", 1);
    //    }
    //    else {
    //        anim.SetInteger("Walk", 0);
    //    }

    //    transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

    //    if (Input.GetButtonDown("Jump") && Time.time > canJump)
    //    {
    //            rb.AddForce(0, jumpForce, 0);
    //            canJump = Time.time + timeBeforeNextJump;
    //            anim.SetTrigger("jump");
    //    }
    //}
}