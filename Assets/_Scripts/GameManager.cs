using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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

    [SerializeField]
    Button getPinkKeyButton;

    string pinkAnswer = "what";

    // Start is called before the first frame update
    void Start()
    {
        InitializeCageColors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initialization

    void InitializeCageColors()
    {
        for (int i = 0; i < cages.Length; i++)
        {
            cages[i].SetCageColor((PuzzleColor)i);
        }
    }

    public void CheckPinkAnswer(string input)
    {
        if (input.ToLower() == pinkAnswer)
        {
            getPinkKeyButton.gameObject.SetActive(true);
        }
    }
}
