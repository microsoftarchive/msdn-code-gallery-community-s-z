using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using Coding4Fun.Kinect.WinForm;
using Microsoft.Kinect;
using WindowsInput;

namespace GestureFramework
{
    public enum JointRelationship
    {
        None,
        Above,
        Below,
        LeftOf,
        RightOf,
        AboveAndRight,
        BelowAndRight,
        AboveAndLeft,
        BelowAndLeft
    }


    public class GestureComponentState
    {
        private readonly GestureComponent _component;
        private bool _beginningRelationshipSatisfied;
        private bool _endingRelationshipSatisfied;


        public bool BeginningRelationshipSatisfied
        {
            get
            {
                if (_component.BeginningRelationship == JointRelationship.None)
                    _beginningRelationshipSatisfied = true;
                return _beginningRelationshipSatisfied;
            }
        }


        public bool EndingRelationshipSatisfied
        {
            get
            {
                if (_component.EndingRelationship == JointRelationship.None)
                    _endingRelationshipSatisfied = true;
                return _endingRelationshipSatisfied;
            }
        }

        public GestureComponent Component
        {
            get
            {
                return _component;
            }
        }


        public GestureComponentState(GestureComponent component)
        {
            _component = component;
            Reset();
        }


        public void Reset()
        {
            _beginningRelationshipSatisfied = false;
            _endingRelationshipSatisfied = false;
        }


        public bool Evaluate(Skeleton skeleton, int xScale, int yScale)
        {
            var sjoint1 = skeleton.Joints[_component.Joint1].ScaleTo(xScale, yScale);
            var sjoint2 = skeleton.Joints[_component.Joint2].ScaleTo(xScale, yScale);

            if (!BeginningRelationshipSatisfied)
            {
                var goodtogo = CompareJointRelationship(sjoint1, sjoint2, _component.BeginningRelationship);
                if (goodtogo)
                {
                    _beginningRelationshipSatisfied = true;
                }
                else
                {
                    return false;
                }
            }


            if (!EndingRelationshipSatisfied)
            {
                var goodtogo = CompareJointRelationship(sjoint1, sjoint2, _component.EndingRelationship);
                if (goodtogo)
                {
                    return _endingRelationshipSatisfied = true;
                }
                return false;
            }

            return true;
        }


        private bool CompareJointRelationship(Joint inJoint1, Joint inJoint2, JointRelationship relation)
        {
            switch (relation)
            {
                case JointRelationship.None:
                    return true;

                case JointRelationship.AboveAndLeft:
                    return ((inJoint1.Position.X < inJoint2.Position.X) && (inJoint1.Position.Y < inJoint2.Position.Y));

                case JointRelationship.AboveAndRight:
                    return ((inJoint1.Position.X > inJoint2.Position.X) && (inJoint1.Position.Y < inJoint2.Position.Y));

                case JointRelationship.BelowAndLeft:
                    return ((inJoint1.Position.X < inJoint2.Position.X) && (inJoint1.Position.Y > inJoint2.Position.Y));

                case JointRelationship.BelowAndRight:
                    return ((inJoint1.Position.X > inJoint2.Position.X) && (inJoint1.Position.Y > inJoint2.Position.Y));

                case JointRelationship.Below:
                    return inJoint1.Position.Y > inJoint2.Position.Y;
                case JointRelationship.Above:
                    return inJoint1.Position.Y < inJoint2.Position.Y;
                case JointRelationship.LeftOf:
                    return inJoint1.Position.X < inJoint2.Position.X;
                case JointRelationship.RightOf:
                    return inJoint1.Position.X > inJoint2.Position.X;
            }
            return false;
        }

    }

    /// <summary>
    /// Describes a single relationship between two joints.
    /// The relationship has two joints and two parts;
    /// a beginning relationship and an ending relationship
    /// </summary>
    public class GestureComponent
    {

        public JointType Joint1
        {
            get;
            set;
        }

        public JointType Joint2
        {
            get;
            set;
        }

        public JointRelationship BeginningRelationship
        {
            get;
            set;
        }


        public JointRelationship EndingRelationship
        {
            get;
            set;
        }

