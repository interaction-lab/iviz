using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Iviz.Msgs.MobileBaseDriver;
using Iviz.Msgs.StdMsgs;
using Iviz.Ros;
using Iviz.Core;
using Iviz.Roslib;

public class Junk : MonoBehaviour {


    RosPublisher<ChestLeds> chestLedPublisher;
    static string chestLedTopic = "/mobile_base/commands/chest_leds";
    static Led qwe { get; set; } = new Led(255, 0, 0);
    ChestLeds ChestLedsMsg;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            Iviz.Msgs.StdMsgs.String s = new String();
            s.Data = "potato";
            ChestLedsMsg = new ChestLeds(new Led[15] { qwe, qwe, qwe, qwe, qwe, qwe, qwe, qwe, qwe, qwe, qwe, qwe, qwe, qwe, qwe });

            chestLedPublisher.Publish(ChestLedsMsg);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ConnectionManager.Connection.Client.Advertise<ChestLeds>(chestLedTopic, out chestLedPublisher);
        }
    }
}
