using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isPathfinding = true;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    // Use this for initialization
    void Start () {
        LoadBlocks();
        ColorStartAndEndWaypoints();
        Pathfind();

        //ExploreNeighbours();
    }

    private void Pathfind() {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isPathfinding) {
            Waypoint searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }

    }

    private void HaltIfEndFound(Waypoint waypoint) {
        if (waypoint == endWaypoint) {
            isPathfinding = false;
        }
    }

    private void ExploreNeighbours(Waypoint from) {
        if (!isPathfinding) { return; }

        foreach (Vector2Int direction in directions) {
            Vector2Int neighbourGridPosition = startWaypoint.GetGridPosition() + direction;
            if (grid.ContainsKey(neighbourGridPosition)) {
                QueueNewNeighbour(neighbourGridPosition);
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourGridPosition) {
        Waypoint neighbour = grid[neighbourGridPosition];
        if (!neighbour.isExplored && !queue.Contains(neighbour)) {
            neighbour.SetTopColor(Color.blue); // todo move later
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = 
        }

    }

    private void ColorStartAndEndWaypoints() {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks() {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            Vector2Int gridPosition = waypoint.GetGridPosition();

            bool isOverlapping = grid.ContainsKey(gridPosition);
            if (isOverlapping) {
                Debug.LogWarning("Skipping overlapping block in position " + gridPosition.ToString());
            } else {
                grid.Add(gridPosition, waypoint);
            }
        }
    }

}
