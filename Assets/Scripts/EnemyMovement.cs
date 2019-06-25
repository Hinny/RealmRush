using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

	void Start () {
        //StartCoroutine(FollowPath());
	}
	
    IEnumerator FollowPath() {
        Debug.Log("Starting Patrol...");
        foreach (Waypoint waypoint in path) {
            yield return new WaitForSeconds(1f);
            transform.position = waypoint.transform.position;
            Debug.Log("Now visiting: " + waypoint.ToString());
        }
        Debug.Log("Ending Patrol!");
    }

}
