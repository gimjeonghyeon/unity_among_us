﻿using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public PlayerColorType playerColorType;
    
    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    private float floatingSpeed;
    private float rotateSpeed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFloatingCrew(Sprite sprite, PlayerColorType playerColorType, Vector3 direction, float floatingSpeed,
        float rotationSpeed, float size)
    {
        this.playerColorType = playerColorType;
        this.direction = direction;
        this.floatingSpeed = floatingSpeed;
        this.rotateSpeed = rotationSpeed;

        spriteRenderer.sprite = sprite;
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColorType));
        
        transform.localScale = new Vector3(size, size, size);
        spriteRenderer.sortingOrder = (int) Mathf.Lerp(1, 32767, size);
    }

    void Update()
    {
        transform.position += direction * floatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotateSpeed));
    }
}