        public GestureComponent(JointType joint1, JointType joint2, JointRelationship endingRelationship, JointRelationship beginningRelationship = JointRelationship.None)
        {
            Joint1 = joint1;
            Joint2 = joint2;

            EndingRelationship = endingRelationship;
            BeginningRelationship = beginningRelationship;
        }
    }


    public class GestureState
    {
        private DateTime _beginExecutionTime;
        private readonly Gesture _gesture;
        private readonly VirtualKeyCode _keycode;


        public Gesture Gesture
        {
            get
            {
                return _gesture;
            }
        }


        public VirtualKeyCode KeyCode
        {
            get
            {
                return _keycode;
            }
        }


        public bool IsExecuting
        {
            get;
            private set;
        }

        public bool HasError
        {
            get;
            private set;
        }

        public List<String> Messages
        {
            get;
            set;
        }


        public bool MessageWaiting
        {
            get;
            set;
        }


        public List<GestureComponentState> ComponentStates
        {
            get;
            set;
        }

        public GestureState(Gesture gesture)
        {
            _gesture = gesture;
            _keycode = gesture.MappedKeycode;
            ComponentStates = new List<GestureComponentState>();
            InitializeComponents();
            Messages = new List<string>();
            MessageWaiting = false;
            IsExecuting = false;
            HasError = false;
        }


        public void InitializeComponents()
        {
            foreach (var component in _gesture.Components)
            {
                var state = new GestureComponentState(component);
                ComponentStates.Add(state);
            }
        }


        public void Reset()
        {
            foreach (var component in ComponentStates)
            {
                component.Reset();
            }

            IsExecuting = false;
            _beginExecutionTime = DateTime.MinValue;
        }


        public bool Evaluate(Skeleton sd, DateTime currentTime, int xScale, int yScale)
        {
            Messages.Clear();
            MessageWaiting = false;

            if (IsExecuting)
            {
                TimeSpan executiontime = currentTime - _beginExecutionTime;
                if (executiontime.TotalMilliseconds > _gesture.MaximumExecutionTime && _gesture.MaximumExecutionTime > 0)
                {
                    Messages.Add("Time Expired for Gesture completion " + _gesture.Description + "by User" + sd.TrackingId + " at " + currentTime.ToString());
                    MessageWaiting = true;
                    HasError = true;
                    Reset();

                    return false;
                }
            }

            foreach (var component in ComponentStates)
            {

                if (component.Evaluate(sd, xScale, yScale))
                {
                    Messages.Add("Gesture " + _gesture.Description + " Component Evaluated Complete for user " +
                                             sd.TrackingId.ToString());
                    MessageWaiting = true;
                }
            }

            var inflightcount = 0;
            var completecount = 0;

            foreach (var component in ComponentStates)
            {
                if (component.BeginningRelationshipSatisfied)
                    inflightcount++;
                if (component.EndingRelationshipSatisfied)
                    completecount++;
            }


            if (completecount >= ComponentStates.Count && IsExecuting)
            {
                Messages.Add("Gesture " + _gesture.Description + " evaluated complete for user " +
                              sd.TrackingId);
                MessageWaiting = true;
                HasError = false;
                Reset();
                return true;
            }

            if (inflightcount >= ComponentStates.Count)
            {
                if (!IsExecuting)
                {
                    Messages.Add("Gesture " + _gesture.Description + " Has Transitioned To In Flight State for user " + sd.TrackingId.ToString());
                    MessageWaiting = true;
                    IsExecuting = true;
                    HasError = false;
                    _beginExecutionTime = DateTime.Now;
                    return false;
                }
            }

            return false;
        }

    }


    public class Gesture
    {
        private readonly Guid _id;
        private readonly List<GestureComponent> _components;
        private readonly String _description;


        public Gesture(string name, int maxExecutionTime)
        {
            _id = Guid.NewGuid();
            _description = name;
            _components = new List<GestureComponent>();
            MaximumExecutionTime = maxExecutionTime;
        }


        public Gesture()
        {
            _id = Guid.NewGuid();
            _components = new List<GestureComponent>();
        }


        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        public String Description
        {
            get
            {
                return _description;
            }
        }

        public string InFlightImageName
        {
            get;
            set;
        }

        public string ErrorImageName
        {
            get;
            set;
        }

