using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rippleproc : MonoBehaviour

  {
    public Transform playerPos;
    public Material RippleMaterial;
    public float MaxAmount = 50f;

    [Range(0, 1)]
    public float Friction = .9f;

    private float Amount = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Effect();
        }
        if (Input.GetKeyDown(KeyCode.E)) { Effect(); }
        this.RippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }
    void Effect()
    {
        this.Amount = this.MaxAmount;
        Vector3 pos = playerPos.position;
        this.RippleMaterial.SetFloat("_CenterX", pos.x);
        this.RippleMaterial.SetFloat("_CenterY", pos.y);
    }
}
