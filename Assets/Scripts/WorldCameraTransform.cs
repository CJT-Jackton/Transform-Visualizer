﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCameraTransform : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }
}
