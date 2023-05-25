using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    public float weaponLiftHeight = 0.01f;
    GameObject currentWeapon;
    bool canPickUp;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))  PickUp();
        if(Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    void PickUp()
    {
        RaycastHit hit;

        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Weapon")
            {
                if(canPickUp) Drop();

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localPosition = new Vector3(0f, weaponLiftHeight, 0f);
                currentWeapon.transform.localEulerAngles = new Vector3(0f, -65f, -25f);
                canPickUp = true;
            }
        }
    }

    void Drop()
    {
        if(currentWeapon != null) 
        {
            currentWeapon.transform.parent = null;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
            currentWeapon.GetComponent<Collider>().isTrigger = false;
            canPickUp = false;
            currentWeapon = null;
        }
    }


}
