using UnityEngine;
using System.Collections;

public class M1911 : MonoBehaviour {
	public AudioClip fireSound;
	public AudioClip reloadSound;

	public Rigidbody bulletShellPrefab;
	Transform bulletShell;
	public Renderer muzzleFlash;
	int frameID = -1;

	public ParticleEmitter hitParticle;
	public float range = 100.0f;
	public float force = 500.0f;

	Vector3 shellEjectDirection;
	public float shellForce = 0.2f;//overall movement force of ejected shell
	public float shellUp = 0.75f;//random vertical direction to apply to shellForce
	public float shellSide = 1.0f;//random horizontal direction to apply to shellForce
	public float shellForward = 0.1f;//random forward direction to apply to shellForce

	public GameObject player;

	enum STATUS {FIRE, RELOAD};
	STATUS status;
	bool hasFire = true;

	public float damage = 20.0f;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
		hitParticle.emit = false;
		player = GameObject.FindWithTag("Player");
		bulletShell = transform.FindChild("BulletShell");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.GetChild(0).animation.isPlaying)
			return;

		if (Input.GetKeyDown("r")) {
			status = STATUS.RELOAD;
			StartCoroutine("M1911Play", status);
		}
	}

	void LateUpdate() {
		if (!muzzleFlash)
			return;

		if (frameID == Time.frameCount) {
			muzzleFlash.transform.localRotation = Quaternion.AngleAxis(Random.value * 360, 
			                                                           Vector3.forward);
			muzzleFlash.enabled = true;
		}
		else {
			muzzleFlash.enabled = false;
		}
	}

	void Fire() {
		if (transform.GetChild(0).animation.isPlaying && status == STATUS.RELOAD)
			return;
		if (transform.GetChild(0).animation.isPlaying)
			transform.GetChild(0).animation.Stop();

		if (frameID + 10 < Time.frameCount)
			hasFire = false;

		frameID = Time.frameCount;
		status = STATUS.FIRE;
		StartCoroutine("M1911Play", status);
	}

	IEnumerator M1911Play(STATUS status) {
		string anim = " ";
		AudioClip clip = null;

		if (status == STATUS.FIRE) {
			anim = "Fire";
			clip = fireSound;
		} 
		else if (status == STATUS.RELOAD) {
			anim = "Reload";
			clip = reloadSound;
		}
		transform.GetChild(0).animation.Play(anim);
		audio.clip = clip;
		audio.Play ();

		FireOneShot();

		yield return new WaitForSeconds(1.5f);
		
	}

	void FireOneShot() {
		RaycastHit hit;

		if (hasFire)
			return;

		hasFire = true;

		Rigidbody bulletShellObject = Instantiate(bulletShellPrefab, bulletShell.position, bulletShell.rotation)
			as Rigidbody;
		shellEjectDirection = new Vector3((shellSide * 0.7f) + (shellSide * 0.4f * Random.value), 
		                                  (shellUp * 0.6f) + (shellUp * 0.5f * Random.value),
		                                  (shellForward * 0.4f) + (shellForward * 0.2f * Random.value));

		bulletShellObject.AddForce(shellForce * transform.TransformDirection(shellEjectDirection), ForceMode.Impulse);

		Vector3 direction = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, direction, out hit, range)) {
			if (hit.rigidbody)
				hit.rigidbody.AddForceAtPosition(force * direction, hit.point);

			hitParticle.transform.position = hit.point;
			hitParticle.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
			hitParticle.Emit();

			hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

			//if (hit.transform.gameObject.tag == "Coin") {
			//	Destroy (hit.transform.gameObject);
			//	player.SendMessage("Pickup");
			//}

		}
	}
}
