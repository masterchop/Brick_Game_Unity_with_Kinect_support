using UnityEngine;
using System.Collections;

public class BrickDestruction : MonoBehaviour {
	public GameObject effects;
	static int numBricks = 0;
	public int pointValue=1;
	public int hitPoints=1;
	public int powerUpChance = 3;
	public GameObject[] powerUpPrefabs;
	// Use this for initialization
	void Start () {
	numBricks++;
		
	}
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision col){
		hitPoints--;
		//if(GameObject.FindGameObjectsWithTag("brick2"))
		//{
		
		if(gameObject.name=="BrickHard"){
			if(hitPoints==2){
				Material newMat = Resources.Load("BrickHard2", typeof(Material)) as Material;
				gameObject.renderer.material = newMat;}
			if(hitPoints==1){
				Material newMat = Resources.Load("BrickHard3", typeof(Material)) as Material;
				gameObject.renderer.material = newMat;}
		}
		if(hitPoints<=0){
            Instantiate(effects, transform.position, transform.rotation);
			Die();
		}
	}
	
	void Die(){
		Destroy(gameObject);
		PaddleMovement paddleMovement = GameObject.Find("Paddle").GetComponent<PaddleMovement>();
		paddleMovement.AddPoint(pointValue);
		numBricks--;
		if(Random.Range(0, powerUpChance)==0){
			Instantiate( powerUpPrefabs[Random.Range(0,powerUpPrefabs.Length)], transform.position, Quaternion.identity);
		}
		if(numBricks<=0){
			GameObject[] paddleObject = GameObject.FindGameObjectsWithTag("ball");
			BallScript ballScript = paddleObject[0].GetComponent<BallScript>();
			ballScript.end();
			LoadLevel();
		}
	}
	void   LoadLevel()
	{	
		if(Application.loadedLevelName=="Level 1")Application.LoadLevel("Level 2");
		if(Application.loadedLevelName=="Level 2")Application.LoadLevel("Level 3");
		if(Application.loadedLevelName=="Level 3")Application.LoadLevel("Level 4");
		if(Application.loadedLevelName=="Level 4")Application.LoadLevel("Level 5");
		if(Application.loadedLevelName=="Level 5")Application.LoadLevel("Level 6");
		if(Application.loadedLevelName=="Level 6")Application.LoadLevel("Level 7");
		if(Application.loadedLevelName=="Level 7")Application.LoadLevel("Level 8");
		if(Application.loadedLevelName=="Level 8")Application.LoadLevel("win");
	}
}
