using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public float posX, posZ;
    public int myLayer;
    public GameObject objMove;
    public GameObject crashObj;
    public GameObject nearObj;
    public bool firstPos = false;
    public bool isMerge = false;
    public LayerMask layerMask;
    public LayerMask layerMaskBase;
    public LayerMask checkLayers;
    public List<GameObject> others;

    PlayerBaseState currentState;
    public PlayerDownState DownState = new PlayerDownState();
    public PlayerDragState DragState = new PlayerDragState();
    public PlayerUpState UpState = new PlayerUpState();
    private void Awake()
    {
        myLayer = gameObject.layer;
    }
    void Start()
    {
        currentState = DownState;
        currentState.EnterState(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }
    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(this, other);
    }
    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(this, other);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
