using UnityEngine;
using System.Collections;

public class PlayerWeapons : MonoBehaviour {
	public GameObject crossHair;
	private bool isPick = false;
	private bool isisPick = false;
	// Use this for initialization
	void Start () {
		crossHair.gameObject.SetActive(false);

		SelectWeapon(0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
			BroadcastMessage("Fire");

		if (Input.GetKeyDown ("1")) {

			crossHair.gameObject.SetActive(false);
			SelectWeapon(0);

		}

		if (Input.GetKeyDown("2")&&isPick) {

			crossHair.gameObject.SetActive(true);
			SelectWeapon(1);
		}
		if (isisPick) {
			SelectWeapon(1);
			isisPick = false;
		}
	
	}

	void SelectWeapon(int index) {
		for (int i = 0; i < transform.childCount; i++) {
			if (i == index)
				transform.GetChild (i).gameObject.SetActive(true);
			else
				transform.GetChild(i).gameObject.SetActive(false);
		}
	}
	void pickUp(bool flag){
		isPick = flag;
		isisPick = true;
		//crossHair.gameObject.SetActive(true);
		crossHair.gameObject.SetActive(true);
		SelectWeapon(1);
	}

}
