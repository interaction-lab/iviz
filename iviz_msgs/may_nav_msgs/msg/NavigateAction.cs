/* This file was created automatically, do not edit! */

using System.Runtime.Serialization;

namespace Iviz.Msgs.MayNavMsgs
{
    [Preserve, DataContract (Name = "may_nav_msgs/NavigateAction")]
    public sealed class NavigateAction : IDeserializable<NavigateAction>,
		IAction<NavigateActionGoal, NavigateActionFeedback, NavigateActionResult>
    {
        [DataMember (Name = "action_goal")] public NavigateActionGoal ActionGoal { get; set; }
        [DataMember (Name = "action_result")] public NavigateActionResult ActionResult { get; set; }
        [DataMember (Name = "action_feedback")] public NavigateActionFeedback ActionFeedback { get; set; }
    
        /// <summary> Constructor for empty message. </summary>
        public NavigateAction()
        {
            ActionGoal = new NavigateActionGoal();
            ActionResult = new NavigateActionResult();
            ActionFeedback = new NavigateActionFeedback();
        }
        
        /// <summary> Explicit constructor. </summary>
        public NavigateAction(NavigateActionGoal ActionGoal, NavigateActionResult ActionResult, NavigateActionFeedback ActionFeedback)
        {
            this.ActionGoal = ActionGoal;
            this.ActionResult = ActionResult;
            this.ActionFeedback = ActionFeedback;
        }
        
        /// <summary> Constructor with buffer. </summary>
        public NavigateAction(ref Buffer b)
        {
            ActionGoal = new NavigateActionGoal(ref b);
            ActionResult = new NavigateActionResult(ref b);
            ActionFeedback = new NavigateActionFeedback(ref b);
        }
        
        public ISerializable RosDeserialize(ref Buffer b)
        {
            return new NavigateAction(ref b);
        }
        
        NavigateAction IDeserializable<NavigateAction>.RosDeserialize(ref Buffer b)
        {
            return new NavigateAction(ref b);
        }
    
        public void RosSerialize(ref Buffer b)
        {
            ActionGoal.RosSerialize(ref b);
            ActionResult.RosSerialize(ref b);
            ActionFeedback.RosSerialize(ref b);
        }
        
        public void Dispose()
        {
        }
        
        public void RosValidate()
        {
            if (ActionGoal is null) throw new System.NullReferenceException(nameof(ActionGoal));
            ActionGoal.RosValidate();
            if (ActionResult is null) throw new System.NullReferenceException(nameof(ActionResult));
            ActionResult.RosValidate();
            if (ActionFeedback is null) throw new System.NullReferenceException(nameof(ActionFeedback));
            ActionFeedback.RosValidate();
        }
    
        public int RosMessageLength
        {
            get {
                int size = 0;
                size += ActionGoal.RosMessageLength;
                size += ActionResult.RosMessageLength;
                size += ActionFeedback.RosMessageLength;
                return size;
            }
        }
    
        public string RosType => RosMessageType;
    
        /// <summary> Full ROS name of this message. </summary>
        [Preserve] public const string RosMessageType = "may_nav_msgs/NavigateAction";
    
        /// <summary> MD5 hash of a compact representation of the message. </summary>
        [Preserve] public const string RosMd5Sum = "7164268b3ddeefa8cb51e80db48df33d";
    
        /// <summary> Base64 of the GZip'd compression of the concatenated dependencies file. </summary>
        [Preserve] public const string RosDependenciesBase64 =
                "H4sIAAAAAAAACsVYW2/bNhR+F5D/QCAPaYfWa9Ou6wL4wYvdzEMuXuKu2JNAS0c2V4lUKSqO9+v3HVKS" +
                "7cZZg6F1jcTWhTz8zv1yKW/VXDoaJE4ZfWZkLqS/jOe4ji63Xl9TVeeuXWD93WdL3hGlM5l8bBdlzf1B" +
                "1P/Kn4Po4ubsRBRyFWt5GxfVvPrxPjcH0W8kU7Ji4X+iACtXs7CBl4yHgnmNVdrx4uXAD78Z7MqlAUGA" +
                "dxAdihsndSptKgpyMpVOiswAt5ovyD7P6ZZy7JJFSanwb92qpKqHjdOFqgT+5qTJyjxfibrCImdEYoqi" +
                "1ioBS8Kpgrb2Y6fSQopSWqeSOpcW641NleblmZUFMXX8VfSpJp2QGA9PsEZXlNROAdAKFBJLslJ6jpci" +
                "qpV2r455Q3Q4XZrnuKU5pN8dLtxCOgZLdyUMiHHK6gRn/BCY64E2pEM4Ja3EE/8sxm31VOAQQKDSJAvx" +
                "BMgnK7cwGgRJ3Eqr5CwnJpxAAqB6xJuOnm5QZtgnQkttWvKB4vqMx5DVHV3m6fkCOsuZ+6qeQ4BYWFpz" +
                "q1Isna08kSRXpJ2AyVlpVxHvCkdGh+9YxliEXV4j+JVVZRIFBaRiqdwiqpxl6l4bbKHfzCB3Ogab5RQ8" +
                "BNVVC1PnKW6MZdTBpATUuVwo6MTzwU4jlrISlm2mAh9sQ2Ovcm+VkIrUzWnQs72FdSwXpIVyArxSxXYL" +
                "06CiRKTJc+xmmlUwnCXh6I60mBFcBBBEQtZJKI8RbYq4wa/SVi2QMOBBM2YtatEGKSBLsSMENrhhVck5" +
                "eT2IqqREZSoJDDYIql5DnX0kLACooq4ckAk4Hlb1WhViVbTfKBji32wFDs+u4ulV/GHw1+RqfDntvwhP" +
                "h9fjP0f8wj+Nx5fx+GJwNuq/DK/fXZ2fX32IL0b94yg84SM47ERzMohSdhUOnMCjRImvb8bf/fPYNAdQ" +
                "BEcR+Jf09mQyD4PjWgYTglJkQs84DPLjtHmv/FroWhgYXLO3J6KJQbjqFkR/1JCh1Z7uel20Nx4BJvgf" +
                "Rx+D45VmL6A1C2AH4duj3uI4ynIj3ZvX4q67WnVX/+yLg7X8OjY6dcENt6S6jZ/vPq2lDx8vetEXmGqv" +
                "lnt2ss3K6BHFBpK8q5F5/E9XbzSFVQg8+wzxAc5B9FkdxGn8bQsy3ExGl8Px5ZloP33xAt8hvPqYuEDQ" +
                "XxGCuOHgh3CbhPTepMGtiN/QHJxOEYDEBs2X2zTZ8mtrYSUoNWbEYfRRhCfXo9HFZDoadoSPtwlbSggF" +
                "DIoPJHYUAV1IFzKD2XEyAveWcwzd+WpHz6M10PufQ/xzRGEphLKCg05OTEHB3BsqAPpkSrZAjZVzwefo" +
                "aQP55v3p6Wg03ID8ahsyJ1WZLBQKQeTgOmEpZDVXe7sE8dAxg1+vrtdy4WNe7zhmZjzrae0z1xr7zpPS" +
                "mr4oGraKCsFBZFLlNVL2A/CuR7+PTjfw9cVP9+FZ+psSn/53weF0bWr3ubk8+zLGGSUSNYqn2R1Woxrm" +
                "0OvrQNTjSt/KHPXEAww0ltd5Sl+82YPldaanjfNOuDa+TnmdhE8H5+drT+6Lnx8LsKm2diF8jHShk/va" +
                "2gatM2ULbl241uvU4KtvRkLpFhObZvL2KzDxODGzUWy5XziAm4MHbOL86ma6SaovfvEEB10d3PQIoCRS" +
                "aI2JUBCC7ETAVLjexGVTiLPcZo/wPU64wrC0WaRLBfZ3VOGolQd5bpa+6+SFcAW7XSdLyMxHBF8Sb6Qz" +
                "3pLSrJ7PWYzNIkd3bt8lb5uHv0cN0I4+/ncV0M1Ovs/QZI2/1SDjo+27uOAcpClu3u3oBI6HAp41Jxdz" +
                "0b17QVKkMeYHaCuM8aVDPKt5MtEOEHRdYL5U5lJXYUm4iZv0EZvE1wXpHhuOY98ND7mC5XkK93yTHKMP" +
                "7yjeYTgciFdD34KgXkXbq9uZjDC15aCEeQxhyBNKXt/q8mbZbb3fzyDdW0wkWAEcfdjTIL+uHZVlmfN8" +
                "B6srqPVjQIKn1pTWOy2uOF36BRCuCS0EhEmtpysMfmTOE6CwiiO1KdFF+1nSUgGaR4Uo4TcDp9JclAeQ" +
                "TZXQZFpcBt4zNOvQLPZgwMTDkxwBvuQGH1yBBZ54+BFWYFG8H4eWDCdYUaqSMFahcDpEJupSaBioDywm" +
                "0E1rjoyYMNkMTUMYHOSIiWuR9RBjU7Ey9RYdH71C8PRi5czeaAKsOZhbiGgAyc8S6NiDhMoyFsDqCBG0" +
                "zbCQkC8IniFO8klHnIhZUAbKVLwGGkd/5sKxqcoyzDB8x1bWvg8Cz7Xj6x7mJEchHa5ncqC/4KFgyxwr" +
                "AMB8mwuMDKPm6R4er+RSkLV42oZw35i3cww+iYWLK/7PMbdLeRDC7PK7MKHyExjOPD4ZsbXATpkeeINi" +
                "206uHd/xPOWhllrwIwZbSK0yk2MU9J9NHMA5idD9L9Ut7RKUFgAA";
                
        public override string ToString() => Extensions.ToString(this);
    }
}
