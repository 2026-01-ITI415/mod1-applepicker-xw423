using UnityEngine;

public class Basket : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
			
	}

	// Update is called once per frame
	void Update()
	{
		// get current screen pos of the mouse from input
		Vector3 mousePos2D = Input.mousePosition;

		// camera's z pos sets how far to push the mouse into 3D
		// if this line causes a NullReferenceException, select main camera
		// in the hierarchy and set its tag to MainCamera in the Inspector
		mousePos2D.z = -Camera.main.transform.position.z;
		// convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
		// move the x position of this Basket to the x pos of the mouse 
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}
}
