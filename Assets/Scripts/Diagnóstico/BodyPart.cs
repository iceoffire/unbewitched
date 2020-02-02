using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BodyPart : MonoBehaviour
{
    [SerializeField]
    List<BodyImage> bodyImages;

    public Image image;
    BodyPartOrigin bodyPartOrigin;

    void Awake()
    {
        image = this.GetComponent<Image>();
    }

    public void UpdateObjectToOrigin(BodyPartOrigin bodyPartOrigin)
    {
        BodyImage bodyImage = bodyImages.FirstOrDefault(x=>x.bodyPartOrigin == bodyPartOrigin);
        if (!bodyImages.IsDefault())
        {
            SetImage(bodyImage.image);
        }
        this.bodyPartOrigin = bodyPartOrigin;
    }

    private void SetImage(Sprite image)
    {
        this.image.sprite = image;
    }

    internal void LoadArt(BodyInformation bodyPart)
    {
        BodyImage bodyImage = bodyImages.FirstOrDefault(x => x.bodyPartOrigin == bodyPart.bodyPart);
        if (!bodyImage.IsDefault())
        {
            this.image.sprite = bodyImage.image;
        }
    }

    public void LoadClickableInformation(BodyInformation leg)
    {
        Clickable clickable = this.gameObject.AddComponent(typeof(Clickable)) as Clickable;
        clickable.notifyInformation = leg.notifyInformation;
        // further -> PUT OnMouseOverIcon
    }
}