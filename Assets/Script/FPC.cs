using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class FPC : MonoBehaviour {
	public GameObject righthand;
	public GameObject set;
	public Rigidbody bulletPrefab;
	public float bulletspeed=30.0f;
	public static int bulletnumber=100;
	public static bool circle = true;
	public AudioClip shootSound;
	public AudioClip walkSound;
	public AudioClip getbulletSound;
	public static int life=10;
	public static bool Fpress = false;
	public GUITexture zhunxin;
	public Text Texthint;
	public Texture2D[]hudcharge;
	public GUITexture chargeHudGUI;
	public GUIText bulletnumberappear;
	public Animator myani;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		chargeHudGUI.texture = hudcharge[life];
		bulletnumberappear.text = "×" + bulletnumber;
		if(Input.GetKeyDown (KeyCode.Z)) 
		{
			if(bulletnumber>0)
			{ 
			   StartCoroutine("bulletwait");
			}
	    
		    if(bulletnumber<=0)
		    {
			   print("you have no bullet");
		    }
		}
		if(life==0)
		{
			myani.SetBool("die",true);
			StartCoroutine("wait");
			life=10;
		}
		if(Input.GetKeyDown (KeyCode.W))
		{
				GetComponent<AudioSource>().PlayOneShot(walkSound);

		}
		if(Input.GetKeyUp (KeyCode.W))
		{
			GetComponent<AudioSource>().Stop();
		}
		if(Input.GetKeyDown (KeyCode.A))
		{
			GetComponent<AudioSource>().PlayOneShot(walkSound);
			
		}
		if(Input.GetKeyUp (KeyCode.A))
		{
			GetComponent<AudioSource>().Stop();
		}
		if(Input.GetKeyDown (KeyCode.S))
		{
			GetComponent<AudioSource>().PlayOneShot(walkSound);
			
		}
		if(Input.GetKeyUp (KeyCode.S))
		{
			GetComponent<AudioSource>().Stop();
		}
		if(Input.GetKeyDown (KeyCode.D))
		{
			GetComponent<AudioSource>().PlayOneShot(walkSound);
			
		}
		if(Input.GetKeyUp (KeyCode.D))
		{
			GetComponent<AudioSource>().Stop();
		}
//		if(Input.GetKeyDown (KeyCode.F))
//		{
//			if()
//			{
//				Texthint.SendMessage("ShowHint","获得子弹");
//				bulletnumber=bulletnumber+5;
//				Destroy(col.gameObject);
//			}
//		}
//		if (Input.GetKeyUp (KeyCode.F))
//		{
//			Fpress = false;
//			print(Fpress);
//		}

    }

	IEnumerator bulletwait()
	{
	    if(circle==true)
	    {
		   righthand.gameObject.GetComponent<Animation>().Play("GunStart");
		   circle=false;
		   yield return new WaitForSeconds (0.3f);

			Rigidbody newbullet=Instantiate(bulletPrefab,set.transform.position,set.transform.rotation)as Rigidbody;
	       GetComponent<AudioSource>().PlayOneShot(shootSound);
	       newbullet.velocity=transform.forward*bulletspeed;
	       newbullet.name = "bullet";
	
	       bulletnumber--;
		
		}
		else
		{
			Rigidbody newbullet=Instantiate(bulletPrefab,set.transform.position,set.transform.rotation)as Rigidbody;
			GetComponent<AudioSource>().PlayOneShot(shootSound);
			newbullet.velocity=transform.forward*bulletspeed;
			newbullet.name = "bullet";

			bulletnumber--;
		}
	}
	
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "bulletpacket") 
		 {
			Texthint.SendMessage("ShowHint","获得5颗子弹");
			bulletnumber=bulletnumber+5;
			Destroy(col.gameObject);

		 }
		if (col.gameObject.name == "MediPack") 
		 {
			Texthint.SendMessage("ShowHint","你的生命恢复了");
			life=10;
			Destroy(col.gameObject);
		 }
		if (col.gameObject.name == "Flashlight")
		{
			zhunxin.enabled=true;
			Texthint.SendMessage("ShowHint","获得准心");
			Destroy(col.gameObject);
		}

	}


	void gunback()
	{
		righthand.gameObject.GetComponent<Animation>().Play("GunBack");
		circle = true;
	}

	IEnumerator wait()
	{

		yield return new WaitForSeconds (4.0f);
		Application.LoadLevel ("Asylumstart");
	}
//
//	IEnumerator Walk()
//	{
//
//		audio.PlayOneShot(walkSound);
//		canmusic =false;
//	}
}