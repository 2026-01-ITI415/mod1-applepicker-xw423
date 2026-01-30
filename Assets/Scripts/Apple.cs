using UnityEngine;

public class Apple : MonoBehaviour
{
	// bottom boundary
	public static float bottomY = -20f;

	// Update is called once per frame
	void Update()
	{
		if( transform.position.y < bottomY )
			Destroy( this.gameObject );
	}
}
