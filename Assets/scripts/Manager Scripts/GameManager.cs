using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
   public static GameManager INSTANCE;
   public GameState state;
    // Start is called before the first frame update
    public static event System.Action<GameState> OnGameStateChanged;
    void Awake() {
        INSTANCE = this;
    }
    void Start()
    {
        updateGameState(GameState.Pre);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateGameState (GameState newState) {
        state = newState;

        switch(newState) {
            case GameState.Pre:
            break;
            case GameState.Play:
            break;
            case GameState.End:
            break;
        }
    }

}
 public enum GameState {
        Pre,
        Play,
        End
    }
