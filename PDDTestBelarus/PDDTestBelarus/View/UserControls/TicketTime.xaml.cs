using System;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PDDTestBelarus.View.UserControls;

public partial class TicketTime : UserControl
{
    private DispatcherTimer timer;
    public int elapsedTime = 1 * 15;
    private Action TimerStopAction;
    public TicketTime(bool needTimer,Action onTimerStop=null)
    {
        InitializeComponent();
        TimerStopAction = onTimerStop;
        Minutes.Text = "--";
        Seconds.Text = "--";
        if (needTimer)
        {
            Minutes.Text = "15";
            Seconds.Text = "00";
            StartTimer();
        }
    }


    public void StartTimer()
    {
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += ChangeTime;
        timer.Start();
    }

    private void ChangeTime(object sender, EventArgs e)
    {
        elapsedTime--;
        Minutes.Text = ((int)elapsedTime / 60).ToString("00");
        Seconds.Text = (elapsedTime % 60).ToString("00");
        if (elapsedTime == 0)
        {
            StopTimer();
            TimerStopAction?.Invoke();
        }
    }

    public int StopTimer()
    {
        timer.Stop();
        timer.Tick -= ChangeTime;
        Minutes.Text = "--";
        Seconds.Text = "--";
        return elapsedTime;
    }
}