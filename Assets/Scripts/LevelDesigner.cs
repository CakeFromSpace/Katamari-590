using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// mostly written by judge russell

// our level is made out of rings of tiles of different sizes, growing outwards from the center
// it's easier just to see the level for yourself than to explain,
// but i should mention the concept so all of this tile-size/grid-size stuff makes sense
public class LevelDesigner : MonoBehaviour
{
    public GameObject player;
    public GameObject katamari;
    public GameObject constellation;
    public GameObject fallen_objects;
    public GameObject youwin;
    public int length;

    public GameObject[] size_0_prefabs;
    public GameObject[] size_1_prefabs;
    public GameObject[] size_2_prefabs;
    public GameObject[] size_3_prefabs;


    private GameObject[][] tiles;
    private Bounds bounds;

    private bool endgame;
    private bool won;

    private bool[,] size_3_attr;
    private List<int> types;

    private int[,] level;

    private float katamari_size;   
    private float grid_actual_size;
    private float tile_size;
    private float level_offset;

    public Text sizetext;
    private int current_size;

    public float cullmultiplier; //how much smaller than the katamari can the object be before it gets destroyed

    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        // update katamari size
        katamari_size = katamari.transform.localScale.x;
        if(!endgame && katamari_size > 400)
        {
            endgame = true;
            foreach(Transform child in transform)
            {
                child.gameObject.tag = "tile";
            }
        }

        if(endgame && transform.childCount < 1)
        {
            won = true;
            youwin.SetActive(true);
        }
    }
    public void Play()
    {
        Camera.main.GetComponent<Chase>().enabled = true;
        katamari.transform.localScale = new Vector3(10, 10, 10);
    }

    public void Restart()
    {   
        player.GetComponent<PlayerStick>().ResetUICam();
        Reset();
        CreateLevel();
    }

    public void Reset()
    {
        
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<MeshCollider>().enabled = true;
        foreach(Transform child in constellation.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in fallen_objects.transform)
        {
            Destroy(child.gameObject);
        }
        katamari.transform.position = new Vector3(0, 10, 0);
        katamari.transform.localScale = new Vector3(10, 10, 10);
        sizetext.GetComponent<Text>().text = "";
    }

    private void CreateLevel()
    {
        won = false;
        endgame = false; 

        size_3_attr = new bool[,] {{true, false, true},
                        {true, false, true},
                        {true, false, true},
                        {true, false, true},
                        {true, false, false},
                        {true, false, true},
                        {false, false, false},
                        {false, false, false},
                        {false, false, false},
                        {false, true, false},
                        {false, true, false},
                        {true, true, true},
                        {true, true, true},
                        {true, true, true}};
        
        current_size = 0;
        // get initial katamari size
        katamari_size = katamari.transform.localScale.x;
        // calculate initial size grid's length and tile size
        bounds = GetComponent<Collider>().bounds; 

        // tiles stores all of the tile prefabs of all 4 sizes
        tiles = new GameObject[][] {size_0_prefabs, size_1_prefabs, size_2_prefabs, size_3_prefabs};

        // types is a list tile types represented by an integer
    

        for(int i = 0; i < 4; i++)
        {
            level = new int[length, length];
            // default value of -1 (no tile)
            for(int j = 0; j<length; j++)
            {
                for(int k = 0; k<length; k++)
                {
                    level[j, k] = -1;
                }    
            }

            // set current size
            current_size = i;
            // calculate length/width of concentric grid & size of each tile
            grid_actual_size = (bounds.size[0] / 8) * Mathf.Pow(2, current_size);
            tile_size = grid_actual_size / length;

            // find the offset for where to begin the level
            level_offset = (bounds.max[0] - bounds.min[0]) / 2 - tile_size * length / 2;

            GenerateLevel();
            DrawLevel();

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
        }
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

    bool ForestNextToDesert(int[,] grid, int[] pos)
    {
        int desert_count = 0;
        if(size_3_attr[grid[pos[0], pos[1]], 1] == false)
        {
            int[][] positions;
            positions = new int[][] { new int[]{ pos[0] - 1, pos[1] - 1 }, new int[]{ pos[0] - 1, pos[1] }, new int[]{ pos[0] - 1, pos[1] + 1 }, new int[]{ pos[0], pos[1] - 1 }, new int[]{ pos[0], pos[1] + 1 }, new int[]{ pos[0] + 1, pos[1] - 1 }, new int[]{ pos[0] + 1, pos[1]}, new int[]{ pos[0] + 1, pos[1] + 1 } };
        
            foreach(int[] p in positions)
            {
                Debug.Log(length);
                Debug.Log(p[0]);
                Debug.Log(p[1]);
                if(p[0] <= -1 || p[0] >= length || p[1] <= -1 || p[1] >= length || grid[p[0], p[1]] == -1 )
                {
                    continue;
                } 
                else
                {
                    if(size_3_attr[grid[p[0], p[1]], 1] == true)
                    {
                        desert_count++;
                    }   
                }
            }

        }
        return desert_count > 2;
    }

    // check tile consistency
    bool CheckConsistency(int[,] grid, int[] pos, int tile_type)
    {
        int old_assn = grid[pos[0], pos[1]];
        grid[pos[0], pos[1]] = tile_type;
        bool consistent = !(ForestNextToDesert(grid, pos));

        return consistent;
    }

    void GenerateLevel()
    {
        // create list of unassigned variables (if the current size is not 0 the tiles generated will be a ring, so the center will be assigned)
        List<int[]> unassigned = new List<int[]>();
        for(int i = 0; i < length; i++)
        {
            for(int j = 0; j < length; j++)
            {
                if(!(current_size > 0 && i >= length / 4 && i < 3 * length / 4 && j >= length / 4 && j < 3 * length / 4))
                {
                    int[] index = new int[]{i, j};
                    unassigned.Add(index);
                }
                
            }
        }

        // reset types list
        types = new List<int>();
        for(int i = 0; i < tiles[current_size].Length; i++)
        {
            types.Add(i);
        } 

        foreach(int[] pos in unassigned)
        {
            //Debug.Log(pos[0]);
            //Debug.Log(pos[1]);

            
            Shuffle<int>(ref types);

            if(current_size == 3)
            {
                if(pos[0] >= length / 2 && pos[1] >= length / 2)
                {
                // shuffle the types
                    // for each value in types, check the consistency, if consistent, assigned
                    for(int i = 0; i < types.Count; i++)
                    {
                        if(size_3_attr[types[i], 1])
                        {
                            level[pos[0], pos[1]] = types[i];
                            break;
                        }
                    }
                }
                else
                {
                    
                    for(int i = 0; i < types.Count; i++)
                    {
                        if(!size_3_attr[types[i], 1])
                        {
                            level[pos[0], pos[1]] = types[i];
                            break;
                        }
                    }
                }
            }
            else
            {
                for(int i = 0; i < types.Count; i++)
                {
                    level[pos[0], pos[1]] = types[i];
                    break;
                }
            }
        }
    }

    void DrawLevel()
    {
        for(int i=0; i<length; i++)
        {
            for(int j=0; j<length; j++)
            {
                if(level[i, j] != -1)
                {
                    //Debug.Log(level[i,j]);
                    GameObject current_tile = Instantiate(tiles[current_size][level[i, j]], new Vector3(0, 0, 0), Quaternion.identity);
                    current_tile.transform.position = new Vector3(bounds.min[0] + level_offset + tile_size * (i + 0.5f), 0, bounds.min[2] + level_offset + tile_size * (j + 0.5f));
                    current_tile.transform.parent = this.transform;
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
