using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
