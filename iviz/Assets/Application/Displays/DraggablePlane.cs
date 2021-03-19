using System;
using Iviz.App;
using Iviz.Controllers;
using Iviz.Core;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Iviz.Displays
{
    public sealed class DraggablePlane : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDraggable
    {
        [SerializeField] Vector3 normal = new Vector3(0, 0, 1);

        bool needsStart;
        Vector3 startIntersection;

        public Transform TargetTransform { get; set; }

        public event MovedAction Moved;
        public event Action PointerDown;
        public event Action PointerUp;

        public bool Visible
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public void OnPointerMove(in Vector2 cursorPos)
        {
            Ray pointerRay = Settings.MainCamera.ScreenPointToRay(cursorPos);
            OnPointerMove(pointerRay);
        }

        public void OnStartDragging()
        {
            needsStart = true;
        }

        public void OnEndDragging()
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (TfListener.GuiInputModule != null)
            {
                TfListener.GuiInputModule.DraggedObject = this;
            }

            PointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUp?.Invoke();
        }

        void SetTargetPose(in Pose pose)
        {
            TargetTransform.SetPose(pose);
        }

        static (Vector3, float) PlaneIntersection(in Ray ray, in Ray other)
        {
            float t = Vector3.Dot(other.origin - ray.origin, ray.direction) /
                      Vector3.Dot(-other.direction, ray.direction);
            Vector3 p = other.origin + t * other.direction;

            return (p, t);
        }

        void OnPointerMove(in Ray pointerRay)
        {
            Transform mTransform = transform;
            Transform mParent = mTransform.parent;
            Transform mTarget = TargetTransform;

            //Ray ray = new Ray(mTransform.position, mParent.TransformDirection(normal));/
            Ray normalRay = new Ray(mParent.position, mParent.TransformDirection(normal));

            (Vector3 intersection, float cameraDistance) = PlaneIntersection(normalRay, pointerRay);
            if (cameraDistance < 0)
            {
                return;
            }

            Vector3 localIntersection = mParent.InverseTransformPoint(intersection);
            if (needsStart)
            {
                startIntersection = localIntersection;
                needsStart = false;
            }
            else
            {
                Vector3 deltaPosition = localIntersection - startIntersection;
                float deltaDistance = deltaPosition.Magnitude();
                if (deltaDistance > 0.5f) deltaPosition *= 0.5f / deltaDistance;

                Vector3 deltaPositionWorld = mParent.TransformVector(deltaPosition);
                SetTargetPose(new Pose(mTarget.position + deltaPositionWorld, mTarget.rotation));
                //mTarget.position += deltaPositionWorld;

                Moved?.Invoke(mTarget.AsPose());
                //startIntersection = localIntersection;
            }
        }
    }
}