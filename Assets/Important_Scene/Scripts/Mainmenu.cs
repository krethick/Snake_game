using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonStart()
    {
        SceneManager.LoadScene("SNAKE_GAME");
    }

    // Update is called once per frame
    public void ButtonCredit()
    {
        SceneManager.LoadScene(2);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
