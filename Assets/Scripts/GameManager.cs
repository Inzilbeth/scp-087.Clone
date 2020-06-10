using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class that manages the gameplay process.
/// </summary>
public class GameManager : MonoBehaviour
{
    Vector3 playerStartingPosition;
    
    public Transform playerTransform;
    public PlayerMovement playerMovement;
    public CharacterController characterController;
    public MouseLook mouseLook;
    public StaircaseSpawner staircaseSpawner;
    public InputField inputField;
    public GameObject menu;
    public GameObject lossCanvas;
    
    public int monsterChance;

    void Start()
    {
        monsterChance = 100;
        playerStartingPosition = new Vector3(-13, 10, 7);
        playerTransform.position = playerStartingPosition;
    }

    /// <summary>
    /// Starts loss couroutine.
    /// </summary>
    public void Loss()
        => StartCoroutine(LossCoroutine());

    /// <summary>
    /// Unlocks the cursor, stops the player from moving & opens a menu with deathmessage.
    /// </summary>
    public IEnumerator LossCoroutine()
    {
        playerMovement.canPlay = false;
        yield return new WaitForSeconds(2);
        mouseLook.canPlay = false;
        lossCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Starts/Restarts a game.
    /// </summary>
    public void LaunchGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
        characterController.enabled = false;
        playerTransform.position = playerStartingPosition;
        characterController.enabled = true;
        staircaseSpawner.SetStartingStructure();
        playerMovement.canPlay = true;
        mouseLook.canPlay = true;
        Cursor.lockState = CursorLockMode.Locked;
        lossCanvas.SetActive(false);
    }

    /// <summary>
    /// Sets monster's spawn chance according to the input field.
    /// Is called on input field'd end of editing.
    /// </summary>
    public void SetMonsterChance()
    {
        Debug.Log(inputField.transform.GetChild(2).GetComponent<Text>().text);
        monsterChance = Mathf.Clamp(Convert.ToInt32(inputField.transform.GetChild(2).GetComponent<Text>().text), 0, 101);
    }

    /// <summary>
    /// Closes the application.
    /// </summary>
    public void Exit()
       => Application.Quit();
}
