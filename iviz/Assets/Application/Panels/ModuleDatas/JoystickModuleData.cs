﻿using Iviz.Controllers;
using Iviz.Resources;

namespace Iviz.App
{
    /// <summary>
    /// <see cref="JoystickPanelContents"/> 
    /// </summary>
    public sealed class JoystickModuleData : ModuleData
    {
        readonly JoystickController controller;
        readonly JoystickPanelContents panel;

        public override Resource.Module Module => Resource.Module.Joystick;
        public override DataPanelContents Panel => panel;
        public override IConfiguration Configuration => controller.Config;
        public override IController Controller => controller;

        public JoystickModuleData(ModuleDataConstructor constructor) :
            base(constructor.ModuleList, constructor.Topic, constructor.Type)
        {
            panel = DataPanelManager.GetPanelByResourceType(Resource.Module.Joystick) as JoystickPanelContents;

            //controller = Instantiate<JoystickController>();
            controller = new JoystickController(this);
            //controller.ModuleData = this;
            if (constructor.Configuration != null)
            {
                controller.Config = (JoystickConfiguration)constructor.Configuration;
            }
            controller.Joystick = ModuleListPanel.Joystick;

            UpdateModuleButton();
        }

        public override void Stop()
        {
            base.Stop();
            controller.Stop();
            //Object.Destroy(controller.gameObject);
        }

        public override void SetupPanel()
        {
            panel.HideButton.State = controller.Visible;

            panel.JoySender.Set(controller.RosSenderJoy);
            panel.TwistSender.Set(controller.RosSenderTwist);
            panel.SendJoy.Value = controller.PublishJoy;
            panel.SendTwist.Value = controller.PublishTwist;

            panel.JoyTopic.Value = controller.JoyTopic;
            panel.TwistTopic.Value = controller.TwistTopic;
            panel.UseStamped.Value = controller.TwistStamped;

            panel.MaxSpeed.Value = controller.MaxSpeed;
            panel.AttachToFrame.Value = controller.AttachToFrame;
            panel.AttachToFrame.Hints = TFListener.FramesForHints;
            panel.XIsFront.Value = controller.XIsFront;

            panel.MaxSpeed.Interactable = controller.PublishTwist;
            panel.AttachToFrame.Interactable = controller.PublishTwist;
            panel.TwistTopic.Interactable = controller.PublishTwist;

            panel.JoyTopic.Interactable = controller.PublishJoy;

            panel.SendJoy.ValueChanged += f =>
            {
                controller.PublishJoy = f;
                panel.JoySender.Set(controller.RosSenderJoy);
                panel.JoyTopic.Interactable = f;
            };
            panel.SendTwist.ValueChanged += f =>
            {
                controller.PublishTwist = f;
                panel.MaxSpeed.Interactable = f;
                panel.AttachToFrame.Interactable = f && controller.TwistStamped;
                panel.XIsFront.Interactable = f;
                panel.TwistSender.Set(controller.RosSenderTwist);
                panel.TwistTopic.Interactable = f;
            };
            panel.MaxSpeed.ValueChanged += f =>
            {
                controller.MaxSpeed = f;
            };
            panel.AttachToFrame.EndEdit += f =>
            {
                controller.AttachToFrame = f;
            };
            panel.XIsFront.ValueChanged += f =>
            {
                controller.XIsFront = f;
            };
            panel.JoyTopic.EndEdit += f =>
            {
                controller.JoyTopic = f;
                panel.JoySender.Set(controller.RosSenderJoy);
            };
            panel.TwistTopic.EndEdit += f =>
            {
                controller.TwistTopic = f;
                panel.TwistSender.Set(controller.RosSenderTwist);
            };
            panel.UseStamped.ValueChanged += f =>
            {
                controller.TwistStamped = f;
                panel.AttachToFrame.Interactable = f && controller.PublishTwist;
            };

            panel.CloseButton.Clicked += () =>
            {
                DataPanelManager.HideSelectedPanel();
                ModuleListPanel.RemoveModule(this);
            };
            panel.HideButton.Clicked += () =>
            {
                controller.Visible = !controller.Visible;
                panel.HideButton.State = controller.Visible;
                UpdateModuleButton();
            };
        }

        public override void AddToState(StateConfiguration config)
        {
            config.Joystick = controller.Config;
        }
    }
}