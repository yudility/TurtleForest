using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassCardMapEulerAngles : MonoBehaviour
{
	public	Transform	CompassPivot;

	void Update ()
	{
		float OurHeading = transform.rotation.eulerAngles.y;

		CompassPivot.localRotation = Quaternion.Euler( 0, 0, OurHeading);
	}
}
