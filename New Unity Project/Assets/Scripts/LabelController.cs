using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LabelController : MonoBehaviour
{
    public BackgroundController BackgroundController;

    public TextMeshProUGUI timeLabel;
    public TextMeshProUGUI locationLabel;
    public TextMeshProUGUI dateLabel;
    public TextMeshProUGUI dayLabel;

    public void UpdateDate(string date)
    {
        dateLabel.text = "<b>" + date + "</b>";
    }

    public void UpdateWeekday(object day)
    {
        dayLabel.text = "<b>" + day + "</b>";
        Debug.Log("Day: " + day);
    }

    public void UpdateTimeSlot(object time)
    {
        timeLabel.text = "<b>" + time + "</b>";
    }

    public void UpdateLocation(string location)
    {
        locationLabel.text = "<b>" + location + "</b>";
    }

    public void UpdateBackground(string background)
    {
        BackgroundController.ChangeBackgroundImage(background);

    }

}