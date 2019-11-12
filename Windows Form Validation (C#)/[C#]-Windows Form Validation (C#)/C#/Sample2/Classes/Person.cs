namespace Sample2
{
    public class Person
    {
        /// <summary>
        /// Not used in this code sample but in real
        /// apps we would be using it as the primary key
        /// </summary>
        int mId;
        public int Id { get { return mId; } }

        string mFirstName;
        public string FirstName { get { return mFirstName; } }

        string mLastName;
        public string LastName { get { return mLastName; } }

        string mStreet;
        public string Street { get { return mStreet; } }

        string mCity;
        public string City { get { return mCity; } }

        string mState;
        public string State { get { return mState; } }

        string mPostalCode;
        public string PostalCode { get { return mPostalCode; } }
        public Person()
        {

        }

        public Person(string pFirstName, string pLastName, string pStreet, string pCity, string pState, string pPostalCode)
        {
            mFirstName = pFirstName;
            mLastName = pLastName;
            mStreet = pStreet;
            mCity = pCity;
            mStreet = pState;
            mState = pState;
            mPostalCode = pPostalCode;
        }
    }
}
