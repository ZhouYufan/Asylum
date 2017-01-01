using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finaldoor : MonoBehaviour {
	public Text Texthint;
	public Canvas inputfield;
	public Text inputtext;
	public Animator myani;
	public bool win=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(win)
		{

			StartCoroutine("wait");

		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name=="First Person Controller")
		{
			if(!win)
			{
			   inputfield.enabled=true;
			}
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
		if(inputtext.text=="4365")
		{
			inputfield.enabled=false;
			gameObject.GetComponent<Animation>().Play("finaldooropen");
			Texthint.SendMessage("ShowHint","m9(^∀^)YOU WIN");
			win=true;

		}
		if(inputtext.text!="4365")
		{
			inputfield.enabled=false;
			Texthint.SendMessage("ShowHint","m9(^∀^)哎哟不对哦");
			StartCoroutine("erro");
		}
	}
	IEnumerator erro()
	{
		yield return new WaitForSeconds (3.0f);
		inputfield.enabled=true;
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (2.0f);
		myani.SetBool("start",true);
		yield return new WaitForSeconds (4.0f);
		Application.LoadLevel ("Asylumstart");
	}
}
