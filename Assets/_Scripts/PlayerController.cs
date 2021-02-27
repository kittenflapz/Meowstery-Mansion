using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Movement setup

    [SerializeField]
    float speed;
    [SerializeField]
    Transform playerTransform;

    Vector3 moveDirection;
    float rotationDirection;
    private Vector2 inputVector;

    // Misc gameplay setup
    int kittensReleasedNum;
    public bool hasPinkKey;
    public bool hasGreenKey;
    public bool hasPurpleKey;
    public bool hasBlackKey;


    [SerializeField]
    GameManager gameManager;

    // UI setup

    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject pinkKeyIcon;
    [SerializeField]
    GameObject greenKeyIcon;
    [SerializeField]
    GameObject purpleKeyIcon;
    [SerializeField]
    GameObject blackKeyIcon;


    private void Awake()
    {
        moveDirection = Vector3.zero;
        inputVector = Vector2.zero;
        rotationDirection = 0;
        gameManager = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        // Movement handling

        moveDirection = playerTransform.forward * inputVector.y;
        rotationDirection = inputVector.x;
        Vector3 movementDirection = moveDirection * (speed * Time.deltaTime);
        playerTransform.position += movementDirection;
        playerTransform.Rotate(new Vector3(0, rotationDirection, 0));
        
    }

    // Gameplay logic

    public void ReleaseKitten(string color)
    {
        switch(color)
        {
            case "pink":
                pinkKeyIcon.SetActive(false);
                break;
            case "purple":
                purpleKeyIcon.SetActive(false);
                break;
            case "green":
                greenKeyIcon.SetActive(false);
                break;
            case "black":
                blackKeyIcon.SetActive(false);
                break;
        }    

        kittensReleasedNum++;
        gameManager.CheckIfCanWin(kittensReleasedNum);
    }

    public void GetKey(string color)
    {
 
        switch(color)
        {
            case "pink":
                hasPinkKey = true;
                pinkKeyIcon.SetActive(true);
                break;
            case "black":
                hasBlackKey = true;
                blackKeyIcon.SetActive(true);
                break;
            case "green":
                hasGreenKey = true;
                greenKeyIcon.SetActive(true);
                break;
            case "purple":
                hasPurpleKey = true;
                purpleKeyIcon.SetActive(true);
                break;
            default:
                break;
        }


    }


    // Input handling

    public void OnPause()
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
}
