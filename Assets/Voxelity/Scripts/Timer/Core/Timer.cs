using UnityEngine;
using UnityEngine.Events;

namespace Voxelity.Timer
{
    public class Timer : MonoBehaviour
    {
        private bool _isRunning = true;
        private bool autoDestroy = true;
        private bool unscaledTime = false;
        private UnityAction onTimerEnd;
        private UnityAction<float> onTimerUpdate;
        private float timeOnStart;

        private string timerName;
        public float RemainingSeconds { get; private set; }
        private void OnEnable()
        {
            TimerUtility.Assign(this);
        }
        private void OnDisable()
        {
            TimerUtility.Remove(this);
        }
        public string TimerName
        {
            get { return timerName; }
        }
        public Timer SetId(string _name)
        {
            timerName = _name;
            SetName(timerName);
            return this;
        }
        public Timer OnComplete(UnityAction onEnd)
        {
            onTimerEnd = (onEnd);
            return this;
        }
        public Timer SetTime(float time)
        {
            RemainingSeconds = time;
            timeOnStart = time;
            return this;
        }
        public Timer SetAutoDestroy(bool isTrue)
        {
            autoDestroy = isTrue;
            return this;
        }
        public Timer OnUpdate(UnityAction<float> onUpdate)
        {
            onTimerUpdate = onUpdate;
            return this;
        }
        public Timer SetUnscaledTime(bool isTrue)
        {
            unscaledTime = isTrue;
            return this;
        }

        private void Update()
        {
            if (!_isRunning) return;
            if(unscaledTime)
                Tick(Time.unscaledDeltaTime);
            else if(Time.timeScale > 0)
                Tick(Time.deltaTime);
        }

        public void AddTime(float time)
        {
            RemainingSeconds += time;
        }
        public void SubtractTime(float time)
        {
            RemainingSeconds -= time;
        }
        public void KillTimer()
        {
            RemainingSeconds = 0;
            Destroy(gameObject);
        }
        public void PauseTimer()
        {
            _isRunning = false;
        }
        public void ResumeTimer()
        {
            _isRunning = true;
        }

        public void Tick(float deltaTime)
        {
            if (RemainingSeconds == 0f) return;

            RemainingSeconds -= deltaTime;

            onTimerUpdate?.Invoke(RemainingSeconds < 0f ? 0f : RemainingSeconds);

            SetName(timerName);

            CheckForTimerEnd();
        }

        private void CheckForTimerEnd()
        {
            if (RemainingSeconds > 0f) return;

            RemainingSeconds = 0f;

            onTimerEnd?.Invoke();

            SetName(timerName);

            if (autoDestroy)
                KillTimer();
        }

        private void SetName(string _name)
        {
            gameObject.name = _name + " : " + RemainingSeconds.ToString("F1");
        }
    }
}