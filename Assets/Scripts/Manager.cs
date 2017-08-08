using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
    public void checkOperation()
    {
        int whole = System.Int32.Parse(GameObject.Find("Whole").GetComponentInChildren<Text>().text);
        int part1 = System.Int32.Parse(GameObject.Find("Part1").GetComponentInChildren<Text>().text);
        int part2 = System.Int32.Parse(GameObject.Find("Part2").GetComponentInChildren<Text>().text);
        int rest = System.Int32.Parse(GameObject.Find("Rest").GetComponentInChildren<Text>().text);
        int amountObjects = GameObject.FindGameObjectsWithTag("Objects").Length;
        Debug.Log(part1 + " + " + part2 + " = " + whole);

        if (part1 + part2 == whole && part1 + part2 + whole + rest == amountObjects)
        {
            GameObject.Find("Dummy").GetComponent<Animator>().enabled = true;
        }
    }
	// Update is called once per frame
	void Update () {
        	
	}
}
