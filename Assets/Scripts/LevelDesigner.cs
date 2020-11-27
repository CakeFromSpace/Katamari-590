using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDesigner : MonoBehaviour
{

    public float current_size = 0;
    public float grid_width;

    public List<GameObject> size_1_prefabs;
    public List<GameObject> size_2_prefabs;
    public List<GameObject> size_3_prefabs;
    public List<GameObject> size_4_prefabs;

    private List<List<GameObject>> prefabs;
    private Bounds bounds;
    
    private int[][] level;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<Collider>().bounds; 
        grid_width = (bounds.size[0] / 8) * Mathf.Pow(2, current_size);

        prefabs = new List<List<GameObject>>(){size_1_prefabs, size_2_prefabs, size_3_prefabs, size_4_prefabs};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawLevel()
    {
    }
}
