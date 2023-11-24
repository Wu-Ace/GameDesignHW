using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public static CharacterController instance; 
    public PlayerState currentState;
    public enum PlayerState
    {
        Idle,
        Walking
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        // Debug.Log("MySceneManager Awake");
    }
    void Start()
    {
        currentState = PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterManager.movement!= Vector3.zero)
        {
            currentState = PlayerState.Walking;
        }
        else
        {
            currentState = PlayerState.Idle;
        }
    }
}
