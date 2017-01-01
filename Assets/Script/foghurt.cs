using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class foghurt : MonoBehaviour {
	public bool fogtime=false;
	public bool foglawed=true;
	public bool dotrigger=false;
	public Text Texthint;
	public GUITexture water;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fogtime)
		{
			StartCoroutine("foglaw");
		}
		if(Input.GetKeyDown (KeyCode.F))
		{
			if(dotrigger)
			{
				if(boxopen2.getwater==true)
				{
					Destroy(gameObject);
				    Texthint.SendMessage("ShowHint","使用了中和喷雾剂");
					water.enabled=false;
				}
			}
		}


	}
	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.name == "First Person Controller")
		{
			dotrigger = true;
			fogtime=true;
			Texthint.SendMessage("ShowHint","正在被毒气侵蚀");
		}
	}
	void OnTriggerExit(Collider col)
	{

		if (col.gameObject.name == "First Person Controller")
		{
			fogtime=false;
			dotrigger = false;
		}
	}
	IEnumerator foglaw()
	{
		if(foglawed)
		{
		    FPC.life--;
		    print (FPC.life);
		    foglawed=false;
		    yield return new WaitForSeconds (1.0f);
		    foglawed=true;
		}
	}
}
