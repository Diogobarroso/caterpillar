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

	//Shake detection variables
	float accelerometerUpdateInterval = 1.0f / 60.0f;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the
	// filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds = 1.0f;
	// This next parameter is initialized to 2.0 per Apple's recommendation,
	// or at least according to Brady! ;)
	float shakeDetectionThreshold = 2.0f;

	float lowPassFilterFactor;
	Vector3 lowPassValue;

	void Start () {
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
    }

    public void checkOperation()
    {
		int whole = Whole.GetComponent<dummyParts> ().getObjects ();
		int part1 = Part1.GetComponent<dummyParts> ().getObjects ();
		int part2 = Part2.GetComponent<dummyParts> ().getObjects ();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Objects");
        int amountObjects = objs.Length;
        Debug.Log(part1 + " + " + part2 + " = " + whole);

        if (part1 + part2 == whole)
        {
            StartCoroutine(Success(objs));
        }
		else
			Application.LoadLevel (Application.loadedLevelName);
			
    }
		
	void Update()
	{
		Vector3 acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		Vector3 deltaAcceleration = acceleration - lowPassValue;

		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
		{
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
        panel.GetComponentInChildren<Button>().onClick.AddListener(() => nextLevel());
    }

    public void nextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index+1);
    }
}
