using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	public AudioClip[] blipAudio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	rigidbody.AddTorque(Vector3.forward * 10f);
		
	}
	
	void OnCollisionEnter(Collision col){
		if(this.gameObject.CompareTag("power1")){
			AudioSource.PlayClipAtPoint(blipAudio[0], transform.position, 0.1f);
			PaddleMovement paddleMovement = GameObject.Find("Paddle").GetComponent<PaddleMovement>();
			paddleMovement.AddPoint(10);
		}
		if(this.gameObject.CompareTag("power2")){
			AudioSource.PlayClipAtPoint(blipAudio[1], transform.position, 0.1f);
			MusicScript musicscript = GameObject.Find("Speaker").GetComponent<MusicScript>();
			musicscript.SpawnExtraBall();
		}
		
		Destroy(gameObject);
	}
}
