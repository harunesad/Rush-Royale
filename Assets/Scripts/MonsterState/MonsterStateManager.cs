using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterStateManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public float health;
    public float armor;
    public float moveSpeed;
    public int specialAttack;

    MonsterBaseState currentState;
    public MonsterMoveState MoveState = new MonsterMoveState();
    public MonsterDieState DieState = new MonsterDieState();
    void Start()
    {
        currentState = MoveState;
        currentState.EnterState(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    void Update()
    {
        healthText.text = health.ToString();
        currentState.UpdateState(this);
    }
    public void SwitchState(MonsterBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
