using StarterAssets;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {
	[SerializeField, Range(1f, 360f)]
	float rotationSpeed = 90f;

	[SerializeField, Range(-89f, 89f)]
	float minVerticalAngle = -45f, maxVerticalAngle = 45f;

	[SerializeField, Min(0f)]
	float upAlignmentSpeed = 360f;

	[SerializeField]
	LayerMask obstructionMask = -1;

	[SerializeField] private StarterAssetsInputs input;

	Vector2 orbitAngles = new Vector2(0, 0f);

	Quaternion gravityAlignment = Quaternion.identity;

	Quaternion orbitRotation;
	
	[Header("Cinemachine")]
	[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
	public GameObject CinemachineCameraTarget;

	void OnValidate () {
		if (maxVerticalAngle < minVerticalAngle) {
			maxVerticalAngle = minVerticalAngle;
		}
	}

	void Awake () {
		transform.localRotation = orbitRotation = Quaternion.Euler(orbitAngles);
	}

	void LateUpdate () {
		UpdateGravityAlignment();
		if (ManualRotation())
		{
			orbitRotation = Quaternion.Euler(orbitAngles);
		}
		
		Quaternion lookRotation = gravityAlignment * orbitRotation;

		CinemachineCameraTarget.transform.rotation = lookRotation;
	}
	
	void UpdateGravityAlignment () {
		
		return;
		Vector3 fromUp = gravityAlignment * Vector3.up;
		Vector3 toUp = CustomGravity.GetUpAxis(CinemachineCameraTarget.transform.position);
		float dot = Mathf.Clamp(Vector3.Dot(fromUp, toUp), -1f, 1f);
		float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
		float maxAngle = upAlignmentSpeed * Time.deltaTime;

		Quaternion newAlignment =
			Quaternion.FromToRotation(fromUp, toUp) * gravityAlignment;
		if (angle <= maxAngle) {
			gravityAlignment = newAlignment;
		}
		else {
			gravityAlignment = Quaternion.SlerpUnclamped(
				gravityAlignment, newAlignment, maxAngle / angle
			);
		}
	}

	bool ManualRotation () {
		Vector2 playerInput = new Vector2(input.look.y, input.look.x);
		const float e = 0.001f;
		if (playerInput.x < -e || playerInput.x > e || playerInput.y < -e || playerInput.y > e) {
			orbitAngles += rotationSpeed * Time.unscaledDeltaTime * playerInput;
			return true;
		}
		return false;
	}
}
