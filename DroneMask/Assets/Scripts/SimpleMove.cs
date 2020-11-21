using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		if( Input.GetKey( KeyCode.UpArrow ) )
		{
			speed += Vector3.forward * Time.deltaTime;
		}
		if( Input.GetKey( KeyCode.DownArrow ) )
		{
			speed += Vector3.back * Time.deltaTime;
		}
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			speed += Vector3.left * Time.deltaTime;
		}
		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			speed += Vector3.right * Time.deltaTime;
		}

		gameObject.transform.Translate( speed );

		speed *= 0.95f;
	}

	[SerializeField]
	Vector3 speed;
}
