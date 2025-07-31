using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    #region Variable
    [SerializeField] private Transform _respawnPoint;
    [SerializeField] private GameObject _player;
    private CinemachineVirtualCamera _cinemechineVirtualCamera;


    [SerializeField] private float respawnTime;
    private float respawnTimeStart;

    private bool respawn;

    private void Awake() {
        _cinemechineVirtualCamera = GameObject.Find(GameObjectNameConstants.PLAYER_CAMERA).GetComponent<CinemachineVirtualCamera>();
    }
    #endregion
    private void Update() {
        CheckRespawn();
    }


    public void Respawn() {
        respawnTimeStart = Time.time;
        respawn = true;
    }

    private void CheckRespawn() {
        if (Time.time > respawnTimeStart + respawnTime && respawn) {
            var playerTemp = Instantiate(_player, _respawnPoint);
            _cinemechineVirtualCamera.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }
}
