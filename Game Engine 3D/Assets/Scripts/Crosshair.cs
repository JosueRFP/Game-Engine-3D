using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Texture rifle;
    [SerializeField] Texture sniper;
    RawImage crosshairImage;
    // Start is called before the first frame update
    void Start()
    {
        crosshairImage = GetComponent<RawImage>();
        GameController.instance.OnRifleMode.AddListener(delegate
        {
            crosshairImage.texture = rifle;
        });
        GameController.instance.OnSniperMode.AddListener(delegate
        {
            crosshairImage.texture = sniper;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
