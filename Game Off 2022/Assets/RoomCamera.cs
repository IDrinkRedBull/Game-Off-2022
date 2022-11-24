using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{
    public GameObject virtualCamera;
    public GameObject objects;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            virtualCamera.SetActive(true);
            objects.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            virtualCamera.SetActive(false);
            objects.SetActive(false);
        }
    }
}
