using Syncfusion.Maui.Calendar;

namespace InactiveMonthNavigation
{
    public class CalendarBehavior : Behavior<SfCalendar>
    {
        private SfCalendar sfCalendar;

        protected override void OnAttachedTo(SfCalendar bindable)
        {
            base.OnAttachedTo(bindable);
            this.sfCalendar = bindable;
            this.sfCalendar.SelectionChanged += SfCalendar_SelectionChanged;
        }

        private void SfCalendar_SelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            DateTime tappedDate = DateTime.Parse(e.NewValue.ToString());
            if (tappedDate.Month != sfCalendar.DisplayDate.Month)
            {
                sfCalendar.DisplayDate = tappedDate;
            }
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.sfCalendar != null)
            {
                this.sfCalendar.SelectionChanged -= SfCalendar_SelectionChanged;
            }

            this.sfCalendar = null;
        }
    }
}
