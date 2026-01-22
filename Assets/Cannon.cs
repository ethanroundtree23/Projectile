using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Animator animator;
    public Transform fireSocket;
    public float rotationRate = 90.0f;
    public ParticleSystem fireFX;

    public int numProjectiles = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        float aimInput = Input.GetAxis("Horizontal");
        aimInput *= rotationRate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Cannon Script Update: before Fire()");
            Fire();
            fireFX.Play();
            //Debug.Log("Cannon Script Update: after Fire()");
        }
    }

    void Fire()
    {
        animator.SetTrigger("Fire");
        Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
        numProjectiles++;
        //Debug.Log("at fireFX.Play()");
        //fireFX.Play();
    }
}
