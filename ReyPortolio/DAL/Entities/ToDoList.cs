namespace ReyPortfolio.DAL.Entities
{
    public class ToDoList
    {
        public int ToDoListId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateOnly Date { get; set; }
        public bool Status { get; set; }
    }
}
