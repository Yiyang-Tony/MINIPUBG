using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CarController : MonoBehaviour {
	public float moveSpeed = 5.0f;
	public float rotateSpeed = 60f;
	private GameObject Front_tire,Front_tire01,tire_rear,tire_rear01,light,speedLight;
	private bool isMove = false;
	public AudioClip accelerationHigh;
	public AudioClip accelerationLow;


	//public GameObject player;

	// Use this for initialization
	void Start () {

		Front_tire = GameObject.Find("Front_tire");
		Front_tire01 = GameObject.Find("Front_tire01");
		tire_rear = GameObject.Find("tire_rear");
		tire_rear01 = GameObject.Find("tire_rear01");
		light = GameObject.Find("Light");
		speedLight = GameObject.Find("speedLight");
		light.SetActive (false);
		speedLight.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		speedLight.SetActive (false);
		if (isMove) {
			if(Input.GetKeyDown("g")){
				transform.FindChild("First Person Controller").gameObject.SetActive(true);
				transform.FindChild("First Person Controller").parent = this.transform.parent;
				isMove = false;
				this.audio.Pause();

			}
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				speedLight.SetActive(true);
				audio.PlayOneShot(accelerationHigh);
				moveSpeed += 5.0f;
			}
			float h = Input.GetAxis ("Horizontal") * Time.deltaTime * rotateSpeed;
			float v = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;
			this.transform.Translate (0, 0, v);
			this.transform.Rotate (0, h, 0);
			if (Input.GetKeyDown ("w")) 
			{

				//moveForward ("front");
				light.SetActive(false);
			}
		
			if (Input.GetKeyDown ("s"))
			{
				audio.PlayOneShot(accelerationLow);
				//moveForward ("back");
				light.SetActive(true);
			}
				
		}
	}

	void canMove(){
		isMove = true;
		this.audio.Play ();
	}


	//void moveForward(string forward){
		//if ("front" == forward) {
		//	Front_tire.animation.Play ("roll");
		//	Front_tire01.animation.Play ("roll");
		//	tire_rear.animation.Play ("roll");
		//	tire_rear01.animation.Play ("roll");
		//}
		//if ("back" == forward) {
		//	Front_tire.animation.Play ("rollBack");
		//	Front_tire01.animation.Play ("rollBack");
		//	tire_rear.animation.Play ("rollBack");
		//	tire_rear01.animation.Play ("rollBack");
		//}
	//}
}
