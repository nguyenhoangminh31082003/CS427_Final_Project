using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    static GameState GameStateInstance;
    static public bool gameOver = false;
    private void Awake()
    {
        if (GameStateInstance == null)
        {
            GameStateInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    static public void SetGameOver()
    {
        gameOver = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
