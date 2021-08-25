using IdleGame.Spawning;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HumanSpawner))]
[CanEditMultipleObjects]
public class HumanSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var tg = target as HumanSpawner;

        if (GUILayout.Button("Setup"))
        {
            tg.Reset();
            EditorUtility.SetDirty(tg);
        }
    }
}
