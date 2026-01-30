using UnityEngine;

public class AppleTree : MonoBehaviour
{
	[Header("Inscribed")]

	// Prefab for instantiating apples
	public GameObject applePrefab;

	// speed at which the AppleTree moves
	public float speed = 1f;
	// distance where AppleTree turns around
	public float leftAndRightEdge = 10f;
	// chance tha the AppleTree will change directions
	public float changeDirChance = 0.1f;
	// seconds between Apples instantiations
	public float appleDropDelay = 1f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// start dropping apples
		Invoke( "DropApple", 2f );
	}

	// Update is called once per frame (frame-based update)
	void Update()
	{
		// basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		// changing direction
		if( pos.x < -leftAndRightEdge )
			speed = Mathf.Abs(speed);
		else if( pos.x > leftAndRightEdge )
			speed = -Mathf.Abs(speed);
	}

	// time-based update (50 times a second)
	void FixedUpdate() {
		// change directions randomly time-based
		if( Random.value < changeDirChance )
			speed *= -1;
	}
	
	void DropApple() {
		GameObject apple = Instantiate<GameObject>( applePrefab );
		apple.transform.position = transform.position;
		Invoke( "DropApple", appleDropDelay );
	}
}
