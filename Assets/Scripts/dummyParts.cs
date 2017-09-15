using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dummyParts : MonoBehaviour {

	int Objects;

	public void Start()
	{
		//Objects = 0;

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Objects++;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Objects--;
    }

	public int getObjects()
	{
		return Objects;
	}
		
}
