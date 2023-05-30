// Copyright (C) 2023 Antonin Rousseau
// 
// aimxr-toolkit-csharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// aimxr-toolkit-csharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with aimxr-toolkit-csharp. If not, see <http://www.gnu.org/licenses/>.

namespace AimXRToolkit.Interactions
{
    using System;
    using UnityEngine;

    public class Button : Interactable
    {
        private MeshCollider _collider;
        private AudioClip _sound; // sound to play when the button is pressed


        public static new Interactable Parse(Models.Component component, GameObject gameObject)
        {
            var interactable = gameObject.AddComponent<Interactions.Button>();
            interactable.SetTag(component.GetTag());
            interactable.SetCollider(gameObject.GetComponent<MeshCollider>() ?? gameObject.AddComponent<MeshCollider>());
            return interactable;
        }

        public override void Action()
        {
            base.getArtifactManager().CallFunction(base.GetTag(), "OnButtonPressed");
        }
        void Start()
        {
            _collider = gameObject.AddComponent<MeshCollider>();
            _collider.convex = true;
            _collider.isTrigger = true;
        }

        public void SetCollider(MeshCollider collider)
        {
            _collider = collider;
        }
    }
}