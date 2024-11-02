using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArabicTextChooser : MonoBehaviour
{
    ExpectedFixedText _expectedFixedText;
    FixArabic3DText _fixArabic3DText;
    ArabicSupportTester _arabicSupportTester;

    [SerializeField] private TMP_FontAsset arabicFont;
    [SerializeField] private TMP_FontAsset otherFont;
    void Start()
    {
        _expectedFixedText = GetComponent<ExpectedFixedText>();
        _fixArabic3DText = GetComponent<FixArabic3DText>();
        _arabicSupportTester = GetComponent<ArabicSupportTester>();
        if(Geekplay.Instance.language == "ar")
        {
            _expectedFixedText.enabled = true;
            _fixArabic3DText.enabled = true;
            _arabicSupportTester.enabled = true;
            GetComponent<TextMeshProUGUI>().font = arabicFont;
        }
        else
        {
            _expectedFixedText.enabled = false;
            _fixArabic3DText.enabled = false;
            _arabicSupportTester.enabled = false;
            GetComponent<TextMeshProUGUI>().font = otherFont;
        }
    }

}
