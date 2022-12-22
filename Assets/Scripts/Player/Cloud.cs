using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private PlayerMoney _player;

    private Vector3 offset;

    private void Update()
    {
        MoveParticl();
    }

    public void MoveParticl()
    {
        transform.eulerAngles = new Vector3(90, 0, 0);
    }
}
