using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {

    Animator anim;
    public int speed;
    Vector3 target;
	// Use this for initialization
	void Start () {
        target = new Vector3(8000, -2000, transform.position.z);
        anim = GetComponent<Animator>();
        anim.enabled = false;
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        //Cheat for animation control
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.enabled = !anim.enabled;
            speed = 300;
        }
	}

    public void setAnimation(bool state)
    {
        anim.enabled = state;
    }

    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }
}
