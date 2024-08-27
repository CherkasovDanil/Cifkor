﻿using System;
using System.Collections.Generic;
using UI.Main;
using UnityEngine;
using Zenject;

namespace Project.UI.Main
{
    public class UIService : IUIService
    {
        private readonly IUIRoot _uIRoot;
        private readonly IInstantiator _instantiator;
        
        private readonly Dictionary<Type,UIWindow> _viewStorage = new();
        private readonly Dictionary<Type, GameObject> _initWindows= new();
        
        private Transform _deactivatedContainer;

        public UIService(
            IInstantiator instantiator,
            IUIRoot uIRoot)
        {
            _instantiator = instantiator;
            _uIRoot = uIRoot;
            
            LoadWindows("UIWindows");
            InitWindows();
        }

        public T Show <T>(int layer = 0) where T : UIWindow
        {
            var window = Get<T>();
            if(window != null)
            {
                window.transform.SetParent(_uIRoot.Container.Layers[layer], false);
                window.transform.localScale = Vector3.one;
                window.transform.localRotation = Quaternion.identity;
                window.transform.localPosition = Vector3.zero;

                var component = window.GetComponent<T>();
                
                component.Show();
                return component;
            }
            return null;
        }

        public T Get<T>() where T : UIWindow
        {
            var type = typeof(T);
            if (_initWindows.ContainsKey(type))
            {
                var view = _initWindows[type];            
                return view.GetComponent<T>();
            }
            return null;
        }

        public void Hide<T>(Action onEnd = null) where T : UIWindow
        {
            var window = Get<T>();
            if(window!=null)
            {
                window.transform.SetParent(_uIRoot.PoolContainer);
                window.Hide();
                onEnd?.Invoke();
            }
        }

        public void InitWindows(Transform poolDeactiveContiner = null)
        {
            _deactivatedContainer = poolDeactiveContiner == null ? _uIRoot.PoolContainer : poolDeactiveContiner;
            foreach (var windowKVP in _viewStorage)
            {
                Init(windowKVP.Key, _deactivatedContainer);
            }
        }

        public void LoadWindows(string source)
        {
            var windows = Resources.LoadAll(source, typeof(UIWindow));

            foreach (var window in windows)
            {
                var windowType = window.GetType();
                _viewStorage.Add(windowType, (UIWindow) window);
            }
        }    
    
        private void Init(Type t, Transform parent = null)
        {
            if(_viewStorage.ContainsKey(t))
            {
                GameObject view;
                if(parent!=null)
                {
                    view = _instantiator.InstantiatePrefab(_viewStorage[t], parent);
                }
                else
                {
                    view = _instantiator.InstantiatePrefab(_viewStorage[t]);
                }
                _initWindows.Add(t, view);
            }
        }
    }
}