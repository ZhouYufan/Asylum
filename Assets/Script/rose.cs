using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rose : MonoBehaviour {
	public Text Texthint;
	public bool dotrigger=false;
	public static bool getrose=false;
	public GUITexture rosepic;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.F))
		{
			if(dotrigger)
			{
				Texthint.SendMessage("ShowHint","获得了一束玫瑰");
				Destroy(gameObject);
				rosepic.enabled=true;
				getrose=true;
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name=="First Person Controller")
		{
			dotrigger=true;
			//			print ("enter");
			Texthint.SendMessage("ShowHint","按F键拾取");
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
