using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tans;
    // public Transform cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = tans.position + new Vector3(0, 1, -1);
        // this.transform.rotation = cam.rotation;

        this.transform.rotation = new Quaternion(0.26467f, 0.00000f, 0.00000f, 0.96434f);
        // Debug.Log(cam.rotation);
    }
}
