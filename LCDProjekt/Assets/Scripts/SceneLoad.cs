using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

    //geht in die nächste Szene über
    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //beendet das Spiel
    public void quitGame()
    {
        Debug.Log("Spiel beendet");
        Application.Quit();
    }
}
