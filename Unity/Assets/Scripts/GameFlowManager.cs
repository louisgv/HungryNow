using UnityEngine;
using System.Collections;

public class GameFlowManager : MonoBehaviour {

	public int countOffset = 2;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	//float timer = 3;
	// Use this for initialization
	void Start () {
		StartCoroutine(CountSeconds());
	}

	IEnumerator CountSeconds(){
		int seconds = 0;
		while (true){
			for (float timer = 0; timer < 1; timer += Time.deltaTime)
				yield return 0;
			seconds++;
			if ((seconds%countOffset)==0)
				Debug.Log(seconds +" seconds have passed.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Time.realtimeSinceStartup);
	
	}

}
