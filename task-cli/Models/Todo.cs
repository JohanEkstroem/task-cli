

using System.Text.Json.Serialization;

namespace task_cli.Models
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
		public string? Description { get; set; }
		[JsonPropertyName("status")]
		public Status Status { get; set; }

		[JsonPropertyName("createdAt")]
		public DateTime? CreatedAt { get; set; }

		[JsonPropertyName("updatedAt")]
		public DateTime? UpdatedAt { get; set; }
	}

}

