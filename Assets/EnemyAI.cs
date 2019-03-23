aiusing UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {
     public Transform player;
     public Transform patrolA;
     public Transform patrolB;

     private string targetstr;
     private Transform target;

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

     // Player tracking during patrolling
     private float followThreshold = 2.5f;

     void Start() {
          seeker = GetComponent<Seeker>();
          rb = GetComponent<Rigidbody2D>();

          if(player == null) {
               Debug.LogError("No player set.");
               return;
          }

        if (patrolA == null) {
            Debug.LogError("No patrolA set.");
            return;
        }

        if (patrolB == null) {
            Debug.LogError("No patrolB set.");
            return;
        }

        targetstr = "A";
          target = patrolA;

          // Find a path to the target, then return to OnPathComplete
          seeker.StartPath(transform.position, target.position, OnPathComplete);

          StartCoroutine(UpdatePath());
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

          if (targetstr != "P") {
               // Calculate how far away the enemy is from its patrol position
               float distGoal = Vector3.Distance(transform.position, target.position);
               //Debug.Log("distGoal: " + distGoal);

               if (targetstr == "A" && distGoal < 0.75) {
                    targetstr = "B";
                    target = patrolB;
                    //Debug.Log("Switching to PatrolB");
               }
               else if (targetstr == "B" && distGoal < 0.75) {
                    targetstr = "A";
                    target = patrolA;
                    //Debug.Log("Switching to PatrolA");
               }

               // Calculate distance to player and switch to following the player if the distance is less than the threshold
               float distP = Vector3.Distance(transform.position, player.position);
               //Debug.Log("distP " + distP);
               if (distP < followThreshold) {
                    targetstr = "P";
                    target = player;
                    Debug.Log("Switching to player");
               }
          }

          if (dist < nextWaypointDistance) {
               currentWaypoint++;
               return;
          }
     }
}
