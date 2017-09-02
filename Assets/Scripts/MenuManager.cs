using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void ClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickParent()
    {
        SceneManager.LoadScene(4);
    }

    public void ClickAnalyze()
    {

    }
}
