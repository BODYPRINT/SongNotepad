﻿//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using UnityEngine;
//using UnityEngine.SceneManagement;
using BS_Utils.Utilities;


namespace SongNotepad
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class SongNotepadController : MonoBehaviour
    {
        public static SongNotepadController instance { get; private set; }
        IPA.Logging.Logger.Level logLevel = IPA.Logging.Logger.Level.Info;

        #region Monobehaviour Messages
        /// <summary>
        /// Only ever called once, mainly used to initialize variables.
        /// </summary>
        private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            //   and destroy any that are created while one already exists.
            if (instance != null)
            {
                Logger.log?.Warn($"Instance of {this.GetType().Name} already exists, destroying.");
                GameObject.DestroyImmediate(this);
                return;
            }
            GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
            instance = this;
            Logger.log?.Debug($"{name}: Awake()");

        }
        /// <summary>
        /// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
        /// </summary>
        private void Start()
        {
            Logger.log.Log( logLevel , "Song Notepad Plugin Started");
            AddEvents();
        }

        /// <summary>
        /// Called every frame if the script is enabled.
        /// </summary>
        private void Update()
        {
            
        }

        /// <summary>
        /// Called every frame after every other enabled script's Update().
        /// </summary>
        private void LateUpdate()
        {

        }

        /// <summary>
        /// Called when the script becomes enabled and active
        /// </summary>
        private void OnEnable()
        {

        }

        /// <summary>
        /// Called when the script becomes disabled or when it is being destroyed.
        /// </summary>
        private void OnDisable()
        {

        }

        /// <summary>
        /// Called when the script is being destroyed.
        /// </summary>
        private void OnDestroy()
        {
            Logger.log?.Debug($"{name}: OnDestroy()");
            instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.
            RemoveEvents();
        }
        #endregion

        private void OnLevelSelect(LevelCollectionViewController _levelCollection, IPreviewBeatmapLevel _previewBeatmapLevel)
        {
            Logger.log.Log(logLevel, "Song Notepad : Song Name = " + _levelCollection.name);          
        }

        private void AddEvents()
        {
            BSEvents.levelSelected += OnLevelSelect;
        }


        private void RemoveEvents()
        {
            BSEvents.levelSelected -= OnLevelSelect;
        }

    }
}
