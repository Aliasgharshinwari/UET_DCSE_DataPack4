using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FollowerEnemy))]
public class FollowerEnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FollowerEnemy followerEnemy = (FollowerEnemy)target;

        // Get the tags from Unity's Tag Manager
        string[] tags = UnityEditorInternal.InternalEditorUtility.tags;

        // Display a dropdown for tags
        int selectedIndex = System.Array.IndexOf(tags, followerEnemy.playerTag);
        selectedIndex = EditorGUILayout.Popup("Player Tag", selectedIndex, tags);

        if (selectedIndex >= 0 && selectedIndex < tags.Length)
        {
            followerEnemy.playerTag = tags[selectedIndex];
        }

        // Save any changes made in the Inspector
        if (GUI.changed)
        {
            EditorUtility.SetDirty(followerEnemy);
        }

        // Draw other default Inspector properties
        DrawDefaultInspector();
    }
}
