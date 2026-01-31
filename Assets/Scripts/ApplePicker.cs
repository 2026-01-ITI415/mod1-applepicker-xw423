using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
	[Header("Inscribed")]
	public GameObject baseketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	private List<GameObject> basketList;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		basketList = new List<GameObject>();

		for( int i = 0; i < numBaskets; i++ )
		{
			GameObject tBasketGO = Instantiate<GameObject>( baseketPrefab );
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i );
			tBasketGO.transform.position = pos;
			basketList.Add( tBasketGO );
		}
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void AppleMissed()
	{
		// Destroy all falling Apples
		GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
		foreach( GameObject tempGO in appleArray )
			Destroy( tempGO );

		// destroy a basket 
		// get index of basket at the end of the list
		int basketIndex = basketList.Count -1;
		// get reference to that basket 
		GameObject basketGO = basketList[basketIndex];
		// remove basket from list and destroy it
		basketList.RemoveAt(basketIndex);
		Destroy(basketGO);

		// restart game when game over
		if( basketList.Count == 0 )
		{
			SceneManager.LoadScene( "ApplePicker" );
		}
	}
}
