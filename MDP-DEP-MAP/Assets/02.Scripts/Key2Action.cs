using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2Action : MonoBehaviour
{
    public GameObject girlToiletLight;
    public GameObject girlDoll;
    public GameObject girlToiletDoor;

    public bool IsPlayerIn = false;
    public bool isTricked = false;
    public float coolTime = 1f;
    public float substractValue = 0.4f;

    private void Update()
    {
        
    }

    IEnumerator DoorOff()
    {
        
        while (girlToiletDoor.transform.rotation.y > -0.70f)
        {Debug.Log(girlToiletDoor.transform.rotation.y);
            girlToiletDoor.transform.Rotate(new Vector3(0, -(100f / 60f), 0));
            yield return null;
        }
    }

    IEnumerator LightOnOff()
    {

            girlToiletLight.SetActive(true);
            yield return new WaitForSeconds(1f);
            girlToiletLight.SetActive(false);
            yield return new WaitForSeconds(1f);

            girlToiletLight.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            girlToiletLight.SetActive(false);
            yield return new WaitForSeconds(0.7f);

            girlToiletLight.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            girlToiletLight.SetActive(false);
            yield return new WaitForSeconds(0.3f);

            girlToiletLight.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            girlToiletLight.SetActive(false);
            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < 7; i++)
            {
                girlToiletLight.SetActive(true);
                yield return new WaitForSeconds(0.05f);
                girlToiletLight.SetActive(false);
                yield return new WaitForSeconds(0.05f);
            }

            girlToiletLight.SetActive(true);
            girlDoll.SetActive(true);

       
       
    }


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player" && !isTricked)
        {
            isTricked = true; //�ѹ��̶� Ʈ����enter�� �ߴٸ� ����ȵǰ��ϴ� �Լ�
            IsPlayerIn = true; //�÷��̾ ������ �˷���
            StartCoroutine("DoorOff");
            StartCoroutine("LightOnOff");
        }
        
    }

}
