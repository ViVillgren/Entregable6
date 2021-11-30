using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLateral : MonoBehaviour
{
    public float speed = 4f;
    private float xLim = 15;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > xLim)
        {
            Destroy(gameObject);
        }
    }
}
