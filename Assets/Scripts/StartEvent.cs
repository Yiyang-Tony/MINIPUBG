using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]
public class StartEvent : MonoBehaviour {

	public AudioClip beep;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public GUITexture loadGUI;

	void start(){
		this.gameObject.SetActive (true);
	}

	void OnMouseEnter() {
		guiTexture.texture = rollOverTexture;
	}
	void OnMouseExit() {
		guiTexture.texture = normalTexture;
	}
	
	IEnumerator OnMouseUp() {
		audio.PlayOneShot (beep);
		yield return new WaitForSeconds(0.35f);
		Instantiate (loadGUI);
		this.gameObject.SetActive (false);
	}
}
