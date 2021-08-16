﻿﻿﻿using UnityEngine;

namespace IdleGame.Selection
{
    public class SelectionManager : MonoBehaviour
    {
        private IRayProvider _rayProvider;
        private ISelector _selector;
        private ISelectionResponse _selectionResponse;

        private Transform _currentSelection;

        private void Awake()
        {
            _rayProvider = GetComponent<IRayProvider>();
            _selector = GetComponent<ISelector>();
            _selectionResponse = GetComponent<ISelectionResponse>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) == false)
                return;

            _selector.Check(_rayProvider.CreateRay());
            var newSelection = _selector.GetSelection();

            if (_currentSelection && newSelection == _currentSelection)
                return;

            if (_currentSelection != null)
                _selectionResponse.OnDeselect(_currentSelection);

            _currentSelection = newSelection;

            if (_currentSelection != null)
                _selectionResponse.OnSelect(_currentSelection);
        }
    }
}