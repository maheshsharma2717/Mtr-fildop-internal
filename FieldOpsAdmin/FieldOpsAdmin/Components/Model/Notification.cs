namespace FieldOpsAdmin.Components.Model
{
        public class Notification
        {
            public string Title { get; set; }
            public string Body { get; set; }
            public DateTime Timestamp { get; set; }

            public Notification(string title, string body)
            {
                Title = title;
                Body = body;
                Timestamp = DateTime.Now;
            }
        }
    }


