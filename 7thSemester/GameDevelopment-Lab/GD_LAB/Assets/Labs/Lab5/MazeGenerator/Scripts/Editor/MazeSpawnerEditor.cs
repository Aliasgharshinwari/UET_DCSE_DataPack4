using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MazeSpawner))]
public class MazeSpawnerEditor : Editor {
    public override void OnInspectorGUI() {
        MazeSpawner mazeSpawner = (MazeSpawner)target;

        mazeSpawner.Algorithm = (MazeSpawner.MazeGenerationAlgorithm)EditorGUILayout.EnumPopup("Algorithm", mazeSpawner.Algorithm);
        mazeSpawner.FullRandom = EditorGUILayout.Toggle("Full Random", mazeSpawner.FullRandom);
        
        if (!mazeSpawner.FullRandom) {
            mazeSpawner.RandomSeed = EditorGUILayout.IntField("Random Seed", mazeSpawner.RandomSeed);
        }
        
        mazeSpawner.Floor = (GameObject)EditorGUILayout.ObjectField("Floor", mazeSpawner.Floor, typeof(GameObject), true);
        mazeSpawner.Wall = (GameObject)EditorGUILayout.ObjectField("Wall", mazeSpawner.Wall, typeof(GameObject), true);
        mazeSpawner.Pillar = (GameObject)EditorGUILayout.ObjectField("Pillar", mazeSpawner.Pillar, typeof(GameObject), true);
        
        mazeSpawner.Rows = EditorGUILayout.IntField("Rows", mazeSpawner.Rows);
        mazeSpawner.Columns = EditorGUILayout.IntField("Columns", mazeSpawner.Columns);
        mazeSpawner.CellWidth = EditorGUILayout.FloatField("Cell Width", mazeSpawner.CellWidth);
        mazeSpawner.CellHeight = EditorGUILayout.FloatField("Cell Height", mazeSpawner.CellHeight);
        
        mazeSpawner.AddGaps = EditorGUILayout.Toggle("Add Gaps", mazeSpawner.AddGaps);
        
        //mazeSpawner.GoalPrefab = (GameObject)EditorGUILayout.ObjectField("Goal Prefab", mazeSpawner.GoalPrefab, typeof(GameObject), true);

        if (GUILayout.Button("Generate Maze")) {
            mazeSpawner.GenerateMaze();
        }

        if (GUILayout.Button("Destroy Maze")) {
            mazeSpawner.DestroyMaze();
        }

        // Apply any changes made to the editor
        if (GUI.changed) {
            EditorUtility.SetDirty(target);
        }
    }
}
