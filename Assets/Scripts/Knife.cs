using UnityEngine;
using System.Collections;

public class Knife : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fire() {
		StartCoroutine("KnifeFire");
	}

	IEnumerator KnifeFire() {
		audio.Play ();
		transform.GetChild(0).animation.Play("MeleeSwingLeft");

		yield return new WaitForSeconds(0.5f);

		audio.Play ();
		transform.GetChild(0).animation.Play("MeleeSwingRight");

		yield return new WaitForSeconds(1.0f);
	}
}
