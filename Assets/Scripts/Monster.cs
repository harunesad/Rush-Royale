using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour
{
    MonsterState MonsterMode = MonsterState.Idle;
    public float health;
    public float armor;
    public float moveSpeed;
    public int specialAttack;

    [SerializeField] GameObject targetPoint;
    [SerializeField] TextMeshProUGUI healthText;
    protected enum MonsterState
    {
        Idle,
        MoveTarget,
        Die,
    }
    private void Start()
    {
        targetPoint = GameObject.Find("TargetPoint");
        InvokeRepeating("AttackPlayer", 2, 15);
    }
    private void Update()
    {
        healthText.text = health.ToString();
        UpdateMonster();
    }
    public void UpdateMonster()
    {
        switch (MonsterMode)
        {
            case MonsterState.Idle:
                if (health <= 0)
                {
                    Destroy(gameObject, 0.5f);
                }
                else
                {
                    MonsterMode = MonsterState.MoveTarget;
                }
                break;
            case MonsterState.MoveTarget:
                if (health <= 0)
                {
                    MonsterMode = MonsterState.Die;
                }
                break;
            case MonsterState.Die:
                MonsterMode = MonsterState.Idle;
                break;
        }
        DoAction();
    }
    public void DoAction()
    {
        switch (MonsterMode)
        {
            case MonsterState.MoveTarget:
                MoveMonster();
                break;
            case MonsterState.Die:
                CostManager.Instance.KillMonster();
                Died();
                break;
        }
    }
    void MoveMonster()
    {
        if (transform.position.z < targetPoint.transform.position.z)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else
        {
            healthText.gameObject.transform.parent.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }
    void AttackPlayer()
    {
        SpecialAttack.instance.Special(specialAttack);
    }
    void Died()
    {
        WaveControl.Instance.monsters.Remove(gameObject);
        UIManager.Instance.CountRemove();
        if (WaveControl.Instance.waveFinish)
        {
            UIManager.Instance.time = 20;
            SpecialAttack.instance.playerSoldiers.Clear();

            for (int i = 0; i < SpawnSystem.Instance.soldiers.Count; i++)
            {
                if (SpawnSystem.Instance.soldiers[i] == null)
                {
                    SpawnSystem.Instance.soldiers.RemoveAt(i);
                    i--;
                }
            }
            SpawnSystem.Instance.ReAttack();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Died();
            Destroy(gameObject);
        }
    }
}
