/*
 * ShipController
 * 
 * This script controls the player's ship, allowing movement and shooting.
 * 
 */
using UnityEngine;

public class ShipController : MonoBehaviour
{
    float speed = 10f;

    public GameObject ShotEffect;

    public ShapeStruct currentShape;

    bool isShot = false;

    public bool IsShot()
    {
        return isShot;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotEffect.SetActive(true);
            isShot = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            ShotEffect.SetActive(false);
            isShot = false;
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            switch(currentShape.GetCurrentShape())
            {
                case ShapeStruct.Shape.Square:
                    currentShape.ChengeCShape(ShapeStruct.Shape.Triangle);
                    break;
                case ShapeStruct.Shape.Triangle:
                    currentShape.ChengeCShape(ShapeStruct.Shape.Circle);
                    break;
                case ShapeStruct.Shape.Circle:
                    currentShape.ChengeCShape(ShapeStruct.Shape.Square);
                    break;
            }
        }
    }
}
