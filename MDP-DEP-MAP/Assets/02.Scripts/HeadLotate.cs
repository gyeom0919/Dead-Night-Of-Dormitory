using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HeadLotate : MonoBehaviour
{
	public GameObject enemy;
	public GameObject controller;

	public float speed;

	// bool catch_Key1 = false;
	public bool is_head_rotation_finish = false;

	public static HeadLotate instance = null;

	private void Awake()
	{

		if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
		{
			instance = this; //���ڽ��� instance�� �־��ݴϴ�.
			DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
		}
		else
		{
			if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
				Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
		}

	}

	public bool isCoroutineFinish = false;
	IEnumerator FollowTarget()
	{
		
		if (enemy != null && !is_head_rotation_finish)
		{
			controller.GetComponent<ContinuousTurnProviderBase>().enabled = false;
			controller.GetComponent<ContinuousMoveProviderBase>().enabled = false;

			Vector3 dir = enemy.transform.position - this.transform.position;
			dir.Normalize();
            while (true)
            {
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
				if (isCoroutineFinish)
				{
					break;
				}
				yield return null;
			}
		}

	}

	public void HeadRotate_Finish()
    {
		is_head_rotation_finish = true;
		isCoroutineFinish = true;
		controller.GetComponent<ContinuousTurnProviderBase>().enabled = true;
		controller.GetComponent<ContinuousMoveProviderBase>().enabled = true;
	}

}
