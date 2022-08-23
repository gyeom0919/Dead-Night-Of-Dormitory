using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2Action : MonoBehaviour
{
    public GameObject girlToiletLight;
    public GameObject girlDoll;
    public GameObject girlToiletDoor;

    public bool IsPlayerIn = false;
    public bool IsLightOn = false;
    public bool isTricked = false;
    public float coolTime = 3f;

    public float substractValue = 0.2f;
    private void Update()
    {
        if(coolTime <= 0)
        {
            gameObject.SetActive(true);
            girlDoll.SetActive(true);
        }
        else if (IsPlayerIn)
        {
            Invoke("LightOnOff", coolTime);
            coolTime -= 0.1f;
        }
    }

    //IEnumerator void DoorOff()
    //{
      //  if(girlToiletDoor.transform.rotation.y <= -90)
      //  {
     //       girlToiletDoor.transform.Rotate(new Vector3(0, -(90f/60), 0));
     //       yield return WaitForSeconds(0.1f);
      //  }
  //  }

    public void LightOnOff()
    {
        IsLightOn = !IsLightOn;
        girlToiletLight.SetActive(IsLightOn);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("����̾");
        if (other.gameObject.tag == "Player" && !isTricked)
        {
            Debug.Log("�������");
            isTricked = true; //�ѹ��̶� Ʈ����enter�� �ߴٸ� ����ȵǰ��ϴ� �Լ�
            IsPlayerIn = true; //�÷��̾ ������ �˷���
        }
        
    }

}
