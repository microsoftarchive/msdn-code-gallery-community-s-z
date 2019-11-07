// EventGenerator from SLEventGenerator
using System.Collections.Generic;
using TimelineLibrary;
using System;

public class EventGenerator
{
    #region Private Fields

    private DateTime                                    m_lastDate;
    private Random                                      m_rnd;

    #endregion

    #region Public Properties

    public List<TimelineEvent> Events
    {
        get;
        set;
    }

    #endregion

    public EventGenerator(
    )
    {
        m_lastDate = new DateTime(1980, 1, 1);
        m_rnd = new Random();
        Events = new List<TimelineEvent>(100);
    }

    public void GenerateEvents(
        int                                             amount
    )
    {
        int                                             daysLater;
        TimelineEvent                                   e;

        for (int i = 0; i < amount; i++)
        {
            //
            // one day to three weeks
            //
            daysLater = m_rnd.Next(1, 21); 

            m_lastDate = m_lastDate.AddDays(daysLater);

            e = new TimelineEvent();
            e.StartDate = m_lastDate;
            //This is the line that I meant. Commented out will result in all TimelineEvents on the same row
            //e.EndDate = m_lastDate;
            e.IsDuration = false;
            e.Link = "http://www.google.com";

            if (i % 3 == 0)
            {
                e.EventColor = "Red";
            }
            else if (i % 2 == 0)
            {
                e.EventColor = "Blue"; 
            }

            e.Title = String.Format("{0}", m_lastDate.ToShortDateString());
            e.Description = "Test Description.";

            Events.Add(e);
        }
    }
}
