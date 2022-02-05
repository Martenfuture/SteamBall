using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingTexture : MonoBehaviour
{
    [SerializeField] float scrollSpeedY;
    [SerializeField] float scrollSpeedX;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = Time.time * scrollSpeedY;
        float moveX = Time.time * scrollSpeedX;
        rend.material.SetTextureOffset("_BaseMap", new Vector2(moveX, moveY));
    }
}
