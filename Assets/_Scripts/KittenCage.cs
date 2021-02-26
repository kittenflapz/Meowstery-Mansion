using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenCage : MonoBehaviour
{
    // ehhhhhhh these may end up being repeated all over the place but life is hard
    [SerializeField]
    Color pink;
    [SerializeField]
    Color green;
    [SerializeField]
    Color purple;
    [SerializeField]
    Color black;

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
        GetComponent<MeshRenderer>().material.SetColor("_Color",Color.white);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player") && !wasOpened)
        {
            player.ReleaseKitten();
            Open();
        }
    }

    public void SetCageColor(PuzzleColor puzzleColor)
    {
        switch(puzzleColor)
        {
            case PuzzleColor.BLACK:
                GetComponent<MeshRenderer>().material.SetColor("_Color", black);
                break;
            case PuzzleColor.PINK:
                GetComponent<MeshRenderer>().material.SetColor("_Color", pink);
                break;
            case PuzzleColor.PURPLE:
                GetComponent<MeshRenderer>().material.SetColor("_Color", purple);
                break;
            case PuzzleColor.GREEN:
                GetComponent<MeshRenderer>().material.SetColor("_Color", green);
                break;
        }
    }

}
