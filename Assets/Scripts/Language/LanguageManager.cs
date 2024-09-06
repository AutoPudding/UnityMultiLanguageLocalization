using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public enum Language
{
    Default,
    English_US,              // English_US
    English_UK,              // English_UK
    Français,             // French
    Deutsch,              // German
    Español,              // Spanish
    Italiano,             // Italian
    Nederlands,           // Dutch
    Polski,               // Polish
    Português,            // Portuguese
    Svenska,              // Swedish
    Dansk,                // Danish
    Suomi,                // Finnish
    Norsk,                // Norwegian
    Bahasa_Melayu,        // Malay
    Filipino,             // Filipino
    Khmer,                // Khmer
    Română,               // Romanian
    Ελληνικά,             // Greek
    Українська,           // Ukrainian
    Magyar,               // Hungarian
    Български,            // Bulgarian
    Српски,               // Serbian
    Hrvatski,             // Croatian
    Türkçe,               // Turkish
    Русский,              // Russian
    Қазақша,              // Kazakh
    Oʻzbekcha,            // Uzbek
    Bahasa_Indonesia,     // Indonesian
    Tiếng_Việt,           // Vietnamese
    简体中文,              // Simplified Chinese
    繁體中文,              // Traditional Chinese
    日本語,                // Japanese
    한국어,                // Korean
    हिन्दी,                  // Hindi
    ไทย,                  // Thai
    العربية,              // Arabic
    עברית,                // Hebrew
    فارسی,                // Persian (Farsi)
}


public class LanguageManager : MonoBehaviour
{
    public Language currentLanguage = Language.English_US;

    public List<MultiLanguageText> multiLanguageTexts = new();
    public List<MultiLanguageSprite> multiLanguageSprites = new();
    public List<MultiLanguageAudioClip> multiLanguageAudioClips = new();
    public List<MultiLanguageObject> multiLanguageObjects = new();

    public UnityEvent onLanguageChange = new();


    private void Awake()
    {
        multiLanguageTexts = multiLanguageTexts.Where(item => item != null).ToList();
        multiLanguageSprites = multiLanguageSprites.Where(item => item != null).ToList();
        multiLanguageAudioClips = multiLanguageAudioClips.Where(item => item != null).ToList();
        multiLanguageObjects = multiLanguageObjects.Where(item => item != null).ToList();

        foreach (MultiLanguageText mutiLanguageText in multiLanguageTexts)
        { mutiLanguageText.languageManager = this; }
        foreach (MultiLanguageSprite mutiLanguageSprite in multiLanguageSprites)
        { mutiLanguageSprite.languageManager = this; }
        foreach (MultiLanguageAudioClip mutiLanguageAudioClip in multiLanguageAudioClips)
        { mutiLanguageAudioClip.languageManager = this; }
        foreach (MultiLanguageObject mutiLanguageObject in multiLanguageObjects)
        { mutiLanguageObject.languageManager = this; }

    }

    private void Start()
    {
        UpdateLanguage();
    }


    // Switch
    public void SwitchLanguage(Language language)
    {
        currentLanguage = language;
        UpdateLanguage();
    }

    public void SwitchLanguage(int index) { SwitchLanguage((Language)index); }
    public void SwitchLanguage(string language) { SwitchLanguage((Language)Enum.Parse(typeof(Language), language)); }


    //Update
    public void UpdateLanguage()
    {
        multiLanguageTexts = multiLanguageTexts.Where(item => item != null).ToList();
        multiLanguageSprites = multiLanguageSprites.Where(item => item != null).ToList();
        multiLanguageAudioClips = multiLanguageAudioClips.Where(item => item != null).ToList();
        multiLanguageObjects = multiLanguageObjects.Where(item => item != null).ToList();

        foreach (MultiLanguageText mutiLanguageText in multiLanguageTexts)
        {
            if (mutiLanguageText == null) continue;
            mutiLanguageText.Update(currentLanguage);
        }
        foreach (MultiLanguageSprite mutiLanguageSprite in multiLanguageSprites)
        {
            if (mutiLanguageSprite == null) continue;
            mutiLanguageSprite.Update(currentLanguage);
        }
        foreach (MultiLanguageAudioClip mutiLanguageAudioClip in multiLanguageAudioClips)
        {
            if (mutiLanguageAudioClip == null) continue;
            mutiLanguageAudioClip.Update(currentLanguage);
        }
        foreach (MultiLanguageObject mutiLanguageObject in multiLanguageObjects)
        {
            if (mutiLanguageObject == null) continue;
            mutiLanguageObject.Update(currentLanguage);
        }

        onLanguageChange.Invoke();

        Debug.Log("Update Language:" + currentLanguage.ToString());
    }


    //Register
    public void Register(MultiLanguageText mutiLanguageText)
    {
        if (mutiLanguageText == null) { return; }

        if (!multiLanguageTexts.Contains(mutiLanguageText))
        { multiLanguageTexts.Add(mutiLanguageText); }

        mutiLanguageText.languageManager = this;
        mutiLanguageText.Update();
    }
    public void Register(MultiLanguageSprite mutiLanguageSprite)
    {
        if (mutiLanguageSprite == null) { return; }

        if (!multiLanguageSprites.Contains(mutiLanguageSprite))
        { multiLanguageSprites.Add(mutiLanguageSprite); }

        mutiLanguageSprite.languageManager = this;
        mutiLanguageSprite.Update();
    }
    public void Register(MultiLanguageAudioClip mutiLanguageAudioClip)
    {
        if (mutiLanguageAudioClip == null) { return; }

        if (!multiLanguageAudioClips.Contains(mutiLanguageAudioClip))
        { multiLanguageAudioClips.Add(mutiLanguageAudioClip); }

        mutiLanguageAudioClip.languageManager = this;
        mutiLanguageAudioClip.Update();
    }
    public void Register(MultiLanguageObject mutiLanguageObject)
    {
        if (mutiLanguageObject == null) { return; }

        if (!multiLanguageObjects.Contains(mutiLanguageObject))
        { multiLanguageObjects.Add(mutiLanguageObject); }

        mutiLanguageObject.languageManager = this;
        mutiLanguageObject.Update();
    }

    //Remove
    public void Remove(MultiLanguageText mutiLanguageText)
    {
        if (mutiLanguageText == null
        || !multiLanguageTexts.Contains(mutiLanguageText))
        { return; }

        multiLanguageTexts.Remove(mutiLanguageText);
        mutiLanguageText.languageManager = null;
    }
    public void Remove(MultiLanguageSprite mutiLanguageSprite)
    {
        if (mutiLanguageSprite == null
        || !multiLanguageSprites.Contains(mutiLanguageSprite))
        { return; }

        multiLanguageSprites.Remove(mutiLanguageSprite);
        mutiLanguageSprite.languageManager = null;
    }
    public void Remove(MultiLanguageAudioClip mutiLanguageAudioClip)
    {
        if (mutiLanguageAudioClip == null
        || !multiLanguageAudioClips.Contains(mutiLanguageAudioClip))
        { return; }

        multiLanguageAudioClips.Remove(mutiLanguageAudioClip);
        mutiLanguageAudioClip.languageManager = null;
    }
    public void Remove(MultiLanguageObject mutiLanguageObject)
    {
        if (mutiLanguageObject == null
        || !multiLanguageObjects.Contains(mutiLanguageObject))
        { return; }

        multiLanguageObjects.Remove(mutiLanguageObject);
        mutiLanguageObject.languageManager = null;
    }


}
