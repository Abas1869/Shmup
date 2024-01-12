using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;

    private void OnBecameVisible()
    {
        canBeDestroyed = true;
    }

    private void OnBecameInvisible()
    {
        canBeDestroyed = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object is visible and can be destroyed
        if (canBeDestroyed)
        {
            // Your existing logic for destruction here
            // For example, if (Input.GetKeyDown(KeyCode.Space)) Destroy(gameObject);
        }
    }
}
