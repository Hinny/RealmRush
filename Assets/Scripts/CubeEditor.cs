using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {


    Waypoint waypoint;

    private void Awake() {
        waypoint = GetComponent<Waypoint>();
    }

    void Update () {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid() {
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPosition = waypoint.GetGridPosition();
        transform.position = new Vector3(gridPosition.x * gridSize, 0f, gridPosition.y * gridSize);
    }

    private void UpdateLabel() {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPosition = waypoint.GetGridPosition();

        string labelText = gridPosition.x + "," + gridPosition.y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
