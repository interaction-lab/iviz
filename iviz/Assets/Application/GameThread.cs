﻿using UnityEngine;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;

namespace Iviz.Displays
{
    public class GameThread : MonoBehaviour
    {
        readonly List<Action> actionsOnlyOnce = new List<Action>();
        readonly List<Action> actionsOnlyOnceTmp = new List<Action>();
        float lastRunTime;

        public static event Action EveryFrame;
        public static event Action LateEveryFrame;
        public static event Action EverySecond;
        public static event Action LateEverySecond;
        
        static GameThread mInstance;
        static GameThread Instance
        {
            get
            {
                return mInstance;
            }
        }

        void Awake()
        {
            mInstance = this;
        }

        void OnDestroy()
        {
            mInstance = null;
        }

        public static void RunOnce([NotNull] Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            
            if (Instance is null)
            {
                return;
            }

            lock (Instance.actionsOnlyOnce)
            {
                Instance.actionsOnlyOnce.Add(action);
            }
        }

        // Update is called once per frame
        void Update()
        {
            EveryFrame?.Invoke();

            float newRunTime = Time.time;
            if (newRunTime - lastRunTime > 1)
            {
                EverySecond?.Invoke();
                LateEverySecond?.Invoke();
                lastRunTime = newRunTime;
            }

            lock (actionsOnlyOnce)
            {
                if (actionsOnlyOnce.Count == 0) return;
                actionsOnlyOnceTmp.Clear();
                actionsOnlyOnceTmp.AddRange(actionsOnlyOnce);
                actionsOnlyOnce.Clear();
            }
            actionsOnlyOnceTmp.ForEach(x => x());
        }
        
        void LateUpdate()
        {
            LateEveryFrame?.Invoke();
        }

    }
}