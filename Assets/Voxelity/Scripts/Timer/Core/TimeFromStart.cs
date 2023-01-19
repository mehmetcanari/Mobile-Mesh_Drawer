using System;
using UnityEngine;

namespace Voxelity.Timer
{
    public class TimeFromStart : MonoBehaviour
    {
        private void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 50;
            GUI.color = Color.white;
            GUILayout.Label(Time.timeSinceLevelLoad.ToString("F1"), style);
        }
    }
}