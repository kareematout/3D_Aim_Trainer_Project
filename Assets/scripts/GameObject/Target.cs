using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [SerializeField] Shoot shootingRef;
    [SerializeField] GameObject player;

    Rigidbody controls;
    gameSettings settings;
    Vector3 Origin;
    Vector3 StrafeLimitL;
    Vector3 StrafeLimitR;
   
    public float target_speed = 1f;
    Scene currentScene;
    float strafeRange = 10f;
    Renderer cubeRenderer;
    float strafeDirection = 1f;
    float strafeTimer = 0f;
    float strafeInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        init();
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentScene.name) {
            case "Strafe":
                checkStrafeLimit();
                break;
            case "Orbit":
                break;
        }

        //if(cubeRenderer == null) return;
        //if(shootingRef == null) return;
        if(shootingRef.isTracking(transform.gameObject)) {
            cubeRenderer.material.SetColor("_Color", Color.cyan);
        } else {
            cubeRenderer.material.SetColor("_Color", Color.red);
        }
    }

    private bool randomBoolean() {
        return (Random.value >= 0.5);
    }
    private void RandomStrafe() {
        strafeDirection = -strafeDirection; // Reverse strafe direction
        strafeTimer = 0f;
    }
    public void ResetPosition() {
            transform.position = Origin;
        }
    private void init() {
        Origin = transform.position;
        StrafeLimitL = Origin + Vector3.left * strafeRange;
        StrafeLimitR = Origin + Vector3.right * strafeRange;
        controls = GetComponent<Rigidbody>();
        cubeRenderer = GetComponent<Renderer>();

    }
    private void HandleGameState(GameState state) {
        switch(state) {
            case GameState.Pre:
            break;
            case GameState.Play:
            HandleMode();
            break;
            case GameState.End:
            break;
        }
    }

    private void HandleMode() {
        controls.velocity = new Vector3(randomBoolean() ? -1 : 1,0,0) * target_speed;
        strafeTimer += Time.deltaTime;
        if (strafeTimer >= strafeInterval)
        {
            RandomStrafe();
        }
    
        controls.velocity += Vector3.right * strafeDirection * target_speed * 0.5f;

    }

    private void checkStrafeLimit() {
        if(transform.position.x >= StrafeLimitR.x) {
            transform.position = StrafeLimitR + (Vector3.left *0.1f);
            controls.velocity *= -1;
        }
        if(transform.position.x <= StrafeLimitL.x) {
            transform.position = StrafeLimitL + (Vector3.right * 0.1f);
            controls.velocity *= -1;
        }
    }
    


}
