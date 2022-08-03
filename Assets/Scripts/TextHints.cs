using UnityEngine;
using System.Collections;

public class TextHints : MonoBehaviour {
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (guiText.enabled) {
			timer += Time.deltaTime;
			if(timer>=1.5)
			{
				guiText.enabled = false;
				timer = 0;
			}
		}
	}
	void ShowHint(string message)
	{
		guiText.text = message;
		if (!guiText.enabled) {
			guiText.enabled = true;
		}
	}

}
