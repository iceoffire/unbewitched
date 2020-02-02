using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Item : MonoBehaviour, IHandled
{
    public Image bottleSpiritImage;
    public Image ingredienteImage;
    public Image bottleImage;
    public Sprite sprite;
    public Rigidbody2D rigidbody2D;
    public RectTransform panelImage;
    Vector3 initialPositionPanelImages;
    private bool isMouseOver;
    public Vector3 initialLocalPosition;
    private bool isBeingHandled
    {
        get
        {
            return this.transform.localPosition != initialLocalPosition;
        }
    }

    private void Start()
    {
        ingredienteImage = this.GetComponentInChildren<Image>();
        ingredienteImage.sprite = sprite;
        initialPositionPanelImages = panelImage.transform.localPosition;
        initialLocalPosition = this.transform.localPosition;
    }

    internal void ResetRigidbody()
    {
        this.rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void ResetPanelPosition()
    {
        this.panelImage.transform.localPosition = initialPositionPanelImages;
    }

    void AnimateFadeIn()
    {
        panelImage.transform.DOLocalMoveY(initialPositionPanelImages.y + 15, 0.3f);
        bottleSpiritImage.color = new Color(1,1,1,0);
        bottleSpiritImage.DOColor(new Color(1, 1, 1, 1), 0.3f);

    }

    void AnimateFadeOut()
    {
        panelImage.transform.DOLocalMoveY(initialPositionPanelImages.y, 0.3f);
        bottleSpiritImage.color = new Color(1, 1, 1, 1);
        bottleSpiritImage.DOColor(new Color(1,1,1, 0), 0.3f);
    }

    private void OnMouseEnter()
    {
        AnimateFadeIn();
    }

    private void OnMouseExit()
    {
        AnimateFadeOut();
    }

    public void Drop()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.None;
    }
}
