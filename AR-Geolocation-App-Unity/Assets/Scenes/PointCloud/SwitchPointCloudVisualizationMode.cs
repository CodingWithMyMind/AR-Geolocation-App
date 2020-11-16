using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPointCloudManager))]
public class SwitchPointCloudVisualizationMode : MonoBehaviour
{
    [SerializeField]
    Button m_ToggleButton;

    public Button toggleButton
    {
        get => m_ToggleButton;
        set => m_ToggleButton = value;
    }

    [SerializeField]
    Text m_Log;

    public Text log
    {
        get => m_Log;
        set => m_Log = value;
    }

    [SerializeField]
    ARAllPointCloudPointsParticleVisualizer.Mode m_Mode = ARAllPointCloudPointsParticleVisualizer.Mode.All;

    public ARAllPointCloudPointsParticleVisualizer.Mode mode
    {
        get => m_Mode;
        set => SetMode(value);
    }

    public void SwitchVisualizationMode()
    {
        SetMode((ARAllPointCloudPointsParticleVisualizer.Mode)(((int)m_Mode + 1) % 3));
    }

    void OnEnable()
    {
        SetMode(m_Mode);
        GetComponent<ARPointCloudManager>().pointCloudsChanged += OnPointCloudsChanged;
    }

    StringBuilder m_StringBuilder = new StringBuilder();

    void OnPointCloudsChanged(ARPointCloudChangedEventArgs eventArgs)
    {
        m_StringBuilder.Clear();
        foreach (var pointCloud in eventArgs.updated)
        {
            m_StringBuilder.Append($"\n{pointCloud.trackableId}: ");
            if (m_Mode == ARAllPointCloudPointsParticleVisualizer.Mode.CurrentFrame)
            {
                if (pointCloud.positions.HasValue)
                {
                    m_StringBuilder.Append($"{pointCloud.positions.Value.Length}");
                }
                else
                {
                    m_StringBuilder.Append("0");
                }

                m_StringBuilder.Append(" points in current frame.");
            }
            else if(m_Mode == ARAllPointCloudPointsParticleVisualizer.Mode.All)
            {
                var visualizer = pointCloud.GetComponent<ARAllPointCloudPointsParticleVisualizer>();
                if (visualizer)
                {
                    m_StringBuilder.Append($"{visualizer.totalPointCount} total points");
                }
            }
            else if(m_Mode == ARAllPointCloudPointsParticleVisualizer.Mode.None)
            {
                m_StringBuilder.Append(" Hiding tracking Points");
            }
        }
        if (log)
        {
            log.text = m_StringBuilder.ToString();
        }
    }

    void SetMode(ARAllPointCloudPointsParticleVisualizer.Mode mode)
    {
        m_Mode = mode;
        if (toggleButton)
        {
            var text = toggleButton.GetComponentInChildren<Text>();
            switch (mode)
            {
                case ARAllPointCloudPointsParticleVisualizer.Mode.All:
                    text.text = "All";
                    break;
                case ARAllPointCloudPointsParticleVisualizer.Mode.CurrentFrame:
                    text.text = "Current Frame";
                    break;

                case ARAllPointCloudPointsParticleVisualizer.Mode.None:
                    text.text = "Show None";
                    break;
            }
        }

        var manager = GetComponent<ARPointCloudManager>();
        foreach (var pointCloud in manager.trackables)
        {
            var visualizer = pointCloud.GetComponent<ARAllPointCloudPointsParticleVisualizer>();
            if (visualizer)
            {
                visualizer.mode = mode;
            }
        }
    }
}
