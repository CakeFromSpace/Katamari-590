using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelDesigner : MonoBehaviour
{
    public GameObject katamari;
    public int length;
    public int current_size;


    public GameObject[] size_0_prefabs;
    public GameObject[] size_1_prefabs;
    public GameObject[] size_2_prefabs;
    public GameObject[] size_3_prefabs;


    private GameObject[][] tiles;
    private Bounds bounds;

    private List<int> types;

    private int[,] level;
    private bool[] generated;

    private float katamari_size;   
    private float grid_actual_size;
    private float tile_size;
    private float level_offset;

    public float cullmultiplier; //how much smaller than the katamari can the object be before it gets destroyed

    // Start is called before the first frame update
    void Start()
    {
        
        katamari_size = katamari.transform.localScale.x;
        bounds = GetComponent<Collider>().bounds; 
        grid_actual_size = (bounds.size[0] / 8) * Mathf.Pow(2, current_size);
        tile_size = grid_actual_size / length;
        level_offset = (bounds.max[0] - bounds.min[0]) / 2 - tile_size * length / 2;
        level = new int[length, length];
        generated = new bool[4];

        for(int i = 0; i<length; i++)
        {
            for(int j = 0; j<length; j++)
            {
                level[i, j] = -1;
            }    
        }

        for(int i = 0; i < generated.Length; i++)
        {
            if(i <= current_size)
            {
                generated[i] = true;
            }
            else
            {
                generated[i] = false;
            }
        }

        tiles = new GameObject[][] {size_0_prefabs, size_1_prefabs, size_2_prefabs, size_3_prefabs};
        types = new List<int>();
        GenerateLevel();
        DrawLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(katamari.transform.localScale.x >= 1 && katamari_size < 1 && !generated[0])
        {
            current_size = 0;
            generated[current_size] = true;
            grid_actual_size = (bounds.size[0] / 8) * Mathf.Pow(2, current_size);
            tile_size = grid_actual_size / length;
            level_offset = (bounds.max[0] - bounds.min[0]) / 2 - tile_size * length / 2;
            GenerateLevel();
            DrawLevel();
        }
        if(katamari.transform.localScale.x >= 10 && katamari_size < 10 && !generated[1])
        {
            current_size = 1;
            generated[current_size] = true;
            grid_actual_size = (bounds.size[0] / 8) * Mathf.Pow(2, current_size);
            tile_size = grid_actual_size / length;
            level_offset = (bounds.max[0] - bounds.min[0]) / 2 - tile_size * length / 2;
            GenerateLevel();
            DrawLevel();
        }
        if(katamari.transform.localScale.x >= 25 && katamari_size < 25 && !generated[2])
        {
            
            current_size = 2;
            generated[current_size] = true;
            grid_actual_size = (bounds.size[0] / 8) * Mathf.Pow(2, current_size);
            tile_size = grid_actual_size / length;
            level_offset = (bounds.max[0] - bounds.min[0]) / 2 - tile_size * length / 2;
            GenerateLevel();
            DrawLevel();
        }
        if(katamari.transform.localScale.x >= 100 && katamari_size < 100 && !generated[3])
        {
            
            current_size = 3;
            generated[current_size] = true;
            grid_actual_size = (bounds.size[0] / 8) * Mathf.Pow(2, current_size);
            tile_size = grid_actual_size / length;
            level_offset = (bounds.max[0] - bounds.min[0]) / 2 - tile_size * length / 2;
            GenerateLevel();
            DrawLevel();
        }
    
        katamari_size = katamari.transform.localScale.x;
    }

    private void Shuffle<T>(ref List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    bool CheckConsistency(int[,] grid, int[] pos, int tile_type)
    {
        grid[pos[0], pos[1]] = tile_type;
        
        

        return true;
    }

    // do backtracking search to create level
    bool BackTrackingSearch(int[,] grid, List<int[]> unassigned)
    {   
        // when all have been assigned return true
        if(unassigned.Count < 1)
        {
            return true;
        }

        // select next index on grid to assigned
        int next_index = UnityEngine.Random.Range(0, unassigned.Count);
        int[] next_variable = unassigned[next_index];
        unassigned.RemoveAt(next_index);
        
        // shuffle the types
        Shuffle<int>(ref types);

        // for each value in types, check the consistency, if consistent, assigned
        foreach(int i in types)
        {
            bool consistent = CheckConsistency(level, next_variable, i);

            if(consistent)
            {
                level[next_variable[0], next_variable[1]] = i;
                break;
            }
        }

        BackTrackingSearch(level, unassigned);
        return false;
    }

    void GenerateLevel()
    {
        List<int[]> unassigned = new List<int[]>();
        for(int i = 0; i < length; i++)
        {
            for(int j = 0; j < length; j++)
            {
                if(!(current_size > 1 && i >= length / 4 && i < 3 * length / 4 && j >= length / 4 && j < 3 * length / 4))
                {
                    int[] index = new int[]{i, j};
                    unassigned.Add(index);
                }
                
            }
        }
        
        for(int i = 0; i < tiles[current_size].Length; i++)
        {
            types.Add(i);
        } 

        BackTrackingSearch(level, unassigned);
    }

    void DrawLevel()
    {
        CullSmall();
        for(int i=0; i<length; i++)
        {
            for(int j=0; j<length; j++)
            {
                if(level[i, j] != -1)
                {
                    GameObject current_tile = Instantiate(tiles[current_size][level[i, j]], new Vector3(0, 0, 0), Quaternion.identity);
                    current_tile.transform.position = new Vector3(bounds.min[0] + level_offset + tile_size * (i + 0.5f), 0, bounds.min[2] + level_offset + tile_size * (j + 0.5f));
                } 
            }
        }
    }

    //Edit by Joe 12/5
    //remove exceedingly small objects in comparison to player from scene
    void CullSmall()
    {
        int i = 0;
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("pickup"))
        {
            if (g.transform.localScale.x < katamari.transform.localScale.x*cullmultiplier)
            {
                Destroy(g);
                i += 1;
            }
        }
        Debug.Log("Culled " + i + " objects");
    }
}
