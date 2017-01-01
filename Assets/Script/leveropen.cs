using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class leveropen : MonoBehaviour {
	public GameObject spike;
	public bool dotrigger=false;
	public Text Texthint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.F))
		{
			print ("F");
			if(dotrigger)
			{
				gameObject.GetComponent<Animation>().Play("opendoor");
				spike.GetComponent<Animation>().Play("spikes");
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name=="First Person Controller")
		{
			dotrigger=true;
			print ("enter");
			Texthint.SendMessage("ShowHint","按F键推动");
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.name=="First Person Controller")
		{
			dotrigger=false;
		}
	}
}
