using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    // Start is called before the first frame update
    public void ButtonRestart()
    {
        SceneManager.LoadScene("PLAYSHIFU_GAME");
    }

    // Update is called once per frame
    public void ButtonMain_Menu()
    {
        SceneManager.LoadScene(0);
    }

   
}
