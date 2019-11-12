using System;
using Microsoft.SharePoint.Client;

namespace Zhukov.Blog.SP.REST
{
    [SubsetCallableType,
        ClientCallableType(Name = "CustomObject",
        ServerTypeId = "740c6a0b-85e2-48a0-a494-e0f1759d4aa8",
        SampleUrl = "{apiroot}/web/zhukov/get")]
    public class CustomObject : ClientObject
    {
        [Remote]
        public int Id
        {
            get
            {
                CheckUninitializedProperty("Id");
                return (int)ObjectData.Properties["Id"];
            }
            set
            {
                ObjectData.Properties["Id"] = value;
                Context?.AddQuery(new ClientActionSetProperty(this, "Id", value));
            }
        }

        [Remote]
        public string Title
        {
            get
            {
                CheckUninitializedProperty("Title");
                return (string)ObjectData.Properties["Title"];
            }
            set
            {
                ObjectData.Properties["Title"] = value;
                Context?.AddQuery(new ClientActionSetProperty(this, "Title", value));
            }
        }

        public CustomObject(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {

        }
    }
}
