using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void ClickPlay()
    {
		Destroy (GameObject.Find ("FirstMenu"));
		GameObject levelSelection = Instantiate(Resources.Load ("Level Selection") as GameObject);
		levelSelection.transform.SetParent(GameObject.Find("Canvas").transform);
		Vector3 pos = new Vector3 (0, -60, 0);
		levelSelection.transform.localPosition = pos;

		for(int i = 0; i < levelSelection.transform.childCount; i++)
		{
			Button but = levelSelection.GetComponentsInChildren<Button>()[i];
			Debug.Log (but.name);
			but.onClick.AddListener (() => OpenLevel (but.name));
		}
    }

	void OpenLevel(string level)
	{
		Debug.Log ("DUUUUUDE");
		SceneManager.LoadScene (level);
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

	void showLevels()
	{
	}
}
