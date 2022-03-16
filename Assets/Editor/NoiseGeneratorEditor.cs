using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class NoiseGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Save"))
            {
                var myTarget = target as NoiseGenerator;
                if (myTarget != null) myTarget.SaveTexture();
            }
        }
    }
}