using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed;
    

    
    void Update()
    {        
        MoveCamera();
    }


    /// <summary>
    /// this moves the camera.
    /// </summary>
    public void MoveCamera()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z), followSpeed * Time.deltaTime);
    }


}
