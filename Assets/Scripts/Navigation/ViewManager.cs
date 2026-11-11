using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    public static ViewManager instance;

    public List<GameObject> views = new();
    public int startView = 0;

    public Image fadeImage;
    public float fadeTime = 0.25f;

    int currentView;
    int nextView;
    float fadeTimer;
    bool fadingOut = false;
    bool fadingIn = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        ShowOnly(startView);
        SetFadeAlpha(0);
    }

    void Update()
    {
        if (fadingOut)
        {
            fadeTimer -= Time.deltaTime;
            SetFadeAlpha(1 - fadeTimer / fadeTime);

            if (fadeTimer <= 0)
            {
                ShowOnly(nextView);
                fadingOut = false;
                fadingIn = true;
                fadeTimer = fadeTime;
            }
        }
        else if (fadingIn)
        {
            fadeTimer -= Time.deltaTime;
            SetFadeAlpha(fadeTimer / fadeTime);

            if (fadeTimer <= 0)
            {
                SetFadeAlpha(0);
                fadingIn = false;
            }
        }
    }

    public void GoToView(int index)
    {
        if (IsFading() == false && index != currentView && index >= 0 && index < views.Count)
        {
            nextView = index;
            fadeTimer = fadeTime;
            fadingOut = true;
        }
    }

    public bool IsFading()
    {
        if (fadingOut || fadingIn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ShowOnly(int index)
    {
        for (int i = 0; i < views.Count; i++)
        {
            if (i == index)
            {
                views[i].SetActive(true);
            }
            else
            {
                views[i].SetActive(false);
            }
        }

        currentView = index;
    }

    void SetFadeAlpha(float alpha)
    {
        if (fadeImage != null)
        {
            fadeImage.color = new Color(0, 0, 0, alpha);
        }
    }
}
