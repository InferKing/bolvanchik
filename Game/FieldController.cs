using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    private static List<GameObject> enemies = new List<GameObject>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!enemies.Contains(collision.gameObject))
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemies.Contains(collision.gameObject))
        {
            enemies.Remove(collision.gameObject);
        }
    }

    public static void ClearField()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var item in array)
        {
            if (!enemies.Contains(item))
            {
                Destroy(item);
            }
        }
    }
}
