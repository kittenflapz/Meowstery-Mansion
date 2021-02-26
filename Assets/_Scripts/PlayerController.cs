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
    TextMeshProUGUI kittensReleased;


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

    public void ReleaseKitten()
    {
        kittensReleasedNum++;
        kittensReleased.SetText(kittensReleasedNum.ToString());
        gameManager.CheckIfCanWin(kittensReleasedNum);
    }

    public void GetKey(string color)
    {
 
        switch(color)
        {
            case "pink":
                hasPinkKey = true;
                break;
            case "black":
                hasBlackKey = true;
                break;
            case "green":
                hasGreenKey = true;
                break;
            case "purple":
                hasPurpleKey = true;
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
