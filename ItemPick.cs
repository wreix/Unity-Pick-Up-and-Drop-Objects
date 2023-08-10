using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public Transform equipPosition;
    public float distance = 10f;
    GameObject currentItem;
    GameObject It;

    bool canGrab;

    private void Update()
    {
        CheckItem();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentItem != null)
                    Drop();


                PickUp();
            }
        }

        if (currentItem != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
                Drop();
        }


    }

    private void CheckItem()
    {
        RaycastHit hit;


        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("Bunu tutabilirim");
                canGrab = true;
                It = hit.transform.gameObject;
            }

        }
        else
        {
            canGrab = false;
        }

    }

    private void PickUp()
    {
        currentItem = It;
        currentItem.transform.position = equipPosition.position;
        currentItem.transform.parent = equipPosition;
        currentItem.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void Drop()
    {
        currentItem.transform.parent = null;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem = null;
    }




}
