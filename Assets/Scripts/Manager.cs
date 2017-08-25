using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    // Use this for initialization
    GameObject panel;
    GameObject Dummy;
	void Start () {
        panel = Instantiate(Resources.Load("Panel") as GameObject);
        panel.transform.SetParent(GameObject.Find("Canvas").transform);
        Vector3 pos = new Vector3(0, 0, 0);
        panel.transform.localPosition = pos;
        panel.SetActive(false);
        Dummy = GameObject.Find("Dummy");
    }
	
    public void checkOperation()
    {
        int whole = System.Int32.Parse(GameObject.Find("Whole").GetComponentInChildren<Text>().text);
        int part1 = System.Int32.Parse(GameObject.Find("Part1").GetComponentInChildren<Text>().text);
        int part2 = System.Int32.Parse(GameObject.Find("Part2").GetComponentInChildren<Text>().text);
        int rest = System.Int32.Parse(GameObject.Find("Rest").GetComponentInChildren<Text>().text);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Objects");
        int amountObjects = objs.Length;
        Debug.Log(part1 + " + " + part2 + " = " + whole);

        if (part1 + part2 == whole && part1 + part2 + whole + rest == amountObjects)
        {
            StartCoroutine(Success(objs));
        }
    }
	// Update is called once per frame
	void Update () {
        	
	}

    IEnumerator Success(GameObject[] objs)
    {
        GameObject.Find("Rest").SetActive(false);
        foreach (GameObject obj in objs)
            obj.SetActive(false);

        for (int i = 0; i < 3; i++)
            Dummy.transform.GetChild(i).GetComponentInChildren<Text>().enabled = false;
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
