using UnityEngine;
using System.Collections;

public class Quitgame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q") || Input.GetKeyDown("joystick button 1"))
   			{
			Application.Quit();
		   }
	
	}
}
