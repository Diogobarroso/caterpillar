using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void ClickPlay()
    {
		Destroy (GameObject.Find ("FirstMenu"));
		Destroy (GameObject.Find ("Title"));
		/*GameObject levelSelection = Instantiate(Resources.Load ("Level Selection") as GameObject);
		levelSelection.transform.SetParent(GameObject.Find("Canvas").transform);
		Vector3 pos = new Vector3 (0, -60, 0);
		levelSelection.transform.localPosition = pos;
		Button[] buts = levelSelection.GetComponentsInChildren<Button> ();

		foreach(Button but in buts)
			but.onClick.AddListener (() => StartCoroutine(OpenLevel (but.name)));
			*/
		StartCoroutine(OpenLevel("1.1"));
    }

	IEnumerator OpenLevel(string level)
	{
		//Destroy(GameObject.Find ("Level Selection(Clone)"));
		GameObject innerSplash = Instantiate(Resources.Load ("InnerSplashAddition") as GameObject);
		innerSplash.transform.SetParent(GameObject.Find("Canvas").transform);
		Vector3 pos = new Vector3(0, 0, 0);
		innerSplash.transform.localPosition = pos;
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene (level);
	}

    public void ClickExit()
    {
        Application.Quit();
    }
		
}
