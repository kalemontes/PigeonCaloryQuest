using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverListener : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            Map.difficulty -= 1;
            SceneManager.LoadScene("Main_Scene");
        }
        if ((Input.GetKey(KeyCode.Escape)))
        {
            Application.Quit();
        }
    }
}
