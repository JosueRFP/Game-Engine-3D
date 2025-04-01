using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SniperZoom : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    [SerializeField] float rifleFOV;
    [SerializeField] float sniperFOV;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        GameController.instance.OnRifleMode.AddListener(delegate
        {
            //Ativa quando o modo rifle é acionado
            virtualCamera.m_Lens.FieldOfView = rifleFOV;
        });
        GameController.instance.OnSniperMode.AddListener(delegate
        {
            //Ativa quando o modo sniper é acionado
            virtualCamera.m_Lens.FieldOfView = sniperFOV;
        });


    }
}
