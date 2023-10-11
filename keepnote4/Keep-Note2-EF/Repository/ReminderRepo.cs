using Keep_Note4.Context;
using Keep_Note4.Model;

namespace Keep_Note4.Repository
{
    public class ReminderRepo : IReminderRepo
    {
        KeepDbContext _context;
        public ReminderRepo(KeepDbContext context)
        {
            _context = context;
        }

        public Reminder CreateReminder(Reminder reminder)
        {
            _context.reminders.Add(reminder);
            _context.SaveChanges();
            return reminder;

        }

        public bool DeletReminder(int reminderId)
        {
            var obj = _context.reminders.FirstOrDefault(x => x.ReminderId == reminderId);
            if (obj != null)
            {
                _context.reminders.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Reminder> GetAllRemindersByUserId(int userId)
        {
            return _context.reminders.Where(x => x.users.UserId == userId).ToList();
        }

        public Reminder GetReminderById(int reminderId)
        {
            var obj = _context.reminders.FirstOrDefault(x => x.ReminderId == reminderId);
            if (obj != null)
                return obj;
            return null;
        }

        public bool UpdateReminder(Reminder reminder)
        {
            var obj = _context.reminders.FirstOrDefault(x => x.ReminderId == reminder.ReminderId);
            if (obj != null)
            {
                obj.ReminderName = reminder.ReminderName;
                obj.ReminderDescription = reminder.ReminderDescription;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
