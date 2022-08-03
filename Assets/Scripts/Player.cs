using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private GameObject car;
	public GUIText text;
	public GUIText gameOver;
	public GUITexture fadeTexture;
	public GUIText HpValue;

	//public string levelToLoad;
	public int employCount = 0;
	private bool flag = true;
	private bool flag1 = true;
	private bool over = true;
	private float hp = 100.0f;

	// Use this for initialization
	void Start () {
		car = GameObject.FindWithTag("Car");
		gameOver.enabled = false;


	}
	void OnControllerColliderHit(ControllerColliderHit hit)
	{

		if (hit.gameObject.tag == "Car") {
		
			text.SendMessage("ShowHint","按F驾驶");
			if(Input.GetKeyDown("f"))
			{
				car.SendMessage("canMove");
				this.transform.parent = car.transform;
				this.gameObject.SetActive(false);
				//Destroy (this.gameObject);
			}
		}
		if (hit.gameObject.tag == "door") {
			if(hit.gameObject.name == "obj_26"&&flag){
			
				hit.gameObject.animation.Play("doorOpen");
				flag = false;
			}
			if(hit.gameObject.name == "obj_49"&&flag1)
			hit.gameObject.animation.Play("doorOpen2");
			flag1 = false;
		}

	}
	// Update is called once per frame
	void Update () {

		if (employCount >= 4) {

			GameObject.Find("SoldierSpawn").SendMessage("stopProduction");

			if(over&&GameObject.FindGameObjectWithTag ("Soldier") == null){//会多生产一次
					gameOverText();
				//Debug.Log (employCount);
					GameObject.Find("gameOver").gameObject.animation.Play("gameovertext");
				Instantiate(fadeTexture);

				over = false;
			}
		}

	}
	void gameOverText(){
		gameOver.enabled = true;
	}
	void scorAdd(){
		employCount++;
	}
	void ApplyDamage(float damage){
		if (hp >= 5)
			hp -= damage;
		else
			hp = 0;
		HpValue.text = hp+"";

		if (hp <= 0) {
			gameOver.enabled = true;
			gameOver.text = "再接再励，下次吃鸡！";
			if(over){
			gameOver.animation.Play("gameovertext");
				Instantiate(fadeTexture);
	
				over = false;
			}
		
		}
	}
}

