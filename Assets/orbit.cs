using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour
{
    [SerializeField]
    public Transform focus = default;

    [SerializeField, Range(1f, 20f)]
    float distance = 5f;

    [SerializeField, Min(0f)]
    float focusRadius = 1f;
	Vector3 focusPoint;
	Vector2 orbitAngles = new Vector2(20f, 0f);
	[SerializeField, Range(1f, 360f)]
	float rotationSpeed = 90f;
	void Start()
	{
		focusPoint = focus.position;
	}

	void LateUpdate()
	{
		UpdateFocusPoint(); 
		ManualRotation();
		Quaternion lookRotation = Quaternion.Euler(orbitAngles);
		Vector3 lookDirection = lookRotation * Vector3.forward;
		Vector3 lookPosition = focusPoint - lookDirection * distance;
		transform.SetPositionAndRotation(lookPosition, lookRotation);
	}
	void ManualRotation()
	{
		Vector2 input = new Vector2(
			0,
			Input.GetAxis("Horizontal")
		);
		const float e = 0.001f;
		if (input.x < -e || input.x > e || input.y < -e || input.y > e)
		{
			orbitAngles += rotationSpeed * Time.unscaledDeltaTime * input;
		}
	}
	void UpdateFocusPoint()
	{
		Vector3 targetPoint = focus.position;
		if (focusRadius > 0f)
		{
			float distance = Vector3.Distance(targetPoint, focusPoint);
			if (distance > focusRadius)
			{
				focusPoint = Vector3.Lerp(
					targetPoint, focusPoint, focusRadius / distance
				);
			}
		}
		else
		{
			focusPoint = targetPoint;
		}
	}
}
