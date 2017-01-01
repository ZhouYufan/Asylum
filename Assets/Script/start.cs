using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {
	public Animator myani;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		myani.SetBool("start",true);
		print ("1");
		StartCoroutine("wait");
//		Application.LoadLevel ("Asylum1");
	}

	void OnClick2()
	{
		Application.Quit(); 
		print ("2");
	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds (4.0f);
		Application.LoadLevel ("Asylum1");
	}
}
