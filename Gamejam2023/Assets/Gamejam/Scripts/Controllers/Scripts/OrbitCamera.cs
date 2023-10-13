using StarterAssets;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {
	[SerializeField, Range(1f, 360f)]
	float rotationSpeed = 90f;

	[SerializeField, Range(-89f, 89f)]
	float minVerticalAngle = -45f, maxVerticalAngle = 45f;

	[SerializeField] private StarterAssetsInputs input;

	Vector2 orbitAngles = Vector2.zero;

	Quaternion orbitRotation;
	
	public Vector2 OrientationAngles => orbitAngles;

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
		if (ManualRotation())
		{
			orbitRotation = Quaternion.Euler(orbitAngles);
		}
		
		CinemachineCameraTarget.transform.localRotation = orbitRotation;
	}

	bool ManualRotation () {
		Vector2 playerInput = new Vector2(input.look.y, input.look.x);
		const float e = 0.001f;
		if (playerInput.x < -e || playerInput.x > e || playerInput.y < -e || playerInput.y > e) {
			orbitAngles += rotationSpeed * Time.unscaledDeltaTime * playerInput;
			if (orbitAngles.x > maxVerticalAngle)
			{
				orbitAngles.x = maxVerticalAngle;
			}

			if (orbitAngles.x < minVerticalAngle)
			{
				orbitAngles.x = minVerticalAngle;
			}
			return true;
		}
		return false;
	}
}
