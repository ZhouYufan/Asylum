using UnityEngine;
using System.Collections;

public class bulletdestory : MonoBehaviour {
	public float removeTime=1.5f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,removeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
