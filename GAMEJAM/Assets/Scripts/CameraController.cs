using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera self;
    // Start is called before the first frame update
    void Start()
    {
        
        self = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            self.orthographicSize += 1;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            self.orthographicSize -= 1;
        }
    }
}
