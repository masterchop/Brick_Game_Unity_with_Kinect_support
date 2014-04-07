using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	
	public AudioClip[] songs;
	int currentSong=-1;
	public GameObject ballPrefab;
	GameObject attachedBall=null;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		 
	}
	// Update is called once per frame
	void Update () {
		
		if(audio.isPlaying == false){
			currentSong++;
			if(currentSong>=songs.Length)
				currentSong=0;
		audio.clip = songs[currentSong];
		audio.Play();}
	
	
	}
	public void SpawnExtraBall(){
		attachedBall=(GameObject)Instantiate(ballPrefab,transform.position + new Vector3(0, 2f, 0),Quaternion.identity);
		Rigidbody ballRigidBody = attachedBall.rigidbody;
		ballRigidBody.isKinematic = false;
		ballRigidBody.AddForce(300f, 300f, 0);
		attachedBall=null;
	}
}

