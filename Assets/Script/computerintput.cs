using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class computerintput : MonoBehaviour {
	public Text Texthint;
	public Canvas inputfield;
	public Text inputtext;
	public GUITexture key;
	public static bool keyget=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name=="First Person Controller")
		{
			inputfield.enabled=true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.name=="First Person Controller")
		{
			inputfield.enabled=false;
		}
	}
	void OnClick()
	{
		if(inputtext.text=="52103")
		{
			inputfield.enabled=false;
			Texthint.SendMessage("ShowHint","正确,获得钥匙");
			keyget=true;
			key.enabled=true;

		}
		if(inputtext.text!="52103")
		{
			inputfield.enabled=false;
			Texthint.SendMessage("ShowHint","错误");
			StartCoroutine("erro");
		}
	}
	IEnumerator erro()
	{
		yield return new WaitForSeconds (3.0f);
		inputfield.enabled=true;
	}

}
