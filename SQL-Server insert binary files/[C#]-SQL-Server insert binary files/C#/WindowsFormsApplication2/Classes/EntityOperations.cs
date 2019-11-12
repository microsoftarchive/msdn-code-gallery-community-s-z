using System;
using System.IO;
using System.Linq;

namespace WindowsFormsApplication2
{
    public class EntityOperations
    {
        public string ExceptionMessage { get; set; }
        public bool AddNewAttachement(string eventTitle, string FilePath, ref int NewIdentifier)
        {
            var eventId = 0;
            try
            {
                using (theContext context = new theContext())
                {

                    /*
                     * Get course id by course name, in this case from the 
                     * I've hard coded the course name to keep things simple.
                     */
                    eventId = context
                        .SampleEvents
                        .Where(eventItem => eventItem.Description == eventTitle)
                        .Select(eventItem => eventItem.id)
                        .FirstOrDefault();

                    /*
                     * Note I'm not checking to see if the item exists, for a real application
                     * it would be wise to do so.
                     */

                    byte[] fileByes;
                    //
                    // Sample method used in the first project via SqlClient data provider to
                    // place file contents into a byte array
                    //
                    using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                    {

                        using (var reader = new BinaryReader(stream))
                        {
                            fileByes = reader.ReadBytes((int)stream.Length);
                        }
                    }

                    // create a new item and populate properties
                    var attachmentItem = new EventAttachment();

                    attachmentItem.EventId = eventId;
                    attachmentItem.FileContent = fileByes;
                    attachmentItem.FileBaseName = Path.GetFileNameWithoutExtension(FilePath);
                    attachmentItem.FileExtention = Path.GetExtension(FilePath);

                    // add new item
                    context.EventAttachments.Add(attachmentItem);
                    // save back to database, once done EF provides us with the new primary key
                    context.SaveChanges();

                    NewIdentifier = attachmentItem.id;

                    return true;

                }
            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
                return false;
            }
        }
    }
}
