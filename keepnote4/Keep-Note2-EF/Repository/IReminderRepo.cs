using Keep_Note4.Model;

namespace Keep_Note4.Repository
{
    public interface IReminderRepo
    {
        Reminder CreateReminder(Reminder reminder);
        bool UpdateReminder(Reminder reminder);
        bool DeletReminder(int reminderId);
        Reminder GetReminderById(int reminderId);
        List<Reminder> GetAllRemindersByUserId(int userId);

    }
}
