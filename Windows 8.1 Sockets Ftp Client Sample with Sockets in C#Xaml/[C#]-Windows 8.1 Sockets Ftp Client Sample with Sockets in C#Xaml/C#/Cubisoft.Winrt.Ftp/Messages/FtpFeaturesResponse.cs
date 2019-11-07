using System;

namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpFeaturesResponse: FtpResponse
    {
        private FtpCapability m_Features = FtpCapability.NONE;

        public FtpFeaturesResponse()
        {
        }

        public FtpCapability Features
        {
            get
            {
                if (m_Features == FtpCapability.NONE)
                {
                    m_Features = ParseFeatures();
                }

                return m_Features;
            }
        }

        private FtpCapability ParseFeatures()
        {
            FtpCapability features = FtpCapability.NONE;

            foreach (string feat in base.InfoMessages.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (feat.ToUpper().Trim().StartsWith("MLST") || feat.ToUpper().Trim().StartsWith("MLSD"))
                    features |= FtpCapability.MLSD;
                else if (feat.ToUpper().Trim().StartsWith("MDTM"))
                    features |= FtpCapability.MDTM;
                else if (feat.ToUpper().Trim().StartsWith("REST STREAM"))
                    features |= FtpCapability.REST;
                else if (feat.ToUpper().Trim().StartsWith("SIZE"))
                    features |= FtpCapability.SIZE;
                else if (feat.ToUpper().Trim().StartsWith("UTF8"))
                    features |= FtpCapability.UTF8;
                else if (feat.ToUpper().Trim().StartsWith("PRET"))
                    features |= FtpCapability.PRET;
                else if (feat.ToUpper().Trim().StartsWith("MFMT"))
                    features |= FtpCapability.MFMT;
                else if (feat.ToUpper().Trim().StartsWith("MFCT"))
                    features |= FtpCapability.MFCT;
                else if (feat.ToUpper().Trim().StartsWith("MFF"))
                    features |= FtpCapability.MFF;
            }

            return features;
        }
    }
}
