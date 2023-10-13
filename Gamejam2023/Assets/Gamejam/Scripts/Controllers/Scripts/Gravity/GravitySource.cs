using Gamejam.Scripts.Controllers.Scripts.Environment;
using UnityEngine;

public class GravitySource : BaseInteractable
{
	[SerializeField] 
	private int priority;

	public int Priority => priority;
	
	public bool WasActive { get; protected set; }

	protected bool shouldDisable;

	public void DisableIfNeeded()
	{
		if (shouldDisable)
		{
			shouldDisable = false;
			gameObject.SetActive(false);
		}
	}
	
	public virtual Vector3 GetGravity (Vector3 position, out bool isActive)
	{
		isActive = true;
		return Physics.gravity;
	}

	public void Activate()
	{
		WasActive = true;
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