using Gamejam.Scripts.Controllers.Scripts.Environment;
using UnityEngine;

public class GravitySource : BaseInteractable
{
	[SerializeField] 
	private int priority;

	public int Priority => priority;
	
	public virtual Vector3 GetGravity (Vector3 position) {
		return Physics.gravity;
	}

	void OnEnable () {
		CustomGravity.Register(this);
	}

	void OnDisable () {
		CustomGravity.Unregister(this);
	}

	public override void OnToggle(bool isActive)
	{
		Activate(isActive);
	}

	protected virtual void Activate(bool isActive)
	{
		gameObject.SetActive(isActive);
	}
}