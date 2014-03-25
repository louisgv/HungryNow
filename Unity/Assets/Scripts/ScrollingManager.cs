using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScrollingManager : MonoBehaviour {

	public Vector2 scrollingSpeed = new Vector2 (2,2);
	public Vector2 direction= new Vector2 (-1,0);
	private SpriteRenderer myLayer;

	public bool isLinkedToCamera = false;

	public bool isLooping = false;
	private List<Transform> backgroundPart;

	private Transform BGSkyline;
	// Use this for initialization
	void Start () {
		//myLayer = renderer.GetComponent<SpriteRenderer>();
		BGSkyline = transform.Find("BGSkyline");
		backgroundPart = new List<Transform>();

		if (isLooping){
			for (int i = 0; i < BGSkyline.childCount; ++i){
				Transform child = BGSkyline.GetChild(i);

				//Add only the visible Children (check)
				if (child.renderer != null){
					backgroundPart.Add(child);

				}
			}
			backgroundPart = backgroundPart.OrderBy(
				t => t.position.x
				).ToList();
		}
	}
	
	// Update is called once per frame
	void Update () {

		// Movement
		Vector3 movement = new Vector3(
			scrollingSpeed.x * direction.x,
			scrollingSpeed.y* direction.y, 
			0	);

		movement *= Time.deltaTime;
		transform.Translate(movement);

		// Move the Camera
		if (isLinkedToCamera){
			Camera.main.transform.Translate(movement);
		}

		if (isLooping){
			Transform firstChild = backgroundPart.FirstOrDefault();

			if (firstChild != null){

				if (firstChild.position.x < Camera.main.transform.position.x){
					// If the child is already on the left, we test if it's outside and needs to ber ecycled
					if (firstChild.renderer.IsVisibleFrom(Camera.main) == false){
						Transform lastChild = backgroundPart.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - 
						                    lastChild.renderer.bounds.min);

						//Set the Child to be after the last Child.
						firstChild.position = new Vector3 (lastPosition.x + lastSize.x, 
						                                   firstChild.position.y, 
						                                   firstChild.position.z);
						backgroundPart.Remove(firstChild);
						backgroundPart.Add (firstChild);
					}
				}
			}
		}
	}
}
