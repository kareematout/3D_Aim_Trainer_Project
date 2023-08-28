using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
   [SerializeField] GameObject ReticleHUD;
   [SerializeField] GameObject CounterHUD;
   float timer = 5f;

    // Start is called before the first frame update
    void Awake() {
        GameManager.OnGameStateChanged += HandleGameState;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleGameState(GameState state) {
         switch(state) {
            case GameState.Pre:
            InvokeRepeating("Countdown", 0, 1);
            ReticleHUD.SetActive(false);
            break;
            case GameState.Play:
            CancelInvoke("Countdown");
            CounterHUD.SetActive(false);
            ReticleHUD.SetActive(true);
            break;
            case GameState.End:
            break;
        }
    }

    private void Countdown() {
        if(timer == 0) {
            GameManager.INSTANCE.updateGameState(GameState.Play);
        }
        CounterHUD.GetComponentInChildren<TextMeshProUGUI>().SetText(timer.ToString(), true);
        timer--;
    }
}
