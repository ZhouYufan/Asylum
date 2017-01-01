using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class boxopen2 : MonoBehaviour {
	public Text Texthint;
	public GUITexture water;
	public bool dotrigger=false;
	public static bool getwater=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update () {
		if(Input.GetKeyDown (KeyCode.F))
		{
//			print ("F");
			if(dotrigger)
			{
				if(boxopen.getweapon==true)
				{
					gameObject.GetComponent<Animation>().Play("box");
					Texthint.SendMessage("ShowHint","使用扳手撬开门，获得了一瓶中和喷雾剂");
					water.enabled=true;
					getwater=true;
				}
				if(boxopen.getweapon!=true)
				{
					Texthint.SendMessage("ShowHint","似乎可以寻找工具撬开它");
				}
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name=="First Person Controller")
		{
			dotrigger=true;
//			print ("enter");
			Texthint.SendMessage("ShowHint","按F键查看");
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


