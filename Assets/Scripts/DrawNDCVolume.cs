using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNDCVolume : MonoBehaviour
{
    public GameObject Line;

    private GameObject[] _lines = new GameObject[12];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _lines.Length; ++i)
        {
            _lines[i] = Instantiate(Line);
            _lines[i].name = name + "_Visualizer_" + i;
        }

        Vector3[] vertex = new Vector3[8];
        vertex[0] = new Vector3(1, 1, 1);
        vertex[1] = new Vector3(-1, 1, 1);
        vertex[2] = new Vector3(-1, 1, -1);
        vertex[3] = new Vector3(1, 1, -1);
        vertex[4] = new Vector3(1, -1, 1);
        vertex[5] = new Vector3(-1, -1, 1);
        vertex[6] = new Vector3(-1, -1, -1);
        vertex[7] = new Vector3(1, -1, -1);

        // Up Face
        LineRenderer lr = _lines[0].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[0]);
        lr.SetPosition(1, vertex[1]);

        lr = _lines[1].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[1]);
        lr.SetPosition(1, vertex[2]);

        lr = _lines[2].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[2]);
        lr.SetPosition(1, vertex[3]);

        lr = _lines[3].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[3]);
        lr.SetPosition(1, vertex[0]);

        // Down Face
        lr = _lines[4].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[4]);
        lr.SetPosition(1, vertex[5]);

        lr = _lines[5].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[5]);
        lr.SetPosition(1, vertex[6]);

        lr = _lines[6].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[6]);
        lr.SetPosition(1, vertex[7]);

        lr = _lines[7].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[7]);
        lr.SetPosition(1, vertex[4]);

        // Side
        lr = _lines[8].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[0]);
        lr.SetPosition(1, vertex[4]);

        lr = _lines[9].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[1]);
        lr.SetPosition(1, vertex[5]);

        lr = _lines[10].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[2]);
        lr.SetPosition(1, vertex[6]);

        lr = _lines[11].GetComponent<LineRenderer>();
        lr.SetPosition(0, vertex[3]);
        lr.SetPosition(1, vertex[7]);
    }
}
