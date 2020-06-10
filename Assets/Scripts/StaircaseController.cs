using UnityEngine;

/// <summary>
/// Controls the behaviour of instatinated staircases.
/// </summary>
public class StaircaseController : MonoBehaviour
{
    GameManager gameManager;
    public GameObject trigger;

    private int triggerChance;
    private static int seed = System.DateTime.Now.Millisecond;

    void Start()
    {
        Random.seed = seed;
        seed++;
        gameManager = FindObjectOfType<GameManager>();
        triggerChance = gameManager.monsterChance;
        trigger.SetActive(Random.Range(0, 101) <= triggerChance);
    }
}
