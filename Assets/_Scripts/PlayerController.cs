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

    // Animation setup (forgive me)
    [SerializeField]
    Animator animator;

    // Misc gameplay setup
    int kittensReleasedNum;
    public bool hasPinkKey;
    public bool hasGreenKey;
    public bool hasPurpleKey;
    public bool hasBlackKey;
    bool isPaused;

    [SerializeField]
    GameManager gameManager;


    // UI setup

    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject introText;
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
        StartCoroutine(WaitAndDismissIntroText(5));

        isPaused = false;

        // fixes a bug where if you pause, go to main menu, then load into the game again, it is still paused
        Time.timeScale = 1;
    }


    private void Update()
    {
        // Movement handling

        moveDirection = playerTransform.forward * inputVector.y;
        rotationDirection = inputVector.x;

        if (moveDirection.magnitude > float.Epsilon || rotationDirection > float.Epsilon)
        {
            animator.SetInteger("Walk", 1);
        }
        else
        {
            animator.SetInteger("Walk", 0);
        }

        Vector3 movementDirection = moveDirection * (speed * Time.deltaTime);
        playerTransform.position += movementDirection;
        playerTransform.Rotate(new Vector3(0, rotationDirection, 0));
        
    }

    // Gameplay logic

    public void ReleaseKitten(string color)
    {
        switch (color)
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


    public IEnumerator WaitAndDismissIntroText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        introText.GetComponent<Animator>().SetTrigger("Dismiss");

    }


    // Input handling

    public void OnPause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }

        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
    }

    public void OnMovement(InputValue value)
    {
        if (!isPaused)
        {
            inputVector = value.Get<Vector2>();
        }
    }
}
