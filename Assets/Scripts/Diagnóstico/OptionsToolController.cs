using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OptionsToolController : MonoBehaviour
{
    public List<OptionsToolButtonController> childsOptions;
    BoxCollider2D boxCollider;

    static OptionsToolController singleton;
    NotifyInformation lastObjectNotifyInformation;
    static bool isMouseOver;
    const float NO_OBJECT_ACTIVE = -1;

    private void Awake()
    {
        singleton = this;
        boxCollider = GetComponent<BoxCollider2D>();
        this.gameObject.SetActive(false);
    }

    public static void Hide()
    {
        singleton.StartCoroutine(_AnimateFadeOut());
    }
    

    public static void Show(Clickable clickableOrigin, NotifyInformation notifyInformation)
    {
        if (IsNeededToShowThisPopUp(notifyInformation))
        {
            ShowThisObject();
            LoadNotifyInformation(notifyInformation);
            HideOptionsThatAreNull(notifyInformation);
            ShowOptionsThatAreShowable(notifyInformation);
            UpdateLocationToMousePosition();
            UpdateCollider();
            Draw();
            MakeChildAnimation(Animate.FadeIn);
        }
    }

    private static bool IsNeededToShowThisPopUp(NotifyInformation notifyInformation)
    {
        return notifyInformation.isClickable;
    }

    private static void ShowOptionsThatAreShowable(NotifyInformation notifyInformation)
    {
        if (!IsNeededToHideExaminate(notifyInformation))
        {
            ShowExaminate();
        }
        if (!IsNeededToHideLook(notifyInformation))
        {
            ShowLook();
        }
        if (!IsNeededToHideWand(notifyInformation))
        {
            ShowWand();
        }
    }

    private static void UpdateCollider()
    {
        int amountObjectsActivatedOnOptionsList = singleton.childsOptions.Count(x => x.gameObject.activeSelf);
        SetBoxColliderHeightAndUpdateIt(amountObjectsActivatedOnOptionsList);
        SetBoxColliderOffsetBasedOnAmountOfObjects(amountObjectsActivatedOnOptionsList);
    }

    private static IEnumerator _AnimateFadeOut()
    {
        MakeChildAnimation(Animate.FadeOut);
        yield return new WaitForSeconds(OptionsToolButtonController.timeToShowAnimate);
        singleton.gameObject.SetActive(false);
    }


    private static float CalculateHeightForCollider(int amountOfObjects)
    {
        try
        {
            float heightForEachObject = GetNormalSizeFromAnyObjectTarget(singleton.childsOptions).y;
            return heightForEachObject * amountOfObjects;
        }
        catch
        {
            return NO_OBJECT_ACTIVE;
        }
    }

    private static void SetBoxColliderOffsetBasedOnAmountOfObjects(int amountOfObject)
    {
        try
        {
            int offSetToThree = -90;
            int offSetPlusForEachObject = 30;
            int MAX_AMOUNT_OF_OBJECTS = 3;
            float newOffset = offSetToThree + offSetPlusForEachObject* (MAX_AMOUNT_OF_OBJECTS-amountOfObject);
            Vector2 normalSizeOfChildOption = GetNormalSizeFromAnyObjectTarget(singleton.childsOptions);
            singleton.boxCollider.offset = new Vector2(normalSizeOfChildOption.x / 2f, newOffset);
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }

    }

    private static Vector2 GetNormalSizeFromAnyObjectTarget(List<OptionsToolButtonController> objects)
    {
        if (objects.Count()>0)
        {
            return objects[0].maximumSize;
        }
        else
        {
            throw new Exception("No object found");
        }
    }

    private static void HideOptionsThatAreNull(NotifyInformation notifyInformation)
    {
        if (IsNeededToHideExaminate(notifyInformation))
        {
            HideExaminate();
        }
        if (IsNeededToHideLook(notifyInformation))
        {
            HideLook();
        }
        if (IsNeededToHideWand(notifyInformation))
        {
            HideWand();
        }
    }

    static void ShowOption(OptionType optionType)
    {
        OptionsToolButtonController optionButton = singleton.childsOptions.FirstOrDefault(x => x.optionType == optionType);
        if (optionButton.IsDefault())
        {
            Debug.LogWarning($"Something went wrong when tried to Hide Option, {optionType} need atention");
        }
        else
        {
            optionButton.gameObject.SetActive(true);
        }
    }

    static void HideOption(OptionType optionType)
    {
        OptionsToolButtonController optionButton = singleton.childsOptions.FirstOrDefault(x => x.optionType == optionType);
        if (optionButton.IsDefault())
        {
            Debug.LogWarning($"Something went wrong when tried to Hide Option, {optionType} need atention");
        }
        else
        {
            optionButton.gameObject.SetActive(false);
        }
    }

    private static bool IsNeededToHideLook(NotifyInformation notifyInformation)
    {
        return notifyInformation.textOnLookClick.Equals(string.Empty);
    }

    private static bool IsNeededToHideWand(NotifyInformation notifyInformation)
    {
        return notifyInformation.textOnWandClick.Equals(string.Empty);
    }

    private static bool IsNeededToHideExaminate(NotifyInformation notifyInformation)
    {
        return notifyInformation.textOnExaminateClick.Equals(string.Empty);
    }

    public static bool IsMouseOver()
    {
        if (!singleton.gameObject.activeSelf) return false;
        return isMouseOver;
    }

    private static void SetBoxColliderHeightAndUpdateIt(int amountOfObjects)
    {
        float newHeightForCollider = CalculateHeightForCollider(amountOfObjects);
        singleton.boxCollider.size = new Vector2(singleton.boxCollider.size.x, newHeightForCollider);
    }

    internal static string GetTextFromOptionType(OptionType optionType)
    {
        switch(optionType)
        {
            case OptionType.Wand:
                return singleton.lastObjectNotifyInformation.textOnWandClick;
            case OptionType.Examinate:
                return singleton.lastObjectNotifyInformation.textOnExaminateClick;
            case OptionType.Look:
                return singleton.lastObjectNotifyInformation.textOnLookClick;
        }
        return "";
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    private static void MakeChildAnimation(Animate fade)
    {
        switch(fade)
        {
            case (Animate.FadeIn):
                AnimateFadeIn();
                break;
            case (Animate.FadeOut):
                AnimateFadeOut();
                break;
        }
    }

    private static void AnimateFadeOut()
    {
        foreach (OptionsToolButtonController optionsButtonController in singleton.childsOptions)
        {
            if (optionsButtonController.gameObject.activeSelf)
            {
                optionsButtonController.AnimateOffShow();
            }
        }
    }

    private static void AnimateFadeIn()
    {
        foreach (OptionsToolButtonController optionsButtonController in singleton.childsOptions)
        {
            if (optionsButtonController.gameObject.activeSelf)
            {
                optionsButtonController.AnimateOnShow();
            }
        }
    }

    private static void LoadNotifyInformation(NotifyInformation notifyInformation)
    {
        singleton.lastObjectNotifyInformation = notifyInformation;
    }

    private static void UpdateLocationToMousePosition()
    {
        // further-> need to respect the boundaries
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        singleton.gameObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    private static void ShowWand()
    {
        ShowOption(OptionType.Wand);
    }

    private static void HideWand()
    {
        HideOption(OptionType.Wand);
    }

    private static void ShowLook()
    {
        ShowOption(OptionType.Look);
    }

    private static void HideLook()
    {
        HideOption(OptionType.Look);
    }

    private static void ShowExaminate()
    {
        ShowOption(OptionType.Examinate);
    }

    private static void HideExaminate()
    {
        HideOption(OptionType.Examinate);
    }

    private static void ShowThisObject()
    {
        singleton.gameObject.SetActive(true);
    }



    private static void Draw()
    {
        singleton.gameObject.SetActive(true);
    }

    public enum Animate
    {
        FadeIn,
        FadeOut,
    }
}

public static class TypeHelper
{
    public static bool IsDefault<T>(this T val)
    {
        return EqualityComparer<T>.Default.Equals(val, default(T));
    }
}