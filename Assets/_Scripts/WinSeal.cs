using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSeal : MonoBehaviour
{

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        print("hello");
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.OnWin();
        }
    }
}

