using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public float speed = 5.0f; // Geschwindigkeit des NPC
    public int value = 1;




 void Start()
    {
        // Erhalte die aktuelle Rotation des GameObjects
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Ändere die Rotation auf der X-Achse um -90 Grad
        currentRotation.x = -90f;

        // Setze die neue Rotation
        transform.rotation = Quaternion.Euler(currentRotation);
    }



    void Update()
    {
        // Bewege den NPC nach links basierend auf der Geschwindigkeit
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Überprüfen, ob der NPC außerhalb des Sichtfelds ist, und ihn zurücksetzen
        if (transform.position.x < -60f)
        {
           Destroy(gameObject);
        }
    }

      void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            Debug.Log("1 Punkt");
            Destroy(gameObject);
            Score.instance.IncreaseCoins(value);
        }
       
    }
}

