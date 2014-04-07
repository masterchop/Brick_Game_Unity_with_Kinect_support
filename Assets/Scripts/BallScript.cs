using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	
	public AudioClip[] blipAudio;
	public static int numBalls= 0;
	// Use this for initialization
	void Start () {
		numBalls++;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyDown("joystick button 1"))rigidbody.velocity = new Vector3(0.1f, 0.1f, 0);
        
		rigidbody.velocity = 11f * (rigidbody.velocity.normalized);
		rigidbody.AddTorque(Vector3.forward * 10f);
		
	
	}
	
	
	public void Die(){
		Destroy(gameObject);
		numBalls--;
		GameObject paddleObject = GameObject.Find("Paddle");
 		PaddleMovement paddleMovement = paddleObject.GetComponent<PaddleMovement>();
		if(numBalls==0)	{paddleMovement.LoseLife();
		AudioSource.PlayClipAtPoint(blipAudio[4], transform.position, 0.1f);}
	}
	public void end()
	{
		numBalls=0;
	}
	
	void OnCollisionEnter (Collision col){
		//AudioClip[] blipAudio2 = get
		if(col.gameObject.CompareTag("wall"))AudioSource.PlayClipAtPoint(blipAudio[0], transform.position, 0.1f);
		if(col.gameObject.CompareTag("Brick"))AudioSource.PlayClipAtPoint(blipAudio[2], transform.position, 0.1f);
		if(col.gameObject.CompareTag("brick2"))AudioSource.PlayClipAtPoint(blipAudio[2], transform.position, 0.1f);
		if(col.gameObject.CompareTag("paddle"))AudioSource.PlayClipAtPoint(blipAudio[3], transform.position, 0.1f);
	}
}
