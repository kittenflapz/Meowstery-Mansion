using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PuzzleColor
{
    PINK,
    GREEN,
    PURPLE,
    BLACK
}



public class GameManager : MonoBehaviour
{
   

    [SerializeField]
    KittenCage[] cages;

    // Start is called before the first frame update
    void Start()
    {
        InitializeCageColors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeCageColors()
    {
        for (int i = 0; i < cages.Length; i++)
        {
            cages[i].SetCageColor((PuzzleColor)i);
        }
    }
}
