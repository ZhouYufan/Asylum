using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hint : MonoBehaviour {
	public Text Texthint;
	public Image Textpanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void ShowHint(string message)
	{	
		Texthint.text = message;
		if (!Texthint.enabled) 
		{ 
			Texthint.enabled = true; 
		}

		StartCoroutine("wait");
	}

	IEnumerator wait()
	{
		if (!Textpanel.enabled) 
		{ 
			Textpanel.enabled = true;

		}
	    yield return new WaitForSeconds (3.0f);
	    Texthint.enabled = false;
		Textpanel.enabled = false;
	}

}
