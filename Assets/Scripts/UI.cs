using UnityEngine;


public class UI : MonoBehaviour
{
    private UnityEngine.UI.Text infoBox;
    private System.Text.StringBuilder stringBuilder;
    private SomoEpicNthDerivedController somo;


    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        
        infoBox = GameObject.Find("InfoBox").GetComponent<UnityEngine.UI.Text>();
        stringBuilder = new System.Text.StringBuilder();
        somo = FindObjectOfType<SomoEpicNthDerivedController>();
    }


    private void FixedUpdate()
    {
        stringBuilder.Clear();
        stringBuilder.Append(1 / Time.deltaTime).Append(" update/s").Append(System.Environment.NewLine).Append(System.Environment.NewLine);

        for (int i = 0; i < somo.derivatives.Length; i++)
            stringBuilder.Append("Derivative ").Append(i + 1).Append(": (").Append(somo.derivatives[i].x).Append(", ").Append(somo.derivatives[i].y).Append(")").Append(System.Environment.NewLine).Append("Drag: ").Append(somo.drags[i]).Append(System.Environment.NewLine).Append(System.Environment.NewLine);

        infoBox.text = stringBuilder.ToString();
    }


    public void FuckGoBack()
    {
        somo.transform.position = Vector3.zero;
    }
}
