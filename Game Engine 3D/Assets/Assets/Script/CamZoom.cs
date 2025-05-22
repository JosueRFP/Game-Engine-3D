using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamZoom : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    [SerializeField] float rifleFov;
    [SerializeField] float sniperFov;


    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        GameController.instance.OnRifleMode.AddListener(delegate
        {
            StartCoroutine(ZooOut());
        });
        GameController.instance.OnSniperMode.AddListener(delegate
        {
            StartCoroutine(ZooIn());
        });
    }
    IEnumerator ZooIn()
    {
        while(virtualCamera.m_Lens.FieldOfView > sniperFov)
        {
            virtualCamera.m_Lens.FieldOfView -= 0.5f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator ZooOut()
    {
        while (virtualCamera.m_Lens.FieldOfView < rifleFov)
        {
            virtualCamera.m_Lens.FieldOfView += 1f;
            yield return new WaitForSeconds(0.01f);
        }
    }




}
