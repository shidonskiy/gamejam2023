using Gamejam.Scripts.Controllers.Scripts.Environment;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Editor
{
    [CustomEditor(typeof(ForceActor))]
    public class ForceActorEditor : UnityEditor.Editor
    {
        private BoxBoundsHandle m_BoundsHandle = new();

        // the OnSceneGUI callback uses the Scene view camera for drawing handles by default
        protected virtual void OnSceneGUI()
        {
            ForceActor boundsExample = (ForceActor)target;

            Handles.matrix = boundsExample.transform.localToWorldMatrix;
            Handles.color = Color.green;
            
            // copy the target object's data to the handle
            m_BoundsHandle.center = boundsExample.boundaryDistance.center;
            m_BoundsHandle.size = boundsExample.boundaryDistance.size;

            // draw the handle
            EditorGUI.BeginChangeCheck();
            m_BoundsHandle.DrawHandle();
            if (EditorGUI.EndChangeCheck())
            {
                // record the target object before setting new values so changes can be undone/redone
                Undo.RecordObject(boundsExample, "Change Bounds");
                
                // copy the handle's updated data back to the target object
                Bounds newBounds = new Bounds(m_BoundsHandle.center, m_BoundsHandle.size);
                boundsExample.boundaryDistance = newBounds;
            }
        }
    }
}