        public int MaximumExecutionTime
        {
            get;
            set;
        }

        public List<GestureComponent> Components
        {
            get
            {
                return _components;
            }
        }

        public VirtualKeyCode MappedKeycode
        {
            get;
            set;
        }


        public Bitmap ErrorImage
        {
            get;
            set;
        }


        public Bitmap InFlightImage
        {
            get;
            set;
        }
    }


    /// <summary>
    /// This class is the topmost gesture state class.  There should only be one of these instantiated
    /// per active user.  There is a dictionary in the form1 class that matches this information to 
    /// an active user Skeleton Id.
    /// </summary>
    public class GestureMapState
    {
        private readonly List<GestureState> _gesturestate;
        public List<string> Messages;
        public bool MessagesWaiting;
        public DateTime LastGestureCompletionTime;


        public Bitmap CurrentStateImage
        {
            get;
            set;
        }


        /// <summary>
        /// This constructor takes the static gesture map from the XML and spins up a state map for the user
        /// </summary>
        /// <param name="map"></param>
        public GestureMapState(GestureMap map)
        {
            Messages = new List<string>();
            MessagesWaiting = false;
            _gesturestate = new List<GestureState>();
            InitializeGestureState(map);
        }


        public void InitializeGestureState(GestureMap map)
        {
            foreach (var gesturemapping in map.Items)
            {
                var state = new GestureState(gesturemapping);
                _gesturestate.Add(state);
            }
        }

        /// <summary>
        /// This method goes through each gesture state for the user and updates it, looking for completed gestures
        /// </summary>
        /// <param name="skeleton"></param>
        /// <param name="passCommandToSystem"></param>
        /// <param name="xScale"></param>
        /// <param name="yScale"></param>
        /// <returns></returns>
        public VirtualKeyCode Evaluate(Skeleton skeleton, Boolean passCommandToSystem, int xScale, int yScale)
        {
            Messages.Clear();
            MessagesWaiting = false;

            foreach (var state in _gesturestate)
            {
                var iscomplete = state.Evaluate(skeleton, DateTime.Now, xScale, yScale);

                if (state.MessageWaiting)
                {
                    foreach (var msg in state.Messages)
                    {
                        Messages.Add(msg);
                    }
                    MessagesWaiting = true;
                }

                // Skip the rest of this unless the gesture is complete
                if (!iscomplete)
                    continue;

                LastGestureCompletionTime = DateTime.Now;
                Messages.Add(state.Gesture.Description + " gesture completed successfully at " + LastGestureCompletionTime.ToString() + "For Player " + skeleton.TrackingId.ToString());
                MessagesWaiting = true;

                if (passCommandToSystem)
                {
                    Messages.Add("Command passed to System: " + state.KeyCode);
                    InputSimulator.SimulateKeyPress(state.KeyCode);
                }


                return state.KeyCode;

            }


            return VirtualKeyCode.NONAME;
        }


        public void ResetAll(Skeleton skeleton)
        {
            foreach (var state in _gesturestate)
            {
                state.Reset();
            }
            Messages.Add(" All gesture states reset for player " + skeleton.TrackingId);
            MessagesWaiting = true;
        }
    }

    /// <summary>
    /// GestureMap - Contains the details of a gesture, including its components and their
    /// required positions.  The gestures are loaded from an xml file in the file system.
    /// </summary>
    public class GestureMap
    {
        public List<Gesture> Items;
        public List<string> Messages;
        public bool MessagesWaiting;
        public int GestureResetTimeout;


        public GestureMap()
        {
            Items = new List<Gesture>();
            Messages = new List<string>();

        }


