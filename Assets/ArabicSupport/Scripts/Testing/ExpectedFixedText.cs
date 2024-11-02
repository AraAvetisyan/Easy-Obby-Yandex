using UnityEngine;
using ArabicSupport;
using TMPro;

public class ExpectedFixedText : MonoBehaviour
{
	[TextArea]
	public string Unfixed;

	[TextArea]
	public string Expected;

	public string Fixed { get; private set; }

	public bool ShowTashkeel = false;
	public bool UseHinduNumbers = true;

	public void Fix()
	{
        Unfixed = GetComponent<TextMeshProUGUI>().text;
		Fixed = ArabicFixer.Fix(Unfixed, ShowTashkeel, UseHinduNumbers);
	}
}
