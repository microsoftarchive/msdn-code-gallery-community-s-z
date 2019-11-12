using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Revenue.EmailUtilities.Converters;
using Revenue.EmailUtilities.Helpers;
using Revenue.EmailUtilities.Utilities;
using System.Linq;

namespace EmailAddress.Tests.Karen
{
    /// <summary>
    /// The test methods here are simply to test MsgKit and MsgReader
    /// </summary>
    [TestClass]
    public class EmlMsgTest
    {
        public string carbonCopyFolder { get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CC"); } }
        [TestTraits(Trait.MailConversion)]
        [TestMethod]
        public void MultipleFileCountConversion()
        {
            var folderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PreexistingEmlFiles");
            int emlCount = folderName.EmlFileCount();
            var ops = new FromEml();
            ops.EmlToMessageFiles(folderName);
            int msgCount = folderName.MsgFileCount();
            Assert.AreEqual(emlCount, msgCount);

            Cleaner cleaner = new Cleaner();
            cleaner.Messages(folderName);
        }
        /// <summary>
        /// To Recipients 1
        /// CC Recipients 2
        /// Body has one paragraph, an unordered list with three li elements
        /// Assert
        /// TO and CC email addresses match expected strings
        /// Body contains a paragraph
        /// </summary>
        /// <remarks>
        /// Utilizes HtmlAgilityPack for parsing DOM elements
        /// </remarks>
        [TestTraits(Trait.MailConversion)]
        [TestMethod]
        public void HogPog()
        {
            // expected email addresses to test against from the .msg file
            string expectedToAddress = "HomerSmith@oregon.gov";
            string[] expectedCcAddresses = { "Jimmy1@comcast.net", "Barb@comcast.net" };

            // location of the .eml file
            //var folderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CC");

            // remove any .msg files for a clean test
            Cleaner cleaner = new Cleaner();
            cleaner.Messages(carbonCopyFolder);

            // get count of .eml files (should be one)
            int emlCount = carbonCopyFolder.EmlFileCount();

            // convert the .eml file to .msg
            var ops = new FromEml();
            ops.EmlToMessageFiles(carbonCopyFolder);

            // get information from the single .msg file created from the .eml file
            var singleMailInformation = ops.GetMailInformation(carbonCopyFolder).FirstOrDefault();
            // remove angle brackets from start and end of email address
            var toAddress = singleMailInformation.ToRecipients.FirstOrDefault();
            Assert.AreEqual(toAddress, expectedToAddress, "To addresses are not matches");

            // get the message body in html format
            var body = singleMailInformation.BodyAsHTML;

            var ccAddresses = singleMailInformation.CCRecipients.ToArray();
            Assert.IsTrue(Enumerable.SequenceEqual(expectedCcAddresses, ccAddresses),"cc mismatch");

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(body);
            var firstParagraph = htmlDoc.DocumentNode.ChildNodes.FirstOrDefault();

            Assert.IsTrue(firstParagraph.Name == "p");
            Assert.IsTrue(firstParagraph.InnerText == "Using Ninject");

        }
        /// <summary>
        /// To Recipients 1
        /// CC Recipients 2
        /// Body has one paragraph, an unordered list with three li elements
        /// Assert
        /// TO and CC email addresses match expected strings
        /// Li elements are matched againsts an array of expected elements
        /// </summary>
        /// <remarks>
        /// Utilizes HtmlAgilityPack for parsing DOM elements
        /// </remarks>
        [TestTraits(Trait.MailConversion)]
        [TestMethod]
        public void ExtractInformationFromMsgBody()
        {
            // expected email addresses to test against from the .msg file
            string expectedToAddress = "HomerSmith@oregon.gov";
            string[] expectedCcAddresses = { "Jimmy1@comcast.net", "Barb@comcast.net" };
            string[] expectedLiElements = { "First", "Second", "Third" };

            // location of the .eml file
            var folderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CC");

            // remove any .msg files for a clean test
            Cleaner cleaner = new Cleaner();
            cleaner.Messages(folderName);

            // get count of .eml files (should be one)
            int emlCount = folderName.EmlFileCount();

            // convert the .eml file to .msg
            var ops = new FromEml();
            ops.EmlToMessageFiles(folderName);

            // get information from the single .msg file created from the .eml file
            var singleMailInformation = ops.GetMailInformation(folderName).FirstOrDefault();
            // remove angle brackets from start and end of email address
            var toAddress = singleMailInformation.ToRecipients.FirstOrDefault();
            Assert.AreEqual(toAddress, expectedToAddress, "To addresses are not matches");

            var ccAddresses = singleMailInformation.CCRecipients.ToArray();
            Assert.IsTrue(Enumerable.SequenceEqual(expectedCcAddresses, ccAddresses));

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(singleMailInformation.BodyAsHTML);
            var firstParagraph = htmlDoc.DocumentNode.ChildNodes.FirstOrDefault();
            Assert.IsTrue(firstParagraph.Name == "p");

            // validate we have an unordered list
            var ulElement = htmlDoc.DocumentNode.ChildNodes.Where(item => item.Name == "ul").FirstOrDefault();
            var liElements = ulElement.ChildNodes.Where(item => item.Name == "li").Select(item => item.InnerText).ToArray();
            // validate expected LI elements matched epected LI text
            Assert.IsTrue(Enumerable.SequenceEqual(expectedLiElements, liElements));
        }
        /// <summary>
        /// To Recipients 4
        /// CC Recipients 2
        /// Body has one paragraph, one a-href within the paragraph.
        /// Assert
        /// Count on TO and CC count
        /// a-href link text matches expected string
        /// </summary>
        /// <remarks>
        /// Utilizes HtmlAgilityPack for parsing DOM elements
        /// </remarks>
        [TestTraits(Trait.MailConversion)]
        [TestMethod]
        public void ExtractSingle_A_Element()
        {
            var folderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Misc");
            var fileName = Path.Combine(folderName, "OneParagraphWithOne_A_Element.eml");

            var expectedLink = @"<a href=""https://www.google.com"">Google</a>";

            // remove any .msg files for a clean test
            Cleaner cleaner = new Cleaner();
            cleaner.Messages(folderName);

            // get count of .eml files (should be one)
            int emlCount = folderName.EmlFileCount();

            // convert the .eml file to .msg
            var ops = new FromEml();
            ops.EmlToMessageFiles(folderName);

            // get information from the single .msg file created from the .eml file
            var singleMailInformation = ops.GetMailInformation(folderName).FirstOrDefault();

            var toAddress = singleMailInformation.ToRecipients.FirstOrDefault();
            Assert.AreEqual(4, singleMailInformation.ToRecipients.Count(), "Expected four to addresses");
            Assert.AreEqual(2, singleMailInformation.CCRecipients.Count(), "Expected two cc addresses");

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(singleMailInformation.BodyAsHTML);

            // Validate the link
            Assert.IsTrue(
                htmlDoc.DocumentNode.ChildNodes.FirstOrDefault()
                    .ChildNodes.FirstOrDefault().NextSibling.OuterHtml == expectedLink);


        }

    }
}
