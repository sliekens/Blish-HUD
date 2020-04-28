﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Blish_HUD.Input.WinApi;
using Microsoft.Xna.Framework.Input;

namespace Blish_HUD.Input {
    public class KeyboardManager : InputManager {

        #region Event Handling

        /// <summary>
        /// Occurs when a key is pressed down.
        /// </summary>
        public event EventHandler<KeyboardEventArgs> KeyPressed;

        /// <summary>
        /// Occurs when a key is released.
        /// </summary>
        public event EventHandler<KeyboardEventArgs> KeyReleased;

        /// <summary>
        /// Occurs when the state of any key changes.
        /// </summary>
        public event EventHandler<KeyboardEventArgs> KeyStateChanged;

        private void OnKeyStateChanged(KeyboardEventArgs e) {
            if (e.EventType == KeyboardEventType.KeyDown) {
                this.KeyPressed?.Invoke(this, e);
            } else {
                this.KeyReleased?.Invoke(this, e);
            }

            this.KeyStateChanged?.Invoke(this, e);
        }

        #endregion

        // TODO: Block using a stack of contexts which can independently process incoming keyboard events
        private bool _hookGeneralBlock;

        /// <summary>
        /// The current state of the keyboard.
        /// </summary>
        public KeyboardState State { get; private set; }

        /// <summary>
        /// A <see cref="ModifierKeys"/> flag indicating the acting
        /// modifier keys (Ctrl, Alt, or Shift) being pressed.
        /// </summary>
        public ModifierKeys ActiveModifiers { get; private set; }

        private readonly ConcurrentQueue<KeyboardEventArgs> _inputBuffer;

        private readonly List<Keys> _keysDown;

        /// <summary>
        /// A list of keys currently being pressed down.
        /// </summary>
        public IReadOnlyList<Keys> KeysDown => _keysDown.AsReadOnly();

        private Action<string> _textInputDelegate;

        internal KeyboardManager() : base(HookType.WH_KEYBOARD_LL) {
            _keysDown    = new List<Keys>();
            _inputBuffer = new ConcurrentQueue<KeyboardEventArgs>();
        }

        private void UpdateStates() {
            Keys[] downArray = _keysDown.ToArray();

            this.State           = new KeyboardState(downArray);
            this.ActiveModifiers = KeysUtil.ModifiersFromKeys(downArray);
        }

        internal override void Update() {
            while (_inputBuffer.TryDequeue(out var keyboardEvent)) {
                if (keyboardEvent.EventType == KeyboardEventType.KeyDown) {
                    // Avoid firing on held keys
                    if (_keysDown.Contains(keyboardEvent.Key)) {
                        continue;
                    }

                    _keysDown.Add(keyboardEvent.Key);
                } else {
                    _keysDown.Remove(keyboardEvent.Key);
                }

                UpdateStates();

                OnKeyStateChanged(keyboardEvent);
            }
        }

        protected override void OnDisable() {
            // Ensure that key states don't get stuck if the
            // application focus is lost while keys were down.

            Keys[] passingKeys = _keysDown.ToArray();
            _keysDown.Clear();

            UpdateStates();

            foreach (var key in passingKeys) {
                OnKeyStateChanged(new KeyboardEventArgs(KeyboardEventType.KeyUp, key));
            }
        }

        public void SetTextInputListner(Action<string> input) {
            _textInputDelegate = input;
        }

        public void UnsetTextInputListner(Action<string> input) {
            if (input == _textInputDelegate) {
                _textInputDelegate = null;
            }
        }

        private void EndTextInputAsyncInvoke(IAsyncResult asyncResult) {
            _textInputDelegate.EndInvoke(asyncResult);
        }

        private bool ProcessInput(KeyboardEventType eventType, Keys key) {
            _inputBuffer.Enqueue(new KeyboardEventArgs(eventType, key));

            if (_textInputDelegate != null) {
                string chars = TypedInputUtil.VkCodeToString((uint)key, eventType == KeyboardEventType.KeyDown);
                _textInputDelegate?.BeginInvoke(chars, EndTextInputAsyncInvoke, null);
                return true /* key != Keys.LeftShift && key != Keys.RightShift */; // "SHIFT" support temporarily disabled
            }

            // TODO: Implement blocking based on the key that is pressed (for example: Key binding blocking the last pressed key)

            return false;
        }

        protected override bool HandleNewInput(IntPtr wParam, IntPtr lParam) {
            if (_hookGeneralBlock)
                return true;

            var eventType = (KeyboardEventType)((uint)wParam % 2 + 256); // filter out SysKeyDown & SysKeyUp
            var key       = (Keys)Marshal.ReadInt32(lParam);

            return ProcessInput(eventType, key);
        }

    }
}