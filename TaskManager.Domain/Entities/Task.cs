
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
        public class Task : BaseEntity
        {
            public Guid Id { get; private set; }
            public string Title { get; private set; }
            public string Description { get; private set; }
            public DateTime? CompletedAt { get; private set; }
            public TaskState Status { get; private set; }
            public Guid AssignedUserId { get; private set; }
            public Task(Guid id, string title, string description, Guid assignedUserId)
            {
                Id = id;
                Title = title;
                Description = description;
                AssignedUserId = assignedUserId;
                CreatedAt = DateTime.UtcNow;
                Status = TaskState.Pending;
            }

            public void Complete()
            {
                Status = TaskState.Completed;
                CompletedAt = DateTime.UtcNow;
            }

            public void UpdateInfo(string title, string description)
            {
                Title = title;
                Description = description;
            }

            public void UpdateStatus(TaskState status)
            {
                Status = status;
                if (status == TaskState.Completed)
                {
                    CompletedAt = DateTime.UtcNow;
                }
                else
                {
                    CompletedAt = null;
                }
            }
        }

}

