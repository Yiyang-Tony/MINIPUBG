using UnityEngine;
using System.Collections;

public class CarDoorManager : MonoBehaviour {
	private bool isOpen = true;
	private float openTime = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	IEnumerator OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Car"&&isOpen) {
			this.gameObject.animation.Play("carDoorOpen");
			isOpen = false;
			openTime = 0;
			yield return new WaitForSeconds(2.0f);

		}
	}
	// Update is called once per frame
	void Update () {
		openTime += Time.deltaTime;
		if (openTime >= 5.0f&&!isOpen) {
			this.gameObject.animation.Play("carDoorClose");
			openTime = 0;
			isOpen = true;
		}
	}
}
