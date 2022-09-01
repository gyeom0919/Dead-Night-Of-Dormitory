using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class Key1Monster : MonoBehaviour
{
    public Transform playerTransform;
    public Transform target;
    public NavMeshAgent navAgent;
    public Transform playerKillPos;
    public Transform foodTransform;
    private Rigidbody rigid;
    private Animator animator;
    private AudioSource audioSourece;

    public AudioClip catchAudio;
    public AudioClip walkAudio;
    public AudioClip haulAudio;

    public GameObject mainCamera;
    public GameObject subCamera;
<<<<<<< Updated upstream
=======
    public GameObject food;
>>>>>>> Stashed changes

    public bool stun = false;
    float timer;
    int waitingTime;

    private void Awake()
    {
        target = playerTransform;
        animator = GetComponent<Animator>();
        audioSourece = GetComponent<AudioSource>();
        navAgent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();

        navstop(); // �����Ҷ� �÷��̾� ������ ����

        timer = 0f;
        waitingTime = 3;
        animator.SetBool("IsStun", false);

    }

    IEnumerator Eat(Transform target)
    {
        
        transform.position -= new Vector3(0f, -1.5f, 0f);

        for (int i = 0; i < 100; i++)
        {
            target.position = foodTransform.position;
            yield return null;
        }
<<<<<<< Updated upstream
=======


        yield return new WaitForSeconds(2f);
        EatFinish();
>>>>>>> Stashed changes
    }

    public void EatFinish()
    {
<<<<<<< Updated upstream
        //���� �ٸԾ����� ����Ǵ� �Լ�
        //���� �����ϰ� �÷��׸� Ȱ��ȭ��Ŵ 
        //Ÿ���� �÷��̾�� �ٲ�
=======
        Debug.Log("�����¼��");
        Destroy(food);
        target = playerTransform;
>>>>>>> Stashed changes
    }

    public void navgo()
    {
        Debug.Log("����մϴ�");
        navAgent.isStopped = false;
    }

    public void navstop()
    {
        navAgent.isStopped = true;
    }

    public void AudioSet_Houl()
    {
        //�Ͽ︵ 

        audioSourece.clip = haulAudio;
        if(!audioSourece.isPlaying)
            audioSourece.Play();
    }

    public void AudioSet_Walk()
    {
        // �ȴ¼Ҹ�

        audioSourece.clip = walkAudio;
        if (!audioSourece.isPlaying)
            audioSourece.Play();
    }

    public void AudioSet_catch()
    {
        //�÷��̾� kill �Ҹ�

        audioSourece.clip = catchAudio;
        if (!audioSourece.isPlaying)
            audioSourece.Play();
    }

    void freezevelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void Update()
    {

        if (stun == false)
        {
            //���� ���°� �ƴ϶�� �÷��̾ ����

            //freezevelocity();
            navAgent.SetDestination(target.position);
        }
        else if (stun == true)
        {
            //���� ���¶�� ����, WaitingTime�� ������


            navAgent.isStopped = true; 
            animator.SetBool("IsStun", true);
            audioSourece.Stop();

            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                timer = 0;
                stun = false;
                animator.SetBool("IsStun", false);
            }
        }
    }

    private bool isCanUseEat = true;
<<<<<<< Updated upstream
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //�÷��̾�� ��Ҵٸ� killPlayer�� ����

=======
    private bool isCanKill = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isCanKill)
        {
            //�÷��̾�� ��Ҵٸ� killPlayer�� ����
            isCanKill = false;
>>>>>>> Stashed changes
            animator.SetTrigger("CatchPlayer");
            AudioSet_catch();
            StartCoroutine("killPlayer");

        }

        if(other.gameObject.tag == "Food" && isCanUseEat)
        {
            isCanUseEat = false;
            animator.SetTrigger("Eat");
            StartCoroutine(Eat(other.transform));
<<<<<<< Updated upstream
=======
            food = other.gameObject;
>>>>>>> Stashed changes
        }
    }

    IEnumerator killPlayer()
    {
        mainCamera.SetActive(false);
        subCamera.SetActive(true); //subCamera���

        //subCamera�� ���������� ������ ������ �̵���Ŵ, ���Ͱ� �÷��̾ ���µ��� ȿ��

        for (int i = 0; i < 20000; i++)
        {  
            subCamera.transform.position = playerKillPos.position + new Vector3(0f, 0f, 0f);
            subCamera.transform.eulerAngles = new Vector3(0, playerKillPos.eulerAngles.y, 0);
            yield return null;
        }
        
    }
}



