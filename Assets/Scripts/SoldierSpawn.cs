using UnityEngine;
using System.Collections;

public class SoldierSpawn : MonoBehaviour {
	public GameObject soldierPrefab;
	private bool isProduction = true;

	// Use this for initialization
	void Start () {
	}
	void stopProduction(){
		isProduction = false;
	}
	// Update is called once per frame
	void Update () {

		if (GameObject.FindGameObjectWithTag ("Soldier") == null && isProduction) {
				Respawn ();
			}
		}


	void Respawn() {
		Random.seed = (int)System.DateTime.Now.Ticks;

		Vector3 pos = transform.position;
		pos.x = pos.x + 50 * Random.value;
		pos.z = pos.z + 50 * Random.value;
		GameObject obj = Instantiate(soldierPrefab, pos, transform.rotation) as GameObject;
		pos.x += 10 * Random.value;
		pos.z += 20 * Random.value;
		GameObject obj1 = Instantiate(soldierPrefab, pos, transform.rotation) as GameObject;
	}
}
