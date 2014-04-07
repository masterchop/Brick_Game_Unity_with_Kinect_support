using UnityEngine;
using System.Collections;

public class PlaneScript2 : MonoBehaviour {
	Material newMat;
	
	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(gameObject);
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName=="Level 3"){
			 newMat= Resources.Load("background3", typeof(Material)) as Material;
			GameObject.Find("Plane").renderer.material=newMat;
		}
	
		if(Application.loadedLevelName=="Level 2"){
			 newMat= Resources.Load("background2", typeof(Material)) as Material;
			GameObject.Find("Plane").renderer.material=newMat;
		}
		if(Application.loadedLevelName=="Level 1"){
			 newMat= Resources.Load("background1", typeof(Material)) as Material;
			GameObject.Find("Plane").renderer.material=newMat;
		}
		if(Application.loadedLevelName=="Level 4"){
			 newMat= Resources.Load("background4", typeof(Material)) as Material;
			GameObject.Find("Plane").renderer.material=newMat;
		}
		if(Application.loadedLevelName=="Level 5"){
			 newMat= Resources.Load("background5", typeof(Material)) as Material;
			GameObject.Find("Plane").renderer.material=newMat;
		}
		if(Application.loadedLevelName=="Level 6"){
			 newMat= Resources.Load("background6", typeof(Material)) as Material;
			GameObject.Find("Plane").renderer.material=newMat;
		}
		if(Application.loadedLevelName=="Level 7"){
			 newMat= Resources.Load("background7", typeof(Material)) as Material;
			GameObject.Find("Plane").renderer.material=newMat;
		}
		if(Application.loadedLevelName=="Level 8"){
			 newMat= Resources.Load("background8", typeof(Material)) as Material;
			GameObject.Find("Plane").renderer.material=newMat;
		}
		
		
	
	}
}
