using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dummyParts : MonoBehaviour {

    public void Start()
    {
        GetComponentInChildren<Text>().text = Objects.ToString();
    }

    int Objects = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        Objects++;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Objects--;
    }

    void Update()
    {
        GetComponentInChildren<Text>().text = Objects.ToString();
    }
}
