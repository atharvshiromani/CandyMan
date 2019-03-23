using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
    
{ private Vector2 velocity;
    public GameObject[] player;
    public float smoothTimeY;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    public bool bounds;
    private float smoothTimeX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // float posX = Mathf.SmoothDamp(transform.position.x, player.tranform.position.x, ref velocity.x, smoothTieX);
        float posX = Mathf.SmoothDamp(transform.position.x, transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, transform.position.y, ref velocity.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
        if(bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                 Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
