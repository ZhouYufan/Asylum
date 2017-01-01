using UnityEngine;
using System.Collections;

public class change : MonoBehaviour {
	public Animator myani;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void trigger()
	{
		myani.SetBool("start",true);
	}
}
