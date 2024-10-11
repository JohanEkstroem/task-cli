using System.Diagnostics.Contracts;

namespace task_cli
{
	public enum Status
	{
		Todo,
		Inprogress,
		Done
	}
	public class Task(int id, string description, Status status)
	{
		public int Id { get; set; } = id;
		public required string Description { get; set; } = description;
		public Status Status { get; set; } = status;
		public DateTime CreatedAt { get; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; }
	}

}

