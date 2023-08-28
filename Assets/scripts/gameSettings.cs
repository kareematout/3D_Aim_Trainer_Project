using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSettings : MonoBehaviour
{
    public bool MovementEnabled = true;
    public float StrafeRange = 10f;
    public Training_Settings mode = Training_Settings.Strafe;
    
    public enum Training_Settings {
        Orbit,
        Strafe
    }
    public void ToggleMovement() {
        MovementEnabled = !MovementEnabled;
    }
    public void ChangeTraining(Training_Settings newSettings) {
        mode = newSettings;
    }
}
