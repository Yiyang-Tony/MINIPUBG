using UnityEngine;
using System.Collections;

public class PickPistol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			//Debug.Log(GameObject.Find("Car").transform.FindChild("First Person Controller").transform.FindChild("Main Camera/Weapons"));
			//GameObject.Find("Car").transform.FindChild("First Person Controller").transform.FindChild("Main Camera/Weapons/gun").gameObject.SetActive(true);
			GameObject.Find("First Person Controller").transform.FindChild("Main Camera/Weapons").SendMessage("pickUp",true);
			Destroy(this.gameObject);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
