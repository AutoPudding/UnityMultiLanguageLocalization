using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LanguageItem<T>
{
    public Language language;
    public T value;

    public LanguageItem(Language language, T value)
    {
        this.language = language;
        this.value = value;
    }
}


[Serializable] public class MultiLanguageText : MultiLanguageItem<string> { }
[Serializable] public class MultiLanguageSprite : MultiLanguageItem<Sprite> { }
[Serializable] public class MultiLanguageAudioClip : MultiLanguageItem<AudioClip> { }
[Serializable] public class MultiLanguageObject : MultiLanguageItem<GameObject> { }

[Serializable]
public class MultiLanguageItem<T>
{
    [HideInInspector]
    public LanguageManager languageManager = null;

    public T currentTranslation = default;

    public List<LanguageItem<T>> languageItems = new();


    public void Update()
    {
        if (languageManager == null) { return; }

        Update(languageManager.currentLanguage);
    }

    public void Update(Language language)
    {
        currentTranslation = GetTranslationIn(language);

        if (currentTranslation == null)
        { currentTranslation = GetTranslationIn(Language.Default); }
    }

    public T GetTranslationIn(Language language)
    {
        foreach (LanguageItem<T> item in languageItems)
        {
            if (item.language == language)
            { return item.value; }
        }

        return default;
    }
}
