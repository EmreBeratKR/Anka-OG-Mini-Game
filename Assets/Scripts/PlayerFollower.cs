using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 offset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - targetObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetObject.position + offset;
    }
}
