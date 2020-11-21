using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		Vector3 translate = Vector3.zero;

		if( Input.GetKey( KeyCode.UpArrow ) )
		{
			translate += Vector3.forward;
		}
		if( Input.GetKey( KeyCode.DownArrow ) )
		{
			translate += Vector3.back;
		}
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			translate += Vector3.left;
		}
		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			translate += Vector3.right;
		}
		transform.Translate( translate * speed );
    }

	[SerializeField]
	float speed = 0.5f;
}
