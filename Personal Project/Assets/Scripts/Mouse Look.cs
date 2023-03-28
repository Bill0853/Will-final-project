using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Vector2 sensitivity;

    private Vector2 rotation;


    private Vector2 GetInput()
    {
        Vector2 input = new Vector2
           (
             Input.GetAxis("Mouse X"),
             Input.GetAxis("Mouse Y")
           );
        return input;
    }

    private void Update()
    {
        Vector2 wantedVelocity = GetInput() * sensitivity;

        rotation += wantedVelocity * Time.deltaTime;

        transform.localEulerAngles = new Vecotor3(rotation.y, rotation.x, 0);
    }
    //watch for finishing
    //https://www.youtube.com/watch?v=Coch-PkHY54


}
