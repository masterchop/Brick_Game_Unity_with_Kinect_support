using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {
	public GUITexture pauseGUI;
	float paddleSpeed = 10f;
	public GameObject ballPrefab;
	int lives = 3;
	GameObject attachedBall=null;
	GUIText guiLives;
	int levels;
	GUIText guiLevels;
	public int score=0;
	public GUISkin scoreboardSkin;
	protected bool paused=false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(GameObject.Find("guiLives"));
		DontDestroyOnLoad(GameObject.Find("guiLevels"));
		guiLives = GameObject.Find("guiLives").GetComponent<GUIText>();
		guiLives.text = "Lives: " + lives;
		
		SpawnBall();
	}
	
	public void OnLevelWasLoaded(){
		if(Application.loadedLevelName!="Level 1")SpawnBall();
		guiLevels= GameObject.Find("guiLevels").GetComponent<GUIText>();
		guiLevels.text=Application.loadedLevelName;
	}
	
	public void AddPoint( int v){
		score+=v;	
	}
	public void LoseLife(){
		lives--;
		guiLives.text = "Lives: " + lives;
		if(lives>0)
			SpawnBall();
		else {
			//gameover
			Destroy(gameObject);
			Application.LoadLevel("gameover");
		}
	}
	public void SpawnBall() {
 		attachedBall=(GameObject)Instantiate(ballPrefab,transform.position + new Vector3(0, 0.75f, 0),Quaternion.identity);

	}
	
	
	void OnGUI(){
		GUI.skin = scoreboardSkin;
		GUI.Label(new Rect(0,10,300,100),"Score: "+score);
	}
	
	// Update is called once per frame
	void Update () {
		 if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 2")) && paused == false)
   			{
   			paused = true;
		 	Time.timeScale = 0;
			pauseGUI.enabled = true;
		   }
   		else if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 2")) && paused == true) {  
		pauseGUI.enabled = false;
   		paused = false;
		Time.timeScale = 1;}
		if(Input.GetKeyDown("q") || Input.GetKeyDown("joystick button 1"))
   			{
			Application.LoadLevel("gameover");
			if(Application.loadedLevelName=="gameover")Application.Quit();
		   }
		//Left-Right motion
		
		transform.Translate(paddleSpeed*Time.deltaTime*Input.GetAxis("Horizontal"),0,0);
		
		if(transform.position.x > 7.4){
			transform.position= new Vector3 (7.4f, transform.position.y, transform.position.z);
		}
		if(transform.position.x < -7.4){
			transform.position= new Vector3 (-7.4f, transform.position.y, transform.position.z);
		}
		
		if(attachedBall){
			Rigidbody ballRigidBody = attachedBall.rigidbody;
			ballRigidBody.position = transform.position + new Vector3(0, 0.75f, 0);
			
			//fire in the hole!
			if(Input.GetKeyDown("joystick button 3")|| Input.GetButtonDown("Jump")){
		
			ballRigidBody.isKinematic = false;
			ballRigidBody.AddForce(300f*Input.GetAxis("Horizontal"), 300f, 0);
			attachedBall=null;
	}
			}
		}
	
	void OnCollisionEnter (Collision col){
		foreach(ContactPoint contact in col.contacts) {
			if(contact.thisCollider == collider){
				//This is the paddle's contact point
				float english = contact.point.x - transform.position.x;
				contact.otherCollider.rigidbody.AddForce( 300f * english, 0, 0);
			}
		}
	}
	
}
