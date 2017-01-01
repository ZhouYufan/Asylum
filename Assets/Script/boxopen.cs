using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class boxopen : MonoBehaviour {
	public Text Texthint;
	public GUITexture weapon;
	public bool dotrigger=false;
	public static bool getweapon=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.F))
		{
			if(dotrigger)
			{
				if(computerintput.keyget==true)
				{
					gameObject.GetComponent<Animation>().Play("box");
					Texthint.SendMessage("ShowHint","使用了钥匙，获得一把扳手");
					weapon.enabled=true;
					getweapon=true;
				}
				if(computerintput.keyget!=true)
				{
					Texthint.SendMessage("ShowHint","这个箱子被上了锁");
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
