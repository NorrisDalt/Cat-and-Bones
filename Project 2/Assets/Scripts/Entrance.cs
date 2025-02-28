using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Entrance : MonoBehaviour
{
    private Animator animator;
    private bool isOpened = false; // Prevents re-triggering

    // Store the initial position of the door
    private Vector3 initialPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Idle");
    }

    public void OpenEntrance()
    {
        if (!isOpened) // Only open once
        {
            isOpened = true;
            animator.SetTrigger("Open"); // Plays the animation when triggered
        }
    }
}