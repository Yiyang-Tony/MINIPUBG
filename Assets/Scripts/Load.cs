using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {
	public string levelToLoad;
	void loadAnim(){
		Application.LoadLevel (levelToLoad);
	}
	// Use this for initialization
	void Start () {
		//Rect currentRes = new Rect (-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
		//guiTexture.pixelInset = currentRes;
		animation.Play("load");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
