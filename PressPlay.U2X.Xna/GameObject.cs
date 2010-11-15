﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using PressPlay.U2X.Xna.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Box2D.XNA;

namespace PressPlay.U2X.Xna
{
    public class GameObject
    {
        public GameObject()
        {
            components = new List<Component>();
        }

        public int id { get; set; }
        public string name { get; set; }

        private Transform _transform;
        public Transform transform 
        { 
            get
            {
                return _transform;
            }
            set
            {
                _transform = value;
                _transform.gameObject = this;
            }
        }

        public String prefab { get; set; }
        [ContentSerializer(CollectionItemName = "component")]
        public List<Component> components { get; set; }

        internal void FixedUpdate()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (!components[i].isStarted)
                {
                    components[i].Start();
                    components[i].isStarted = true;
                }
                if (Component.IsAwake(components[i]) && components[i] is IFixedUpdateable)
                {
                    (components[i] as IFixedUpdateable).FixedUpdate();
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].FixedUpdate();
                }
            }
        }

        internal void Update()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (!components[i].isStarted)
                {
                    components[i].Start();
                    components[i].isStarted = true;
                }
                if (Component.IsAwake(components[i]) && components[i] is IUpdateable)
                {
                    (components[i] as IUpdateable).Update(null);
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].Update();
                }
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (Component.IsAwake(components[i]) && components[i] is IRenderable)
                {
                    (components[i] as IRenderable).Draw(spriteBatch);
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].Draw(spriteBatch);
                }
            }
        }

        internal void OnTriggerEnter(Contact contact)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (Component.IsAwake(components[i]) && components[i] is ICollidable)
                {
                    (components[i] as ICollidable).OnTriggerEnter(contact);
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].OnTriggerEnter(contact);
                }
            }
        }

        internal void OnTriggerExit(Contact contact)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (Component.IsAwake(components[i]) && components[i] is ICollidable)
                {
                    (components[i] as ICollidable).OnTriggerExit(contact);
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].OnTriggerExit(contact);
                }
            }
        }

        internal void OnCollisionEnter(Contact contact)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (Component.IsAwake(components[i]) && components[i] is ICollidable)
                {
                    (components[i] as ICollidable).OnCollisionEnter(contact);
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].OnCollisionEnter(contact);
                }
            }
        }

        internal void OnCollisionExit(Contact contact)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (Component.IsAwake(components[i]) && components[i] is ICollidable)
                {
                    (components[i] as ICollidable).OnCollisionExit(contact);
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].OnCollisionExit(contact);
                }
            }
        }

        internal void OnPreSolve(Contact contact, Manifold manifold)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (Component.IsAwake(components[i]) && components[i] is ICollidable)
                {
                    (components[i] as ICollidable).OnPreSolve(contact, manifold);
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].OnPreSolve(contact, manifold);
                }
            }
        }

        internal void OnPostSolve(Contact contact, ContactImpulse contactImpulse)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (Component.IsAwake(components[i]) && components[i] is ICollidable)
                {
                    (components[i] as ICollidable).OnPostSolve(contact, contactImpulse);
                }
            }
            if (transform != null && transform.children != null)
            {
                for (int i = 0; i < transform.children.Count; i++)
                {
                    transform.children[i].OnPostSolve(contact, contactImpulse);
                }
            }
        }
    }
}