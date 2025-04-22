using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    Camera cam;

    public ParticleSystem muzzleFlash;
    public ParticleSystem capsules;

    public GameObject shotPrefab;
    public GameObject shotPoint;

    public float shotInterval = 0.1f;
    public float shotInstantiateTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        muzzleFlash.Stop();
        capsules.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (mousePosition - (Vector2)transform.position).normalized;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzzleFlash.Play();
            capsules.Play();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            muzzleFlash.Stop();
            capsules.Stop();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(Time.time > shotInstantiateTime)
            {
                Instantiate(shotPrefab, shotPoint.transform.position, transform.rotation);
                shotInstantiateTime = Time.time + shotInterval;
            }
            
        }

    }


}
