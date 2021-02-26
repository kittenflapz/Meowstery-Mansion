using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenCage : MonoBehaviour
{
    bool wasOpened;
    AudioSource meow;
    PlayerController player;

    private void Awake()
    {
        meow = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerController>();
    }

    public void Open()
    {
        meow.Play();
        wasOpened = true;
        GetComponent<MeshRenderer>().material.SetColor("_Color",Color.magenta);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player") && !wasOpened)
        {
            player.ReleaseKitten();
            Open();
        }
    }
}
