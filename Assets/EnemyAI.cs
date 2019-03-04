using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {
     public Transform target;

     // Update path per second
     public float updateRate = 2f;

     private Seeker seeker;
     private Rigidbody2D rb;

     // Calculated Path
     public Path path;

     // AI speed per second
     public float speed = 300f;
     public ForceMode2D fMode;

     [HideInInspector]
     public bool pathIsEnded = false;

     public float nextWaypointDistance = 3;

     // Current target waypoint
     private int currentWaypoint = 0;

     // Has the enemy seen the player or not
     private bool seenPlayer = false;

     void Start() {
          seeker = GetComponent<Seeker>();
          rb = GetComponent<Rigidbody2D>();

          if(target == null) {
               Debug.LogError("No target set.");
               return;
          }

          //TODO: Finish seenTarget and get rid of this line
          seenPlayer = true;

          // Find a path to the target, then return to OnPathComplete
          seeker.StartPath(transform.position, target.position, OnPathComplete);

          StartCoroutine(UpdatePath());
     }

     bool seenTarget() {
          if (seenPlayer)
               return true;

          // Check if enemy has a line of sight to the player
          //TODO: finish this function
          return true;
     }

     IEnumerator UpdatePath() {
          if (target == null) {
               Debug.Log("No target set.");
               yield return false;
          }

          // Find a path to the target, then return to OnPathComplete
          seeker.StartPath(transform.position, target.position, OnPathComplete);
          yield return new WaitForSeconds(1f / updateRate);
          StartCoroutine(UpdatePath());
     }

     public void OnPathComplete(Path p) {
          //TODO: Add check if enemy has seen the player
          // Check if the path had an error or not
          if(!p.error) {
               path = p;
               currentWaypoint = 0;
          }
     }

     void FixedUpdate() {
          if (target == null) {
               //Debug.Log("No target set.");
               return;
          }

          if (path == null)
               return;

          if (!seenTarget()) {
               return;
          }

          if (currentWaypoint >= path.vectorPath.Count) {
               if (pathIsEnded)
                    return;
               //Debug.Log("End of path reached.");
               pathIsEnded = true;
               return;
          }

          pathIsEnded = false;

          // Find direction to next waypoint
          Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
          dir *= speed * Time.fixedDeltaTime;

          // Move enemy
          rb.AddForce(dir, fMode);

          float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

          if (dist < nextWaypointDistance) {
               currentWaypoint++;
               return;
          }
     }
}
