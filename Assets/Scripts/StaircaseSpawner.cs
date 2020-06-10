using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that controls staircases spawn.
/// </summary>
public class StaircaseSpawner : MonoBehaviour
{

    public GameObject StaircasePrefab;
    public GameObject player;

    int staircaseCount;
    float staircaseHeight;

    List<GameObject> currentStaircases = new List<GameObject>();

    void Start()
    {
        staircaseCount = 5;
        staircaseHeight = 16;

        SetStartingStructure();
    }

    private void LateUpdate()
        => SpawnCheck();

    /// <summary>
    /// Sets a starting structure of staircases & clears old data.
    /// </summary>
    public void SetStartingStructure()
    {
        foreach (var item in currentStaircases)
        {
            Destroy(item);
        }

        currentStaircases.Clear();

        for (int i = 0; i < staircaseCount; i++)
        {
            SpawnStaircase();
        }
    }

    /// <summary>
    /// Checks if a staircase spawn is needed and 
    /// calls a structure downwards snap if so.
    /// </summary>
    private void SpawnCheck()
    {
        if (currentStaircases[0].transform.position.y - 
            player.transform.position.y > 36)
        {
            SpawnStaircase();
            DestroyStaircase();
        }
    }

    /// <summary>
    /// Spawns another staircase below the existing ones.
    /// </summary>
    private void SpawnStaircase()
    {
        GameObject staircase = Instantiate(StaircasePrefab, transform);

        Vector3 staircasePosition;

        if (currentStaircases.Count > 0)
        {
            staircasePosition = currentStaircases[currentStaircases.Count - 1].transform.position
                + new Vector3(0, -staircaseHeight, 0);
        }
        else
        {
            staircasePosition = Vector3.zero;
        }

        staircase.transform.position = staircasePosition;
        currentStaircases.Add(staircase);
    }

    /// <summary>
    /// Removes the highest staircase.
    /// </summary>
    private void DestroyStaircase()
    {
        Destroy(currentStaircases[0]);
        currentStaircases.RemoveAt(0);
    }
}
