using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class playGame : MonoBehaviour
{
    private void Update()
    {
        if (Gamepad.current.buttonEast.IsPressed() || Input.anyKey)
        {
            SceneChanger.instance.TransitionToNewScene("SnowScene");
        }
    }
}
