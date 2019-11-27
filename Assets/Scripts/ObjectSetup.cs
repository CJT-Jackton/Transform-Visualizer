using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetup : MonoBehaviour
{
    public GameObject MainCamera;
    public Material ClipMaterial, NDCMaterial;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] children = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; ++i)
        {
            children[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject child in children)
        {
            // Object in clip space
            GameObject clipObject = Instantiate(child, transform);
            clipObject.name = child.name + " [Clip]";
            clipObject.layer = 12; // Clip Camera
            clipObject.GetComponent<MeshRenderer>().material = ClipMaterial;

            ClipMatrixSetup setup = clipObject.AddComponent<ClipMatrixSetup>();
            setup.camera = MainCamera;

            // Object in NDC space
            GameObject ndcObject = Instantiate(child, transform);
            ndcObject.name = child.name + " [NDC]";
            ndcObject.layer = 13; // NDC Camera
            ndcObject.GetComponent<MeshRenderer>().material = NDCMaterial;

            setup = ndcObject.AddComponent<ClipMatrixSetup>();
            setup.camera = MainCamera;
        }
    }
}
