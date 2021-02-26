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

    MeshRenderer[] meshRenderers;

    private void Awake()
    {
        meow = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerController>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void Open()
    {
        meow.Play();
        wasOpened = true;
        GetComponent<MeshRenderer>().material.SetColor("_Color",Color.white);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !wasOpened)
        {
            print("hello");
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
                SetAllMeshRendererColors(black);
                color = PuzzleColor.BLACK;
                break;
            case PuzzleColor.PINK:
                SetAllMeshRendererColors(pink);
                color = PuzzleColor.PINK;
                break;
            case PuzzleColor.PURPLE:
                SetAllMeshRendererColors(purple);
                color = PuzzleColor.PURPLE;
                break;
            case PuzzleColor.GREEN:
                SetAllMeshRendererColors(green);
                color = PuzzleColor.GREEN;
                break;
        }
    }

    private void SetAllMeshRendererColors(Color color)
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.SetColor("_Color", color);
        }
    }

}
