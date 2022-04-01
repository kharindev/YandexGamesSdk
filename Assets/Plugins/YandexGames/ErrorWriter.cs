using UnityEngine;

namespace YandexGamesSdk
{
    public class ErrorWriter : MonoBehaviour
    {
        private const string FILE_NAME = "Errors.txt";

        private void OnEnable()
        {
            Application.logMessageReceived += LogCallback;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= LogCallback;
        }

        void LogCallback(string condition, string stackTrace, LogType type)
        {
            if (type == LogType.Error || type == LogType.Exception)
            {
                LogError(condition, stackTrace);
            }
        }

        private void LogError(string condition, string stackTrace)
        {
            var error = "Unity Error \n" + condition + "\n" + stackTrace;
            YandexGames.ConsoleLog(error);
        }
    }
}