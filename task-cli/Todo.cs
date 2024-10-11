

using System.Text.Json.Serialization;

namespace task_cli
{
	public enum Status
	{
		Todo,
		Inprogress,
		Done
	}
	public class Todo
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }
		// public required string Description { get; set; } = description;
		// public Status Status { get; set; } = status;
		// public DateTime CreatedAt { get; } = DateTime.Now;
		// public DateTime UpdatedAt { get; set; }
	}

}