        public void LoadGesturesFromXml(string xmlfilename)
        {
            Items.Clear();
            var gesture = new Gesture();
            var firstpass = true;
            var mappingdone = false;

            Messages.Add("Loading XML File " + xmlfilename + " from application directory");
            MessagesWaiting = true;

            try
            {
                var reader = new XmlTextReader(xmlfilename);

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "Gestures")
                            {
                                Messages.Add("Reading Header Information from XML File");
                                MessagesWaiting = true;
                                ParseHeaderFromXml(reader);
                            }
                            if (reader.Name == "Gesture")
                            {
                                if (firstpass == false && mappingdone)
                                {
                                    Items.Add(gesture);
                                    mappingdone = false;
                                }

                                Messages.Add("Gesture Found in XML File");
                                MessagesWaiting = true;
                                gesture = ParseGestureFromXml(reader);
                                firstpass = false;
                            }
                            if (reader.Name == "GestureComponent")
                            {
                                Messages.Add("Gesture Component Found in XML File");
                                MessagesWaiting = true;
                                gesture = ParseGestureComponentsFromXml(reader, gesture);
                                mappingdone = true;
                            }
                            break;
                    }

                }

                if (firstpass == false && mappingdone)
                {
                    Items.Add(gesture);
                }

            }
            catch (Exception ex)
            {
                Messages.Add("Error Loading XML File: " + ex);
                MessagesWaiting = true;
            }

            Messages.Add("Completed XML File Load");
            MessagesWaiting = true;
        }


        public void ParseHeaderFromXml(XmlReader reader)
        {
            try
            {
                var timeout = reader.GetAttribute("GestureResetTimeout");
                if (timeout != null)
                {
                    GestureResetTimeout = Convert.ToInt32(timeout);
                }
            }
            catch (Exception ex)
            {
                Messages.Add("Error Loading XML File: " + ex);
                MessagesWaiting = true;
            }

        }


        public Gesture ParseGestureComponentsFromXml(XmlReader reader, Gesture gesture)
        {
            var firstjoint = reader.GetAttribute("FirstJoint");
            var secondjoint = reader.GetAttribute("SecondJoint");
            JointType firstjointtype;
            JointType secondjointtype;
            GestureComponent component;

            if (firstjoint != null)
            {
                firstjointtype = (JointType)(Enum.Parse(typeof(JointType), firstjoint));
                Messages.Add("First Joint: " + firstjoint);
            }
            else
            {
                return gesture;
            }

            if (secondjoint != null)
            {
                secondjointtype = (JointType)(Enum.Parse(typeof(JointType), secondjoint));
                Messages.Add("Second Joint: " + secondjoint);
            }
            else
            {
                return gesture;
            }

            var beginningrelationship = reader.GetAttribute("BeginningRelationship");
            var endingrelationship = reader.GetAttribute("EndingRelationship");


            var endingrelationshippos = JointRelationship.None;
            var beginningrelationshippos = JointRelationship.None;


            if (endingrelationship != null)
            {
                endingrelationshippos = (JointRelationship)(Enum.Parse(typeof(JointRelationship), endingrelationship));
                Messages.Add("Ending Relationship: " + endingrelationship);
            }

            if (beginningrelationship != null)
            {
                beginningrelationshippos = (JointRelationship)(Enum.Parse(typeof(JointRelationship), beginningrelationship));
                Messages.Add("Beginning Relationship: " + beginningrelationship);
            }

            if (beginningrelationshippos != JointRelationship.None)
            {
                component = new GestureComponent(firstjointtype, secondjointtype, endingrelationshippos,
                                                     beginningrelationshippos);
            }
            else
            {
                component = new GestureComponent(firstjointtype, secondjointtype, endingrelationshippos);
            }

            gesture.Components.Add(component);
            Messages.Add("Component added to gesture:" + gesture.Description);

            return gesture;
        }


        public Gesture ParseGestureFromXml(XmlTextReader reader)
        {
            var name = reader.GetAttribute("Description");
            var maxexecutiontime = reader.GetAttribute("MaxExecutionTime") ?? "0";
            var keycode = reader.GetAttribute("MappedKeyCode") ?? "NONAME";

            Messages.Add("Gesture Name: " + name);
            Messages.Add("Maximum Gesture Execution Time: " + maxexecutiontime);
            Messages.Add("KeyCode Mapping: " + keycode);
            MessagesWaiting = true;

            var gesture = new Gesture(name, Convert.ToInt32(maxexecutiontime));
            gesture.MappedKeycode = (VirtualKeyCode)(Enum.Parse(typeof(VirtualKeyCode), keycode));
            gesture.MaximumExecutionTime = Convert.ToInt32(maxexecutiontime);

            return gesture;
        }
    }

}

