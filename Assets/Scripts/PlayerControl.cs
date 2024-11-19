using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Movement")]
    private float horizontalInput;
    private float forwordInput;
    public float turnSpeed;
    public float moveSpeed;

    [Header("Projectile Object")]
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwordInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwordInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
