using UnityEngine;
using System.Collections.Generic;
using Gamejam.Scripts.Controllers.Scripts.Environment;

public static class CustomGravity {

	static List<GravitySource> sources = new List<GravitySource>();
	private static List<ForceActor> forces = new List<ForceActor>();

	public static Vector3 Forward = Vector3.forward;

	public static void Register (GravitySource source) {
		Debug.Assert(
			!sources.Contains(source),
			"Duplicate registration of gravity source!", source
		);
		sources.Add(source);
	}

	public static void Unregister (GravitySource source) {
		Debug.Assert(
			sources.Contains(source),
			"Unregistration of unknown gravity source!", source
		);
		sources.Remove(source);
	}

	public static void RegisterForce(ForceActor force)
	{
		forces.Add(force);
	}
	
	public static void UnregisterForce(ForceActor force)
	{
		forces.Remove(force);
	}

	public static Vector3 GetForce(Vector3 position)
	{
		Vector3 force = Vector3.zero;
		foreach (var forceActor in forces)
		{
			force += forceActor.GetForce(position);
		}

		return force;
	}
	
	public static Vector3 GetGravity (Vector3 position) {
		Vector3 g = Vector3.zero;
		for (int i = 0; i < sources.Count; i++) {
			g += sources[i].GetGravity(position, out var isActive);
		}
		return g;
	}

	public static Vector3 GetGravity (Vector3 position, out Vector3 upAxis) {
		Vector3 g = Vector3.zero;
		int priority = 0;
		for (int i = sources.Count - 1; i >= 0; i--)
		{
			var sourceGravity = sources[i].GetGravity(position, out var isActive);
			if (!isActive)
			{
				continue;
			}
			
			if (sourceGravity.sqrMagnitude > 0 && sources[i].Priority > priority)
			{
				priority = sources[i].Priority;
				Forward = sources[i].transform.forward;
				sources[i].Activate();
				g = sourceGravity;
			}
			else if (sources[i].Priority == priority)
			{
				if (g.sqrMagnitude < sourceGravity.sqrMagnitude)
				{
					Forward = sources[i].transform.forward;
					sources[i].Activate();
					g = sourceGravity;
				}
			}
		}
		upAxis = -g.normalized;
		return g;
	}
}