using UnityEngine;
using UnityEditor;

public class ObjectPlacer : EditorWindow
{
    private GameObject objectToPlace;
    private bool isPlacingObjects = false;

    [MenuItem("Tools/Object Placer")]
    public static void ShowWindow()
    {
        GetWindow<ObjectPlacer>("Object Placer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Object Placer", EditorStyles.boldLabel);
        objectToPlace = (GameObject)EditorGUILayout.ObjectField("Object to Place", objectToPlace, typeof(GameObject), false);

        if (objectToPlace != null)
        {
            if (!isPlacingObjects)
            {
                if (GUILayout.Button("Start Placing Objects"))
                {
                    isPlacingObjects = true;
                    SceneView.duringSceneGui += OnSceneGUI;
                }
            }
            else
            {
                if (GUILayout.Button("Stop Placing Objects"))
                {
                    isPlacingObjects = false;
                    SceneView.duringSceneGui -= OnSceneGUI;
                }
            }
        }
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;
        if (e.type == EventType.MouseDown && e.button == 0 && objectToPlace != null)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            Vector3 position = ray.origin;
            position.z = 0; // Nastav z souřadnici na 0 pro 2D prostředí

            // Zaokrouhli pozici na nejbližší celé číslo
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);

            Undo.RegisterCreatedObjectUndo(Instantiate(objectToPlace, position, Quaternion.identity), "Place Object");
            e.Use();
        }
    }
}