using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float maxX = 7f;
    private float moveRight = 1f;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Debug.Log("Number of Pooled Objects: " + gameManager.pooledObjects.Count);
    }

    // Update is called once per frame
    void Update()
    {
        bool touchScreenPressed = false;
        if (Touchscreen.current != null)
        {
            if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame) touchScreenPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) || touchScreenPressed)
        {
            //Debug.Log("Space Key was pressed");
            GameObject ballObject = gameManager.GetPooledObject();
            if (ballObject != null)
            {
                ballObject.transform.position = transform.position;
                ballObject.SetActive(true);
                gameManager.decreaseActiveBalls();
                GetComponent<AudioSource>().Play();
            }
        }

        if (gameManager.isActive())
        {
            if (transform.position.x >= -maxX && transform.position.x <= maxX)
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * moveRight);
            }
            else
            {
                moveRight *= -1f;
                transform.position = new Vector3(transform.position.x + (0.1f * moveRight), transform.position.y, transform.position.z);

            }
        }
        
    }
}
