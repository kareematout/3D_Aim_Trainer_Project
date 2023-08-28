using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] GameObject weapon;
    [SerializeField] ParticleSystem MuzzleFlash;
    private Animation anim;

    public float range = 100f;
    // Start is called before the first frame update
    void Start()
    {
        if(weapon) {
            anim = weapon.GetComponent<Animation>();
        }
    }

    // Update is called once per frame
    public void AttemptShot()
    {
        if(MuzzleFlash){
            MuzzleFlash.Play();
        }
        if(anim) {
            anim.Play("GunRecoil");
        }
        RaycastHit Hit;
        if(Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out Hit, range)) {
            Debug.Log(Hit.transform.name);
        }


    }

    public bool isTracking(GameObject target) 
    {
        RaycastHit Hit;
        Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out Hit, range);
        return Hit.transform.gameObject == target;
    }
}
