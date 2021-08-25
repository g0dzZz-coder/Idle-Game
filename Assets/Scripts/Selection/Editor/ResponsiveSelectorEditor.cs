using IdleGame.Selection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ResponsiveSelector))]
public class ResponsiveSelectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var tg = target as ResponsiveSelector;

        if (GUILayout.Button("Find all"))
        {
            tg.Reset();
            EditorUtility.SetDirty(tg);
        }
    }
}