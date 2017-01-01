using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class leveropen2 : MonoBehaviour {
	public GameObject spike;
	public bool dotrigger=false;
	public Text Texthint;
	public bool canopen=true;
	public int keyframe=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.F))
		{
			if(dotrigger)
			{
				Texthint.SendMessage("ShowHint","把手似乎被卡住了，长按F试试");
			}
		}	
		if (Input.GetKey(KeyCode.F))
		{
			//记录按下的帧数
			keyframe++;
	
		}
		if (Input.GetKeyUp (KeyCode.F))
		{
			//抬起后清空帧数
			keyframe=0;

		}
		if(keyframe>=80)
		{
			if(canopen&&dotrigger)
			{
				gameObject.GetComponent<Animation>().Play("opendoor");
				spike.GetComponent<Animation>().Play("spikes");
				canopen=false;
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name=="First Person Controller")
		{
			dotrigger=true;
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
