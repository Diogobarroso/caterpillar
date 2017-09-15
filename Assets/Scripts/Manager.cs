using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    // Use this for initialization
    GameObject panel;
    GameObject Dummy;
	GameObject Whole;
	GameObject Part1;
	GameObject Part2;
	GameObject[] objects;
	List<Vector3> positions;

	//Shake detection variables
	float accelerometerUpdateInterval = 1.0f / 120.0f;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the
	// filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds = 1.0f;
	// This next parameter is initialized to 2.0 per Apple's recommendation,
	// or at least according to Brady! ;)
	float shakeDetectionThreshold = 2.0f;

	float lowPassFilterFactor;
	Vector3 lowPassValue;

	void Start () {
		positions = new List<Vector3> ();
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
        panel = Instantiate(Resources.Load("Panel") as GameObject);
        panel.transform.SetParent(GameObject.Find("Canvas").transform);
        Vector3 pos = new Vector3(0, 0, 0);
        panel.transform.localPosition = pos;
        panel.SetActive(false);
        Dummy = GameObject.Find("Dummy");
		Whole = GameObject.Find ("Whole");
		Part1 = GameObject.Find ("Part1");
		Part2 = GameObject.Find ("Part2");

		objects = GameObject.FindGameObjectsWithTag ("Objects");
		foreach (GameObject obj in objects)
			positions.Add (obj.transform.localPosition);
    }

	private void checkOperation()
    {
		int whole = Whole.GetComponent<dummyParts> ().getObjects ();
		int part1 = Part1.GetComponent<dummyParts> ().getObjects ();
		int part2 = Part2.GetComponent<dummyParts> ().getObjects ();
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Objects");
		Debug.Log (part1 + " + " + part2 + " = " + whole);

		if (part1 + part2 == whole) {
			Debug.Log ("CORRECT: " + part1 + " + " + part2 + " = " + whole);
			StartCoroutine (Success (objs));
		} else {
			Debug.Log ("WRONG");
			for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Objects").Length; i++)
				objects [i].transform.localPosition = positions [i];
		}
	}
		
	void Update()
	{
		Vector3 acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp (lowPassValue, acceleration, lowPassFilterFactor);
		Vector3 deltaAcceleration = acceleration - lowPassValue;

		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold) {
			checkOperation ();
		}
	}

    IEnumerator Success(GameObject[] objs)
    {
        foreach (GameObject obj in objs)
            obj.SetActive(false);

        GameObject.Find("Dummy").GetComponent<Animator>().enabled = true;
        GameObject.Find("Dummy").GetComponent<DummyScript>().setSpeed(300);

        yield return new WaitForSeconds(2);
        panel.SetActive(true);
        for (int i = 0; i < 2; i++)
        {
            GameObject.Find("StarBG" + i).GetComponent<Image>().color = Color.white;
        }
		panel.GetComponentInChildren<Button>().onClick.AddListener(() => StartCoroutine(nextLevel()));
    }

	IEnumerator nextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
		if (index == 3) {
			Destroy (GameObject.Find ("Panel(Clone)"));
			GameObject grats = Instantiate (Resources.Load ("CongratulationsAddition") as GameObject);
			grats.transform.SetParent (GameObject.Find ("Canvas").transform);
			Vector3 pos = new Vector3 (0, 0, 0);
			grats.transform.localPosition = pos;
			yield return new WaitForSeconds (2);
			Destroy (grats);
			GameObject innerSplash = Instantiate (Resources.Load ("InnerSplashSubtraction") as GameObject);
			innerSplash.transform.SetParent (GameObject.Find ("Canvas").transform);
			Vector3 tmp = new Vector3 (0, 0, 0);
			innerSplash.transform.localPosition = tmp;
			yield return new WaitForSeconds (2);

		} else if (index == 6)
		{
			Destroy (GameObject.Find ("Panel(Clone)"));
			GameObject grats = Instantiate (Resources.Load ("CongratulationsSubtraction") as GameObject);
			grats.transform.SetParent (GameObject.Find ("Canvas").transform);
			Vector3 pos = new Vector3 (0, 0, 0);
			grats.transform.localPosition = pos;
			yield return new WaitForSeconds (2);
			SceneManager.LoadScene (0);
		}
        SceneManager.LoadScene(index+1);
    }

	public void homeButton()
	{
		SceneManager.LoadScene ("caterpillar_menu");
	}
}
