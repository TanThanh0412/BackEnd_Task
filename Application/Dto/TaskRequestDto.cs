namespace Application.Dto
{
    public class TaskRequestDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
