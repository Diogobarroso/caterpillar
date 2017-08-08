using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.enabled = !anim.enabled;
        }
	}

    public void setAnimation(bool state)
    {
        anim.enabled = state;
    }
}
