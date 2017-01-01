using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finalcodeget : MonoBehaviour {
	public Text Texthint;
	public bool dotrigger=false;
	public GameObject finalhint;
	public GUITexture rosepic;
	public GameObject rose2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.F))
		{
			if(dotrigger)
			{
				if(rose.getrose)
				{
				   Texthint.SendMessage("ShowHint","将玫瑰放了上去");
				   rose2.GetComponent<Animation>().Play("roseappear");
			
				   finalhint.gameObject.SetActive(true);
				   rosepic.enabled=false;
				}
				if(!rose.getrose)
				{
					Texthint.SendMessage("ShowHint","雕像的手上似乎缺少了什么");
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
