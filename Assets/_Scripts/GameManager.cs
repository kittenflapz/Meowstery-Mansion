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
    [SerializeField]
    Button getBlackKeyButton;
    [SerializeField]
    Button getPurpleKeyButton;
    [SerializeField]
    Button getGreenKeyButton;

    [SerializeField]
    GameObject winTriggerBox;
    
    [SerializeField]
    GameObject heavenLight;


    [SerializeField]
    GameObject winMenu;

    string pinkAnswer = "what";
    string blackAnswer = "my shadow";
    string purpleAnswer = "1";
    string greenAnswer = "el";

    bool canWin = false;

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
    public void CheckBlackAnswer(string input)
    {
        if (input.ToLower() == blackAnswer)
        {
            getBlackKeyButton.gameObject.SetActive(true);
        }
    }

    public void CheckPurpleAnswer(string input)
    {
        if (input.ToLower() == purpleAnswer)
        {
            getPurpleKeyButton.gameObject.SetActive(true);
        }
    }
    
    public void CheckGreenAnswer(string input)
    {
        if (input.ToLower() == greenAnswer)
        {
            getGreenKeyButton.gameObject.SetActive(true);
        }
    }

    public void CheckIfCanWin(int numKittensReleased)
    {
        if (numKittensReleased == 4 && canWin == false)
        {
            canWin = true;
            OnCanWin();
        }
    }

    private void OnCanWin()
    {
       StartCoroutine (WaitAndMoveSeal(3f));
    }

    public void OnWin()
    {
        winMenu.SetActive(true);
    }

    public IEnumerator WaitAndMoveSeal(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        winTriggerBox.GetComponent<Animator>().SetTrigger("SealMove");
        winTriggerBox.GetComponent<AudioSource>().Play();
        heavenLight.SetActive(true);

    }
}
