using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenuGameObject; 
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.inGameMenuGameObject.activeInHierarchy)
            {
                this.inGameMenuGameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                this.inGameMenuGameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
