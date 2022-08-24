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
    public float coolTime = 2f;

    private void Update()
    {
        if (coolTime <= 0)
        {
            girlToiletLight.SetActive(true);
            girlDoll.SetActive(true);
        }
    }

    IEnumerator DoorOff()
    {
        while (girlToiletDoor.transform.rotation.y > -90f)
        {
            girlToiletDoor.transform.Rotate(new Vector3(0, -(100f / 60f), 0));
            yield return null;
        }
    }

    IEnumerator LightOnOff()
    {

        while (coolTime > 0)
        {
            girlToiletLight.SetActive(true);
            yield return new WaitForSeconds(coolTime);
            girlToiletLight.SetActive(false);
            yield return new WaitForSeconds(coolTime);
            coolTime -= 0.1f;
        }
       
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
