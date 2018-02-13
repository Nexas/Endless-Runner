﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffsetX : MonoBehaviour {

    public int materialIndex = 0;
    public Vector2 uvAnimationRate;
    public string textureName = "_MainTex";
    Vector2 uvOffset = Vector2.zero;

    void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
