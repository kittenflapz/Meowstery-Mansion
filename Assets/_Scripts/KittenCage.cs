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
    PuzzleColor color;
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
            switch (color)
            {
                case PuzzleColor.BLACK:
                    if (player.hasBlackKey)
                    {
                        player.ReleaseKitten();
                        Open();
                    }
                    break;
                case PuzzleColor.PINK:
                    if (player.hasPinkKey)
                    {
                        player.ReleaseKitten();
                        Open();
                    }
                    break;
                case PuzzleColor.PURPLE:
                    if (player.hasPurpleKey)
                    {
                        player.ReleaseKitten();
                        Open();
                    }
                    break;
                case PuzzleColor.GREEN:
                    if (player.hasGreenKey)
                    {
                        player.ReleaseKitten();
                        Open();
                    }
                    break;
            }      
        }
    }

    public void SetCageColor(PuzzleColor puzzleColor)
    {   
        
       switch(puzzleColor)
        {
            case PuzzleColor.BLACK:
                GetComponent<MeshRenderer>().material.SetColor("_Color", black);
                color = PuzzleColor.BLACK;
                break;
            case PuzzleColor.PINK:
                GetComponent<MeshRenderer>().material.SetColor("_Color", pink);
                color = PuzzleColor.PINK;
                break;
            case PuzzleColor.PURPLE:
                GetComponent<MeshRenderer>().material.SetColor("_Color", purple);
                color = PuzzleColor.PURPLE;
                break;
            case PuzzleColor.GREEN:
                GetComponent<MeshRenderer>().material.SetColor("_Color", green);
                color = PuzzleColor.GREEN;
                break;
        }
    }

}
