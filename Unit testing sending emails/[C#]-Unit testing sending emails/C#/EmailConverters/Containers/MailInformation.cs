using MsgReader.Outlook;
using Revenue.EmailUtilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Revenue.EmailUtilities.Containers
{
    public class MailInformation
    {
        string mSender;
        public string Sender { get { return mSender; } }
        string mSubject;
        public string Subject { get { return mSubject; } }
        string mHtmlBody;
        public string BodyAsHTML { get { return mHtmlBody; } }
        List<string> mToRecipients;
        public List<string> ToRecipients
        {
            get
            {
                for (int index = 0; index < mToRecipients.Count -1; index++)
                {
                    mToRecipients[index] = mToRecipients[index].RemoveAngleBrackets();
                }
                return mToRecipients;
            }
        }

        List<string> mCCRecipients;
        public List<string> CCRecipients
        {
            get
            {
                for (int index = 0; index < mCCRecipients.Count - 1; index++)
                {
                    mCCRecipients[index] = mCCRecipients[index].RemoveAngleBrackets();
                }
                return mCCRecipients;
            }
        }

        private DateTime? mCreationDate;
        public DateTime? CreationDate { get { return mCreationDate; } }
        List<Object> mAttachments;
        public List<Object>  Attachments { get { return mAttachments; } }
        public int AttachmentCount { get { return mAttachments.Count; } }
        public MailInformation(Storage.Message message)
        {
            mSender = message.GetEmailSender(false, false).Trim();
            mSubject = message.Subject;
            mHtmlBody = message.BodyHtml;
            mCreationDate = message.CreationTime;
            mAttachments = message.Attachments;

            string recipientItems = message.GetEmailRecipients(Storage.Recipient.RecipientType.To, false, false);
            if (recipientItems.Contains(";"))
            {
                mToRecipients = GetRecipients(recipientItems).ToList();
            }
            else
            {
                mToRecipients = new List<string>() { recipientItems };
            }

            recipientItems = message.GetEmailRecipients(Storage.Recipient.RecipientType.Cc, false, false);
            if (recipientItems.Contains(";"))
            {
                mCCRecipients = GetRecipients(recipientItems).ToList();
            }
            else
            {
                mCCRecipients = new List<string>();
            }

        }
        private IEnumerable<string> GetRecipients(string pRecipients)
        {
            return pRecipients.Split(';').Select(item => item.Trim());
        }
        /// <summary>
        /// TODO - Flatten body (use my SQL Flattern pattern)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var toItems = string.Join(";", ToRecipients.ToArray());
            var ccItems = string.Join(";", CCRecipients.ToArray());
            return $"'{Sender}','{Subject}', '{toItems}', '{ccItems}', {AttachmentCount}";
        }
    }
}
